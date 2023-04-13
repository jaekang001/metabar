using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecount : MonoBehaviour
{
    public Text timeText;
    public GameObject timeoverImage;
    private float timeElapsed = 0.0f;
    int minutes = 0;
    int seconds = 0;
    public string timeString;
    string value;

    // Start is called before the first frame update
    void Start()
    {
        timeoverImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        SetValue();
        if (minutes==1)
        {
            timeoverImage.SetActive(true);
            timeElapsed = 0.0f;
        }
    }

   

    public void SetValue()
    {
        timeElapsed += Time.deltaTime;
        minutes = Mathf.FloorToInt(timeElapsed / 60.0f);
        seconds = Mathf.FloorToInt(timeElapsed % 60.0f);
        value = string.Format("{0:00}:{1:00}", minutes, seconds);
        PlayerPrefs.SetString(timeString, value);
        timeString = PlayerPrefs.GetString(timeString);
        timeText.text = "Time: " + timeString;
        //PlayerPrefs를 이용한 timer저장값
    }
}
