using UnityEngine;
using System.Collections;
using TMPro;

public class Sprachauswahl : MonoBehaviour
{

    #region
    //Texte Startbildschrim
    [SerializeField] private TMP_Text _quicksearchButton;
    [SerializeField] private TMP_Text _filteredsearchButton;

    //Texte Kriteriensuche
    [SerializeField] private TMP_Text _filteredsearchKSHeading;
    [SerializeField] private TMP_Text _buildingKS;
    [SerializeField] private TMP_Text _capacityKS;
    [SerializeField] private TMP_Text _equipmentKS;
    [SerializeField] private TMP_Text _timeslotKS;
    [SerializeField] private TMP_Text _searchKS;
    [SerializeField] private TMP_Text _backKS;

    //Texte Error Popup
    [SerializeField] private TMP_Text _errorPupupHeading;
    [SerializeField] private TMP_Text _errorMessageEP;
    [SerializeField] private TMP_Text _backToSearchEP;

    //Texte Suchergebnisse
    [SerializeField] private TMP_Text _searchResultsHeading;
    [SerializeField] private TMP_Text _informationSR;
    [SerializeField] private TMP_Text _roomNumberSR;
    [SerializeField] private TMP_Text _buildingSR;
    [SerializeField] private TMP_Text _floorSR;
    [SerializeField] private TMP_Text _capacitySR;
    [SerializeField] private TMP_Text _equipmentSR;
    [SerializeField] private TMP_Text _showMoreRoomsSR;
    [SerializeField] private TMP_Text _BookingSR;
    [SerializeField] private TMP_Text _bookNowSR;
    [SerializeField] private TMP_Text _backSR;

    //Texte Buchungsbestätigung
    [SerializeField] private TMP_Text _successfulBookingHeading;
    [SerializeField] private TMP_Text _timeslotB;
    [SerializeField] private TMP_Text _cancelReservationB;
    [SerializeField] private TMP_Text _confirmReservationB;
    #endregion

    #region
    //TODO: comment + rewrite to avoid redundancy
    public void changeSystemLanguageToGerman()
    {
        //Startmenu
        _quicksearchButton.text = Deutsch.quicksearch;
        _filteredsearchButton.text = Deutsch.filteredsearch;

        //Kriteriensuche
        _filteredsearchKSHeading.text = Deutsch.filteredsearchTitle;
        _buildingKS.text = Deutsch.building;
        _capacityKS.text = Deutsch.capacity;
        _equipmentKS.text = Deutsch.equipment;
        _timeslotKS.text = Deutsch.timeslotKS;
        _searchKS.text = Deutsch.search;
        _backKS.text = Deutsch.back;

        //Texte Error Popup
        _errorPupupHeading.text = Deutsch.errorPopupHeading;
        _errorMessageEP.text = Deutsch.errorMessageEP;
        _backToSearchEP.text = Deutsch.backToSearchEP;

        //Suchergebnisse
        _searchResultsHeading.text = Deutsch.searchResults;
        _informationSR.text = Deutsch.information;
        _roomNumberSR.text = Deutsch.roomNumber;
        _buildingSR.text = Deutsch.building;
        _floorSR.text = Deutsch.floor;
        _capacitySR.text = Deutsch.capacity;
        _equipmentSR.text = Deutsch.equipment;
        _showMoreRoomsSR.text = Deutsch.showMoreRooms;
        _BookingSR.text = Deutsch.booking;
        _bookNowSR.text = Deutsch.bookNow;
        _backSR.text = Deutsch.back;

        //Texte Buchungsbestätigung
        _successfulBookingHeading.text = Deutsch.successfulBooking;
        _timeslotB.text = Deutsch.timeslot;
        _cancelReservationB.text = Deutsch.cancelReservation;
        _confirmReservationB.text = Deutsch.confirmReservation;

    }
    #endregion

    #region
    //TODO: comment + rewrite to avoid redundancy
    public void changeSystemLanguageToEnglish()
    {
        _quicksearchButton.text = Englisch.quicksearch;
        _filteredsearchButton.text = Englisch.filteredsearch;

        //Kriteriensuche
        _filteredsearchKSHeading.text = Englisch.filteredsearchTitle;
        _buildingKS.text = Englisch.building;
        _capacityKS.text = Englisch.capacity;
        _equipmentKS.text = Englisch.equipment;
        _timeslotKS.text = Englisch.timeslotKS;
        _searchKS.text = Englisch.search;
        _backKS.text = Englisch.back;

        //Texte Error Popup
        _errorPupupHeading.text = Englisch.errorPopupHeading;
        _errorMessageEP.text = Englisch.errorMessageEP;
        _backToSearchEP.text = Englisch.backToSearchEP;

        //Suchergebnisse
        _searchResultsHeading.text = Englisch.searchResults;
        _informationSR.text = Englisch.information;
        _roomNumberSR.text = Englisch.roomNumber;
        _buildingSR.text = Englisch.building;
        _floorSR.text = Englisch.floor;
        _capacitySR.text = Englisch.capacity;
        _equipmentSR.text = Englisch.equipment;
        _showMoreRoomsSR.text = Englisch.showMoreRooms;
        _BookingSR.text = Englisch.booking;
        _bookNowSR.text = Englisch.bookNow;
        _backSR.text = Englisch.back;

        //Texte Buchungsbestätigung
        _successfulBookingHeading.text = Englisch.successfulBooking;
        _timeslotB.text = Englisch.timeslot;
        _cancelReservationB.text = Englisch.cancelReservation;
        _confirmReservationB.text = Englisch.confirmReservation;

    }
    #endregion



}

