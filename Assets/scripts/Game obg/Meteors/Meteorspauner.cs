using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorspauner : MonoBehaviour
{
    public float BonusSpawnChance = 30;
    public GameObject BigPrefab, MediumPrefab, SmallPrefab, TinyPrefab, BonusPrefab;
    public float MinSpawnX, MaxSpawnX;
    public float MinSpawnY, MaxSpawnY;
    public float SpawnDelay = 1;

    private float elapsedTime = 0;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > SpawnDelay)
        {
            float randX = Random.Range(MinSpawnX, MaxSpawnX);
            float randY = Random.Range(MinSpawnY, MaxSpawnY);
            Vector3 randPos = new Vector3(randX, randY);
            float chance = Random.Range(0, 101);
            if (chance <= BonusSpawnChance)
            {
                Spawn(randPos, MeteorType.Bonus);
            }
            else
            {
                MeteorType[] types = { MeteorType.Big, MeteorType.Medium, MeteorType.Small };
                int randomIndex = Random.Range(0, types.Length);
                Spawn(randPos, types[randomIndex]);
            }
            elapsedTime = 0;
        }
    }
    public void Spawn(Vector3 position, MeteorType type=MeteorType.Big, int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject clone = null;
            if (type == MeteorType.Big)
            {
                clone = Instantiate(BigPrefab);
            }
            else if (type == MeteorType.Medium)
            {
                clone = Instantiate(MediumPrefab);
            }
            else if (type == MeteorType.Small)
            {
                clone = Instantiate(SmallPrefab);
            }
            else if (type == MeteorType.Tiny)
            {
                clone = Instantiate(TinyPrefab);
            }
            else if (type == MeteorType.Bonus)
            {
                clone = Instantiate(BonusPrefab);
            }
            clone.transform.position = position;
            Meteor meteor = clone.transform.GetComponent<Meteor>();
            meteor.Meteorspawner = this;
            meteor.Type = type;
            Destroy(clone, 5);
        }
    }
}
