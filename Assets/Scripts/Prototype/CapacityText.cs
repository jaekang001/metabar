using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class CapacityText : MonoBehaviour
{
    [SerializeField]
    private ProtoJigger target;
    [SerializeField]
    private float capacity = 0.0f;


    [SerializeField]
    TMPro.TextMeshPro capasityText = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float temp = target.GetCurrentCapacity();
        if (capacity != target.GetCurrentCapacity())
        {
            capacity = temp;
            capasityText.text = capacity.ToString() + "ml";
        }
    }

}
