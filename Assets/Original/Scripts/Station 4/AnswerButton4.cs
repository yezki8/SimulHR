using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;

public class AnswerButton4 : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public string outputOnMax = "Maximum Reached";
    public string outputOnMin = "Minimum Reached";

    public Station4Manager station4Manager;
    public Station4UI station4UI;
    public char answerFor;

    protected virtual void OnEnable()
    {
        controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
        // controllable.ValueChanged += ValueChanged;
        controllable.MaxLimitReached += MaxLimitReached;
    }

    protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
        Answered();
    }

    public void Answered()
    {
        if (!station4UI.isInstructionComplete)
            station4UI.NextIntro();
        else
            station4Manager.EndQuestion();
    }
}
