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

    // Start is called before the first frame update
    void Start()
    {
        transform.Find("Button_Quicksearch").GetComponent<Button_UI>().ClickFunc = Suchen;
        transform.Find("Button_Filtered_Search").GetComponent<Button_UI>().ClickFunc = Kriteriensuche;
        
    }

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
            _suchergebnisKS.SetSelectedTS("8 - 9:30 Uhr"); //TODO: implement logic to pass the current TS
            _suchergebnisKS.Show();
            Hide();
        } else
        {
            //TODO: implement some kind of error handling / notification about no room being available.
        }
    }

    public void Kriteriensuche()
    {
        _kriteriensuche.Show();
    }
}
