using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoTableObject : ProtoClickObject
{
    [SerializeField]
    protected Vector2 firstPoint = Vector3.zero;
    [SerializeField]
    protected Vector2 lastPoint = Vector3.zero;
    [SerializeField]
    private float dragDistance = 1;

    protected IEnumerator myDrag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnClick()
    {
        base.OnClick();
        Debug.Log("On Click");
    }

    protected virtual void OnDrop()
    {
        Debug.Log("On Drop");
    }

    protected override void OnEnter()
    {
        base.OnEnter();
        
    }

    protected override void OnExit()
    {
        base.OnExit();
    }

    override protected IEnumerator WaitClick()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                myDrag = Dragging();
                StartCoroutine(myDrag);
                Debug.Log("WaitClick Stop");
                StopCoroutine(myWait);
            }
            yield return null;
        }
    }

    protected IEnumerator Dragging()
    {
        Vector2 posOrgn = transform.localPosition;
        firstPoint = GetMousePosition();

        while (true)
        {
            lastPoint = GetMousePosition();
            transform.localPosition = posOrgn + (lastPoint - firstPoint);
            Debug.Log("Is Dragging");
            if (Input.GetMouseButtonUp(0))
            {
                float dis = Vector2.Distance(firstPoint, lastPoint);
                if (dis > dragDistance)
                {
                    OnDrop();  
                }
                else
                {
                    OnClick();
                }
                Debug.Log("Dragging Stop");
                transform.localPosition = posOrgn;
                StopCoroutine(myDrag);
            }
            yield return null;
        }
    }
}
