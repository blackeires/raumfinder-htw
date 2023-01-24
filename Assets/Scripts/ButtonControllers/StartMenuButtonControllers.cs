using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuButtonControllers : MonoBehaviour
{

    [SerializeField] private Startmenu _startmenu;

    public void HandleQuicksearchClick()
    {
        _startmenu.Suchen();
    }

    public void HandleFilteredSearchClick()
    {
        _startmenu.Kriteriensuche();
    }

}
