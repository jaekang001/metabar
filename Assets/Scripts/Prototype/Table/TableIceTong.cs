using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableIceTong : TableTool
{
    [SerializeField]
    private SpriteRenderer iceSprite = null;
    [SerializeField]
    private bool isIce = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetIce(bool state)
    {
        iceSprite.enabled = state;
        isIce = state;
    }

    protected override void OnClick()
    {
        base.OnClick();

    }

    protected override void OnDrop()
    {
        base.OnDrop();

        if (IsInColObjByTag("Glass"))
        {
            SetIce(false);
            FindObjByTagFromColObj("Glass").GetComponent<Glass>().SetIce(true);
        }
    }

    protected override void OnColEnter()
    {
        base.OnColEnter();
        if (IsInColObjByTag("IcePaill"))
        {
            SetIce(true);
        }
    }
}
