using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchResultButtonController : MonoBehaviour
{
    [SerializeField] private SuchergebnisKS suchergebnis;

    /// <summary>
    /// navigates to previously visited page 
    /// </summary>
    public void HandleBackClick()
    {
        suchergebnis.Back();
    }

    /// <summary>
    /// books the selected room when book now button is clicked
    /// </summary>
    public void HandleBookingClick()
    {
        suchergebnis.BookRoom();
    }
}
