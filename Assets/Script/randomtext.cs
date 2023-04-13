using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomtext : MonoBehaviour
{
    public Text QuizText;
    private string[] QuizTextArray = { "데낄라", "진", "브랜디","위스키","보드카" };
    private int RandomNum;
    // Start is called before the first frame update
    void Start()
    {
        //0부터5까지 저장된 배열에서 랜덤하게 발생
        RandomNum = Random.Range(0, 5);
        Debug.Log(RandomNum);
        QuizText.text = QuizTextArray[RandomNum];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
