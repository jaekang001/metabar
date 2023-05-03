using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGlass : Glass
{
    

     

    

    public void Float(Drop drop)
    {
        if (Amount <= capacity)
        {
            if (liquidList.Count > 0)
            {
                if (liquidList[liquidList.Count -1].IsFloatable(drop.Name))
                {
                    //플로팅 가능
                    liquidList.Add(new Liquid(0.5f, drop.Name));
                }
                else
                {
                    //플로팅 불가능
                    liquidList[liquidList.Count - 1].AddDrink(0.5f, drop.Name);
                }
            }
            else
            {
                liquidList.Add(new Liquid(0.5f, drop.Name));
            }
            SetDrinkSprite();
        }
        GameObject.Destroy(drop.gameObject);
    }
    public void Build(Drop drop)
    {
        if (Amount <= capacity)
        {
            if(liquidList.Count > 0)
            {
                liquidList[liquidList.Count - 1].AddDrink(0.5f, drop.Name);
            }
            else
            {
                liquidList.Add(new Liquid(0.5f, drop.Name));
            }
            SetDrinkSprite();
        }
        GameObject.Destroy(drop.gameObject);
    }
}


