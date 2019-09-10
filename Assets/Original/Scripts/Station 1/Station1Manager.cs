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

    public char[] correctAnswer;
    public float dueTime;
    public bool isStationComplete = false;
    private int currQuestion = 0;           //0 adalah permulaan
    private float score = 0.0f;
    private float timePassed = 0;

    //umpulan text
    public Text txtAngkaSoal;
    public Text txtKeteranganJawaban;
    public Text txtKeteranganSoal;
    public Text txtKeteranganCara;
    public Text txtSoal;
    SceneChanger sceneChanger;

    void Start()
    {
        sceneChanger = GetComponent<SceneChanger>();

        // Set tutorial's object, which is questionObjects 15
        questionObject = Instantiate(questionObjects[15]);              //15 adalah objek biasa untuk tutorial
        questionObject.transform.localPosition = questionLocation.localPosition;
        questionObject.transform.parent = questionLocation;

        // Set answers selection
        //answerATarget.material = answerAImages[currQuestion - 1].material;
        //answerBTarget.material = answerBImages[currQuestion - 1].material;
        //answerCTarget.material = answerCImages[currQuestion - 1].material;
        //answerDTarget.material = answerDImages[currQuestion - 1].material;

        // Display Tutorial Text
        txtAngkaSoal.text = ("Tutorial");           //nomor soal kosong pas mulai
        txtKeteranganJawaban.text = ("Pilih jawaban menggunakan Laser Pointer dari tangan kanan anda untuk memulai.");
        txtKeteranganSoal.text = ("Tekan tombol trigger tangan kanan anda untuk memegang objek soal");
        txtKeteranganCara.text = ("Pilihlah jawaban sesuai dengan objek yang tertera didepan anda");
    }

    // Fixed Update is called once per fixed time
    void FixedUpdate()
    {
        if (!isStationComplete && currQuestion > 0)     //waktu dibuat maju setelah question 1 mulai
            timePassed += Time.deltaTime;
    }

    // Update regular
    void Update()
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
        if (currQuestion <= 15)  //questionObjects.Length
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

            // Update indikator soal
            txtAngkaSoal.text = currQuestion.ToString("F0");
            txtKeteranganJawaban.text = ("");
            txtKeteranganSoal.text = ("");
            txtKeteranganCara.text = ("");
        }
        else
        {
            Destroy(questionObject);
            Destroy(answerATarget);
            Destroy(answerBTarget);
            Destroy(answerCTarget);
            Destroy(answerDTarget);
            txtAngkaSoal.text = ("");
            txtKeteranganJawaban.text = ("Selamat, anda telah menyelesaikan scene 1. ");
            txtKeteranganCara.text = ("Score tidak akan ditampilkan, melainkan disimpan didalam sistem");
            txtAngkaSoal.text = ("");
            txtSoal.text = ("");
            txtKeteranganSoal.text = ("Scene selanjutnya sedang dalam proses development, terima kasih telah mencoba scene ini :)");
        }
    }

    public void SelectIncorrectAnswer()
    {
        //Nambah soal setelah soal yang sebelumnya sudah dijawab
        score += 0;
        currQuestion++;

        // Check array outta bound error
        if (currQuestion <= 15)
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

            // Update indikator soal
            txtAngkaSoal.text = currQuestion.ToString("F0");
            txtKeteranganJawaban.text = ("");
            txtKeteranganSoal.text = ("");
            txtKeteranganCara.text = ("");
        }
        else
        {
            Destroy(questionObject);
            Destroy(answerATarget);
            Destroy(answerBTarget);
            Destroy(answerCTarget);
            Destroy(answerDTarget);
            txtKeteranganJawaban.text = ("Selamat, anda telah menyelesaikan scene 1. ");
            txtKeteranganCara.text = ("Score tidak akan ditampilkan, melainkan disimpan didalam sistem");
            txtAngkaSoal.text = ("");
            txtSoal.text = ("");
            txtKeteranganSoal.text = ("Scene selanjutnya sedang dalam proses development, terima kasih telah mencoba scene ini :)");
        }
    }

    public int getCurrQuestion()
    {
        if (currQuestion == 0)
        {
            return 15;
        }
        else
        {
            return currQuestion;
        }
        
    }

    public void stationEnds()
    {
        Debug.Log("Station 1 End. Score: " + score + ". Time left: " + (dueTime - timePassed));

        Destroy(questionObject);
        Destroy(answerATarget.gameObject);
        Destroy(answerBTarget.gameObject);
        Destroy(answerCTarget.gameObject);
        Destroy(answerDTarget.gameObject);

        ReportNewScore();

        sceneChanger.sceneToIntro();

        // To-do: Bikin kata2 selamatnya
    }
}
