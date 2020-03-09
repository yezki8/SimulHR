using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station1UI : MonoBehaviour
{
    public Station1Manager station1Manager;

    public GameObject[] instructionObjects;    // Make it 1 (size)
    private GameObject instructionObject;
    public Transform instructionObjLoc;
    public GameObject answerSelectionLocation;

    public bool isInstructionComplete = false;

    //kumpulan text
    public Text txtAngkaSoal;
    public Text txtKeteranganJawaban;
    public Text txtKeteranganSoal;
    public Text txtKeteranganCara;
    public Text txtSoal;
    public GameObject NextButton;

    int TutorialText = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Display Instruction Text
        txtAngkaSoal.text = ("");           //nomor soal kosong pas mulai
        txtKeteranganJawaban.text = ("Selamat datang pada scene 1");
        txtKeteranganSoal.text = ("");
        txtKeteranganCara.text = ("");
        txtSoal.text = ("");

        // Instatiate Instruction obj
        instructionObject = Instantiate(instructionObjects[0]);
        instructionObject.transform.localPosition = instructionObjLoc.localPosition;
        instructionObject.transform.parent = instructionObjLoc;

        // Hide answer's selection
        answerSelectionLocation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(TutorialText == 1)
        {
            txtKeteranganJawaban.text = ("Selamat datang pada scene 1");
        }else if(TutorialText == 2)
        {
            txtKeteranganJawaban.text = ("Pada saat ini, ada akan diberikan 4 pilihan jawaban dan 1 soal objek");
        }else if (TutorialText == 3)
        {
            txtKeteranganJawaban.text = ("Anda diminta untuk memilih jawaban yang sesuai dengan objek yang ada");
        }else if (TutorialText == 4)
        {
            txtKeteranganJawaban.text = ("Arahkan tangan kanan dan tekan tombol trigger untuk memegang dan memutar objek soal");
        }else if (TutorialText == 5)
        {
            txtKeteranganJawaban.text = ("Pilih salah satu jawaban dengan mengarahkan laser pointer ungu ke pilihan jawaban, lalu tekan tombol trigger");
        }else if (TutorialText == 6)
        {
            txtKeteranganJawaban.text = ("Pilih salah satu jawaban untuk memulai kuis ini");
            answerSelectionLocation.SetActive(true);
            Destroy(NextButton.gameObject);
        }


        if (isInstructionComplete)
        {
            txtAngkaSoal.text = station1Manager.getCurrQuestion().ToString();
            txtKeteranganJawaban.text = ("");
            txtSoal.text = ("Soal");
            Destroy(NextButton.gameObject);
        }

        if (station1Manager.isStationComplete)
        {
            txtAngkaSoal.text = ("");
            txtSoal.text = ("");
        }
    }

    public void SetInstructionComplete()
    {
        isInstructionComplete = true;
        Destroy(instructionObject);

        // Set text
        txtAngkaSoal.text = ("");           //nomor soal kosong pas mulai
        txtKeteranganJawaban.text = ("");
        txtKeteranganSoal.text = ("");
        txtKeteranganCara.text = ("");
    }

    public void tambahCounter()
    {
        TutorialText++;
    }

    public void showScore(float score)
    {
        
        txtKeteranganCara.text = ("Anda benar ") + score + (" dari 15 soal");
        
        Debug.Log("score at text: " + score.ToString());
    }
}
