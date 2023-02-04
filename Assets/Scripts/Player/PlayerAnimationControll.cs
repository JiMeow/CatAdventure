using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControll : MonoBehaviour
{
    Animator playerAnim;
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }
    
    public void AnimationJumpThenGround()
    {
        playerAnim.SetBool("Jump", true);
        StartCoroutine(JumpThenGround());
    }

    IEnumerator JumpThenGround()
    {
        yield return new WaitForSeconds(0.8f);
        playerAnim.SetBool("Jump", false);
    }

    public void AnimationAttackThenStop()
    {
        playerAnim.SetBool("Attack", true);
        StartCoroutine(AttackThenStop());
    }

    IEnumerator AttackThenStop()
    {
        yield return new WaitForSeconds(0.75f);
        playerAnim.SetBool("Attack", false);
    }

    public void AnimationDie()
    {
        playerAnim.SetBool("Die", true);
    }

    public void ResetBool()
    {
        playerAnim.SetBool("Jump", false);
        playerAnim.SetBool("Attack", false);
        playerAnim.SetBool("Die", false);
    }
}
