using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ProgressCache : MonoBehaviour
{
    public static ProgressCache Instance { get; private set; }

    public float[] resultValue;
    public int currentStation = 1;

    private string fileName, 
        date;

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

        if (currentStation > resultValue.Length)
            SaveData();
    }    

    public void ResetGame()
    {
        // Reset score value and station progress
        currentStation = 1;
        for (int i = 0; i < resultValue.Length; i++)
            resultValue[i] = 0;
    }

    public void SaveData()
    {
        // Save values of tests into an external data

        // Setting up name
        date = System.DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
        fileName = "Report " + date + ".txt";

        // string path = "Assets/Original/Resources/" +fileName;
        string path = Application.dataPath + "/Original/Resources/" + fileName;

        // Write some text to the "fileName" file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(date);
        writer.WriteLine("VR-PAT Report File");
        for (int i = 0; i < resultValue.Length; i++)
            writer.WriteLine("Station " + (i + 1) + " : " +resultValue[i]);

        writer.WriteLine("\nTrait");
        // TO-DO: wait for pa Aul gives the conclusion of these test.

        writer.Close();

        Debug.Log("File written to: " + path);
    }
}
