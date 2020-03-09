using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;

public class AnswerButton4 : MonoBehaviour
{
    public VRTK_BaseControllable controllable;

    public Station4Manager station4Manager;
    public Station4UI station4UI;

    protected virtual void OnEnable()
    {
        controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
        // controllable.ValueChanged += ValueChanged;
        controllable.MaxLimitReached += MaxLimitReached;
    }

    protected virtual void OnDisable()
    {
        controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
        // controllable.ValueChanged += ValueChanged;
        controllable.MaxLimitReached -= MaxLimitReached;
    }

    protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
        if (!station4UI.isInstructionComplete)
            station4UI.NextIntro();
        else if (station4Manager.isCurrQuestionStarted)
            station4Manager.EndQuestion();
        else
            station4Manager.StartQuestion();
    }
}
