using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float[] resultScore;
    private int stationCleared = 0;

    public virtual void ReportNewScore() {
        Debug.Log("Report new score from Game Manager");
    }

    public void AddNewScore(float score)
    {
        resultScore[stationCleared] = score;
        stationCleared++;
    }
}
