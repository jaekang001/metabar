using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ProtoWaterRotation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private MaterialPropertyBlock propBlock;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        propBlock = new MaterialPropertyBlock();
    }

    void Update()
    {
        float zRotation = -transform.eulerAngles.z;

        spriteRenderer.GetPropertyBlock(propBlock);
        propBlock.SetFloat("_Rotation", zRotation);
        spriteRenderer.SetPropertyBlock(propBlock);
    }

}
