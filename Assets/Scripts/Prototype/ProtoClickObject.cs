using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoClickObject : MonoBehaviour
{
    protected IEnumerator myWait;

    private Camera mainCamera = null;
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
        //Debug.Log(gameObject.name);
    }

    protected virtual void OnEnter()
    {
        //Debug.Log("OnMouseEnter");
        myWait = WaitClick();
        StartCoroutine(myWait);
    }


    protected void OnMouseEnter()
    {
        OnEnter();
    }

    protected virtual void OnExit()
    {
        //Debug.Log("OnMouseExit");
        StopCoroutine(myWait);
    }

    protected void OnMouseExit()
    {
        OnExit();
    }

    virtual protected IEnumerator WaitClick()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
                StopCoroutine(myWait);
            }
            yield return null;
        }

    }

    protected Vector2 GetMousePosition()
    {
        if (!mainCamera)
        {
            mainCamera = Camera.main;
        }
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
