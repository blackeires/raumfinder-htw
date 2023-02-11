using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bedienungshilfe : MonoBehaviour
{
    [SerializeField] private GameObject _bedienungshilfeMenu;

    /// <summary>
    /// opens the help menu 
    /// </summary>
    public void openMenu()
    {
        _bedienungshilfeMenu.SetActive(true);
    }

    /// <summary>
    /// closes the search window
    /// </summary>
    public void closeMenu()
    {
        _bedienungshilfeMenu.SetActive(false);
    }


}
