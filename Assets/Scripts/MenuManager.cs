using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void MenuExit()
    {
        Application.Quit();
    }

    public void MenuStart()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void MenuSetting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void MenuCredit()
    {
        Application.OpenURL("https://github.com/JiMeow/CatAdventure");
    }
}
