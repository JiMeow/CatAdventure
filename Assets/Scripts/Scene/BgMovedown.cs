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
        transform.localPosition = new Vector3(0, transform.localPosition.y - speed, 0);
        leftHeight -= speed;
    }

    void Restart()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        leftHeight = height;
    }
}
