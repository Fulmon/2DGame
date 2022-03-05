using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Item
{
    [SerializeField] GameObject hpBar;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = GameObject.Find("HPBar");
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo(hpBar);
    }

    protected override void ItemEffect()
    {
        player.charHP++;
    }
}
