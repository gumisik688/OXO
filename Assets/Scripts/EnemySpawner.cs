using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine; 

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemy;
    [SerializeField] private int enemyAmount;
    [SerializeField] private float timeBetweenSpawn = .1f;


    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(enemyAmount < 10)
        {
            int randomPos = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[randomPos].position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawn);
            enemyAmount++;
        }
    }

}

