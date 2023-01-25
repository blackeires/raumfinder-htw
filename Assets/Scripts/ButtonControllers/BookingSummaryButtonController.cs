using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookingSummaryButtonController : MonoBehaviour
{
    [SerializeField] private Buchungsuebersicht _buchungsübersicht;

    public void HandleSubmitClick()
    {
        _buchungsübersicht.BuchungAbschließen();
    }
}
