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
    public int currQuestion = 0;
    [TextArea(3, 10)] public string[] questionList;

    public Animator ceo;

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
        ceo.SetBool("mendengarkan", false);
        ceo.SetBool("bicara", true);

        station4UI.ShowQuestion();

        // Wait for 5 seconds to stop "bicara", then shift animation to listening
        StartCoroutine(ListeningAnimation());
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

    IEnumerator ListeningAnimation()
    {
        yield return new WaitForSeconds(5);

        // Ceo stops talking
        ceo.SetBool("bicara", false);
        // Starts listening
        ceo.SetBool("mendengarkan", true);

        if (currQuestion == 2)
        {
            // Di pertanyaan 3: Ceo nya heran sama jawabannya
            yield return new WaitForSeconds(5);
            ceo.SetBool("mendengarkan", false);
            ceo.SetBool("heran", true);
        }
        else if (currQuestion == 1)
        {
            // Di pertanyaan 2: ceo nya lirik2 ke luar
            yield return new WaitForSeconds(5);
            ceo.SetBool("mendengarkan", false);
            ceo.SetBool("lirik", true);

            yield return new WaitForSeconds(5);
            ceo.SetBool("lirik", false);
            ceo.SetBool("mendengarkan", true);
        }
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

        // ReportNewScore();

        sceneChanger.sceneToIntro();

        // To-do: Bikin kata2 selamatnya
    }
}
