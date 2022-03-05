using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public GameObject[] gameObjects;

    private int randomDrop;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        randomDrop = Random.Range(0, gameObjects.Length);
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        if (player)
        {
            MoveCharacter(player);
        }
        DestroyCharacter(gameObjects[randomDrop]);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            charHP -= player.GetComponent<Player>().charAttack;
        }
    }
}