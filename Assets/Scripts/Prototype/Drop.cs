using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 주류 이름 열거형
/// </summary>
public enum DrinkName
{
    Vodka,
    Gin,
    BrandyCognac,
    CALVADOS,
    FineCALVADOS,
    Rum,
    BacardiRum,
    BourbonWhisky,
    ScotchWhisky,
    CremeDeMentheWhite,
    CremeDeMentheGreen,
    DryVermouth,
    SweetVermouth,
    Kahlua,
    CremeDeCacaoBrown,
    CremeDeCacaoWhite,
    TripleSec,
    Drambuie,
    MALIBU,
    BaileysIrishCream,
    GrandMarnier,
    CremeDeBanana,
    Midori,
    Melon,
    ApplePucker,
    Campari,
    Cointreau,
    ApricotFlavoredBrandy,
    BenedictineDOM,
    BlueCuracao,
    CremeDeCassis,
    AngosturaBitters,
    CherryFlavoredBrandy,
    SloeGin,
    Galliano,
    GamHongRo,
    AndongSoju,
    JindoHongju,
    GeumsanInsamju,
    SunwoonsanBokbunjaWine,
    Chardonnay,
    SauvignonBlanc,
    SweetAndSour,
    GrenadineSyrup,
    RaspberrSyrup,
    PinaColadaMix,
    LemonJuice,
    OrangeJuice,
    GrapefruitJuice,
    WhiteGrapeJuice,
    CranberryJuice,
    LightMilk,
    PineappleJuice,
    LimeJuice,
    SodaWater,
    Cola,
    Sprite,
    GingerAle,
    Salt,
    PowderedSugar


}
/// <summary>
/// 주류 타입 열거형
/// 증류주,혼합주,전통주,과실주,주스,시럽,믹스,조미료
/// </summary>
public enum DrinkType
{
    Distilled,
    Compounded,
    Traditional,
    Fermented,
    Juice,
    Syrup,
    Mix,
    Seasoning
}

/// <summary>
/// 물방울 컴포넌트
/// </summary>
public class Drop : MonoBehaviour
{
    /// <summary>
    /// 주류의 이름
    /// </summary>
    [SerializeField]
    DrinkName name = DrinkName.Vodka;
    /// <summary>
    /// 주류의 타입
    /// </summary>
    [SerializeField]
    DrinkType type = DrinkType.Distilled;

    [SerializeField]
    Color color = new Color(0, 0, 0);

    [SerializeField]
    SpriteRenderer spriteRen = null;

    /// <summary>
    /// 주류의 도수
    /// </summary>
    [SerializeField]
    int proof = 0;

    /// <summary>
    /// 주류의 무게
    /// </summary>
    [SerializeField]
    int weight = 0;

    /// <summary>
    /// 주류의 이름 반환
    /// </summary>
    public DrinkName Name { get { return name; } }
    /// <summary>
    /// 주류의 타입 반환
    /// </summary>
    public DrinkType Type { get { return type; } }
    /// <summary>
    /// 주류의 도수 반환
    /// </summary>
    public int Proof
    {
        get { return proof; }
    }
    /// <summary>
    /// 주류의 무게 반환
    /// </summary>
    public int Weight { get { return weight; } }

    /// <summary>
    /// 물방울 필드 초기화 메서드
    /// </summary>
    /// <param name="name">물방울의 주류 이름</param>
    public void Init(DrinkName name)
    {
        this.name = name;
        this.type = WhatIsDrinkType(name);
        this.color = GameResMng.Instance.GetDrinkColorByDrinkName(name);
        spriteRen.color = this.color;
    }

    /// <summary>
    /// 주류 이름으로 타입 검색
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public DrinkType WhatIsDrinkType(DrinkName name)
    {
        if (name >= DrinkName.Vodka && name <= DrinkName.ScotchWhisky)
        {
            return DrinkType.Distilled;
        }
        else if (name >= DrinkName.CremeDeMentheWhite && name <= DrinkName.Galliano)
        {
            return DrinkType.Compounded;
        }
        else if (name >= DrinkName.GamHongRo && name <= DrinkName.SunwoonsanBokbunjaWine)
        {
            return DrinkType.Traditional;
        }
        else if (name >= DrinkName.Chardonnay && name <= DrinkName.SauvignonBlanc)
        {
            return DrinkType.Fermented;
        }
        else if (name >= DrinkName.SweetAndSour && name <= DrinkName.RaspberrSyrup)
        {
            return DrinkType.Syrup;
        }
        else if (name == DrinkName.PinaColadaMix)
        {
            return DrinkType.Mix;
        }
        else if (name >= DrinkName.LemonJuice && name <= DrinkName.GingerAle)
        {
            return DrinkType.Juice;
        }
        else if (name >= DrinkName.Salt && name <= DrinkName.PowderedSugar)
        {
            return DrinkType.Seasoning;
        }
        return DrinkType.Distilled;
    }

    /// <summary>
    /// 주류 이름으로 도수 검색
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public int WhatIsProof(DrinkName name)
    {
        return 0;
    }

    /// <summary>
    /// 주류 이름으로 무게 검색
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public int WhatIsWeight(DrinkName name)
    {
        return 0;
    }



}
