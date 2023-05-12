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
    private DrinkName drinkName = DrinkName.Vodka;
    /// <summary>
    /// 주류의 타입
    /// </summary>
    [SerializeField]
    private DrinkType type = DrinkType.Distilled;

    [SerializeField]
    private Color color = new Color(0, 0, 0);

    [SerializeField]
    private SpriteRenderer spriteRen = null;

    /// <summary>
    /// 주류의 도수
    /// </summary>
    [SerializeField]
    private int proof = 0;

    /// <summary>
    /// 주류의 무게
    /// </summary>
    [SerializeField]
    private int weight = 0;

    /// <summary>
    /// 주류의 이름 반환
    /// </summary>
    public DrinkName Name { get { return drinkName; } }
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
    public void Init(DrinkName drinkName)
    {
        this.drinkName = drinkName;
        this.type = WhatIsDrinkType(drinkName);
        this.color = GameResMng.Instance.GetDrinkColorByDrinkName(drinkName);
        spriteRen.color = this.color;
    }

    /// <summary>
    /// 주류 이름으로 타입 검색
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public DrinkType WhatIsDrinkType(DrinkName drinkName)
    {
        if (drinkName >= DrinkName.Vodka && drinkName <= DrinkName.ScotchWhisky)
        {
            return DrinkType.Distilled;
        }
        else if (drinkName >= DrinkName.CremeDeMentheWhite && drinkName <= DrinkName.Galliano)
        {
            return DrinkType.Compounded;
        }
        else if (drinkName >= DrinkName.GamHongRo && drinkName <= DrinkName.SunwoonsanBokbunjaWine)
        {
            return DrinkType.Traditional;
        }
        else if (drinkName >= DrinkName.Chardonnay && drinkName <= DrinkName.SauvignonBlanc)
        {
            return DrinkType.Fermented;
        }
        else if (drinkName >= DrinkName.SweetAndSour && drinkName <= DrinkName.RaspberrSyrup)
        {
            return DrinkType.Syrup;
        }
        else if (drinkName == DrinkName.PinaColadaMix)
        {
            return DrinkType.Mix;
        }
        else if (drinkName >= DrinkName.LemonJuice && drinkName <= DrinkName.GingerAle)
        {
            return DrinkType.Juice;
        }
        else if (drinkName >= DrinkName.Salt && drinkName <= DrinkName.PowderedSugar)
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
    public int WhatIsProof(DrinkName drinkName)
    {
        return 0;
    }

    /// <summary>
    /// 주류 이름으로 무게 검색
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public int WhatIsWeight(DrinkName drinkName)
    {
        return 0;
    }



}
