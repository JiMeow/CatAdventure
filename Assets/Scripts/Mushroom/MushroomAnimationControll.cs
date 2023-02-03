using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAnimationControll : MonoBehaviour
{
    Animator mushroomAnim;

    private void Start()
    {
        mushroomAnim = GetComponent<Animator>();
    }

    public void AnimationWalk()
    {
        mushroomAnim.SetBool("Walk", true);
    }

    public void AnimationIdle()
    {
        mushroomAnim.SetBool("Walk", false);
    }
}
