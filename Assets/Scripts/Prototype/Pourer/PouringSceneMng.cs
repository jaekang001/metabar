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
    //Cocktail,
    //Pilsner,
    OldFashioned,
    //ChampagneSaucer,
    //ChampagneFlute,
    //Collins,
    //Highball,
    //Sour,
    //WhiteWine,
    SherryWine,
    Liqueur,
    //MixingGlass,
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
    private GameObject vesselObject;

    [SerializeField]
    private GameObject[] vesselPrefabs;

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 500, 20), "This is some debug text");
    }

    void Load()
    {
        int loadVessel = PlayerPrefs.GetInt("VesselName");
        vesselObject = Instantiate(vesselPrefabs[loadVessel], vesselPoint);
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
}
