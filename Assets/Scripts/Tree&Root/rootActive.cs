using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootActive : MonoBehaviour
{
    bool isRootActive = false;
    bool isTreeActive = false;
    
    GameObject tree;
    SpriteRenderer rootSprite;
    GameObject bg;

    void Start()
    {
        string[] name = new string[3];
        name = gameObject.name.Split('_');
        string treeName = "Tree" + '_' + name[1] + '_' + name[2];
        tree = GameObject.Find(treeName);
        if (tree != null)
            tree.SetActive(false);
        rootSprite = GetComponent<SpriteRenderer>();
        bg = GameObject.Find("Bg");
    }
    
    void Update()
    {
        if (!isRootActive)
            return;
        PlantTree();
    }

    void PlantTree()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isTreeActive && bg.GetComponent<SpriteRenderer>().color.a < 0.1f)
            {
                StartCoroutine(ActiveTree());
            }
        }
    }
    
    void CutTree()
    {
        if(isTreeActive)
        {
            StartCoroutine(DeactiveTree());        
        }
    }

    IEnumerator ActiveTree()
    {
        float fadeTime = GameManager.instance.BgFadeTime;

        Time.timeScale = 0;
        GameManager.instance.FadeInBackground();
        yield return new WaitForSecondsRealtime(fadeTime + 0.5f);
        
        tree.SetActive(true);
        isTreeActive = true;
        rootSprite.color = new Color(1, 1, 1, 0);
        
        Time.timeScale = 1;
        GameManager.instance.FadeBackground();
        yield return new WaitForSecondsRealtime(fadeTime);
    }

    IEnumerator DeactiveTree()
    {
        float fadeTime = GameManager.instance.BgFadeTime;
        
        Time.timeScale = 0;
        GameManager.instance.FadeInBackground();
        yield return new WaitForSecondsRealtime(fadeTime + 0.5f);
        
        tree.SetActive(false);
        isTreeActive = false;
        rootSprite.color = new Color(1, 1, 1, 1);


        Time.timeScale = 1;
        GameManager.instance.FadeBackground();
        yield return new WaitForSecondsRealtime(fadeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isRootActive = true;
        }
        if (collision.gameObject.tag == "AttackArea")
        {
            CutTree();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isRootActive = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isRootActive = true;
        }
        if (collision.gameObject.tag == "AttackArea")
        {
            CutTree();
        }
    }
}
