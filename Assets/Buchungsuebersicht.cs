using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using TMPro;

public class Buchungsuebersicht : MonoBehaviour
{
    //UI Game Objects
    [SerializeField] private Logik _logik;
    [SerializeField] private SuchergebnisKS _suchergebnis;
    [SerializeField] private Startmenu _startmenu;

    //UI Elements
    [SerializeField] private TMP_Text _raumTextfeld;
    [SerializeField] private TMP_Text _zeitfensterTextfeld;

    //Variables booking info
    private string _raumname = "";
    private string _zeitfenster = "";

    [SerializeField] private SpeechToCommand speechToCommandController;

    /// <summary>
    /// Sets the state of this object to active and adds functionality to Abschlieﬂen Button.
    /// </summary>
    public void Show()
    {
        speechToCommandController.SetupCommandsBuchungsuebersicht();
        gameObject.SetActive(true);
        FillBookingInfo();
    }

    /// <summary>
    /// Sets the state of this object to not active.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Sets the private variable _raumname to the passed string.
    /// </summary>
    /// <param name="str">The string that _raumname will be set to.</param>
    public void SetRaumname(string str)
    {
        _raumname = str;
    }

    /// <summary>
    /// Sets the private variable _zeitfenster to the passed string.
    /// </summary>
    /// <param name="str">The string that _zeitfenster will be set to.</param>
    public void SetZeitfenster(string str)
    {
        _zeitfenster = str;
    }

    /// <summary>
    /// Fills in booking info into respective text elements
    /// </summary>
    private void FillBookingInfo()
    {
        _raumTextfeld.text = _raumname;
        _zeitfensterTextfeld.text = _zeitfenster;
    }

    /// <summary>
    /// Sets the state of this object to not active and that of _suchergebnis to active
    /// </summary>
    private void Back()
    {
        _suchergebnis.Show();
        Hide();
    }

    /// <summary>
    /// Navigates to the statmenu.
    /// </summary>
    public void BuchungAbschlieﬂen()
    {
        _startmenu.Show();
        Hide();
    }

    public void BuchungStornieren()
    {

    }

}