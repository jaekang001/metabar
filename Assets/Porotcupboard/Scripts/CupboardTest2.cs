using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardTest2 : MonoBehaviour
{
    private bool state2;
    private GameObject selectCup2;
    private Transform boardTransform;

    void Start()
    {
        state2 = false;
        boardTransform = GameObject.Find("board").transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "cupboard2")
                {
                    if (state2 == false)
                    {
                        selectCup2 = hit.collider.gameObject;
                        selectCup2.transform.GetChild(0).gameObject.SetActive(true);
                        selectCup2.transform.SetParent(boardTransform);
                        state2 = true;
                    }
                    else
                    {
                        if (selectCup2.gameObject == hit.collider.gameObject)
                        {
                            selectCup2.transform.GetChild(0).gameObject.SetActive(false);
                            selectCup2.transform.SetParent(IsCameraInDefaultPosition() ? boardTransform : selectCup2.transform.parent);
                            state2 = false;
                        }
                        else
                        {
                            selectCup2.transform.GetChild(0).gameObject.SetActive(false);
                            selectCup2.transform.SetParent(IsCameraInDefaultPosition() ? boardTransform : selectCup2.transform.parent);
                            hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                            hit.collider.transform.SetParent(IsCameraInDefaultPosition() ? boardTransform : hit.collider.transform.parent);
                            selectCup2 = hit.collider.gameObject;
                        }
                    }
                }
            }
        }
    }

    private bool IsCameraInDefaultPosition()
    {
        return Camera.main.transform.position == new Vector3(0.0f, 0.0f, -10.0f);
    }
}
