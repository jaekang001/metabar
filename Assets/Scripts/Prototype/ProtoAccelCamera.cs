using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoAccelCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal")*Time.deltaTime, Input.GetAxis("Vertical") * Time.deltaTime, 0)*4.0f);

        if(Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.forward, 20.0f * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.back, 20.0f * Time.deltaTime);
    }
}
