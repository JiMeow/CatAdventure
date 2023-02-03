using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMovedown : MonoBehaviour
{
    public float leftHeight = 2.56f;
    public float speed = 0.01f;

    Vector3 startPos;
    float height;
    void Start()
    {
        startPos = transform.position;
        height = leftHeight;
    }

    void Update()
    {

    }
    
    void FixedUpdate()
    {
        Drop();
        
    }

    void Drop()
    {
        if (leftHeight <= 0)
        {
            Restart();
        }
        transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        leftHeight -= speed;
    }

    void Restart()
    {
        transform.position = startPos;
        leftHeight = height;
    }
}
