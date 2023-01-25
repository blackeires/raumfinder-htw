using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] private Startmenu _startmenu;
    [SerializeField] private GameObject _openPage;

    public void openMainMenu()
    {
        _openPage.SetActive(false);
        _startmenu.Show();
    }

}
