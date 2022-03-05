using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private GameObject enemy;

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
            //todo  修正
            charHP -= enemy.GetComponent<Enemy>().charAttack;
        }
    }
}
