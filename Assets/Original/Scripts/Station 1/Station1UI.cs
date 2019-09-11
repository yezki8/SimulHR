using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station1UI : MonoBehaviour
{
    public Station1Manager station1Manager;

    public GameObject[] instructionObjects;    // Make it 1 (size)
    private GameObject instructionObject;
    public Transform instructionObjLoc;

    public bool isInstructionComplete = false;

    //kumpulan text
    public Text txtAngkaSoal;
    public Text txtKeteranganJawaban;
    public Text txtKeteranganSoal;
    public Text txtKeteranganCara;
    public Text txtSoal;

    // Start is called before the first frame update
    void Start()
    {
        // Display Instruction Text
        txtAngkaSoal.text = ("Instruction");           //nomor soal kosong pas mulai
        txtKeteranganJawaban.text = ("Pilih jawaban menggunakan Laser Pointer dari tangan kanan anda untuk memulai.");
        txtKeteranganSoal.text = ("Tekan tombol trigger tangan kanan anda untuk memegang objek soal");
        txtKeteranganCara.text = ("Pilihlah jawaban sesuai dengan objek yang tertera didepan anda");

        // Instatiate Instruction obj
        instructionObject = Instantiate(instructionObjects[0]);
        instructionObject.transform.localPosition = instructionObjLoc.localPosition;
        instructionObject.transform.parent = instructionObjLoc;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInstructionComplete)
        {
            txtAngkaSoal.text = station1Manager.getCurrQuestion().ToString();
        }

        if (station1Manager.isStationComplete)
        {
            txtAngkaSoal.text = ("");
            txtKeteranganJawaban.text = ("Selamat, anda telah menyelesaikan scene 1. ");
            txtKeteranganCara.text = ("Score tidak akan ditampilkan, melainkan disimpan didalam sistem");
            txtAngkaSoal.text = ("");
            txtSoal.text = ("");
            txtKeteranganSoal.text = ("Scene selanjutnya sedang dalam proses development, terima kasih telah mencoba scene ini :)");
        }
    }

    public void SetInstructionComplete()
    {
        isInstructionComplete = true;
        Destroy(instructionObject);

        // Set text
        txtAngkaSoal.text = ("");           //nomor soal kosong pas mulai
        txtKeteranganJawaban.text = ("");
        txtKeteranganSoal.text = ("");
        txtKeteranganCara.text = ("");
    }
}
