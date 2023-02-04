using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool isJump = false;
    public bool isAttack = false;
    public bool isDie = false;

    public Rigidbody2D rb;
    GameObject attackArea;
    PlayerAnimationControll playerAnim;
    PlayerManager playerManage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimationControll>();
        playerManage = GetComponent<PlayerManager>();
        attackArea = transform.Find("AttackArea").gameObject;
        attackArea.SetActive(false);
    }
    void Update()
    {
        CheckBackToMainMenu();
        if (isDie)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        Attack();
        Jump();
        CheckDie();
        ActiveHelp();
    }
    void FixedUpdate()
    {
        if (isDie)
            return;
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
                SoundManager.instance.PlayJumpSound();
                isJump = true;
                rb.velocity = Vector2.zero;
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
                SoundManager.instance.PlayAttackSound();
                attackArea.SetActive(true);
                isAttack = true;
                playerAnim.AnimationAttackThenStop();
                StartCoroutine(AttackThenStop());
            }
        }
    }

    void CheckDie()
    {
        if (isJump || isAttack)
            return;
        
        if (transform.position.y < -10 || Input.GetKeyDown(KeyCode.K))
        {
            PlayerDie();
        }
    }

    void CheckBackToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.instance.BackToMainMenu();
        }
    }

    void ActiveHelp()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameManager.instance.ActiveHelpUI();
        }
    }

    IEnumerator AttackThenStop()
    {
        yield return new WaitForSeconds(0.75f);
        isAttack = false;
        attackArea.SetActive(false);
    }
    
    public void ResetJump()
    {
        isJump = false;
    }
    
    public void PlayerDie()
    {
        isDie = true;
        rb.velocity = Vector2.zero;
        playerManage.PlayerDie();
    }
}
