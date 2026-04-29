using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject[] PowerupPrefabs;
    public GameObject ExplosionPrefab;
    public Meteorspauner Meteorspawner;
    public float SpeedX;
    public float MaxSpeedX = -5, MinSpeedX = 5;
    public float MinSpeedY = -3, MaxSpeedY = -6;
    public float SpeedY;
    public MeteorType Type;
    private Player player;
    private CamerShake CamerShaker;
    private bool used = false;

    void Start()
    {
        SpeedX = Random.Range(MinSpeedX, MaxSpeedX);
        SpeedY = Random.Range(MinSpeedY, MaxSpeedY);
        player = FindObjectOfType<Player>();
        CamerShaker = Camera.main.GetComponent<CamerShake>();
    }
    void Update()
    {
        transform.position += new Vector3(SpeedX, SpeedY) * Time.deltaTime;
        if (player != null && player.Velocity.y > 0)
        {
            transform.position += player.Velocity.y * Vector3.down;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLaser") && !used)
        {
            used = true;

            GameObject explosion = Instantiate(ExplosionPrefab);
            explosion.transform.position = collision.transform.position;
            Destroy(collision.gameObject);
            Score.Instance.ChangeScore((int)Type);
            if (Type == MeteorType.Big)
            {
                Meteorspawner.Spawn(transform.position, MeteorType.Medium, 2);
                CamerShaker.ShakeShake(0.3f, 0.5f);
            }
            else if (Type == MeteorType.Medium)
            {
                Meteorspawner.Spawn(transform.position, MeteorType.Small, 2);
                CamerShaker.ShakeShake(0.2f, 0.4f);
            }
            else if (Type == MeteorType.Small)
            {
                Meteorspawner.Spawn(transform.position, MeteorType.Tiny, 2); 
                CamerShaker.ShakeShake(0.1f, 0.3f);
            }
            else if (Type == MeteorType.Tiny)
            { 
            // add score
            }
            else if (Type == MeteorType.Bonus)
            {
                int randomIndex = Random.Range(0, 3);
                GameObject randomPower = Instantiate(PowerupPrefabs[randomIndex]);
                randomPower.transform.position = transform.position;
            }
            Destroy(gameObject);
        }    
    }
   
}


