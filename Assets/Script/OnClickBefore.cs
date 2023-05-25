using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickBefore : MonoBehaviour
{
    public void pushBefore()
    {
        GameObject.Find("EventManager").GetComponent<GameScore>().BeforeButton();
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
