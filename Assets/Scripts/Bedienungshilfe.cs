using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bedienungshilfe : MonoBehaviour
{
    [SerializeField] private GameObject _bedienungshilfeMenu;

    public void openMenu()
    {
        _bedienungshilfeMenu.SetActive(true);
    }

    public void closeMenu()
    {
        _bedienungshilfeMenu.SetActive(false);
    }


}
