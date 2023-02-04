using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSFX : MonoBehaviour
{
    private void Update()
    {
        int musicScale = Mathf.RoundToInt(SoundManager.instance.SFXVolume / 0.2f);
        for (int i = 0; i < musicScale; i++)
        {
            GameObject scale = transform.GetChild(i).gameObject;
            SpriteRenderer sprite = scale.GetComponent<SpriteRenderer>();
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        }
        for (int i = musicScale; i < 10; i++)
        {
            GameObject scale = transform.GetChild(i).gameObject;
            SpriteRenderer sprite = scale.GetComponent<SpriteRenderer>();
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
        }
    }

    public void SFXUp()
    {
        SoundManager.instance.SFXVolume += 0.2f;
        if (SoundManager.instance.SFXVolume > 2)
        {
            SoundManager.instance.SFXVolume = 2;
        }
    }

    public void SFXDown()
    {
        SoundManager.instance.SFXVolume -= 0.2f;
        if (SoundManager.instance.SFXVolume < 0)
        {
            SoundManager.instance.SFXVolume = 0;
        }
    }
}
