using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControll : MonoBehaviour
{
    public static CheckPointControll instance;
    
    GameObject[] checkPointList;
    public Vector3 lastCheckPointPos;
    public bool isChecked = false;

    private void Awake()
    {
        if(instance == null)
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
        checkPointList = GameObject.FindGameObjectsWithTag("CheckPoint");
    }
    
    void Update()
    {
        
    }

    public void SetSpawnPoint(GameObject checkPoint)
    {
        foreach (GameObject cp in checkPointList)
        {
            if (cp == checkPoint)
            {
                lastCheckPointPos = cp.transform.position;
                isChecked = true;
            }
            else
            {
                cp.GetComponent<Animator>().SetBool("Active", false);
            }
        }
    }
}
