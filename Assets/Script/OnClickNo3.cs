using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickNo3 : MonoBehaviour
{
    public void pushNo3()
    {
        GameObject.Find("EventManager").GetComponent<GameScore>().check(3);
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
