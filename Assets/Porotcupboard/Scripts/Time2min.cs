using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time2min : MonoBehaviour
{
    public Text[] timeText;
    
    public float time = 10;
    int min, sec;
    private bool timestart=true;
    public GameObject gameout;//게임오버 화면
    public GameObject[] menue;//이전,홈 버튼
    public GameObject[] underbar;//천장스크롤 UI

    // Start is called before the first frame update
    void Start()
    {
        timeText[0].text = "02";
        timeText[1].text = "00";

        underbar[0].SetActive(true);
        underbar[1].SetActive(true);

       
    }

    // Update is called once per frame
    void Update()
    {
        if(timestart == true)
        {
            time -= Time.deltaTime;
            min =(int)time/60;
            sec=((int)time-min * 60)%60;
            gameout.SetActive(false);

            if(sec>=60){
                min += 1;
                sec -= 60;
            }
            else{
                timeText[0].text = min.ToString();
                timeText[1].text = sec.ToString();
            }

        }
        
        

        

        if(time <= 0)
        {
             timestart = false;
             gameout.SetActive(true);
             menue[0].SetActive(true);
             menue[1].SetActive(true);
             underbar[0].SetActive(false);
             underbar[1].SetActive(false);
             underbar[2].SetActive(false);
             underbar[3].SetActive(false);
           
        }

        

       
        
    }
}
