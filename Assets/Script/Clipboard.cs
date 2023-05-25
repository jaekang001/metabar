using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct Test //public struct
{
    public string story;
    public string title;
    public int result;
    public int number;
    public string no1;
    public string no2;
    public string no3;
    public string no4;
};

public class Clipboard : MonoBehaviour
{

    void Start()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Write_test_set");
    }

    public Test csvfileOpen(int testNumber)
    {
        Test tes = new Test();

        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Write_test_set");

        tes.title = data_Dialog[testNumber]["Title"].ToString();
        tes.story = data_Dialog[testNumber]["Story"].ToString();
        tes.no1 = data_Dialog[testNumber]["Number1"].ToString();
        tes.no2 = data_Dialog[testNumber]["Number2"].ToString();
        tes.no3 = data_Dialog[testNumber]["Number3"].ToString();
        tes.no4 = data_Dialog[testNumber]["Number4"].ToString();
        tes.result = Int32.Parse(data_Dialog[testNumber]["Result"].ToString());
        tes.number = Int32.Parse(data_Dialog[testNumber]["Number"].ToString());

        return tes;
    }
}
