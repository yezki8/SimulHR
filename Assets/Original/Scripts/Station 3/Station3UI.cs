using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station3UI : MonoBehaviour
{
    public Station3Manager station3Manager;
    
    public GameObject ButtonYes;
    public GameObject ButtonNo;
    int score;

    public bool isInstructionComplete = false;

    //kumpulan text
    public Text txtKeteranganCara;
    public Text txtSoalKiri;
    public Text txtSoalKanan;
    public Text txtNomor;

    public GameObject NextButton;
    public GameObject NextStationButton;

    int TutorialText = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Display Instruction Text
        txtSoalKanan.text = ("");
        txtSoalKiri.text = ("");

        // Instatiate Instruction obj

        // Hide answer's selection
        ButtonYes.SetActive(false);
        ButtonNo.SetActive(false);
        txtNomor.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        if (isInstructionComplete)
        {
            txtKeteranganCara.text = ("");
        }

        if (station3Manager.isStationComplete)
        {
            txtKeteranganCara.text = ("Station 3 telah selesai");
            score = station3Manager.score;
            txtSoalKanan.text = ("Anda benar ") + score;
            txtSoalKiri.text = ("Dari 30 soal");
            Destroy(ButtonYes.gameObject);
            Destroy(ButtonNo.gameObject);
            NextStationButton.SetActive(true);
            txtNomor.text = "";
        }
        else
        {
            if (TutorialText == 1)
            {
                txtKeteranganCara.text = ("Selamat datang pada scene 3");
                NextStationButton.SetActive(false);
            }
            else if (TutorialText == 2)
            {
                txtKeteranganCara.text = ("Pada saat ini, ada akan diberikan 2 text didepan anda");
            }
            else if (TutorialText == 3)
            {
                txtKeteranganCara.text = ("Lihat dengan teliti kedua text tersebut. Apakah sama atau tidak");
                txtSoalKanan.text = ("Text Kanan");
                txtSoalKiri.text = ("Text Kiri");
            }
            else if (TutorialText == 4)
            {
                txtKeteranganCara.text = ("Tentukan bila text itu sama atau tidak dengan kedua tombol di meja");
            }
            else if (TutorialText == 5)
            {
                txtKeteranganCara.text = ("Tekan salah satu tombol untuk memulai station ini");

            }
            else if (TutorialText == 6)
            {
                txtKeteranganCara.text = ("");
                ButtonYes.SetActive(true);
                ButtonNo.SetActive(true);
                Destroy(NextButton.gameObject);
                txtNomor.text = ("Soal ") + station3Manager.getCurrQuestion();
            }


        }
    }

    public void SetInstructionComplete()
    {
        isInstructionComplete = true;
        Destroy(NextButton.gameObject);
    }

    public void tambahCounter()
    {
        TutorialText++;
    }
}
