using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardTest1 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool state;
    private GameObject selectCup;
   
    void Start()
    {
        state = false;
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
                if (hit.collider.tag == "cupboard1")
                {
                    if (state == false)
                    {
                        hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                        hit.collider.transform.GetChild(1).gameObject.SetActive(true);
                        selectCup = hit.collider.gameObject;
                        state = true;
                    }
                    else
                    {
                        if (selectCup.gameObject == hit.collider.gameObject)
                        {
                            hit.collider.transform.GetChild(0).gameObject.SetActive(false);
                            hit.collider.transform.GetChild(1).gameObject.SetActive(false);
                            
                            state = false;
                        }
                        else
                        {
                            selectCup.transform.GetChild(0).gameObject.SetActive(false);
                            selectCup.transform.GetChild(1).gameObject.SetActive(false);
                            hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                            hit.collider.transform.GetChild(1).gameObject.SetActive(true);
                            selectCup = hit.collider.gameObject;
                        }
                    }
                }
			}
		}
    }
}