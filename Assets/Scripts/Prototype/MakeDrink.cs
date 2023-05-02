using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDrink : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private DrinkName name = DrinkName.Vodka;

    private void Save()
    {

    }

    private void Load()
    {
        GameResMng resMng = GameResMng.Instance;
        name = (DrinkName)PlayerPrefs.GetInt("DrinkName");
        spriteRenderer.sprite = resMng.GetSpriteByName(resMng.GetSpriteNameByDrinkName(name));
    }

    private void Awake()
    {
        Load();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
