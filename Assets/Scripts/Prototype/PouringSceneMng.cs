using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TechniqueType
{
    Build,
    Float,
}

public enum VesselType
{
    Cocktail,
    Pilsner,
    OldFashioned,
    ChampagneSaucer,
    ChampagneFlute,
    Collins,
    Highball,
    Sour,
    WhiteWine,
    SherryWine,
    Liqueur,
    MixingGlass,
    Jigger
}

public class PouringSceneMng : MonoBehaviour
{
    [SerializeField]
    private TechnicType technicType = TechnicType.Float;
    [SerializeField]
    private VesselType vesselType = VesselType.OldFashioned;

    [SerializeField]
    private Transform vesselPoint;
    [SerializeField]
    private Transform pourerPoint;

    [SerializeField]
    private GameObject pourerObject;
    [SerializeField]
    private GameObject veselObject;

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 500, 20), "This is some debug text");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
