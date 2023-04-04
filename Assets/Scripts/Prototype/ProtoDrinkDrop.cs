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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        temp += 1f*Time.deltaTime;
        if (temp > 0.2)
        {
            Instantiate(dropPrefab, dropPoint.position + new Vector3(Random.Range(-0.1f,0.1f),Random.Range(-0.1f, 0.1f),0), Quaternion.identity);
            temp = 0;
        }
    }

}
