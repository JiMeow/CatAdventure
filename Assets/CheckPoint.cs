using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCheckPoint : MonoBehaviour
{
    Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Active", true);
        }
    }
}
