using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public char[] correctAnswer;

    public Text txtAngkaSoal;
    private int currQuestion = 1;
    private int score;
    private float timePassed = 0;
    public float dueTime;

    public bool isStationComplete = false;

    void Start()
    {
        questionObject = Instantiate(questionObjects[currQuestion - 1]);
        questionObject.transform.localPosition = questionLocation.localPosition;

        answerATarget.material = answerAImages[currQuestion - 1].material;
        answerBTarget.material = answerBImages[currQuestion - 1].material;
        answerCTarget.material = answerCImages[currQuestion - 1].material;
        answerDTarget.material = answerDImages[currQuestion - 1].material;

        txtAngkaSoal.text = currQuestion.ToString("F0");
    }

    // Fixed Update is called once per fixed time
    void FixedUpdate()
    {
        if (! isStationComplete)
            timePassed += Time.deltaTime;
    }

    // Regular Update
    void Update()
    {
        // Check if station 1 is not completed yet
        if (! isStationComplete)
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

    public override void ReportNewScore()
    {
        // Placeholder: Buat nyimpen soal di GameManager utama
    }

    public void SelectCorrectAnswer()
    {
        //Nambah soal setelah soal yang sebelumnya sudah dijawab
        score += 100 / questionObjects.Length;
        currQuestion++;

        // Check array outta bound error
        if (currQuestion <= questionObjects.Length)
        {
            // Change question
            Destroy(questionObject);
            questionObject = Instantiate(questionObjects[currQuestion - 1]);
            questionObject.transform.localPosition = questionLocation.localPosition;

            // Change answer's selection
            answerATarget.material = answerAImages[currQuestion - 1].material;
            answerBTarget.material = answerBImages[currQuestion - 1].material;
            answerCTarget.material = answerCImages[currQuestion - 1].material;
            answerDTarget.material = answerDImages[currQuestion - 1].material;

            // Update indikator soal
            txtAngkaSoal.text = currQuestion.ToString("F0");
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

            // Change answer's selection
            answerATarget.material = answerAImages[currQuestion - 1].material;
            answerBTarget.material = answerBImages[currQuestion - 1].material;
            answerCTarget.material = answerCImages[currQuestion - 1].material;
            answerDTarget.material = answerDImages[currQuestion - 1].material;

            // Update indikator soal
            txtAngkaSoal.text = currQuestion.ToString("F0");
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

        // To-do: Bikin kata2 selamatnya
    }
}
