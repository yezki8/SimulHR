using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station4UI : MonoBehaviour
{
    public Station4Manager station4Manager;

    public bool isInstructionComplete = false;

    //kumpulan text
    public Text questionText,
        timeText;

    public void ShowQuestion()
    {
        questionText.text = station4Manager.questionList[station4Manager.currQuestion];
    }    

    public void SetInstructionComplete()
    {
        isInstructionComplete = true;
    }
}
