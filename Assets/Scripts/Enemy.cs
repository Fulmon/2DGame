using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player = GameObject.FindGameObjectWithTag("Player"))
        {
            MoveCharacter(player);
        }
        DestroyCharacter();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            charHP -= player.GetComponent<Player>().charAttack;
        }
    }
}
