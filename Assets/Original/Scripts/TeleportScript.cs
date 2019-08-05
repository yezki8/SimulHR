using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{

    public GameObject BowlingBall;
    public GameObject Spawner;
    // Start is called before the first frame update
    void Start()
    {
        BowlingBall = GameObject.FindGameObjectWithTag("bowling");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bowling")
        {
            other.transform.position = Spawner.transform.position;
        }
    }
}
