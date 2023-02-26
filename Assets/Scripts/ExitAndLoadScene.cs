using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitAndLoadScene : MonoBehaviour
{
    public void LoadScene(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }
   
    public void Exit()
    {
        Application.Quit();
    }
}
