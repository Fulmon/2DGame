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
            float randomPosY = Random.Range(-2, 4);
            if (maxEnemySpawn >= 10)
            {
                maxEnemySpawn -= 10;
                Instantiate(enemyPrefab2, new Vector2(randomPosX, randomPosY), enemyPrefab2.transform.rotation);
            }
            Instantiate(enemyPrefab, new Vector2(randomPosX, randomPosY), enemyPrefab.transform.rotation);
        }
    }
}
