using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class TableGlass : TableObject
{

    private List<Liquid> liquidList = new List<Liquid>();

    [SerializeField]
    private SpriteRenderer liquidSprite = null;

    [SerializeField]
    private float capacity = 50.0f;

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
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        Save();
    }


    void Load()
    {
        liquidList.Clear();
        int count = PlayerPrefs.GetInt("LiquidCount");

        float amount = 0f;
        float weight = 0f;
        Color color;
        int dcount = 0;
        List<DrinkName> names = new List<DrinkName>();

        for (int i = 0; i < count; i++)
        {
            names.Clear();
            amount = PlayerPrefs.GetFloat("Liquid" + i + "Amount");
            weight = PlayerPrefs.GetFloat("Liquid" + i + "Weight");
            color = new Color(PlayerPrefs.GetFloat("Liquid" + i + "ColorR"),
                                PlayerPrefs.GetFloat("Liquid" + i + "ColorG"),
                                PlayerPrefs.GetFloat("Liquid" + i + "ColorB"));

            dcount = PlayerPrefs.GetInt("Liquid" + i + "DrinkTagCount"); ;

            for (int j = 0; j < dcount; j++)
            {
                names.Add(GameResMng.Instance.GetDrinkNameBySpriteName(PlayerPrefs.GetString("Liquid" + i + "DrinkTag" + j)));
            }
        }
    }

    void Save()
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

    public void SetDrinkSprite()
    {
        try
        {
            if (liquidList[0] != null)
                liquidSprite.material.SetFloat("_Cutoff1", liquidList[0].Amount / capacity);
        }
        catch
        {

        }
        try
        {
            if (liquidList[1] != null)
                liquidSprite.material.SetFloat("_Cutoff2", (liquidList[1].Amount + liquidList[0].Amount) / capacity);
        }
        catch
        {

        }
        try
        {
            if (liquidList[2] != null)
                liquidSprite.material.SetFloat("_Cutoff3", Amount / capacity);
        }
        catch
        {

        }
    }

    protected override void OnClick()
    {
        base.OnClick();

    }
}
