using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProtoJigger : MonoBehaviour
{
    [SerializeField]
    ProtoJiggerCol jiggerCol = null;

    [SerializeField]
    SpriteRenderer jiggerSprite = null;

    [SerializeField]
    TMPro.TextMeshPro capasityText = null;

    [SerializeField]
    private float curCapacity = 0.0f;

    [SerializeField]
    private float maxCapacity = 50.0f;

    public float GetCurrentCapacity()
    {
        return curCapacity;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inputDrop()
    {
        curCapacity += 0.5f;
        if(curCapacity > maxCapacity)
            curCapacity = maxCapacity;

        capasityText.text = curCapacity.ToString()+"ml";
        jiggerSprite.material.SetFloat("_Cutoff", curCapacity/maxCapacity);
    }
}
