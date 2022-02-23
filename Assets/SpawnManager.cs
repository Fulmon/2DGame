using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPreafabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemyGenerator", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnemyGenerator()
    {
        float randomPosX = Random.Range(-2, 2);
        Instantiate(enemyPreafabs,new Vector2(randomPosX,4),enemyPreafabs.transform.rotation);
    }
}
