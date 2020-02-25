using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSnapFix : MonoBehaviour
{
    public SphereCollider sCollider;

    public void ReenableCollider()
    {
        sCollider.radius = 0.4f;
    }
}
