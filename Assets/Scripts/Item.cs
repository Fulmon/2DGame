using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float itemSpeed;
    public AudioClip audioClip;

    private float waitTime;

    private void Awake()
    {
        waitTime = Random.Range(0.1f, 0.3f);
    }

    protected void MoveTo(GameObject moveToObj)
    {
        Vector3 moveTo = moveToObj.transform.position - transform.position;

        waitTime -= Time.deltaTime;
        if (waitTime > 0) return;

        transform.position += moveTo * itemSpeed * Time.deltaTime;

        if (moveTo.magnitude < 10f)
        {
            ItemEffect();
            Destroy(gameObject);
        }
    }

    protected virtual void ItemEffect()
    {

    }
}
