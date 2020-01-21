using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station4UI : MonoBehaviour
{
    public Station4Manager station4Manager;

    public bool isInstructionComplete = false;

    //kumpulan text
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetInstructionComplete()
    {
        isInstructionComplete = true;
    }
}
