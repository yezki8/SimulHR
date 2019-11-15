using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PersonaCluster
{
    public GameObject person;
    public string name;
    public int age;
    [TextArea(3,10)]public string description;
    public Transform oriPosition;
}

[System.Serializable]
public class LifeBoat
{
    public GameObject seat;
    public string name = "";
}

public class Station2Manager : GameManager 
{
    [SerializeField] PersonaCluster[] personaClusters;
    [SerializeField] LifeBoat[] lifeBoats;

    public bool isStationComplete = false;
    private int score = 0;

    private float timePassed = 0;
    private float dueTime = 480;

    public SceneChanger sceneChanger;
    public Station2UI station2UI;
    private PersonaCluster tempCluster;
    // Fixed Update is called once per fixed time
    void FixedUpdate()
    {
        // Only run the timer IF instruction has completed AND Station has yet to complete
        if (station2UI.isInstructionComplete && !isStationComplete)
            timePassed += Time.deltaTime;
    }

    void Update()
    { 
        // Check if instruction for station 1 has completed yet
        if (station2UI.isInstructionComplete)
        {
            // Check if station 1 is not completed yet
            if (!isStationComplete)
            {
                // Check if all question have been answered OR reaching dueTime
                if (timePassed > dueTime)
                {
                    // EndGame
                    isStationComplete = true;
                    StationEnds();
                }
            }
        }
    }

    public void SelectPersona(int codePersona)
    {
        tempCluster = personaClusters[codePersona];
        station2UI.namePersona.text = "Nama : " + personaClusters[codePersona].name;
        station2UI.agePersona.text = "Umur : " + personaClusters[codePersona].age;
        station2UI.descPersona.text = "Deskripsi : " + personaClusters[codePersona].description;
    }

    public void SelectLifeBoat(int priority)
    {
        // Priority on editor are set to 1,2,3, or 4
        priority--;

        if (station2UI.namePersona.text.Equals("Nama : "))
        {
            Debug.Log("Click any of the personas first");
        }
        else
        {
            int indexPersona = 0;

            if (! lifeBoats[priority].name.Equals(""))
            {
                // Cari index personanya sabaraha
                for (int i = 0; i < personaClusters.Length; i++)
                    if (lifeBoats[priority].name == personaClusters[i].name)
                        indexPersona = i;

                // Move the persona to the original position
                personaClusters[indexPersona].person.transform.position =
                    personaClusters[indexPersona].oriPosition.position;
            }


            // Retrieve name info
            lifeBoats[priority].name = tempCluster.name;
            //lifeBoats[priority].name = station2UI.namePersona.text;
            //lifeBoats[priority].name = lifeBoats[priority].name.Remove(0, 7);
            Debug.Log("name: " + lifeBoats[priority].name);

            // Cari index personanya sabaraha
            //indexPersona = 0;
            for (int i = 0; i < personaClusters.Length; i++)
                if (lifeBoats[priority].name == personaClusters[i].name)
                    indexPersona = i;

            // Pindahin persona ke lifeboat
            personaClusters[indexPersona].person.transform.position =
                lifeBoats[priority].seat.transform.position;
        }
        
        // Update List
        UpdatePassengerInfo();
    }

    public void UpdatePassengerInfo()
    {
        string buffer = "";
        for (int i = 0; i < lifeBoats.Length; i++)
            buffer += i + 1 +". " +lifeBoats[i].name +"\n";

        station2UI.lifeboatText.text = buffer;
    }

    public override void ReportNewScore()
    {
        // Buat nyimpen soal di GameManager utama
        ProgressCache.Instance.ReportNewValue(score);
    }

    public void StationEnds()
    {
        Debug.Log("Station End. Score: " + score + ". Time left: " + (dueTime - timePassed));

        station2UI.showScore(score);

        //ReportNewScore();

        // To-do: Bikin kata2 selamatnya
    }
}
