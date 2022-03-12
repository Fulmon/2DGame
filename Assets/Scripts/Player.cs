using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Player : Character
{
    [SerializeField] Scrollbar hpBar;
    [SerializeField] Text hpText;
    [SerializeField] AudioClip audioClip;

    private GameObject enemy;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy = GameObject.FindGameObjectWithTag("Enemy"))
        {
            MoveCharacter(enemy);
        }
        HPBarDisplay();
        DestroyCharacter();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") != false)
        {
            audioSource.PlayOneShot(audioClip, 0.5f);
            charHP -= enemy.GetComponent<Enemy>().charAttack;
            //if (enemy.GetComponent<Enemy>().charHP <= 0)
            //{
            //    Destroy(enemy);
            //}
        }
    }

    void HPBarDisplay()
    {
        hpBar.size = (float)charHP / (float)maxHP;
        hpText.text = "HP : " + charHP.ToString();
        if (charHP <= 0)
        {
            Destroy(hpBar.handleRect.GetComponent<Image>());
        }
    }

    // セーブとロードのJson
    [Serializable]
    class SaveData
    {
        public int saveHp;
        public int saveMaxHp;
        public int saveAtk;
        public float saveSpeed;
    }

    public void SavePlayer()
    {
        SaveData saveData = new SaveData();
        saveData.saveHp = charHP;
        saveData.saveMaxHp = maxHP;
        saveData.saveAtk = charAttack;
        saveData.saveSpeed = charSpeed;

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

            charHP = saveData.saveHp;
            maxHP = saveData.saveMaxHp;
            charAttack = saveData.saveAtk;
            charSpeed = saveData.saveSpeed;
        }
    }
}
