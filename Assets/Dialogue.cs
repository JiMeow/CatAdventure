using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public float typeSpeed = 0.1f;
    public float waitTime = 3f;
    public string[] thanks;


    [SerializeField]
    private TMP_Text text;

    void Start()
    {
        StartCoroutine(Type(thanks));
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
            foreach (char letter in line.ToCharArray())
            {
                text.text = text.text.Remove(text.text.Length - 1);
                yield return new WaitForSeconds(typeSpeed);
            }
        }
        SceneManager.LoadScene("MainMenu");
    }
}
