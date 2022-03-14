using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    private GameObject wallet;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        wallet = GameObject.Find("WalletText");
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo(wallet);
    }

    protected override void ItemEffect()
    {
        if (!gameManager.isGameOver)
        {
            gameManager.GetComponent<AudioSource>().PlayOneShot(audioClip, 1.0f);
            gameManager.wallet++;
        }
    }
}
