using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manage : MonoBehaviour
{
    public Text SoalKanan, SoalKiri;
    public string[] KumpulanSoalKanan;
    public string[] KumpulanSoalKiri;
    public char[] correctAnswer;

    public float dueTime;
    public bool isStationComplete = false;
    private int currQuestion = 1;           //0 is instruction
    private float score = 0.0f;
    private float timePassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        SoalKanan.text = (KumpulanSoalKanan[currQuestion - 1]);
        SoalKiri.text = (KumpulanSoalKiri[currQuestion - 1]);
    }

    private void FixedUpdate()
    {
        if (!isStationComplete)
        {
            timePassed += Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if station 3 is not completed yet
        if (!isStationComplete)
        {
            // Check if all question have been answered OR reaching dueTime
            if (currQuestion > KumpulanSoalKanan.Length || timePassed > dueTime || currQuestion > KumpulanSoalKanan.Length)
            {
                // EndGame
                isStationComplete = true;
            }
        }
    }

    public void SelectCorrectAnswer()
    {
        //Nambah soal dan skor setelah soal yang sebelumnya sudah dijawab
        score += 100.0f / KumpulanSoalKanan.Length; ;
        currQuestion++;

        // Check array outta bound error
        if (currQuestion <= KumpulanSoalKanan.Length)
        {
            // Change question
            SoalKanan.text = (KumpulanSoalKanan[currQuestion - 1]);
            SoalKiri.text = (KumpulanSoalKiri[currQuestion - 1]);
        }
        else
        {
            SoalKanan.text = "selesai";
            SoalKiri.text = "selesai";
        }
    }
    public void SelectIncorrectAnswer()
    {
        currQuestion++;

        // Check array outta bound error
        if (currQuestion <= KumpulanSoalKanan.Length)
        {
            // Change question
            SoalKanan.text = (KumpulanSoalKanan[currQuestion - 1]);
            SoalKiri.text = (KumpulanSoalKiri[currQuestion - 1]);
        }
        else
        {
            SoalKanan.text = "selesai";
            SoalKiri.text = "selesai";
        }
    }
    public int getCurrQuestion()
    {
        return currQuestion;
    }
}
