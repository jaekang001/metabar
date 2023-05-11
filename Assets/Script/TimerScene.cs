using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScene : MonoBehaviour
{

    public Timecount timer;// Timer 클래스의 인스턴스를 참조하기 위한 변수
    private Text timerText;
    int minutes;
    int seconds;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>(); // 자신의 UI Text 오브젝트를 참조합니다.
        float savedTime = PlayerPrefs.GetFloat("Time"); // 저장된 타이머 값을 불러옵니다.
        if (savedTime > 0)
        {
            timer.timeLeft = savedTime; // 불러온 타이머 값을 사용합니다.
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (timer.timeLeft > 0)
        {
            timer.timeLeft -= Time.deltaTime; // 타이머 값을 감소시킵니다.
        }
        minutes = Mathf.FloorToInt(timer.timeLeft/ 60.0f); // 분을 계산합니다.
        seconds = Mathf.FloorToInt(timer.timeLeft % 60.0f); // 초를 계산합니다.
        if (timer != null)
        {
            timerText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds); ; // 타이머 값을 UI Text에 표시합니다.
        }
        PlayerPrefs.SetFloat("Time",timer.timeLeft);
     
    }
}

