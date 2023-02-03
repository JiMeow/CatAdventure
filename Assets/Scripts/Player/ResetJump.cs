using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetJump : MonoBehaviour
{
    PlayerControll playerMove;
    void Start()
    {
        playerMove = GetComponentInParent<PlayerControll>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            playerMove.ResetJump();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            playerMove.ResetJump();
        }
    }


}
