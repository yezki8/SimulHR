using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station4UI : MonoBehaviour
{
    public Station4Manager station4Manager;

    public bool isInstructionComplete = false;

    [TextArea(3, 10)] public string[] introductionTextList;
    int n = 0;

    //kumpulan text
    public Text questionText,
        timeText;

    private void Start()
    {
        timeText.text = introductionTextList[n];
    }

    public void ShowQuestion()
    {
        questionText.text = station4Manager.questionList[station4Manager.currQuestion];
    }    

    public void InterQuestion()
    {
        questionText.text = "Okay";
        timeText.text = "Tekan tombol untuk lanjut.";
    }

    public void NextIntro()
    {
        if (n + 1 < introductionTextList.Length)
        {
            n++;
            timeText.text = introductionTextList[n];
        }
        else
        {
            isInstructionComplete = true;
            station4Manager.StartQuestion();
        }
    }
}
