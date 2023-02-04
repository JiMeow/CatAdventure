using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    private AudioSource BgSound;
    [SerializeField]
    private AudioSource AttackSound;
    [SerializeField]
    private AudioSource JumpSound;
    [SerializeField]
    private AudioSource DieSound;
    [SerializeField]
    private AudioSource GoalSound;
    [SerializeField]
    private AudioSource ButtonSound;
    [SerializeField]
    private AudioSource CheckPointSound;

    public float SFXVolume = 0.5f;
    public float BGMVolume = 0.5f;

    private void Update()
    {
        BgSound.volume = BGMVolume;
        AttackSound.volume = SFXVolume;
        JumpSound.volume = SFXVolume;
        DieSound.volume = SFXVolume;
        GoalSound.volume = SFXVolume;
        ButtonSound.volume = SFXVolume;
        CheckPointSound.volume = SFXVolume;
    }

    public void PlayBgSound()
    {
        BgSound.Play();
    }

    public void PlayAttackSound()
    {
        AttackSound.Play();
    }

    public void PlayJumpSound()
    {
        JumpSound.Play();
    }

    public void PlayDieSound()
    {
        DieSound.Play();
    }

    public void PlayCheckpointSound()
    {
        CheckPointSound.Play();
    }

    public void PlayGoalSound()
    {
        GoalSound.Play();
    }

    public void PlayButtonSound()
    {
        ButtonSound.Play();
    }

    public void StopBgSound()
    {
        BgSound.Stop();
    }
}
