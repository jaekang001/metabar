using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{   
    void start()
    {

    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
