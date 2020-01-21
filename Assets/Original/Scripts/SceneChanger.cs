using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    // This script is inteded to  t e l e p o r t  the player across scenes
    public void sceneToIntro()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void sceneTo(string sceneName)
    {
        try
        {
            SceneManager.LoadScene(sceneName);
        }
        catch
        {
            Debug.LogError("Error when changing scene using func sceneTo()");
        }
    }

    public void sceneExit()
    {
        Application.Quit();
    }
}
