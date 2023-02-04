using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLeft : MonoBehaviour
{
    public float speed = 0.1f;
    public float leftDistance = 5f;

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.localPosition = new Vector3(transform.localPosition.x - speed, transform.localPosition.y, 0);
        leftDistance -= speed;
        if (leftDistance <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "AttackArea")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "AttackArea")
        {
            Destroy(gameObject);
        }
    }
}
