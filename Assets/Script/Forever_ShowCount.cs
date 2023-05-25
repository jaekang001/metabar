using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forever_ShowCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = GameScore.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScoreUpdate()
    {
        GetComponent<Text>().text = GameScore.value.ToString();
    }
}
