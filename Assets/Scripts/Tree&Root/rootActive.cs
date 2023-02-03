using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootActive : MonoBehaviour
{
    bool isRootActive = false;
    bool isTreeActive = false;
    
    GameObject tree;
    SpriteRenderer rootSprite;

    void Start()
    {
        string[] name = new string[3];
        name = gameObject.name.Split('_');
        string treeName = "Tree" + '_' + name[1] + '_' + name[2];
        tree = GameObject.Find(treeName);
        tree.SetActive(false);

        rootSprite = GetComponent<SpriteRenderer>();
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
            if (!isTreeActive)
            {
                ActiveTree();
            }
        }
    }
    
    void CutTree()
    {
        if(isTreeActive)
        {
            DeactiveTree();
        }
    }

    void ActiveTree()
    {
        tree.SetActive(true);
        isTreeActive = true;
        rootSprite.color = new Color(1, 1, 1, 0);
    }

    void DeactiveTree()
    {
        tree.SetActive(false);
        isTreeActive = false;
        rootSprite.color = new Color(1, 1, 1, 1);
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
