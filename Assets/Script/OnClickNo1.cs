using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickNo1 : MonoBehaviour
{

    public void pushNo1()
    {
        GameObject.Find("EventManager").GetComponent<GameScore>().check(1);
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
