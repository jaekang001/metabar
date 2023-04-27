using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProtoSpriteButton : ProtoClickObject
{
    [SerializeField]
    private UnityEvent onClick;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnClick()
    {
        base.OnClick();
        onClick.Invoke();   
    }
}
