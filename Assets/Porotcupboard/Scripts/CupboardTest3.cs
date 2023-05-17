/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardTest3 : MonoBehaviour
{

    private bool state3;
    private GameObject selectCup3;
    private Transform boardTransform;

    void Start()
    {
        state3 = false;
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
                if (hit.collider.tag == "cupboard3")
                {
                    if (state3 == false)
                    {

                        hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                        hit.collider.transform.SetParent(boardTransform);
                        selectCup3 = hit.collider.gameObject;
                        state3 = true;
                    }
                    else
                    {
                        if (selectCup3.gameObject == hit.collider.gameObject)
                        {
                            hit.collider.transform.GetChild(0).gameObject.SetActive(false);
                            hit.collider.transform.SetParent(transform);
                            state3 = false;
                        }
                        else
                        {
                            selectCup3.transform.GetChild(0).gameObject.SetActive(false);
                            selectCup3.transform.SetParent(transform);
                            hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                            hit.collider.transform.SetParent(boardTransform);
                            selectCup3 = hit.collider.gameObject;
                        }
                    }
                }
                else if (hit.collider.transform.IsChildOf(transform) && hit.collider.gameObject.activeSelf)
                {
                    hit.collider.transform.SetParent(boardTransform);
                }
            }
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardTest3 : MonoBehaviour
{
    private bool state3;
    private GameObject selectCup3;
    private Transform boardTransform;

    void Start()
    {
        state3 = false;
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
                if (hit.collider.tag == "cupboard3")
                {
                    if (state3 == false)
                    {
                        hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                        hit.collider.transform.SetParent(boardTransform);
                        selectCup3 = hit.collider.gameObject;
                        state3 = true;
                    }
                    else
                    {
                        if (selectCup3.gameObject == hit.collider.gameObject)
                        {
                            hit.collider.transform.GetChild(0).gameObject.SetActive(false);
                            hit.collider.transform.SetParent(transform);
                            state3 = false;
                        }
                        else
                        {
                            selectCup3.transform.GetChild(0).gameObject.SetActive(false);
                            selectCup3.transform.SetParent(transform);

                            if (hit.collider.transform.childCount > 0)
                            {
                                hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                                hit.collider.transform.SetParent(boardTransform);
                                selectCup3 = hit.collider.gameObject;
                            }
                        }
                    }
                }
                else if (hit.collider.transform.IsChildOf(transform) && hit.collider.gameObject.activeSelf)
                {
                    hit.collider.transform.SetParent(boardTransform);
                }
            }
        }
    }
}

