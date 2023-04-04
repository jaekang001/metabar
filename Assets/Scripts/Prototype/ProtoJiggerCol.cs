using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoJiggerCol : MonoBehaviour
{
    [SerializeField]
    private ProtoJigger jigger = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Drop")
        {
            GameObject.Destroy(collision.gameObject);
            jigger.inputDrop();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
