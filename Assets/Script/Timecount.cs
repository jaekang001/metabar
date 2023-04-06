using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecount : MonoBehaviour
{
    public Text timeText;
    public GameObject timeoverImage;
    private float timeElapsed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        timeoverImage.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeElapsed / 60.0f);
        int seconds = Mathf.FloorToInt(timeElapsed % 60.0f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeText.text = "Time: " + timeString;

        if(minutes==1)
        {
            timeoverImage.SetActive(true);
            timeElapsed = 0.0f;
        }
    }
}
