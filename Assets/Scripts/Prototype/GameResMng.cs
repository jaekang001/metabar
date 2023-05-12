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
    /// 스프라이트 등록 리스트
    /// </summary>
    [SerializeField]
    List<Sprite> sprites = new List<Sprite>();

    private Dictionary<DrinkName,Color> drinkColor = new Dictionary<DrinkName,Color>();
    
    private Dictionary<DrinkName,float> drinkWeight = new Dictionary<DrinkName,float>();

    private static GameResMng instance;

    public static GameResMng Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            drinkColor.Add(DrinkName.Gin, new Color(1f, 1f, 1f));
            drinkColor.Add(DrinkName.SweetVermouth, new Color(1f, 0.5f, 0.2f));
            drinkColor.Add(DrinkName.Campari, new Color(0.2f, 0.5f, 1f));
            drinkWeight.Add(DrinkName.Gin, 3);
            drinkWeight.Add(DrinkName.SweetVermouth, 1);
            drinkWeight.Add(DrinkName.Campari, 5);
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
            case DrinkName.Gin:
                return "proto_Spirits_gin";
            case DrinkName.SweetVermouth:
                return "proto_liquor_sweet_vermouth";
            case DrinkName.Campari:
                return "proto_liquor_campari";
        }
        return null;
    }

    public DrinkName GetDrinkNameBySpriteName(string spriteName)
    {
        switch (spriteName)
        {
            case "proto_Spirits_gin":
                return DrinkName.Gin;
            case "proto_liquor_sweet_vermouth":
                return DrinkName.SweetVermouth;
            case "proto_liquor_campari":
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
        foreach(Sprite sprite in sprites)
        {
            if(sprite.name == name) return sprite;
        }
        return null;
    }

    public Sprite GetSpriteByDrinkName(DrinkName drinkName)
    {
        string name = GetSpriteNameByDrinkName(drinkName);
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == name) return sprite;
        }
        return null;
    }
}
