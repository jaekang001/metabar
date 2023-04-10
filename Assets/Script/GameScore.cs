using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스코어 본체
public class GameScore : MonoBehaviour
{

    public static int value; // 공유하는 스코어 값

    public int startCounter = 0; // 스코어 초기값을 0으로 지정
    // Start is called before the first frame update
    void Start()
    {
        value = startCounter; //카운터 초기값을 리셋
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
