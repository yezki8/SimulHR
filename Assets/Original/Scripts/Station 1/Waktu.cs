using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waktu : MonoBehaviour
{
    public float detik, menit;
    public Text txtDetik, txtMenit;
    // Start is called before the first frame update
    void Start()
    {
        detik = 0;
        menit = 0;
        txtDetik.text = detik.ToString("F00");
        txtMenit.text = menit.ToString("F00");
    }

    // Update is called once per frame
    void Update()
    {
        detik += Time.deltaTime;
        if (detik < 60)
        {
            txtDetik.text = detik.ToString("F00");
        }
        else
        {
            menit += 1;
            detik = 0;
            txtMenit.text = menit.ToString("f00");
            
            
        }
    }
}
