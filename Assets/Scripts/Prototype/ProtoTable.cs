using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class ProtoTable : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tools;
    [SerializeField]
    private GameObject[] glasses;
    [SerializeField]
    private GameObject[] alcohols;
    [SerializeField]
    private GameObject[] nonAlcoholics;


    [SerializeField]
    private bool isUsingPre = false;

    [SerializeField]
    private Vector3[] toolPos;
    [SerializeField]
    private Vector3[] glassPos;
    [SerializeField]
    private Vector3[] drinkPos;

    [SerializeField]
    private ToolName[] preTools;

    [SerializeField]
    private GlassName preGlass;

    [SerializeField]
    private DrinkName[] preDrinks;

    private void Load()
    {
        if (isUsingPre)
        {
            //사전준비데이터 사용

        }
        else
        {
            //사전준비데이터 미사용
            //PlayerPref에서 데이터 가져오기

        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Load();
        ToolSet();
        GlassSet();
        AlcoholSet();
        //NonAlcoholicSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ToolSet()
    {
        Vector3 pos = transform.position;
        int i = 0;
        foreach (ToolName toolID in preTools) {
            pos = toolPos[i++];
            Instantiate(this.tools[(char)toolID], pos, Quaternion.identity, transform);

        }
    }

    private void GlassSet()
    {
        Instantiate(this.glasses[(char)preGlass], glassPos[0], Quaternion.identity, transform);
    }

    private void AlcoholSet()
    {
        Vector3 pos = transform.position;
        int i = 0;
        foreach (DrinkName alcoholID in preDrinks)
        {
            pos = drinkPos[i++];
            Instantiate(this.alcohols[(char)alcoholID], pos, Quaternion.identity, transform);
            

        }
    }

    private void NonAlcoholicSet()
    {
        Vector3 pos = transform.position;
        int i = 0;
        foreach (DrinkName nAlcoholicID in preDrinks)
        {

            Instantiate(this.nonAlcoholics[(char)nAlcoholicID], pos, Quaternion.identity, transform);
            pos += drinkPos[i++];

        }
    }


    public void Submit()
    {
        Debug.Log("Submit");
    }
}
