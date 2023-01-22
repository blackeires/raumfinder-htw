using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using RaumfinderEMM.Geschaeftslogik;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Kriteriensuche : MonoBehaviour
{
    //UI Game Objects
    [SerializeField] private Logik _logik;
    [SerializeField] private Startmenu _startmenu;
    [SerializeField] private SuchergebnisKS _suchergebnisKS;

    //Error Pop Up
    [SerializeField] private GameObject _errorPopup;

    //Search Form
    [SerializeField] private GameObject _form;


    //Form Input Fields
    [SerializeField] private TMP_Dropdown _gebaeudeDropdown;
    [SerializeField] private TMP_Dropdown _kapazitaetDropdown;
    [SerializeField] private TMP_Dropdown _ausstattungDropdown;
    [SerializeField] private TMP_Dropdown _zeitfensterDropdown;

    //Speech to Command Controller
    [SerializeField] private SpeechToCommand speechToCommandController;

    /// <summary>
    /// Sets the state of this object to not active.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Sets the state of this object to active, the state of _startmenu to not active and adds functionality to Zurück_Button
    /// </summary>
    public void Show()
    {
        speechToCommandController.SetupCommandsKriteriensuche();
        gameObject.SetActive(true);
        _startmenu.Hide();
        transform.Find("Zurück_Button").GetComponent<Button_UI>().ClickFunc = Back;
    }

    /// <summary>
    /// Searches for a room based on the criteria specified in the dropdown menus
    /// </summary>
    public void Search()
    {
        Geschaeftslogik gl = _logik.GetGeschaeftsLogik();

        //Get values from drop down menus
        char gebaeude = DropdownUtils.getGebaeudeAsChar(_gebaeudeDropdown);
        int kapazitaet = DropdownUtils.getKapazitaetAsInt(_kapazitaetDropdown);
        string[] ausstattung = DropdownUtils.getAusstattungAsArray(_ausstattungDropdown);
        int zeitfenster = DropdownUtils.GetzeitfensterAsInt(_zeitfensterDropdown);

        bool status = _logik.Kriteriensuche(zeitfenster, gebaeude, kapazitaet, ausstattung);

        if (status == true)
        {
            _suchergebnisKS.SetPreviousPage("Kriteriensuche");
            _suchergebnisKS.SetSelectedTS(DropdownUtils.getInputFromDropdown(_zeitfensterDropdown));
            Hide();
            _suchergebnisKS.Show();
        } else
        {
            _errorPopup.SetActive(true);
            _form.SetActive(false);
        }

    }

    /// <summary>
    /// Navigates back to start menu.
    /// </summary>
    public void Back()
    {
        _startmenu.Show();
        Hide();
    }

    /// <summary>
    /// Hides the error prompt and shows the form again.
    /// </summary>
    public void HideErrorPopUp()
    {
        _errorPopup.SetActive(false);
        _form.SetActive(true);
    }

    public void OpenGebaeudeDD()
    {
        DropdownUtils.OpenDropdownMenu(_gebaeudeDropdown);
    }

    public void OpenKapazitaetDD()
    {
        DropdownUtils.OpenDropdownMenu(_kapazitaetDropdown);
    }

    public void OpenAusstattungDD()
    {
        DropdownUtils.OpenDropdownMenu(_ausstattungDropdown);
    }

    public void OpenZeitfensterDD()
    {
        DropdownUtils.OpenDropdownMenu(_zeitfensterDropdown);
    }

    //TODO: remove function!
    public void TEST()
    {
        DropdownUtils.OpenDropdownMenu(_gebaeudeDropdown);
        DropdownUtils.navigateInDD(_gebaeudeDropdown, "down");
    }
}
