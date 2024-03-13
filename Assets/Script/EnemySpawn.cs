using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform playerObj;
    public GameObject enemy;
    public float spawnRate;
    public float timer = 0;
    public float minDistance = 50;
    public int enemyLimit = 50;
    public LogicScript gameLogic;

    private void Start()
    {
        spawnEnemy();
    }

    private void Update()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyLimit = (int)Mathf.Floor(gameLogic.time) * 2;
        //Debug.Log(enemyCount);
        if (enemyCount > enemyLimit)
        {
            return;
        }
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
            return;
        }
        timer = 0;
        
        spawnEnemy();
    }

    private void spawnEnemy()
    {
        
        do
        {
            Vector3 playerPos = playerObj.position;
            float xRand = Random.Range(-100, 100);
            float yRand = Random.Range(-100, 100);
            float zRand = Random.Range(-100, 100);
            Vector3 spawnPos = new Vector3(xRand, yRand, zRand);
            if (Vector3.Distance(playerPos, spawnPos) > minDistance)
            {
                Instantiate(enemy, spawnPos, Quaternion.identity);
                return;
            }
        } while (true);
        

    }
}
