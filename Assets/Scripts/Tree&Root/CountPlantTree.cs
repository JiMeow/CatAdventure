using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountPlantTree : MonoBehaviour
{
    public static CountPlantTree instance;
    public int countPlantTree = 0;

    private void Awake()
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

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            countPlantTree = 0;
        }
    }

    public void CountTreeThisScene()
    {
        GameObject[] tree = GameObject.FindGameObjectsWithTag("Tree");
        countPlantTree += tree.Length;
    }
}
