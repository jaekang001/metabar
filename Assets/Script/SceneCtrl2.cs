using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneCtrl2 : MonoBehaviour
{
    public Text timeText;
    Timecount timecount;
    public GameObject TimerManager;
    // Start is called before the first frame update
    void Start()
    {
        timecount = TimerManager.GetComponent<Timecount>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("ProtoCounter");
        timeText.text = "Time: " + PlayerPrefs.GetString(timecount.timeString);
    }
}
