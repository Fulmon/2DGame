using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public Text waveText;
    public int waveCount;
    public int enemyCount;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemyPrefab2;
    [SerializeField] GameObject enemyPrefab3;

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            WaveManager();
            EnemyGenerator(waveCount);
        }
    }

    void WaveManager()
    {
        waveCount++;
        waveText.text = "Wave : " + waveCount.ToString();
    }

    void EnemyGenerator(int maxEnemySpawn)
    {
        for (int i = 0; i < maxEnemySpawn; i++)
        {
            float randomPosX = Random.Range(-2, 2);
            float randomPosY = Random.Range(-1.5f, 3.5f);

            //Instantiate(enemyPrefab, new Vector2(randomPosX, randomPosY), enemyPrefab.transform.rotation);

            if (maxEnemySpawn >= 100)
            {
                Instantiate(enemyPrefab3, new Vector2(randomPosX, randomPosY), enemyPrefab.transform.rotation);
                maxEnemySpawn -= 100;
                i--;
            }
            else if (100 > maxEnemySpawn && maxEnemySpawn >= 10)
            {
                Instantiate(enemyPrefab2, new Vector2(randomPosX, randomPosY), enemyPrefab.transform.rotation);
                maxEnemySpawn -= 10;
                i--;
            }
            else if (10 > maxEnemySpawn)
            {
                Instantiate(enemyPrefab, new Vector2(randomPosX, randomPosY), enemyPrefab.transform.rotation);
            }
        }
    }
}
