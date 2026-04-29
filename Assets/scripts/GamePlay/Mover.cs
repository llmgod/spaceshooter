using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Vector3 Speed;
    void Update()
    {
        transform.position += Speed * Time.deltaTime;
        
    }
}
