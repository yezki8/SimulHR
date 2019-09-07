using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public virtual void ReportNewScore() {
        // Virtual means abstract. To be implemented by inherition
    }
}
