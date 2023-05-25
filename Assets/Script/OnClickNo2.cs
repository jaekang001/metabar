using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickNo2 : MonoBehaviour
{

    public void pushNo2()
    {
        GameObject.Find("EventManager").GetComponent<GameScore>().check(2);
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
