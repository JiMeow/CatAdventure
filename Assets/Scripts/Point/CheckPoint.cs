using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && anim.GetBool("Active") == false)
        {
            anim.SetBool("Active", true);
            SoundManager.instance.PlayCheckpointSound();
            CheckPointControll.instance.SetSpawnPoint(gameObject);
        }
    }
}
