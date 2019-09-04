using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station1Manager : GameManager 
{
    public GameObject[] questionObjects;
    private GameObject questionObject;
    public Transform spawnerLocation;

    public Image[] answerAImages;
    public Image[] answerBImages;
    public Image[] answerCImages;
    public Image[] answerDImages;

    public Image answerATarget;
    public Image answerBTarget;
    public Image answerCTarget;
    public Image answerDTarget;

    public int currQuestion = 1;
    public Text txtAngkaSoal;
    private int score;
    private float timePassed = 0;
    public float dueTime;

    void Start()
    {
        questionObject = Instantiate(questionObjects[currQuestion - 1]);
        questionObject.transform.localPosition = spawnerLocation.localPosition;
        txtAngkaSoal.text = currQuestion.ToString("F0");

        //cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));

        answerATarget.material = answerAImages[currQuestion - 1].material;
        answerBTarget.material = answerBImages[currQuestion - 1].material;
        answerCTarget.material = answerCImages[currQuestion - 1].material;
        answerDTarget.material = answerDImages[currQuestion - 1].material;
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
        //if (currQuestion > questionObjects.Length || timePassed > dueTime)
        //{
        //    // Selesai gamenya
        //    Debug.Log("Station 1 End");
        //}
    }

    public override void ReportNewScore()
    {

    }

    public void SelectCorrectAnswer()
    {
        //Nambah soal setelah soal yang sebelumnya sudah dijawab
        score += 100 / questionObjects.Length;
        currQuestion++;

        txtAngkaSoal.text = currQuestion.ToString("F0");

        // Change question
        Destroy(questionObject);
        questionObject = Instantiate(questionObjects[currQuestion - 1]);
        questionObject.transform.localPosition = spawnerLocation.localPosition;

        // Change answer's selection
        answerATarget.material = answerAImages[currQuestion - 1].material;
        answerBTarget.material = answerBImages[currQuestion - 1].material;
        answerCTarget.material = answerCImages[currQuestion - 1].material;
        answerDTarget.material = answerDImages[currQuestion - 1].material;

        Debug.Log(score);
    }

    public void SelectIncorrectAnswer()
    {
        currQuestion++;
        Debug.Log("incorrect answer has been clicked");

        txtAngkaSoal.text = currQuestion.ToString("F0");
    }
}
