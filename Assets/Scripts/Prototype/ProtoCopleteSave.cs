using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoCopleteSave : MonoBehaviour
{
    [SerializeField]
    ProtoJigger jigger;
    public void Save()
    {
        PlayerPrefs.SetFloat("MakeCapacity", jigger.GetCurrentCapacity());
        PlayerPrefs.SetString("MakeDrinkName","Temp");
    }
}
