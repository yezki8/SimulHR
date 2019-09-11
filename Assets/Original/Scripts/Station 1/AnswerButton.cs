using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class AnswerButton : MonoBehaviour
{
    public Button yourButton;
    public Station1Manager station1Manager;
    public Station1UI station1UI;
    public char answerFor;

    void Start()
    {
        // Assign onClick tasks on a button
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        // Check if the instruction still on going
        if (!station1UI.isInstructionComplete)
        {
            station1UI.SetInstructionComplete();
            Debug.Log(station1UI.isInstructionComplete);

            // Instruction is completed. Proceed to start the station 1 questions
            station1Manager.SelectIncorrectAnswer();
        }
        else
        {
            // Check if the station still on going
            if (!station1Manager.isStationComplete)
            {
                // check with station 1 manager's array of correct answer
                if (answerFor == station1Manager.correctAnswer[station1Manager.getCurrQuestion() - 1])
                {
                    Debug.Log("C o r r e c t !");
                    station1Manager.SelectCorrectAnswer();
                }
                else
                {
                    Debug.Log("I n c o r r e c t !");
                    station1Manager.SelectIncorrectAnswer();
                }
            }
        }
    }
}
