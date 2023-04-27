using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecount : MonoBehaviour
{
    public GameObject timeoverImage;
    public float timeLeft = 420.0f; // 7분 타이머를 설정합니다.
    public Text timer;
    int minutes;
    int seconds;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        timeoverImage.SetActive(false);
        float savedTime = PlayerPrefs.GetFloat("TimeLeft"); // 저장된 타이머 값을 불러옵니다.
        if (savedTime > 0)
        {
            timeLeft = savedTime; // 불러온 타이머 값을 사용합니다.
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime; // 타이머 값을 감소시킵니다.
        } // 시간을 감소시킵니다.
        minutes = Mathf.FloorToInt(timeLeft / 60.0f); // 분을 계산합니다.
        seconds = Mathf.FloorToInt(timeLeft % 60.0f); // 초를 계산합니다.

        
        timer.text = "Time:" + string.Format("{0:00}:{1:00}", minutes, seconds);
        if (timeLeft < 0)
        {
            // 타이머를 멈춥니다.
            timeLeft = 0;
            timeoverImage.SetActive(true);

        }
        PlayerPrefs.SetFloat("TimeLeft", timeLeft);
    }

}
