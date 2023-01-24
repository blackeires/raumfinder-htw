using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodeMonkey.Utils;
using RaumfinderEMM.Geschaeftslogik;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Todo: function name w/ upper case letters
public class SuchergebnisKS : MonoBehaviour
{
    private List<Raum> _filteredRooms;

    //Previously visited page
    private string _previousPage = "";
    private string _selectedTS = "";

    //UI Game Objects
    [SerializeField] private Logik _logik;
    [SerializeField] private Kriteriensuche _kriteriensuche;
    [SerializeField] private Startmenu _startmenu;
    [SerializeField] private Buchungsübersicht _buchungsübersicht;

    //Textfelder Rauminformationen
    [SerializeField] private TMP_Text _raumnummerText;
    [SerializeField] private TMP_Text _gebaeudeText;
    [SerializeField] private TMP_Text _etageText;
    [SerializeField] private TMP_Text _kapazitaetText;
    [SerializeField] private TMP_Text _ausstattungText;

    //Dropdown für weitere Räume
    [SerializeField] private TMP_Dropdown _weitereRaeumeDD;

    //Drpdown Timeslot für Buchung 
    [SerializeField] private TMP_Dropdown _bookingDD;

    [SerializeField] private SpeechToCommand speechToCommandController;

    /// <summary>
    /// Sets state of this object to not active.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Sets state of this object to active and calls setup functions.
    /// </summary>
    public void Show()
    {
        speechToCommandController.SetupCommandsSuchergebnis();
        gameObject.SetActive(true);
        SetupSuchergebnis();
    }

    /// <summary>
    /// Gets the list of filtered room, sets up dropdowns and calls SetupButtonFunctionality.
    /// </summary>
    private void SetupSuchergebnis()
    {
        _filteredRooms = _logik.GetFilteredRooms();
        fillInRoomInfo(_filteredRooms.First());
        fillRoomDropdown();
        fillBookingDropdown();
        SetupButtonFunctionality();
    }

    /// <summary>
    /// Adds funtionality to all buttons.
    /// </summary>
    private void SetupButtonFunctionality()
    {
        transform.Find("Buchen_Button").GetComponent<Button_UI>().ClickFunc = BookRoom;
        transform.Find("Zurück_Button").GetComponent<Button_UI>().ClickFunc = Back;
    }

    /// <summary>
    /// Setter for previous page.
    /// </summary>
    /// <param name="str">The name of the site that was previously visited.</param>
    public void SetPreviousPage(string str)
    {
        _previousPage = str;
    }

    /// <summary>
    /// Setter for selected timeslot.
    /// </summary>
    /// <param name="s">The timeslot that was selected during the search process.</param>
    public void SetSelectedTS(string s)
    {
        _selectedTS = s;
    }

    /// <summary>
    /// Navigates to the previously visited page.
    /// </summary>
    public void Back()
    {
        if (_previousPage == "Kriteriensuche")
        {
            _kriteriensuche.Show();
        }
        else
        {
            _startmenu.Show();
        }
        Hide();
    }

    /// <summary>
    /// Fills the room information section with information of passed room.
    /// </summary>
    /// <param name="r">Room object of which the information should be displayed.</param>
    private void fillInRoomInfo(Raum r)
    {
        _raumnummerText.text = r.GetRaumname();
        _gebaeudeText.text = r.GetGebaeude().ToString();
        _etageText.text = r.GetEtage().ToString();
        _kapazitaetText.text = r.GetKapazitaet().ToString();
        _ausstattungText.text = r.getAusstattungAsString();
    }

    /// <summary>
    /// Fills room dropdown with the names of all free rooms matching the search criteria.
    /// </summary>
    private void fillRoomDropdown()
    {
        if (_filteredRooms.Count != 0)
        {
            List<string> options = new List<string>();
            foreach (Raum r in _filteredRooms)
            {
                options.Add(r.GetRaumname());
            }
            _weitereRaeumeDD.ClearOptions();
            _weitereRaeumeDD.AddOptions(options);
        }
    }

    /// <summary>
    /// Pre selects the timeslot in the booking dropdown, that was selected during search process.
    /// </summary>
    private void fillBookingDropdown()
    {
        List<string> options = new List<string>();
        options.Add(_selectedTS);
        _bookingDD.ClearOptions();
        _bookingDD.AddOptions(options);
    }

    /// <summary>
    /// Updates the room information section, based on the room that is currently selected in the _weitereRaeume dropdown.
    /// </summary>
    public void updateInfo()
    {
        string gewaehlterRaum = DropdownUtils.getInputFromDropdown(_weitereRaeumeDD);
        Raum rauminformationen = _logik.GetRoomInfo(gewaehlterRaum);
        fillInRoomInfo(rauminformationen);
    }


    /// <summary>
    /// Books the room with the name of the currently selected room during the currently selected timeslot.
    /// </summary>
    public void BookRoom()
    {
        bool status = _logik.BookRoom(DropdownUtils.getInputFromDropdown(_weitereRaeumeDD), DropdownUtils.GetzeitfensterAsInt(_bookingDD));
        if (!status)
        {
            //TODO: Error prompt
        } else
        {
            _buchungsübersicht.SetRaumname(DropdownUtils.getInputFromDropdown(_weitereRaeumeDD));
            _buchungsübersicht.SetZeitfenster(DropdownUtils.getInputFromDropdown(_bookingDD));
            _buchungsübersicht.Show();
            Hide();
        }
        
    }

    public void OpenWeitereRaeumeDD()
    {
        DropdownUtils.OpenDropdownMenu(_weitereRaeumeDD);
    }

    public void NavigateUpInActiveDD()
    {
        if (_weitereRaeumeDD.IsActive())
        {
            DropdownUtils.navigateUpInDD(_weitereRaeumeDD);
        }

    }

    public void NavigateDownInActiveDD()
    {
        if (_weitereRaeumeDD.IsActive())
        {
            DropdownUtils.navigateDownInDD(_weitereRaeumeDD);
        }
    }

    public void selectOptionInActiveDD()
    {
        _weitereRaeumeDD.enabled = false;
        _weitereRaeumeDD.enabled = true;
    }

}
