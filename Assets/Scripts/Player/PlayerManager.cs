using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int life = 9;

    bool isDead = false;
    PlayerAnimationControll playerAnim;
    PlayerControll playerControll;

    void Start()
    {
        playerAnim = GetComponent<PlayerAnimationControll>();
        playerControll = GetComponent<PlayerControll>();
    }

    public void PlayerDie()
    {
        if (isDead)
            return;

        isDead = true;
        playerControll.isDie = true;
        playerControll.dialogue.SetActive(true);
        playerAnim.AnimationDie();
        SoundManager.instance.PlayDieSound();
        float fadeTime = GameManager.instance.BgFadeTime;
        StartCoroutine(PlayerDie(fadeTime));
    }

    IEnumerator PlayerDie(float fadeTime)
    {
        GameManager.instance.FadeInBackground();
        yield return new WaitForSecondsRealtime(fadeTime + 0.5f);
        playerControll.dialogue.SetActive(false);
        if (CheckPointControll.instance.isChecked)
        {
            transform.position = CheckPointControll.instance.lastCheckPointPos;
            playerAnim.ResetBool();
            GameManager.instance.FadeBackground();
            yield return new WaitForSecondsRealtime(fadeTime - 0.5f);
            playerControll.isDie = false;
            isDead = false;
            
        }
        else
        {
            playerControll.isDie = false;
            isDead = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerDie();
        }
    }
}
