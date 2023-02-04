using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossDialogue : MonoBehaviour
{
    public float typeSpeed;
    public float waitTime = 3f;
    public string[] bossTrueEnd;
    public string[] bossFalseEnd;

    [SerializeField]
    private TMP_Text text;

    public void PlayTrueEndingDialogue()
    {
        StartCoroutine(Type(bossTrueEnd));
    }

    public void PlayFalseEndingDialogue()
    {
        StartCoroutine(Type(bossFalseEnd));
    }

    IEnumerator Type(string[] sentence)
    {
        foreach (string line in sentence)
        {
            foreach (char letter in line.ToCharArray())
            {
                text.text += letter;
                yield return new WaitForSeconds(typeSpeed);
            }
            yield return new WaitForSeconds(waitTime);
            text.text = "";
        }
    }

}
