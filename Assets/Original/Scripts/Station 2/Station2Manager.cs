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
    [TextArea(3, 10)] public string description;
    public Transform oriPosition;
    public Transform camPostition;
    public int seatedAt;
    public Animator animasi;
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

    public int[] personaSavedIndex;
    public Transform faceCamera;

    public bool isStationComplete = false;
    private float score = 0;

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

        UpdateFaceCamera();
    }

    public void SelectLifeBoat(int priority)
    {
        // Priority on editor are set to 1,2,3, or 4
        priority--;

        // HARUS udah ada persona yg dipilih. Baru bisa milih LifeBoat seat
        if (station2UI.namePersona.text.Equals("Nama : "))
        {
            Debug.Log("Click any of the personas first");
        }
        else
        {
            int indexPersona = 0;

            /* Cases: If clicking to a seat but the seat's already taken by another persona. 
             * Solution: Move the persona on the seat to original position,
             *      then move currently selected personas to selected LifeBoat seat. 
            */
            if (! lifeBoats[priority].name.Equals(""))
            {
                // Cari index personanya sabaraha
                for (int i = 0; i < personaClusters.Length; i++)
                    if (lifeBoats[priority].name == personaClusters[i].name)
                        indexPersona = i;

                // Move the persona to the original position
                personaClusters[indexPersona].person.transform.position =
                    personaClusters[indexPersona].oriPosition.position;
                personaClusters[indexPersona].person.transform.rotation =
                    personaClusters[indexPersona].oriPosition.rotation;
                personaClusters[indexPersona].animasi.SetInteger("Kondisi", 0);

                // The persona are not seated anymore
                personaClusters[indexPersona].seatedAt = 0;
            }


            // Cari index personanya sabaraha
            for (int i = 0; i < personaClusters.Length; i++)
                if (tempCluster.name == personaClusters[i].name)
                    indexPersona = i;

            /* Case: Persona already seated, and currently selected. But clicked to another seat
             * Solution: remove name from lifeBoats.name and seatedAt from personaClusters.seatedAt
            */
            if (personaClusters[indexPersona].seatedAt != 0)
            {
                lifeBoats[personaClusters[indexPersona].seatedAt].name = "";
                personaClusters[indexPersona].seatedAt = 0;
            }

            /* Standard function protocol
             */ 
            // Retrieve name info
            lifeBoats[priority].name = tempCluster.name;
            Debug.Log("name: " + lifeBoats[priority].name);

            // Pindahin persona ke lifeboat
            personaClusters[indexPersona].person.transform.position =
                lifeBoats[priority].seat.transform.position;
            personaClusters[indexPersona].person.transform.rotation =
                lifeBoats[priority].seat.transform.localRotation;

            // Now the persona are seated and update the camera
            personaClusters[indexPersona].seatedAt = priority++;
            UpdateFaceCamera();

            // Time to stop the wavy-wavy-please-notice-me animation
            // TO-DO: Switch the animator to idle-seating pose.
            personaClusters[indexPersona].animasi.SetInteger("Kondisi", 1);
           

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

    public void CalculateScore()
    {
        float jawabanBenar = 0,
            tempScore = 0;

        // Get all the current persona on the lifeboat
        for (int i = 0; i < lifeBoats.Length; i++)
        {
            for (int j = 0; j < personaClusters.Length; j++)
            {
                if (lifeBoats[i].name.Equals(personaClusters[j].name))
                {
                    personaSavedIndex[i] = j;
                    break;
                }
            }
        }

        /* Correct answer, in order, and their indexes are :
         *  Desi    [4], 
         *  Cintami [3],
         *  Budi    [2],
         *  Ahmad   [1]. 
         */
        for (int i = 0; i < personaSavedIndex.Length; i++)
        {
            if (personaSavedIndex[i] == 4 ||
                personaSavedIndex[i] == 3 ||
                personaSavedIndex[i] == 2 ||
                personaSavedIndex[i] == 1)
                jawabanBenar++;

            switch (i)
            {
                case 0:
                    if (personaSavedIndex[i] == 4)
                        tempScore += 10;
                    break;
                case 1:
                    if (personaSavedIndex[i] == 3)
                        tempScore += 5;
                    break;
                case 2:
                    if (personaSavedIndex[i] == 2)
                        tempScore += 2.5f;
                    break;
                case 3:
                    if (personaSavedIndex[i] == 1)
                        tempScore += 2.5f;
                    break;
            }
        }

        tempScore = tempScore + (jawabanBenar * 20);
        Debug.Log("jawabanBenar: " + jawabanBenar +
            " score" + tempScore);

        score = tempScore;
    }

    public void EndEarly()
    {
        isStationComplete = true;
        StationEnds();
    }

    private void UpdateFaceCamera()
    {
        faceCamera.position = tempCluster.camPostition.transform.position;
        faceCamera.rotation = tempCluster.camPostition.transform.rotation;
    }

    public override void ReportNewScore()
    {
        // Buat nyimpen soal di GameManager utama
        ProgressCache.Instance.ReportNewValue(score);
    }

    public void StationEnds()
    {
        CalculateScore();

        Debug.Log("Station 2 End. Score: " + score + ". Time left: " + (dueTime - timePassed));

        station2UI.showScore(score);

        ReportNewScore();

        sceneChanger.sceneTo("Station 3");

        // To-do: Bikin kata2 selamatnya
    }
}
