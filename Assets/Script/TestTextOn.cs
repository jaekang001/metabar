using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTextOn : MonoBehaviour
{

    GameObject clipboard;

    GameObject story;

    GameObject title;

    GameObject Number1;

    GameObject Number2;

    GameObject Number3;

    GameObject Number4;

    GameObject ProblemNo;

    // Start is called before the first frame update??   
    void Start() 
    {
        title = GameObject.Find("ProText");      
		story = GameObject.Find("StoryText");
        Number1 = GameObject.Find("No.1_Text");
        Number2 = GameObject.Find("No.2_Text");
        Number3 = GameObject.Find("No.3_Text");
        Number4 = GameObject.Find("No.4_Text");
        clipboard = GameObject.Find("EventManager");
        ProblemNo = GameObject.Find("TitleText");
        TestSave(0);
    }
    // Update is called once per frame??   
    void Update()
    {

    }
    public void TestSave(int i)
    {
        Test test1 = clipboard.GetComponent<Clipboard>().csvfileOpen(i);
        title.GetComponent<Text>().text = test1.title.ToString();
        story.GetComponent<Text>().text = test1.story.ToString();
        Number1.GetComponent<Text>().text = test1.no1.ToString();
        Number2.GetComponent<Text>().text = test1.no2.ToString();
        Number3.GetComponent<Text>().text = test1.no3.ToString();
        Number4.GetComponent<Text>().text = test1.no4.ToString();
        ProblemNo.GetComponent<Text>().text = test1.number.ToString();
        GameScore.result = test1.result;
    }
}