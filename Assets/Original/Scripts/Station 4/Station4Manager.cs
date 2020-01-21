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

    public SceneChanger sceneChanger;
    public Station4UI station4UI;

    void Start()
    {
        
    }

    // Fixed Update is called once per fixed time
    void FixedUpdate()
    {
        // run the timer
        if (isCurrQuestionStarted)
        {
            timePassed += Time.deltaTime;
        }
        else if (timePassed >= dueTime[currQuestion])
        {
            endQuestion();
        }

    }

    public void startQuestion()
    {
        isCurrQuestionStarted = true;
    }

    public void endQuestion()
    {
        isCurrQuestionStarted = false;
        timePassed = 0;
        if ((currQuestion + 1) < dueTime.Length)
        {
            currQuestion++;
        }
    }

    public override void ReportNewScore()
    {
        // Buat nyimpen soal di GameManager utama
        // ProgressCache.Instance.ReportNewValue(score);
    }

    public void stationEnds()
    {
        Debug.Log("Station 4 End. Time left: " );

        //ReportNewScore();

        //sceneChanger.sceneToIntro();

        // To-do: Bikin kata2 selamatnya
    }
}
