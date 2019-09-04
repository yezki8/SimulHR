using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Button yourButton;
    public Station1Manager station1Manager;
    public char answerFor;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (answerFor == station1Manager.correctAnswer[station1Manager.getCurrQuestion() - 1])
        {
            station1Manager.SelectCorrectAnswer();
            Debug.Log("Correct!");
        }
        else
        {
            station1Manager.SelectIncorrectAnswer();
            Debug.Log("You have clicked the button programmatically!");
        }
    }
}
