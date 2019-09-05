using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    // This script is inteded to  t e l e p o r t  the player
    public void sceneToStation1()
    {
        SceneManager.LoadScene("Lv 1");
    }

    public void sceneToIntro()
    {
        SceneManager.LoadScene("Introduction");
    }
}
