using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick_MainMenu : MonoBehaviour
{
    public GameObject WritingTestBtu;
    public GameObject PracticalTestBtu;
    public GameObject Title;
    // Start is called before the first frame update
    void Start()
    {
        Title.SetActive(true);
        WritingTestBtu.SetActive(true);
        PracticalTestBtu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
