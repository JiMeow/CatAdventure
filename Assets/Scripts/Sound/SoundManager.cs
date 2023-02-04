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

    public float SFXVolume = 1f;
    public float BGMVolume = 1f;

    float BgSoundOriginalVolume;
    float AttackSoundOriginalVolume;
    float JumpSoundOriginalVolume;
    float DieSoundOriginalVolume;
    float GoalSoundOriginalVolume;
    float ButtonSoundOriginalVolume;
    float CheckPointSoundOriginalVolume;

    private void Start()
    {
        BgSoundOriginalVolume = BgSound.volume;
        AttackSoundOriginalVolume = AttackSound.volume;
        JumpSoundOriginalVolume = JumpSound.volume;
        DieSoundOriginalVolume = DieSound.volume;
        GoalSoundOriginalVolume = GoalSound.volume;
        ButtonSoundOriginalVolume = ButtonSound.volume;
        CheckPointSoundOriginalVolume = CheckPointSound.volume;
    }

    private void Update()
    {
        BgSound.volume = BgSoundOriginalVolume * BGMVolume;
        AttackSound.volume = AttackSoundOriginalVolume * SFXVolume;
        JumpSound.volume = JumpSoundOriginalVolume * SFXVolume;
        DieSound.volume = DieSoundOriginalVolume * SFXVolume;
        GoalSound.volume = GoalSoundOriginalVolume * SFXVolume;
        ButtonSound.volume = ButtonSoundOriginalVolume * SFXVolume;
        CheckPointSound.volume = CheckPointSoundOriginalVolume * SFXVolume;
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
