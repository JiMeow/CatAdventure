using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationControll : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void AnimationAttack()
    {
        anim.SetBool("Attack", true);
    }

    public void AnimationDamaged()
    {
        anim.SetBool("Damaged", true);
    }
}
