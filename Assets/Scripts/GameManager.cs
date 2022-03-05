using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int wallet;
    public int level = 1;
    public int levelUpCost;
    public bool isGameOver;

    [SerializeField] GameObject gameoverDisplay;

    // Header
    [SerializeField] Text costText;
    [SerializeField] Text levelText;
    [SerializeField] Text walletText;

    // Footer
    [SerializeField] Text maxHpText;
    [SerializeField] Text atkText;
    [SerializeField] Text speedText;

    [SerializeField] Image backgroundImage; // todo scale調整

    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        //backgroundImage.transform.localScale = GetComponent<Canvas>().transform.localScale;
    }

    void Update()
    {
        walletText.text = "所持金 : " + wallet;
        costText.text = "Cost : " + levelUpCost;
        levelText.text = "Level : " + level;

        maxHpText.text = "MaxHP : " + player.maxHP;
        atkText.text = "ATK : " + player.charAttack;
        speedText.text = "Speed : " + player.charSpeed.ToString("F1");

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

    public void LVUP()
    {
        if (wallet >= levelUpCost)
        {
            level++;

            wallet -= levelUpCost;
            levelUpCost++;

            player.charAttack++;
            player.maxHP++;
            player.charHP = player.maxHP;
            player.charSpeed += 0.1f;
        }
    }
}
