using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public int level = 1;

    [SerializeField] Scrollbar hpBar;
    [SerializeField] Text hpText;
    [SerializeField] AudioClip audioClip;

    private GameObject enemy;
    private AudioSource audioSource;

    private void Start()
    {
        charHP = maxHP;
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
        StatusForLevel();
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

    void StatusForLevel()
    {
        maxHP = 10 + level;
        charAttack = level;
        charSpeed = 5.0f + ((float)level / 10);
    }
}
