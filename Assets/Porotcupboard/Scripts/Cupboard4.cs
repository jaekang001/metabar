using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard4 : MonoBehaviour
{
    private bool state4;
    private GameObject selectCup4;
   
    void Start()
    {
        state4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If the left mouse button is clicked.
		if (Input.GetMouseButtonDown(0))
		{
			//Get the mouse position on the screen and send a raycast into the game world from that position.
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint,Vector2.zero);

			//If something was hit, the RaycastHit2D.collider will not be null.
			if (hit.collider != null)
			{
                if (hit.collider.tag == "cupboard4")
                {
                    if (state4 == false)
                    {
                        hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                        //hit.collider.transform.GetChild(1).gameObject.SetActive(true);
                        selectCup4 = hit.collider.gameObject;
                        state4 = true;
                    }
                    else
                    {
                          if (selectCup4.gameObject == hit.collider.gameObject)
                        {
                            hit.collider.transform.GetChild(0).gameObject.SetActive(false);
                            //hit.collider.transform.GetChild(1).gameObject.SetActive(false);
                            
                            state4 = false;
                        }
                        else
                        {
                            hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                            //hit.collider.transform.GetChild(1).gameObject.SetActive(true);
                            selectCup4 = hit.collider.gameObject;
                        }
                    }
                }
			}
		}
    }
}
