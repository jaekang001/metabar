using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time2min : MonoBehaviour
{
    public Text[] timeText;
    public Text gameOverText;
    float time = 120;
    int min, sec;

    // Start is called before the first frame update
    void Start()
    {
        timeText[0].text = "02";
        timeText[1].text = "00";
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        

        min =(int)time/60;
        sec=((int)time-min * 60)%60;

        if(min <= 0 && sec <=0)
        {
            
        }
        else{
            if(sec>=60){
                min += 1;
                sec -= 60;
            }
            else{
                timeText[0].text = min.ToString();
                timeText[1].text = sec.ToString();
            }
        }
    }
}
