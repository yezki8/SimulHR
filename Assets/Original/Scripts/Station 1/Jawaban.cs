using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Jawaban : MonoBehaviour
{
    private int nSoal;
    public Text txtSoal;
    public Button pilihanA, pilihanB, pilihanC, pilihanD;
    // Start is called before the first frame update
    void Start()
    {
        nSoal = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AClick(Button pilihanA)
    {
        Debug.Log("Tombol A ke Klik");
    }
    public void BClick()
    {
        Debug.Log("Tombol B ke Klik");
    }
    public void Click()
    {
        Debug.Log("Tombol C ke Klik");
    }
    public void DClick()
    {
        Debug.Log("Tombol D ke Klik");
    }
}
