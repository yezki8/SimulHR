using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton3 : MonoBehaviour
{
    public Manage station3Manager;
    public Station3UI station3UI;
    public char answerFor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Answered()
    {
        //Jika totorial blom selesai, maka kehitungnya incorrect
        if (!station3UI.isInstructionComplete)
        {
            station3UI.SetInstructionComplete();
            Debug.Log(station3UI.isInstructionComplete);

            // Instruction is completed. Proceed to start the station 1 questions
            station3Manager.SelectIncorrectAnswer();
        }
        else
        {
            if (answerFor == station3Manager.correctAnswer[station3Manager.getCurrQuestion() - 1])
            {
                Debug.Log("C o r r e c t !");
                station3Manager.SelectCorrectAnswer();
            }
            else
            {
                Debug.Log("answerFor: " + answerFor + ", correctAnswer: " + station3Manager.correctAnswer[station3Manager.getCurrQuestion() - 1]);
                Debug.Log("I n c o r r e c t !");
                station3Manager.SelectIncorrectAnswer();
            }
        }
        
    }
}
