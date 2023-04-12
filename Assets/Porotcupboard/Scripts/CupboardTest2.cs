using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardTest2 : MonoBehaviour
{
    private bool state2;
    private GameObject selectCup2;
   
    void Start()
    {
        state2 = false;
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
                if (hit.collider.tag == "cupboard2")
                {
                    if (state2 == false)
                    {
                        hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                        selectCup2 = hit.collider.gameObject;
                        state2 = true;
                    }
                    else
                    {
                        if (selectCup2.gameObject == hit.collider.gameObject)
                        {
                            hit.collider.transform.GetChild(0).gameObject.SetActive(false);
                            state2 = false;
                        }
                        else
                        {
                            selectCup2.transform.GetChild(0).gameObject.SetActive(false);
                            hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                            selectCup2 = hit.collider.gameObject;
                        }
                    }
                }
			}
		}
    }
}
