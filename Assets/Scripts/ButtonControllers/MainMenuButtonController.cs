using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] private Startmenu _startmenu;
    [SerializeField] private GameObject _openPage;

    /// <summary>
    /// opens the main menu when main menu button is clicked
    /// </summary>
    public void openMainMenu()
    {
        _openPage.SetActive(false);
        _startmenu.Show();
    }

}
