using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickNo4 : MonoBehaviour
{
    public void pushNo4()
    {
        GameObject.Find("EventManager").GetComponent<GameScore>().check(4);
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
