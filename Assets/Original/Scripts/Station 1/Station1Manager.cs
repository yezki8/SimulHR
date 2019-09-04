﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station1Manager : GameManager 
{
    public GameObject[] questionObjects;
    private GameObject questionObject;
    public Transform questionLocation;

    public Image[] answerAImages;
    public Image answerATarget;

    public char[] correctAnswer;

    private int currQuestion = 1;
    private int score;
    private float timePassed = 0;
    public float dueTime;

    void Start()
    {
        questionObject = Instantiate(questionObjects[currQuestion - 1]);
        questionObject.transform.localPosition = questionLocation.localPosition;
        //cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));

        answerATarget.material = answerAImages[currQuestion - 1].material;
    }

    // Fixed Update is called once per fixed time
    void FixedUpdate()
    {
        //m_timeText.text = (int)(timePassed / 60) + ":" + (int)(timePassed % 60);
        timePassed += Time.deltaTime;
    }

    // Update regular
    void Update()
    {
        if (currQuestion > questionObjects.Length || timePassed > dueTime)
        {
            // Selesai gamenya
            Debug.Log("Station 1 End");
        }
    }

    public override void ReportNewScore()
    {

    }

    public void SelectCorrectAnswer()
    {
        score += 100 / questionObjects.Length;
        currQuestion++;

        // Change question
        Destroy(questionObject);
        questionObject = Instantiate(questionObjects[currQuestion - 1]);
        questionObject.transform.localPosition = questionLocation.localPosition;

        // Change answer's selection
        answerATarget.material = answerAImages[currQuestion - 1].material;

        Debug.Log(score);
    }

    public void SelectIncorrectAnswer()
    {
        score += 0;
        currQuestion++;

        // Change question
        Destroy(questionObject);
        questionObject = Instantiate(questionObjects[currQuestion - 1]);
        questionObject.transform.localPosition = questionLocation.localPosition;

        // Change answer's selection
        answerATarget.material = answerAImages[currQuestion - 1].material;

        Debug.Log(score);
    }

    public int getCurrQuestion()
    {
        return currQuestion;
    }
}
