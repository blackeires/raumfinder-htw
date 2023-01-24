using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilteredSearchButtonController : MonoBehaviour
{
    [SerializeField] Kriteriensuche kriteriensuche;

    public void HandleBackClick()
    {
        kriteriensuche.Back();
    }
}
