using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoDrinkDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject dropPrefab;
    [SerializeField]
    private Transform dropPoint;

    float temp = 0;
    [SerializeField]
    private bool isTilted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTilted)
        {
            float curAngle = transform.rotation.eulerAngles.z;
            float slope = Mathf.Abs(curAngle - 180)/180;
            float dropScale = 0.6f * 2f * Mathf.Pow(2f * 9.81f * slope , 0.5f);
            
            Debug.Log("curAngle="+ curAngle + " dropScale=" + dropScale + " slope=" + slope);
            temp += 1f * Time.deltaTime;
            if (temp > dropScale * 0.05f)
            {
                Instantiate(dropPrefab, dropPoint.position + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0), Quaternion.identity);
                temp = 0;
            }
        }

        if(transform.rotation.eulerAngles.z > 45 && transform.rotation.eulerAngles.z < 315)
        {
            isTilted = true;
        }
        else
        {
            isTilted = false;   
        }

    }

}
