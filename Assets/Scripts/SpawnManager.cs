using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public Text waveText;
    public int waveCount;
    public int enemyCount;

    [SerializeField] GameObject enemyPreafabs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
            Instantiate(enemyPreafabs, new Vector2(randomPosX, 4), enemyPreafabs.transform.rotation);
        }
    }
}
