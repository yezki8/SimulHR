using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressCache : MonoBehaviour
{
    public static ProgressCache Instance { get; private set; }

    public float[] resultValue;
    public int currentStation = 1;

    private void Awake()
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

    public void ReportNewValue(float scoreValue)
    {
        resultValue[currentStation - 1] = scoreValue;
        currentStation++;
        Debug.Log(currentStation);
    }    

    public void SaveData()
    {
        // Save values of tests into an external data
    }
}
