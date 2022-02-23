using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float charSpeed;
    public int charAttack;
    public int charHP;

    public int maxHP;

    private Rigidbody2D Rb2D;

    private void Awake()
    {
        Rb2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void MoveCharacter(GameObject target)
    {
        if (GameObject.Find($"{target.name}")) //　todo 名前で判定
        {
            Vector2 vecTarget = (target.transform.position - transform.position).normalized;
            Rb2D.AddForce(vecTarget * charSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    public virtual void DestroyCharacter()
    {
        if (charHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
