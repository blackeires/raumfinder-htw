using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchResultButtonController : MonoBehaviour
{
    [SerializeField] private SuchergebnisKS suchergebnis;

    public void HandleBackClick()
    {
        suchergebnis.Back();
    }

    public void HandleBookingClick()
    {
        suchergebnis.BookRoom();
    }
}
