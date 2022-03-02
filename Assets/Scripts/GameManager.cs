using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int wallet;
    public bool isGameOver;

    [SerializeField] GameObject gameoverDisplay;
    [SerializeField] Text walletText;
    [SerializeField] Image backgroundImage; // todo scale調整

    private void Awake()
    {
        //backgroundImage.transform.localScale = GetComponent<Canvas>().transform.localScale;
    }

    void Update()
    {
        walletText.text = "所持金 : " + wallet;
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            GameOver();
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
