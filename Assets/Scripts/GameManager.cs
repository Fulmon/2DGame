using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    [SerializeField] GameObject gameoverDisplay;

    //private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        //spawnManager = FindObjectOfType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            GameOver();
            //spawnManager.waveText.transform.position = new Vector3(0, -400);
        }
    }

    void GameOver()
    {
        isGameOver = true;
        gameoverDisplay.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
