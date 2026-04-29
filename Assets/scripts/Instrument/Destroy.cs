using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float Time = 1f;
    void Start()
    {
        Destroy(gameObject, Time);
    }
}