using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 리소스 관리 클래스
/// Sprite, CSV파일
/// </summary>
public class GameResMng : MonoBehaviour
{
    /// <summary>
    /// 임시 스프라이트 등록 리스트
    /// </summary>
    [SerializeField]
    List<Sprite> alcoholSprites = new List<Sprite>();

    /// <summary>
    /// 논알콜 스프라이트 리스트
    /// </summary>
    [SerializeField]
    List<Sprite> nonalcoholicSprites = new List<Sprite>();

    /// <summary>
    /// 유리잔 스프라이트 리스트
    /// </summary>
    [SerializeField]
    List<Sprite> glassSprites = new List<Sprite>();

    private Dictionary<DrinkName,Color> drinkColor = new Dictionary<DrinkName,Color>();
    
    private Dictionary<DrinkName,float> drinkWeight = new Dictionary<DrinkName,float>();

    private static GameResMng instance;

    public static GameResMng Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        nonalcoholicSprites.Clear();
        glassSprites.Clear();

        nonalcoholicSprites.AddRange( Resources.LoadAll<Sprite>("Textures/NonAlcoholic/"));
        glassSprites.AddRange(Resources.LoadAll<Sprite>("Textures/Glasses/"));

        if(instance == null)
        {
            instance = this;
            drinkColor.Add(DrinkName.Vodka, new Color(1f, 1f, 1f));
            drinkColor.Add(DrinkName.Kahlua, new Color(0.64f, 0.16f, 0.16f));
            drinkColor.Add(DrinkName.GrenadineSyrup, new Color(0.86f, 0.07f, 0.23f));
            drinkColor.Add(DrinkName.CremeDeMentheGreen, new Color(0f, 1f, 0f));
            drinkColor.Add(DrinkName.BrandyCognac, new Color(0.8f, 0.49f, 0.19f));
            drinkColor.Add(DrinkName.BaileysIrishCream, new Color(0.96f, 0.87f, 0.7f));
            drinkColor.Add(DrinkName.GrandMarnier, new Color(1f, 0.64f, 0f));
            drinkColor.Add(DrinkName.Gin, new Color(1f, 1f, 1f));
            drinkColor.Add(DrinkName.SweetVermouth, new Color(0.72f, 0.52f, 0.04f));
            drinkColor.Add(DrinkName.Campari, new Color(0.86f, 0.07f, 0.23f));
            drinkWeight.Add(DrinkName.Vodka, 9);
            drinkWeight.Add(DrinkName.Kahlua, 11);
            drinkWeight.Add(DrinkName.GrenadineSyrup, 12);
            drinkWeight.Add(DrinkName.CremeDeMentheGreen, 10);
            drinkWeight.Add(DrinkName.BrandyCognac, 9);
            drinkWeight.Add(DrinkName.BaileysIrishCream, 10);
            drinkWeight.Add(DrinkName.GrandMarnier, 9);
            drinkWeight.Add(DrinkName.Gin, 9);
            drinkWeight.Add(DrinkName.SweetVermouth, 10);
            drinkWeight.Add(DrinkName.Campari, 9);

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Color GetDrinkColorByDrinkName(DrinkName name)
    {
        return drinkColor[name];
    }

    public float GetDrinkWeightByDrinkName(DrinkName name)
    {
        return drinkWeight[name];
    }

    public string GetSpriteNameByDrinkName(DrinkName drinkName)
    {
        switch(drinkName)
        {
            case DrinkName.Vodka:
                return "Alcohol_Distilled_Vodka";
            case DrinkName.Kahlua:
                return "Alcohol_Compounded_Kahlua";
            case DrinkName.GrenadineSyrup:
                return "Nonalcoholic_Syrup_GrenadineSyrup";
            case DrinkName.CremeDeMentheGreen:
                return "Alcohol_Compounded_CremeDeMentheGreen";
            case DrinkName.BrandyCognac:
                return "Alcohol_Distilled_BrandyCognac";
            case DrinkName.BaileysIrishCream:
                return "Alcohol_Compounded_BaileysIrishCream";
            case DrinkName.GrandMarnier:
                return "Alcohol_Compounded_GrandMarnier";

            case DrinkName.Gin:
                return "Alcohol_Distilled_Gin";
            case DrinkName.SweetVermouth:
                return "Alcohol_Compounded_SweetVermouth";
            case DrinkName.Campari:
                return "Alcohol_Compounded_Campari";
        }
        return null;
    }

    public DrinkName GetDrinkNameBySpriteName(string spriteName)
    {
        switch (spriteName)
        {
            case "Alcohol_Distilled_Vodka":
                return DrinkName.Vodka;
            case "Alcohol_Compounded_Kahlua":
                return DrinkName.Kahlua;
            case "Nonalcoholic_Syrup_GrenadineSyrup":
                return DrinkName.GrenadineSyrup;
            case "Alcohol_Compounded_CremeDeMentheGreen":
                return DrinkName.CremeDeMentheGreen;
            case "Alcohol_Distilled_BrandyCognac":
                return DrinkName.BrandyCognac;
            case "Alcohol_Compounded_BaileysIrishCream":
                return DrinkName.BaileysIrishCream;
            case "Alcohol_Compounded_GrandMarnier":
                return DrinkName.GrandMarnier;

            case "Alcohol_Distilled_Gin":
                return DrinkName.Gin;
            case "Alcohol_Compounded_SweetVermouth":
                return DrinkName.SweetVermouth;
            case "Alcohol_Compounded_Campari":
                return DrinkName.Campari;
        }
        return DrinkName.Gin;
    }
    

    /// <summary>
    /// 이름으로 스프라이트 찾아서 반환
    /// </summary>
    /// <param name="name">스프라이트 이름</param>
    /// <returns></returns>
    public Sprite GetSpriteByName(string name)
    {
        foreach(Sprite sprite in alcoholSprites)
        {
            if(sprite.name == name) return sprite;
        }
        foreach (Sprite sprite in nonalcoholicSprites)
        {
            if (sprite.name == name) return sprite;
        }
        return null;
    }

    public Sprite GetSpriteByDrinkName(DrinkName drinkName)
    {
        string name = GetSpriteNameByDrinkName(drinkName);
        foreach (Sprite sprite in alcoholSprites)
        {
            if (sprite.name == name) return sprite;
        }
        foreach (Sprite sprite in nonalcoholicSprites)
        {
            if (sprite.name == name) return sprite;
        }
        return null;
    }
}
