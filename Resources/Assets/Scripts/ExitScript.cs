using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    private GameObject settingsMenu;

    private void Start()
    {
        settingsMenu = GameObject.Find("SettingsMenu");
        settingsMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
