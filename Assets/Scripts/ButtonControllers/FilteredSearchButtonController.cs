using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilteredSearchButtonController : MonoBehaviour
{
    [SerializeField] Kriteriensuche kriteriensuche;

    /// <summary>
    /// Handles click of back button on filtered search page
    /// </summary>
    public void HandleBackClick()
    {
        kriteriensuche.Back();
    }
}
