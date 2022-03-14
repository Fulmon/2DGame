using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GameManager : MonoBehaviour
{
    public int wallet;
    public int levelUpCost;
    public bool isGameOver;

    [SerializeField] GameObject gameoverDisplay;
    [SerializeField] AudioClip[] audioClips;

    // Header
    [SerializeField] Text costText;
    [SerializeField] Text levelText;
    [SerializeField] Text walletText;

    // Footer
    [SerializeField] Text maxHpText;
    [SerializeField] Text atkText;
    [SerializeField] Text speedText;

    private Player player;
    private AudioSource audioSource;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        audioSource = GetComponent<AudioSource>();
        LoadPlayer();
    }

    void Update()
    {
        levelUpCost = player.level;
        TextDisplay();

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
        SavePlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void TextDisplay()
    {
        walletText.text = "所持金 : " + wallet;
        costText.text = "Cost : " + levelUpCost;
        levelText.text = "Level : " + player.level;

        maxHpText.text = "MaxHP : " + player.maxHP;
        atkText.text = "ATK : " + player.charAttack;
        speedText.text = "Speed : " + player.charSpeed.ToString("F1");
    }

    public void LVUP()
    {
        if ((wallet >= levelUpCost) && !isGameOver)
        {
            audioSource.PlayOneShot(audioClips[0]);
            wallet -= levelUpCost;

            player.level++;

            player.charHP = player.maxHP + 1;
        }
        else
        {
            audioSource.PlayOneShot(audioClips[1]);
        }
    }

    private void OnApplicationQuit()
    {
        SavePlayer();
    }

    // セーブとロードのJson
    [Serializable]
    class SaveData
    {
        public int saveLevel;
        public int saveMaxHP;
        public int saveWallet;
    }

    public void SavePlayer()
    {
        SaveData saveData = new SaveData();
        saveData.saveLevel = player.level;
        saveData.saveMaxHP = player.maxHP;
        saveData.saveWallet = wallet;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            if (saveData.saveLevel == 0) return;
            player.level = saveData.saveLevel;
            player.maxHP = saveData.saveMaxHP;
            wallet = saveData.saveWallet;
        }
    }
}
