using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressCache : MonoBehaviour
{
    public static ProgressCache mainCache;
    public float[] resultValue;
    public int currentStation;

    public void ReportNewValue(float value)
    {

    }

    private void SingletonManager()
    {
        // Did not understand ^^
    }

    public void SaveData()
    {
        // Save values of tests into an external data
    }
}
