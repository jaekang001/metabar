using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoSetPrefs : MonoBehaviour
{
    [SerializeField]
    private string Key;
    public void SetUserPref(string data)
    {
        PlayerPrefs.SetString(Key+"String", data);
    }
    public void SetUserPref(float data)
    {
        PlayerPrefs.SetFloat(Key + "Float", data);
    }
    public void SetUserPref(int data)
    {
        PlayerPrefs.SetInt(Key + "Int", data);
    }
}
