using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuButtonControllers : MonoBehaviour
{

    [SerializeField] private Startmenu _startmenu;

    /// <summary>
    /// initiates quicksearch when quicksearch button is clicked
    /// </summary>
    public void HandleQuicksearchClick()
    {
        _startmenu.Suchen();
    }

    /// <summary>
    /// initiates filtered search when filtered search button is clicked
    /// </summary>
    public void HandleFilteredSearchClick()
    {
        _startmenu.Kriteriensuche();
    }

}
