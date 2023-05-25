using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SceneManagement
using UnityEngine.SceneManagement;

public class movetomain : MonoBehaviour
{
   public void SceneChange()
   {
      SceneManager.LoadScene("mainmenu");
   }
}
