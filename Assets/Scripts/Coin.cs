using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public float coinSpeed;

    private GameManager gameManager;
    private Text walletText;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        walletText = GameObject.Find("WalletText").GetComponent<Text>();
        waitTime = Random.Range(0.1f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveTo = walletText.transform.position - transform.position;

        waitTime -= Time.deltaTime;
        if (waitTime > 0) return;

        transform.position += moveTo * coinSpeed * Time.deltaTime;

        if (moveTo.magnitude < 10f)
        {
            gameManager.wallet += 1;
            Destroy(gameObject);
        }
    }
}
