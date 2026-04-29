using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float Speed = 10;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
    }
}
