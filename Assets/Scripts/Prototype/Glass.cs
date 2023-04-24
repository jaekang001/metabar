using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer jiggerSprite = null;

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
        if (curCapacity > maxCapacity)
            curCapacity = maxCapacity;
        jiggerSprite.material.SetFloat("_Cutoff1", curCapacity / maxCapacity);
    }
}
