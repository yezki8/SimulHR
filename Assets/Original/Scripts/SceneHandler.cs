using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class SceneHandler : MonoBehaviour
{

    public SteamVR_LaserPointer laserPointer;
    public Button answerButton;

    // Start is called before the first frame update

    private void Awake()
    {
        //deklarasikan apa yang terjadi terhadap status poointer
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;

    }

    private void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "AnswerButton")
        {
            Debug.Log("Button was undetected");
        }
        
    }

    private void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "AnswerButton")
        {
            Debug.Log("Button was detected");
        }
    }

    //Void bila pointer masuk atau kena button
    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "AnswerButton")
        {
            Debug.Log("Button was clicked"); 
        }
        
    }
}
