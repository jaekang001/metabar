using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefClear : MonoBehaviour
{
    public static PrefClear Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

}
