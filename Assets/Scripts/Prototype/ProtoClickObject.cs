using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoClickObject : MonoBehaviour
{
    protected IEnumerator myWait;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnClick()
    {
        Debug.Log(gameObject.name);
    }
    protected void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
        myWait = WaitClick();
        StartCoroutine(myWait);
    }
    protected void OnMouseExit()
    {
        Debug.Log("OnMouseExit");
        StopCoroutine(myWait);
    }

    protected IEnumerator WaitClick()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
            yield return null;
        }

    }

}
