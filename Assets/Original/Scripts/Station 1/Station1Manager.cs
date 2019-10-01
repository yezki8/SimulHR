using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SceneChanger))]

public class Station1Manager : GameManager 
{
    public GameObject[] questionObjects;
    private GameObject questionObject;
    public Transform questionLocation;

    public Image[] answerAImages;
    public Image[] answerBImages;
    public Image[] answerCImages;
    public Image[] answerDImages;

    public Image answerATarget;
    public Image answerBTarget;
    public Image answerCTarget;
    public Image answerDTarget;

    public GameObject NavButton;      //button untuk pindah ke intro, dibuat gameObject biar bisa di active dan non active

    public char[] correctAnswer;
    public float dueTime;
    public bool isStationComplete = false;
    private int currQuestion = 0;           //0 is instruction
    private float score = 0.0f;
    private float timePassed = 0;

    SceneChanger sceneChanger;
    Station1UI station1UI;

    void Start()
    {
        sceneChanger = GetComponent<SceneChanger>();
        station1UI = GetComponent<Station1UI>();

        NavButton.SetActive(false);           //Hide buttonnya pada saat scene mulai

        // Set tutorial's object, which is questionObjects 15
        //questionObject = Instantiate(questionObjects[currQuestion - 1]);              //15 adalah objek biasa untuk tutorial
        //questionObject.transform.localPosition = questionLocation.localPosition;
        //questionObject.transform.parent = questionLocation;

        // Set answers selection
        //answerATarget.material = answerAImages[currQuestion - 1].material;
        //answerBTarget.material = answerBImages[currQuestion - 1].material;
        //answerCTarget.material = answerCImages[currQuestion - 1].material;
        //answerDTarget.material = answerDImages[currQuestion - 1].material;
    }

    // Fixed Update is called once per fixed time
    void FixedUpdate()
    {
        // Only run the timer IF instruction has completed AND Station has yet to complete
        if (station1UI.isInstructionComplete && !isStationComplete)
        {
            timePassed += Time.deltaTime;
        }
    }

    void Update()
    { 
        // Check if instruction for station 1 has completed yet
        if (station1UI.isInstructionComplete)
        {
            // Check if station 1 is not completed yet
            if (!isStationComplete)
            {
                // Check if all question have been answered OR reaching dueTime
                if (currQuestion > questionObjects.Length || timePassed > dueTime)
                {
                    // EndGame
                    isStationComplete = true;
                    stationEnds();
                }
            }
        }
    }

    public override void ReportNewScore()
    {
        // Buat nyimpen soal di GameManager utama
        ProgressCache.Instance.ReportNewValue(score);
    }

    public void SelectCorrectAnswer()
    {
        //Nambah soal dan skor setelah soal yang sebelumnya sudah dijawab
        score += 100.0f / questionObjects.Length; ;
        currQuestion++;

        // Check array outta bound error
        if (currQuestion <= questionObjects.Length)
        {
            
            // Change question
            Destroy(questionObject);
            questionObject = Instantiate(questionObjects[currQuestion - 1]);
            questionObject.transform.localPosition = questionLocation.localPosition;
            questionObject.transform.parent = questionLocation;

            // Change answers selection
            answerATarget.material = answerAImages[currQuestion - 1].material;
            answerBTarget.material = answerBImages[currQuestion - 1].material;
            answerCTarget.material = answerCImages[currQuestion - 1].material;
            answerDTarget.material = answerDImages[currQuestion - 1].material;
        }
        else
        {
            Destroy(questionObject);
            Destroy(answerATarget);
            Destroy(answerBTarget);
            Destroy(answerCTarget);
            Destroy(answerDTarget);
            
        }
    }

    public void SelectIncorrectAnswer()
    {
        //Nambah soal setelah soal yang sebelumnya sudah dijawab
        score += 0;
        currQuestion++;

        // Check array outta bound error
        if (currQuestion <= questionObjects.Length)
        {
            // Change question
            Destroy(questionObject);
            questionObject = Instantiate(questionObjects[currQuestion - 1]);
            questionObject.transform.localPosition = questionLocation.localPosition;
            questionObject.transform.parent = questionLocation;

            // Change answers selection
            answerATarget.material = answerAImages[currQuestion - 1].material;
            answerBTarget.material = answerBImages[currQuestion - 1].material;
            answerCTarget.material = answerCImages[currQuestion - 1].material;
            answerDTarget.material = answerDImages[currQuestion - 1].material;
        }
        else
        {
            Destroy(questionObject);
            Destroy(answerATarget);
            Destroy(answerBTarget);
            Destroy(answerCTarget);
            Destroy(answerDTarget);
        }
    }

    public int getCurrQuestion()
    {
        return currQuestion;        
    }

    public void stationEnds()
    {
        Debug.Log("Station 1 End. Score: " + score + ". Time left: " + (dueTime - timePassed));

        Destroy(questionObject);
        Destroy(answerATarget.gameObject);
        Destroy(answerBTarget.gameObject);
        Destroy(answerCTarget.gameObject);
        Destroy(answerDTarget.gameObject);

        NavButton.SetActive(true);            //nyalain buttonnya
        station1UI.showScore(score);

        //ReportNewScore();

        //sceneChanger.sceneToIntro();

        // To-do: Bikin kata2 selamatnya
    }
}
