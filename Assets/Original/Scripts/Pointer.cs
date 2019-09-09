using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Pointer : MonoBehaviour
{
    public static GameObject currentObject;
    int currentID;

    //Referensi fungsi tombol
    public SteamVR_Action_Boolean AnswerButton;

    //Referensi tangan
    public SteamVR_Input_Sources handType;

    //Referensi tombol
    public Button pilihan;

    // Start is called before the first frame update
    void Start()
    {
        currentObject = null;
        currentID = 0;

        //FUngsi Trigger
        AnswerButton.AddOnStateDownListener(TriggerDown, handType);
        AnswerButton.AddOnStateUpListener(TriggerUp, handType);
    }

    private void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is up)");
    }

    private void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is down");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            int id = hit.collider.gameObject.GetInstanceID();

            if (currentID != id)
            {
                currentID = id;
                currentObject = hit.collider.gameObject;

                string name = currentObject.tag;
                if (name == "AnswerButton")
                {
                    Debug.Log("Button terdeteksi");

                }
            }
        }        
    }
}
