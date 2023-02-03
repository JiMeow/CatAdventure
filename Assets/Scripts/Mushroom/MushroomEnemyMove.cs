using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemyMove : MonoBehaviour
{
    public float speed;

    Vector3 vecLeftToMove;
    void Start()
    {
        
    }

    void Update()
    {
        RaycastFindPlayer();
    }

    void FixedUpdate()
    {
        MoveToPlayer();
    }

    void RaycastFindPlayer()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + transform.right, transform.right, 10);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position - transform.right, -transform.right, 10);
        if (hitRight.collider != null)
        {
            if (hitRight.collider.tag == "Player")
            {
                vecLeftToMove = hitRight.transform.position - transform.position;
            }
        }
        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.tag == "Player")
            {
                vecLeftToMove = hitLeft.transform.position - transform.position;
            }
        }
    }
    
    void MoveToPlayer()
    {
        Vector3 vecToMove = vecLeftToMove.normalized * speed;
        if (vecToMove.magnitude > vecLeftToMove.magnitude)
        {
            vecToMove = vecLeftToMove;
        }
        vecLeftToMove -= vecToMove;
        transform.position += vecToMove;
    }
}
