using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GenerateReportFile : MonoBehaviour
{
    private string fileName;
    private string date;

    private void Start()
    {
        WriteString();
    }

    public void WriteString()
    {
        // Setting up name
        date = System.DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
        fileName = "Report " + date + ".txt";

        // string path = "Assets/Original/Resources/" +fileName;
        string path = Application.dataPath +"/Original/Resources/" +fileName;

        // Write some text to the "fileName" file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(date);
        writer.WriteLine("\n\nTest Report File ");
        writer.Write("By Anjass");
        writer.Close();

        Debug.Log("File written to: " + path);
    }

    public void ReadString()
    {
        string path = "Assets/Original/Resources/" +fileName;

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path); 
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}
