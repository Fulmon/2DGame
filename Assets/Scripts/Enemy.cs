using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public GameObject[] gameObjects;

    [SerializeField] GameObject enemyHpBar;

    private int randomDrop;
    private GameObject player;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        randomDrop = Random.Range(0, gameObjects.Length);
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        if (player)
        {
            MoveCharacter(player);
        }
        HPBarDisplay();
        DestroyCharacter(gameObjects[randomDrop]);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") != false)
        {
            animator.SetTrigger("EffectTrigger");
            charHP -= player.GetComponent<Player>().charAttack;
        }
    }

    void HPBarDisplay()
    {
        enemyHpBar.transform.localScale = new Vector3(1.2f * charHP / maxHP, 0.2f, 0);
        if (charHP <= 0)
        {
            Destroy(enemyHpBar);
        }
    }
}