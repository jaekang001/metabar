using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Drink))]
public class PourerDrink : Pourer
{

    [SerializeField]
    private GameObject dropPrefab;

    [SerializeField]
    private Transform dropPoint;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private DrinkName drinkName = DrinkName.Vodka;

    [SerializeField]
    private bool isTilted = false;


    private float temp = 0;

    private void Save()
    {

    }

    private void Load()
    {
        GameResMng resMng = GameResMng.Instance;
        drinkName = (DrinkName)PlayerPrefs.GetInt("DrinkName");
        Debug.Log(resMng.GetSpriteByDrinkName(drinkName));
        spriteRenderer.sprite = resMng.GetSpriteByDrinkName(drinkName);
    }


    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTilted)
        {
            float curAngle = transform.rotation.eulerAngles.z;
            float slope = Mathf.Abs(curAngle - 180) / 180;
            float dropScale = 0.6f * 2f * Mathf.Pow(2f * 9.81f * slope, 0.5f);

            //Debug.Log("curAngle="+ curAngle + " dropScale=" + dropScale + " slope=" + slope);
            temp += 1f * Time.deltaTime;
            if (temp > dropScale * 0.05f)
            {
                Instantiate(dropPrefab, dropPoint.position + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0), Quaternion.identity).GetComponent<Drop>().Init(drinkName);
                temp = 0;
            }
        }

        if (transform.rotation.eulerAngles.z > 45 && transform.rotation.eulerAngles.z < 315)
        {
            isTilted = true;
        }
        else
        {
            isTilted = false;
        }
    }
}
