using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleMusic : MonoBehaviour
{
    private void Update()
    {
        int musicScale = Mathf.RoundToInt(SoundManager.instance.BGMVolume / 0.2f);
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

    public void MusicUp()
    {
        SoundManager.instance.BGMVolume += 0.2f;
        if (SoundManager.instance.BGMVolume > 2)
        {
            SoundManager.instance.BGMVolume = 2;
        }
    }

    public void MusicDown()
    {
        SoundManager.instance.BGMVolume -= 0.2f;
        if (SoundManager.instance.BGMVolume < 0)
        {
            SoundManager.instance.BGMVolume = 0;
        }
    }
}
