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
        yield return new WaitForSeconds(0.85f);
        playerAnim.SetBool("Jump", false);
    }
}
