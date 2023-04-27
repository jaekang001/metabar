using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProtoSceneCtrl : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int number)
    {
        SceneManager.LoadScene(number);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
