using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookingSummaryButtonController : MonoBehaviour
{
    [SerializeField] private Buchungsübersicht _buchungsübersicht;

    public void HandleSubmitClick()
    {
        _buchungsübersicht.BuchungAbschließen();
    }
}
