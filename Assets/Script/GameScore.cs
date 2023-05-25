using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameScore : MonoBehaviour
{
    public static int result; // result
    public static int value; // Problem Number
    public static int Problem = 0; // present Problem
    public static int ProblemLast = 10; // How many a Problem
    public static int[] UserResult;
    public static int[] ResultSet;

    int startCounter = 0; // start score
    int Match;

    // Start is called before the first frame update
    void Start()
    {

        Match = startCounter;
        value = startCounter;

        UserResult = new int[ProblemLast];
        ResultSet = new int[ProblemLast];

        resultSetting();

        //GameObject.Find("EventManager").GetComponent<TestTextOn>().TestSave(); 

        PlayerPrefs.SetInt("HowPro", ProblemLast);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resultSetting() // result setting function
    {
        
        for (int i = 0; i <= ProblemLast-1; i++)
        {
            Test test1 = GameObject.Find("EventManager").GetComponent<Clipboard>().csvfileOpen(i);
            ResultSet[i] = test1.result;
        }

        //print(ResultSet);
        
    }

    public void check(int che)
    {
        if (Problem < ProblemLast)
        {
            UserResult[Problem] = che;
            Problem++;
            GameObject.Find("EventManager").GetComponent<TestTextOn>().TestSave(Problem);

            //print(Problem);
        }
        else
        {
            CheckResult();
            PlayerPrefs.SetInt("Match", Match);
            SceneManager.LoadScene("ProtoWriteTestResult");
        }

        /*
        if (che == result) // right
        {
            UserResult[Problem] = che;
            Problem++;
            //GameObject.Find("ScoreText").GetComponent<Forever_ShowCount>().ScoreUpdate();
            GameObject.Find("EventManager").GetComponent<TestTextOn>().TestSave(Problem);
        }
        else // not right
        {
            Problem++;
            GameObject.Find("EventManager").GetComponent<TestTextOn>().TestSave(Problem);
        }
        */

    }
    public void BeforeButton()
    {
        if (Problem >= 0)
        {
            Problem--;
            GameObject.Find("EventManager").GetComponent<TestTextOn>().TestSave(Problem);
            //print(Problem);
        }
    }
    public void NextButton()
    {
        if (Problem < ProblemLast)
        {
            Problem++;
            GameObject.Find("EventManager").GetComponent<TestTextOn>().TestSave(Problem);
            //print(Problem);
        }
    }

    void CheckResult()
    {
        for(int i = 0; i< ProblemLast - 1; i++)
        {
            if(UserResult[i] == ResultSet[i])
            {
                Match++;
            }
        }
    }
}
