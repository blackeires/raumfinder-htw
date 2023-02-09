using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookingSummaryButtonController : MonoBehaviour
{
    [SerializeField] private Buchungsuebersicht _buchungsübersicht;

    /// <summary>
    /// Handles click of "Buchung Abschließen" Button
    /// </summary>
    public void HandleSubmitClick()
    {
        _buchungsübersicht.BuchungAbschliessen();
    }
}
