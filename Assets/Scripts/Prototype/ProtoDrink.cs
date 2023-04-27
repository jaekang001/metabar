using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProtoDrink : ProtoClickObject
{
    [SerializeField]
    private ProtoSceneCtrl sceneCtrl;
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
        sceneCtrl.LoadScene(3);
    }
}
