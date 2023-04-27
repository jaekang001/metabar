using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonctrl : MonoBehaviour
{
    bool buttonActive;
    public GameObject TimerManager;
    Timecount tm;
    // Start is called before the first frame update
    void Start()
    {
        buttonActive = false;
        tm = TimerManager.GetComponent<Timecount>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clickbutton()
    {
        if(!buttonActive)
        {
            tm.SetTimerOn();
            buttonActive = true;
        }
        else
        {
            tm.SetTimeroff();
            buttonActive = false;
        }
    }
}
