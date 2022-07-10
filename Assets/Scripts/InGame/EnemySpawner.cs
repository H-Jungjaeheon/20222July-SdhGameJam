using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnEnemys = new GameObject[3];
    [SerializeField] private float MaxSpawnCount, NowSpawnCount;
    [SerializeField] private Vector3[] SpawnVectors = new Vector3[2];

    void Update() => EnemySpawn();
    private void EnemySpawn()
    {
        NowSpawnCount += Time.deltaTime;
        if(NowSpawnCount >= MaxSpawnCount)
        {
            int RandCount = Random.Range(0, 3);
            int RandVectorCount = Random.Range(0, 2);
            if(RandVectorCount == 1) 
            {
                Instantiate(SpawnEnemys[RandCount], SpawnVectors[RandVectorCount], SpawnEnemys[RandCount].transform.rotation);
            }
            else
            {
                for(int DowningCount = 0; DowningCount < 2; DowningCount++)
                    Instantiate(SpawnEnemys[RandCount], SpawnVectors[DowningCount], SpawnEnemys[RandCount].transform.rotation);
            }
            NowSpawnCount = 0;
        }
    }
}
