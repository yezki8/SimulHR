using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station2UI : MonoBehaviour
{
    public Station2Manager station2Manager;

    public bool isInstructionComplete = false;

    //kumpulan text
    public Text namePersona,
        agePersona,
        descPersona,
        lifeboatText;

    int TutorialText = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInstructionComplete)
        {
            
        }

        if (station2Manager.isStationComplete)
        {
            
        }
    }

    public void SetInstructionComplete()
    {
        
    }

    public void showScore(float score)
    {
        
        //txtKeteranganCara.text = ("Score anda ") + score;
        
        Debug.Log("score at text: " + score.ToString());
    }
}
