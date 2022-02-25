using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    // todo 近い敵に向かっていく
    [SerializeField] Scrollbar hpBar;
    [SerializeField] Text hpText;

    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            charHP -= enemy.GetComponent<Enemy>().charAttack;
        }
    }

    private void HPBarDisplay()
    {
        hpBar.size = (float)charHP / (float)maxHP;
        hpText.text = "HP : " + charHP.ToString();
        if (charHP <= 0)
        {
            // Handleを壊す
        }
    }
}
