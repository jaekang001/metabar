using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultShow : MonoBehaviour
{
    GameObject Protext;
    GameObject Resulttext;

    // Start is called before the first frame update
    void Start()
    {
        int HowManyPro = PlayerPrefs.GetInt("HowPro");
        int Match = PlayerPrefs.GetInt("Match");

        Protext = GameObject.Find("AllProblem");
        Resulttext = GameObject.Find("ResultProblem");


        Protext.GetComponent<Text>().text = HowManyPro.ToString();
        Resulttext.GetComponent<Text>().text = Match.ToString();

        print(HowManyPro);
        print(Match);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
