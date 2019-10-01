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
        Debug.Log("Button is Pressed");
        if (answerFor == station3Manager.correctAnswer[station3Manager.getCurrQuestion() - 1])
        {
            Debug.Log("C o r r e c t !");
            station3Manager.SelectCorrectAnswer();
        }
        else
        {
            Debug.Log("I n c o r r e c t !");
            station3Manager.SelectIncorrectAnswer();
        }
    }
}
