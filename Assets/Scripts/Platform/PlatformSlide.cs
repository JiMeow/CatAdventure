using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSlide : MonoBehaviour
{
    public float distance;
    public float speed;
    public float distanceLeft;
    
    bool isRight = true;
    void Start()
    {
        distanceLeft = distance;
    }
    
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if(isRight)
        {
            if (distanceLeft > 0)
            {
                transform.Translate(Vector2.right * speed);
                distanceLeft -= speed;
            }
            else
            {
                isRight = false;
                distanceLeft = -distance;
            }
        }
        else
        {
            if (distanceLeft < 0)
            {
                transform.Translate(Vector2.left * speed);
                distanceLeft += speed;
            }
            else
            {
                isRight = true;
                distanceLeft = distance;
            }
        }
    }
}
