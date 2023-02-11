using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using RaumfinderEMM.Geschaeftslogik;

public class Startmenu : MonoBehaviour
{
    [SerializeField] private Kriteriensuche _kriteriensuche;
    [SerializeField] private SuchergebnisKS _suchergebnisKS;
    [SerializeField] private Logik _logik;

    [SerializeField] private SpeechToCommand speechToCommandController;

    /// <summary>
    /// Sets the state of this object to not active.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Sets the state of this object to active.
    /// </summary>
    public void Show()
    {
        speechToCommandController.SetupCommandsStartMenu();
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Searches for a room that is currently free and navigates to the search result page, if free rooms were found.
    /// </summary>
    public void Suchen()
    {
        _logik.Schnellsuche();

        //Check if rooms were found.
        if (_logik.GetFilteredRooms().Count > 0)
        {
            _suchergebnisKS.SetPreviousPage("Startseite");
            _suchergebnisKS.SetSelectedTS(getCurrentTimeslotAsString());
            _suchergebnisKS.Show();
            Hide();
        } 
    }

    /// <summary>
    /// opens the Kriteriensuche menu
    /// </summary>
    public void Kriteriensuche()
    {
        _kriteriensuche.Show();
    }

    /// <summary>
    /// Generates the string representation of the timeslot based on the current time
    /// </summary>
    /// <returns>String representation of the current timeslot</returns>
    private string getCurrentTimeslotAsString()
    {
        switch (_logik.getCurrentTimeslot())
        {
            case 1:
                return "8 - 9:30 Uhr";
            case 2:
                return "9:30 - 11 Uhr";
            case 3:
                return "11 - 12:30 Uhr";
            case 4:
                return "12:30 - 14 Uhr";
            case 5:
                return "14 - 15:30 Uhr";
            case 6:
                return "15:30 - 17 Uhr";
            case 7:
                return "17 - 18:30 Uhr";
            case 8:
                return "18:30 - 20 Uhr";

            default:
                return "8 - 9:30 Uhr";
        }
    }

    
}
