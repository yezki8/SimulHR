using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station4Manager : GameManager 
{
    public float[] dueTime;
    private float timePassed = 0;

    public bool isStationComplete = false;
    public bool isCurrQuestionStarted = false;
    private int currQuestion = 0;

    private bool lateEnd = false;
    public string[] clearanceStatus = new string[3];

    public SceneChanger sceneChanger;
    public Station4UI station4UI;

    void FixedUpdate()
    {
        // run the timer only if the question already started
        if (isCurrQuestionStarted)
        {
            timePassed += Time.deltaTime;
            station4UI.timeText.text = TimePassedString(); 

            // if time runs dead
            if (timePassed >= dueTime[currQuestion])
            {
                lateEnd = true;
                EndQuestion();
            }
        }
    }

    public void StartQuestion()
    {
        isCurrQuestionStarted = true;
    }

    public void EndQuestion()
    {
        // Write report
        if (lateEnd)
            clearanceStatus[currQuestion] = "Late";
        else
            clearanceStatus[currQuestion] = "Time taken " + TimePassedString();

        // Reset status
        lateEnd = false;
        isCurrQuestionStarted = false;
        timePassed = 0;

        // Advance
        if ((currQuestion + 1) < dueTime.Length)
            currQuestion++;
        else 
            StationEnds();
    }

    public string TimePassedString(){
        int sec = (int)timePassed % 60,
            min = (int)timePassed / 60;

        return (min + ":" + sec);
    }

    public override void ReportNewScore()
    {
        // Buat nyimpen soal di ProgressCache utama
        // ProgressCache.Instance.ReportNewValue(score);
    }

    public void StationEnds()
    {
        Debug.Log("Station 4 End. Time left: " );

        ReportNewScore();

        // To-do: Bikin kata2 selamatnya
    }
}
