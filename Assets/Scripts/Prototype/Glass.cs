using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Glass : MonoBehaviour
{
    protected List<Liquid> liquidList = new List<Liquid>();

    [SerializeField]
    protected SpriteRenderer liquidSprite = null;

    [SerializeField]
    protected float capacity = 50.0f;

    public float Amount
    {
        get
        {
            float amount = 0;
            foreach (Liquid liquid in this.liquidList)
            {
                amount += liquid.Amount;
            }
            return amount;
        }
    }

    protected void Load()
    {
        liquidList.Clear();
        int count = PlayerPrefs.GetInt("LiquidCount");

        float amount;
        float weight;
        UnityEngine.Color color;
        int dcount;
        List<DrinkName> names = new List<DrinkName>();

        for (int i = 0; i < count; i++)
        {
            names.Clear();
            amount = PlayerPrefs.GetFloat("Liquid" + i + "Amount");
            weight = PlayerPrefs.GetFloat("Liquid" + i + "Weight");
            color = new UnityEngine.Color(PlayerPrefs.GetFloat("Liquid" + i + "ColorR"),
                                PlayerPrefs.GetFloat("Liquid" + i + "ColorG"),
                                PlayerPrefs.GetFloat("Liquid" + i + "ColorB"));

            dcount = PlayerPrefs.GetInt("Liquid" + i + "DrinkTagCount"); ;

            for (int j = 0; j < dcount; j++)
            {
                names.Add(GameResMng.Instance.GetDrinkNameBySpriteName(PlayerPrefs.GetString("Liquid" + i + "DrinkTag" + j)));
            }
            Debug.Log("MakeGlassLiquid" + i + "Add(" + amount + "," + weight + "," + color + "," + names);
            liquidList.Add(new Liquid(amount, weight, color, names));
        }
        SetDrinkSprite();
    }

    protected void Save()
    {
        PlayerPrefs.SetInt("LiquidCount", liquidList.Count);
        for (int i = 0; i < liquidList.Count; i++)
        {
            PlayerPrefs.SetFloat("Liquid" + i + "Amount", liquidList[i].Amount);
            PlayerPrefs.SetFloat("Liquid" + i + "Weight", liquidList[i].Weight);
            PlayerPrefs.SetFloat("Liquid" + i + "ColorR", liquidList[i].Color.r);
            PlayerPrefs.SetFloat("Liquid" + i + "ColorG", liquidList[i].Color.g);
            PlayerPrefs.SetFloat("Liquid" + i + "ColorB", liquidList[i].Color.b);

            PlayerPrefs.SetInt("Liquid" + i + "DrinkTagCount", liquidList[i].DrinkTags.Count);
            for (int j = 0; j < liquidList[i].DrinkTags.Count; j++)
            {
                PlayerPrefs.SetString("Liquid" + i + "DrinkTag" + j, GameResMng.Instance.GetSpriteNameByDrinkName(liquidList[i].DrinkTags[j]));
            }
        }
    }

    protected void Start()
    {
        Load();
    }

    protected void Update()
    {

    }

    protected void OnDestroy()
    {
        Save();
    }

    public void SetDrinkSprite()
    {
        try
        {
            if (liquidList[0] != null)
            {
                liquidSprite.material.SetFloat("_Cutoff1", liquidList[0].Amount / capacity);
                liquidSprite.material.SetColor("_LayerColor1", liquidList[0].Color);
            }
        }
        catch
        {

        }
        try
        {
            if (liquidList[1] != null)
            {
                liquidSprite.material.SetFloat("_Cutoff2", (liquidList[1].Amount + liquidList[0].Amount) / capacity);
                liquidSprite.material.SetColor("_LayerColor2", liquidList[1].Color);
            }
        }
        catch
        {

        }
        try
        {
            if (liquidList[2] != null)
            {
                liquidSprite.material.SetFloat("_Cutoff3", Amount / capacity);
                liquidSprite.material.SetColor("_LayerColor3", liquidList[2].Color);
            }
        }
        catch
        {

        }
    }

    public void SwapDrink(int a, int b)
    {
        float aCap = liquidSprite.material.GetFloat("_Cutoff" + a.ToString());
        Color aColor = liquidSprite.material.GetColor("_LayerColor" + a.ToString());
        float bCap = liquidSprite.material.GetFloat("_Cutoff" + b.ToString());
        Color bColor = liquidSprite.material.GetColor("_LayerColor" + b.ToString());
        liquidSprite.material.SetFloat("_Cutoff" + a.ToString(), bCap);
        liquidSprite.material.SetFloat("_Cutoff" + b.ToString(), aCap);
        liquidSprite.material.SetColor("_LayerColor" + a.ToString(), bColor);
        liquidSprite.material.SetColor("_LayerColor" + b.ToString(), aColor);
    }
}

public class Liquid
{
    private float amount = 0;
    private float weight = 0;
    private UnityEngine.Color color;
    private List<DrinkName> drinkTags = new List<DrinkName>();

    public Liquid(float amount, DrinkName drinkName)
    {
        this.amount = amount;
        this.weight = GameResMng.Instance.GetDrinkWeightByDrinkName(drinkName);
        this.color = GameResMng.Instance.GetDrinkColorByDrinkName(drinkName);
        this.drinkTags.Add(drinkName);
    }

    public Liquid(float amount, float weight, UnityEngine.Color color, List<DrinkName> drinkTags)
    {
        this.amount = amount;
        this.weight = weight;
        this.color = color;
        this.drinkTags = drinkTags;
    }

    public float Amount
    {
        get { return amount; }
    }
    public UnityEngine.Color Color
    {
        get { return color; }
    }
    public float Weight
    {
        get { return weight; }
    }
    public List<DrinkName> DrinkTags
    {
        get { return drinkTags; }
    }

    public void AddDrink(float amount, DrinkName drinkName)
    {
        float weight = GameResMng.Instance.GetDrinkWeightByDrinkName(drinkName);
        UnityEngine.Color color = GameResMng.Instance.GetDrinkColorByDrinkName(drinkName);

        // 새로운 량과 기존 량의 비율을 계산합니다.
        float newAmountRatio = amount / (this.amount + amount);
        float oldAmountRatio = 1 - newAmountRatio;

        // weight와 color를 비율에 맞게 섞습니다.
        this.weight = this.weight * oldAmountRatio + weight * newAmountRatio;
        this.color = UnityEngine.Color.Lerp(this.color, color, newAmountRatio);

        this.amount += amount;
        this.drinkTags.Add(drinkName);
    }

    /// <summary>
    /// 파라미터로 받은 드링크 종류가 이 드링크 위에 뜰 수 있는지 여부 반환
    /// </summary>
    /// <param name="drinkName"></param>
    /// <returns></returns>
    public bool IsFloatable(DrinkName drinkName)
    {
        float weight = GameResMng.Instance.GetDrinkWeightByDrinkName(drinkName);

        if (weight - this.weight < -0.1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}