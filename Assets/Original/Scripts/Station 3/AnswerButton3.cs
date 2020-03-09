using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;

public class AnswerButton3 : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public string outputOnMax = "Maximum Reached";
    public string outputOnMin = "Minimum Reached";

    public Station3Manager station3Manager;
    public Station3UI station3UI;
    public char answerFor;

    protected virtual void OnEnable()
    {
        controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
        // controllable.ValueChanged += ValueChanged;
        controllable.MaxLimitReached += MaxLimitReached;
        controllable.MinLimitReached += MinLimitReached;
    }

    protected virtual void OnDisable()
    {
        controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
        // controllable.ValueChanged += ValueChanged;
        controllable.MaxLimitReached -= MaxLimitReached;
        controllable.MinLimitReached -= MinLimitReached;
    }

    protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMax != "")
        {
            Debug.Log(outputOnMax);
        }
        Answered();
    }

    protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMin != "")
        {
            Debug.Log(outputOnMin);
        }
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
            if (station3Manager.getCurrQuestion() < station3Manager.correctAnswer.Length)
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
