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

    void Load()
    {

    }

    void Save()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnDestroy()
    {
        Save();
    }

    public void Float(Drop drop)
    {
        curCapacity += 0.5f;
        if (curCapacity > maxCapacity)
            curCapacity = maxCapacity;

        AddDrink();

        GameObject.Destroy(drop.gameObject);
    }
    public void Build(Drop drop)
    {
        curCapacity += 0.5f;
        if (curCapacity > maxCapacity)
            curCapacity = maxCapacity;

        AddDrink();

        GameObject.Destroy(drop.gameObject);
    }

    public void AddDrink()
    {
        jiggerSprite.material.SetFloat("_Cutoff1", curCapacity / maxCapacity);
    }

    public void SwapDrink(int a,int b)
    {
        float aCap = jiggerSprite.material.GetFloat("_Cutoff" + a.ToString());
        Color aColor = jiggerSprite.material.GetColor("_LayerColor"+a.ToString());
        float bCap = jiggerSprite.material.GetFloat("_Cutoff" + b.ToString());
        Color bColor = jiggerSprite.material.GetColor("_LayerColor" + b.ToString());
        jiggerSprite.material.SetFloat("_Cutoff" + a.ToString(),bCap);
        jiggerSprite.material.SetFloat("_Cutoff" + b.ToString(),aCap);
        jiggerSprite.material.SetColor("_LayerColor" + a.ToString(), bColor);
        jiggerSprite.material.SetColor("_LayerColor" + b.ToString(), aColor);
    }
}
