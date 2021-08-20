using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Spawning Settings")]
    [Tooltip("Enemy that will be spawned")]
    [SerializeField] GameObject EnemyPrefab;
    [Tooltip("Number of enemies allowed on screen at any given time")]
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [Tooltip("Time it takes for the enemies to come back")]
    [SerializeField] [Range(0.1f, 30.0f)] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();    
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(EnemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }    
        }
    }
}

