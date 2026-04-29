using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int difficulty = 0;

    public GameObject[] Enemies;

    private int killed = 0;

    public int MaxEnemiesCount = 3;
    private int enemiesCount = 0;

    public float MinSpawnDelay = 3;
    public float MaxSpawnDelay = 6;

    public int EnemiesLevelUp = 5;

    void Awake()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true) 
        {
            if (enemiesCount < MaxEnemiesCount)
            {
                enemiesCount++;
                float delay = Random.Range(MinSpawnDelay, MaxSpawnDelay);
                yield return new WaitForSeconds(delay);
                GameObject clone = Instantiate(Enemies[Random.Range(0, difficulty + 1)]);
                clone.transform.position = new Vector3(Random.Range(-2, 2), 6);
                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.OnDead.AddListener(RemoveEnemy);
            }
            else
            {
                yield return null;
            }
        }
    }

    private void RemoveEnemy()
    {
        killed++;
        difficulty = killed / EnemiesLevelUp;
        if (difficulty >= Enemies.Length)
        {
            difficulty = Enemies.Length - 1;
        }
        enemiesCount--;
    }
}
