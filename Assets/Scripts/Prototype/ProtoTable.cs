using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class ProtoTable : MonoBehaviour
{
    [SerializeField]
    private Transform toolPoint;
    [SerializeField]
    private Transform glassPoint;
    [SerializeField]
    private Transform drinkPoint;

    [SerializeField]
    private GameObject[] tools;
    [SerializeField]
    private GameObject[] glasses;
    [SerializeField]
    private GameObject[] drinks;

    
    // Start is called before the first frame update
    void Start()
    {
        ToolSet(new int[] { 0,1});
        GlassSet(0);
        DrinkSet(new int[] { 0, 1 ,2});
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ToolSet(int[] toolIDs)
    {
        Vector3 pos = toolPoint.position;
        foreach (int toolID in toolIDs) {

            Instantiate(this.tools[toolID], pos, Quaternion.identity, toolPoint);
            pos += new Vector3(0,-2,-1);

        }
    }

    private void GlassSet(int glassID)
    {
        Instantiate(this.glasses[glassID], glassPoint.position, Quaternion.identity, glassPoint);
    }

    private void DrinkSet(int[] drinkIDs) {
        Vector3 pos = drinkPoint.position;
        foreach (int drinkID in drinkIDs)
        {

            Instantiate(this.drinks[drinkID], pos, Quaternion.identity, drinkPoint);
            pos += new Vector3(1, -1, -1);

        }
    }
    
}
