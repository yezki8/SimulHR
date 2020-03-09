using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station3Manager : GameManager
{

    public Text SoalKanan, SoalKiri;
    public string[] KumpulanSoalKanan;
    public string[] KumpulanSoalKiri;
    public char[] correctAnswer;

    public float dueTime;
    public bool isStationComplete = false;
    public int currQuestion = 0;           //0 is instruction
    public int score;
    private float timePassed = 0;

    public SceneChanger sceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        //SoalKanan.text = (KumpulanSoalKanan[currQuestion - 1]);
        //SoalKiri.text = (KumpulanSoalKiri[currQuestion - 1]);
        score = 0;
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
            if (currQuestion >= KumpulanSoalKanan.Length || timePassed > dueTime || currQuestion >= KumpulanSoalKiri.Length)
            {
                // EndGame
                isStationComplete = true;
            }
        }
    }

    public void SelectCorrectAnswer()
    {
        //Nambah soal dan skor setelah soal yang sebelumnya sudah dijawab
        score += 1 ;
        currQuestion++;

        // Check array outta bound error
        if (currQuestion < KumpulanSoalKanan.Length)
        {
            // Change question
            SoalKanan.text = (KumpulanSoalKanan[currQuestion-1]);
            SoalKiri.text = (KumpulanSoalKiri[currQuestion-1]);
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
        if (currQuestion < KumpulanSoalKanan.Length)
        {
            // Change question
            SoalKanan.text = (KumpulanSoalKanan[currQuestion-1]);
            SoalKiri.text = (KumpulanSoalKiri[currQuestion-1]);
        }
        else
        {
            isStationComplete = true;
        }
    }
    public int getCurrQuestion()
    {
        return currQuestion;
    }

    public override void ReportNewScore()
    {
        // Buat nyimpen soal di GameManager utama
        ProgressCache.Instance.ReportNewValue(score);
    }

    public void Station3End()
    {
        Debug.Log("Station 3 End. Score: " + score);

        ReportNewScore();

        sceneChanger.sceneTo("Station 4");
    }
}
