using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float BgFadeTime;
    public int BgStepFade;
    GameObject bg;

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
    }

    void Start()
    {
        bg = GameObject.Find("Bg");
        FadeBackground();
    }

    public void FadeBackground()
    {
        StartCoroutine(FadeBackground(BgFadeTime, BgStepFade));
    }

    IEnumerator FadeBackground(float fadeTime, int step)
    {
        float startAlpha = bg.GetComponent<SpriteRenderer>().color.a;
        float timePerStep = 1.0f / step;
        while (startAlpha > 0)
        {
            startAlpha -= timePerStep;
            bg.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, startAlpha);
            yield return new WaitForSecondsRealtime(fadeTime * timePerStep);
        }
    }

    public void FadeInBackground()
    {
        StartCoroutine(FadeInBackground(BgFadeTime, BgStepFade));
    }

    IEnumerator FadeInBackground(float fadeTime, int step)
    {
        float startAlpha = bg.GetComponent<SpriteRenderer>().color.a;
        float timePerStep = 1.0f / step;
        while (startAlpha < 1)
        {
            startAlpha += timePerStep;
            bg.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, startAlpha);
            yield return new WaitForSecondsRealtime(fadeTime * timePerStep);
        }
    }


}
