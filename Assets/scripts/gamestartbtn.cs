using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SceneManagement
using UnityEngine.SceneManagement;

public class gamestartbtn : MonoBehaviour
{
   public void StartButton(){
    SceneManager.LoadScene("selectmode");
   }
}
