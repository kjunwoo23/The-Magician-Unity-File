using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public int maxCount;
    public int enemyCount;
    public float spawnTime;
    public float curTime;
    public Transform[] spawnPoints;
    public GameObject enemy;
    public float day;
    public int kill;
    int i;
    void Start()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (day == 1)
        {
            i = 0;
            enemyCount = 0;
            maxCount = 3;
            kill = 0;
            day = 0;
        }
        if (day == 2)
        {
            i = 3;
            enemyCount = 0;
            maxCount = 2;
            kill = 0;
            day = 0;
        }
        if (day == 2.5)
        {
            i = 5;
            enemyCount = 0;
            maxCount = 3;
            kill = 0;
            day = 0;
        }
        if (day == 3.0)
        {
            i = 8;
            enemyCount = 0;
            maxCount = 4;
            kill = 0;
            day = 0;
        }
        if (day == 3.5)
        {
            i = 12;
            enemyCount = 0;
            maxCount = 3;
            kill = 0;
            day = 0;
        }
        if (day == 4.0)
        {
            i = 15;
            enemyCount = 0;
            maxCount = 3;
            kill = 0;
            day = 0;
        }
        if (day == 4.5)
        {
            i = 18;
            enemyCount = 0;
            maxCount = 4;
            kill = 0;
            day = 0;
        }
        if (day == 5.0)
        {
            i = 22;
            enemyCount = 0;
            maxCount = 7;
            kill = 0;
            day = 0;
        }
        if (day == 5.5)
        {
            i = 29;
            enemyCount = 0;
            maxCount = 4;
            kill = 0;
            day = 0;
        }
        if (day == 6.0)
        {
            i = 33;
            enemyCount = 0;
            maxCount = 3;
            kill = 0;
            day = 0;
        }
        if (day == 6.3f)
        {
            i = 36;
            enemyCount = 0;
            maxCount = 3;
            kill = 0;
            day = 0;
        }
        if (day == 6.6f)
        {
            i = 39;
            enemyCount = 0;
            maxCount = 4;
            kill = 0;
            day = 0;
        }
        if (day == 7.0f)
        {
            i = 43;
            enemyCount = 0;
            maxCount = 5;
            kill = 0;
            day = 0;
        }
        if (day == 7.5f)
        {
            i = 48;
            enemyCount = 0;
            maxCount = 4;
            kill = 0;
            day = 0;
        }
        if (curTime >= spawnTime && enemyCount < maxCount)
        {
            SpawnEnemy(i);
            i++;
        }
        curTime += Time.deltaTime;
    }
    public void SpawnEnemy(int x)
    {
        enemyCount++;
        Instantiate(enemy, spawnPoints[x]);
        curTime = 0;
    }
}
