using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickNext : MonoBehaviour
{

    public void pushNext()
    {
        GameObject.Find("EventManager").GetComponent<GameScore>().NextButton();
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
