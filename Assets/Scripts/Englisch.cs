using System;
using UnityEngine;
using TMPro;

public class Englisch
{
    //Texte Startbildschrim
    [SerializeField] private TMP_Text quicksearchButton;
    [SerializeField] private TMP_Text filteredsearchButton;


    //Startbildschirm
    public const string quicksearch = "Find closest free room";
    public const string filteredsearch = "Find room according to criteria";

    //Kriteriensuche
    public const string filteredsearchTitle = "Filtered Search";
    public const string timeslotKS = "Time frame";
    public const string search = "Search now";

    //Error Popup
    public const string errorPopupHeading = "Error:";
    public const string errorMessageEP = "There are no rooms available with the desired criteria.";
    public const string backToSearchEP = "Back to search";

    //Suchergebnisse
    public const string searchResults = "Search Results";
    public const string information = "Information";
    public const string roomNumber = "Room number";
    public const string building = "Building";
    public const string floor = "Floor";
    public const string capacity = "Capacity";
    public const string equipment = "Equipment";
    public const string showMoreRooms = "Show more rooms:";
    public const string booking = "Booking";
    public const string bookNow = "Book now";

    //Buchungsbestätigung
    public const string successfulBooking = "Reservation successful!";
    public const string timeslot = "Reserved during:";
    public const string cancelReservation = "Cancel Reservation";
    public const string confirmReservation = "Confirm Reservation";

    //Sonstiges
    public const string back = "Back";

}

