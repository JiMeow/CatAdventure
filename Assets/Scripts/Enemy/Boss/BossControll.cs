using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControll : MonoBehaviour
{
    public bool isStartFight = false;
    bool trueEnding = false;
    bool complete = false;
    bool isFire = false;
    
    BossAnimationControll animControll;
    BossDialogue dialogue;
    private void Start()
    {
        animControll = GetComponent<BossAnimationControll>();
        dialogue = GetComponent<BossDialogue>();
    }

    void Update()
    {
        if (!isStartFight)
            BossFight();
        else if (!complete)
        {
            if (trueEnding)
                TrueEnding();
            else
                FalseEnding();
            complete = true;
        }
        else
        {
            if (!trueEnding && !isFire)
                StartCoroutine(Fire());
        }
        
    }

    bool RaycastFindPlayer()
    {
        Vector3 vecToRay = new Vector3(transform.position.x, -3.4f, transform.position.z);
        RaycastHit2D hitLeft = Physics2D.Raycast(vecToRay - transform.right, -transform.right, 7);
        if (hitLeft.collider != null)
        {
            Debug.Log(hitLeft.collider.name);
            if (hitLeft.collider.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }

    int CountTreeThatPlant()
    {
        GameObject[] tree = GameObject.FindGameObjectsWithTag("Tree");
        return tree.Length + CountPlantTree.instance.countPlantTree;
    }

    void BossFight()
    {
        if (RaycastFindPlayer())
        {
            if (CountTreeThatPlant() >= 8)
            {
                trueEnding = true;
            }
            isStartFight = true;
        }
    }

    void TrueEnding()
    {
        Debug.Log("TrueEnding");
        dialogue.PlayTrueEndingDialogue();
    }

    void FalseEnding()
    {
        animControll.AnimationAttack();
        dialogue.PlayFalseEndingDialogue();
    }

    IEnumerator Fire()
    {
        isFire = true;
        yield return new WaitForSeconds(1);
        isFire = false;
        GameObject bullet = Instantiate(Resources.Load("Bullet") as GameObject);
        bullet.transform.position = new Vector3(transform.position.x - 1, -2.93f, transform.position.z);
    }
}
