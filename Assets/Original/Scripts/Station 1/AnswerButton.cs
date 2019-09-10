using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class AnswerButton : MonoBehaviour
{
    public Button yourButton;
    public Station1Manager station1Manager;
    public char answerFor;

    void Start()
    {
        // Assign onClick tasks on a button
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        

    }

    void TaskOnClick()
    {
        // Check if the station still on going
        if (!station1Manager.isStationComplete)
        {
           // check with station 1 manager's array of correct answer
           if (answerFor == station1Manager.correctAnswer[station1Manager.getCurrQuestion() - 1]) // -1 dihilangkan
           {
               Debug.Log("C o r r e c t!");
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
