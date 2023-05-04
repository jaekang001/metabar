using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TableDrink : TableObject
{
    [SerializeField]
    private ProtoSceneCtrl sceneCtrl;

    [SerializeField]
    private DrinkName name = DrinkName.Vodka;

    private void Save()
    {
        PlayerPrefs.SetInt("DrinkName",((int)name));
    }
    // Start is called before the first frame update
    void Start()
    {
        sceneCtrl = GameObject.Find("SceneCtrl").GetComponent<ProtoSceneCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnClick()
    {
        base.OnClick();
    }

    protected override void OnDrop()
    {
        base.OnDrop();

        if(IsGlassDrop())
        {
            Save();
            sceneCtrl.LoadScene(4);
        }
        //
    }

    private bool IsGlassDrop()
    {
        foreach(GameObject obj in colObjects)
        {
            TableObjectType type = obj.GetComponent<TableObject>().Type;
            if(type == TableObjectType.Glass)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsJiggerDrop()
    {
        return true;
    }

}
