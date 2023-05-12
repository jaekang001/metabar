using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TechnicType { Build, Float };
public class GlassCol : MonoBehaviour
{
    [SerializeField]
    private VesselGlass glass = null;
    [SerializeField]
    private TechnicType type;
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
        if (collision.tag == "Drop")
        {
            Drop drop = collision.GetComponent<Drop>();

            
            if(type == TechnicType.Build)
                glass.Build(drop);
            else if (type == TechnicType.Float)
                glass.Float(drop);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
