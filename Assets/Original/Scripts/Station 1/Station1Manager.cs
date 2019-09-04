using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station1Manager : GameManager 
{
    public GameObject[] questionObjects;
    private GameObject questionObject;
    public Transform spawnerLocation;
    private int currQuestion = 1;
    private int score;
    private float timePassed = 0;
    public float dueTime;

    void Start()
    {
        questionObject = Instantiate(questionObjects[currQuestion - 1]);
        questionObject.transform.localPosition = spawnerLocation.localPosition;

        //cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
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

        Destroy(questionObject);
        questionObject = Instantiate(questionObjects[currQuestion - 1]);
        questionObject.transform.localPosition = spawnerLocation.localPosition;

        Debug.Log(score);
    }

    public void SelectIncorrectAnswer()
    {
        currQuestion++;
        Debug.Log("incorrect answer has been clicked");
    }
}
