using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 담는 용기 글래스 전용 컴포넌트
/// </summary>
[RequireComponent(typeof(Glass))]
public class VesselGlass : Vessel
{
    [SerializeField]
    private Glass glass;


    /// <summary>
    /// 플로팅 메서드
    /// </summary>
    /// <param name="drop"></param>
    public void Float(Drop drop)
    {
        if (glass.Amount <= glass.MaxCapacity)
        {
            if (glass.HasLiquid)
            {
                if (glass.IsFloatable(drop.Name))
                {
                    //플로팅 가능
                    glass.FloatingLiquid(0.5f, drop.Name);
                }
                else
                {
                    //플로팅 불가능
                    glass.MixingLiquid(0.5f,drop.Name);
                }
            }
            else
            {
                glass.FloatingLiquid(0.5f, drop.Name);
            }
            glass.SetDrinkSprite();
        }
        GameObject.Destroy(drop.gameObject);
    }
    /// <summary>
    /// 빌딩 메서드
    /// </summary>
    /// <param name="drop"></param>
    public void Build(Drop drop)
    {
        if (glass.Amount <= glass.MaxCapacity)
        {
            if (glass.HasLiquid)
            {
                glass.MixingLiquid(0.5f, drop.Name);
            }
            else
            {
                glass.FloatingLiquid(0.5f, drop.Name);
            }
            glass.SetDrinkSprite();
        }
        GameObject.Destroy(drop.gameObject);
    }
}


