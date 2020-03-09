using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuestionCluster
{
    public GameObject questionObject;
    public char correctAnswer;
    public List<Image> choiceList = new List<Image>();
}

public class Station1Manager : GameManager 
{
    [SerializeField] QuestionCluster[] questionList;

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
    private int score = 0;
    private float timePassed = 0;

    public SceneChanger sceneChanger;
    public Station1UI station1UI;

    void Start()
    {
        NavButton.SetActive(false);           //Hide buttonnya pada saat scene mulai
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
        // Buat nyimpen soal di ProgressCache utama
        ProgressCache.Instance.ReportNewValue(score);
    }

    public void SelectCorrectAnswer()
    {
        //Nambah soal dan skor setelah soal yang sebelumnya sudah dijawab
        score += 1;
        currQuestion++;

        // Check array outta bound error
        if (currQuestion <= questionList.Length)
        {
            
            // Change question
            Destroy(questionObject);
            questionObject = Instantiate(questionList[currQuestion - 1].questionObject);
            questionObject.transform.localPosition = questionLocation.localPosition;
            questionObject.transform.parent = questionLocation;

            // Change answers selection
            answerATarget.material = questionList[currQuestion - 1].choiceList[0].material;
            answerBTarget.material = questionList[currQuestion - 1].choiceList[1].material;
            answerCTarget.material = questionList[currQuestion - 1].choiceList[2].material;
            answerDTarget.material = questionList[currQuestion - 1].choiceList[3].material;
        }
        else
        {
            //stationEnds();
            
        }
    }

    public void SelectIncorrectAnswer()
    {
        //Nambah soal setelah soal yang sebelumnya sudah dijawab
        score += 0;
        currQuestion++;

        // Check array outta bound error
        if (currQuestion <= questionList.Length)
        {
            // Change question
            Destroy(questionObject);
            questionObject = Instantiate(questionList[currQuestion - 1].questionObject);
            questionObject.transform.localPosition = questionLocation.localPosition;
            questionObject.transform.parent = questionLocation;

            // Change answers selection
            answerATarget.material = questionList[currQuestion - 1].choiceList[0].material;
            answerBTarget.material = questionList[currQuestion - 1].choiceList[1].material;
            answerCTarget.material = questionList[currQuestion - 1].choiceList[2].material;
            answerDTarget.material = questionList[currQuestion - 1].choiceList[3].material;
        }
        else
        {
            //stationEnds();
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

        ReportNewScore();

        //sceneChanger.sceneToIntro();

        // To-do: Bikin kata2 selamatnya
    }
}
