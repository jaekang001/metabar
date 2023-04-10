using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickNo2 : MonoBehaviour
{

    public GameObject button;


    public void addScore()
    {
        GameScore.value = GameScore.value + 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
