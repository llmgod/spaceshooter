using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private Vector3 initPos;
    public float speed = 1;
    public float RespawnDistance;
    private Player player;
    private Meteorspauner meteorspauner;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime ;
        if (player == null)
        {
            speed = 12;
        }
        else
        {
            if (player.Velocity.y > 0)
            {
                transform.position += player.Velocity.y * Vector3.down / 2;
            }
        }

        if (Mathf.Abs(transform.position.y - initPos.y) > RespawnDistance)
        {
            transform.position = initPos;
        }
    }
}
