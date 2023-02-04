using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadMenu()
    {
        SoundManager.instance.PlayButtonSound();
        SceneManager.LoadScene("Menu");
    }

    public void MenuExit()
    {
        SoundManager.instance.PlayButtonSound();
        Application.Quit();
    }

    public void MenuStart()
    {
        SoundManager.instance.PlayButtonSound();
        SceneManager.LoadScene("Stage1");
    }

    public void MenuSetting()
    {
        SoundManager.instance.PlayButtonSound();
        SceneManager.LoadScene("Setting");
    }

    public void MenuCredit()
    {
        SoundManager.instance.PlayButtonSound();
        Application.OpenURL("https://github.com/JiMeow/CatAdventure");
    }
}
