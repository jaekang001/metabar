using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolName
{
    BostonShaker,
    StandardShaker,
    MixingGlass,
    SqueezerTop,
    SqueezerBottom,
    BarSpoonM,
    BarSpoonL,
    BarSpoonXL,
    Muddler,
    JiggerCup,
    IcePaill,
    IceTong,
    IcePick,
    Strainer,
    Coaster,
    CocktailPick,

}
public class TableTool : TableObject
{
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
    }

    protected override void OnDrop()
    {
        base.OnDrop();

    }

    protected override void OnEnter()
    {
        base.OnEnter();

    }

    protected override void OnExit()
    {
        base.OnExit();
    }
}
