using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool isJump = false;
    public bool isAttack = false;

    Rigidbody2D rb;
    PlayerAnimationControll playerAnim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimationControll>();
    }
    void Update()
    {
        Attack();
        Jump();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        // can't walk when attack
        if (isAttack)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }
        // get horizon
        float horizon = Input.GetAxis("Horizontal");
        if(horizon == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (horizon > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (horizon < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (!isJump)
            {
                isJump = true;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                playerAnim.AnimationJumpThenGround();
            }
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J) || Input.GetMouseButtonDown(0))
        {
            if(!isAttack)
            {
                isAttack = true;
                playerAnim.AnimationAttackThenStop();
                StartCoroutine(AttackThenStop());
            }
        }
    }

    IEnumerator AttackThenStop()
    {
        yield return new WaitForSeconds(0.75f);
        isAttack = false;
    }
    
    public void ResetJump()
    {
        isJump = false;
    }
}
