using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RaumfinderEMM.Geschaeftslogik;
using System;
using System.Net.NetworkInformation;

public class Logik : MonoBehaviour
{

    private Geschaeftslogik _gl;
    private List<Raum> _filteredRooms;
    private string _language = "DE";

    // Start is called before the first frame update
    void Start()
    {
        _gl = new Geschaeftslogik();
    }


    /// <summary>
    /// Performs a quicksearch and sets the value of _filteredRooms to the returned array.
    /// </summary>
    //TODO: implement a function that gets the current timeslot based on current time
    public void Schnellsuche()
    {
        _filteredRooms = _gl.getFreeRooms(1);
    }

    /// <summary>
    /// Searches for free rooms matching the specified criteria.
    /// </summary>
    /// <param name="zeitfenster">Int from 1 - 8 representing a certain timeslot</param>
    /// <param name="gebaeude">Char corresponding to the building the room should be in.</param>
    /// <param name="kapazitaet">The desired capacity of the room.</param>
    /// <param name="ausstattung">An array of strings containing the requested equipment.</param>
    public bool Kriteriensuche(int zeitfenster, char gebaeude, int kapazitaet, string[] ausstattung)
    {
        _filteredRooms = _gl.getFreeRooms(zeitfenster, gebaeude, kapazitaet, ausstattung);
        if (_filteredRooms.Count == 0)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Getter for _gl.
    /// </summary>
    /// <returns>The Geschäftslogik object stored in the variable.</returns>
    public Geschaeftslogik GetGeschaeftsLogik()
    {
        return _gl;
    }

    /// <summary>
    /// Setter for language
    /// </summary>
    /// <param name="language">A string corresponding to the selected language.</param
    public void setLanguage(String language)
    {
        _language = language;
    }

    /// <summary>
    /// Getter for _filteredRooms.
    /// </summary>
    /// <returns>The list of rooms stored in the variable.</returns>
    public List<Raum> GetFilteredRooms()
    {
        return _filteredRooms;
    }

    /// <summary>
    /// Setter for _filteredRooms.
    /// </summary>
    /// <param name="filteredRooms">A List<Raum>.</param>
    public void SetFilteredRooms(List<Raum> filteredRooms)
    {
        _filteredRooms = filteredRooms;
    }

    /// <summary>
    /// Returns information on the room with the passed name.
    /// </summary>
    /// <param name="name">String containing the complete name of the room (e.g. WH C 638)</param>
    /// <returns>A Raum object, containing the information about the passed room.</returns>
    public Raum GetRoomInfo(string name)
    {
        return _gl.getRoomInformation(name);
    }

    /// <summary>
    /// Books a room within a specific timeslot.
    /// </summary>
    /// <param name="name">String containing the complete name of the room (e.g. WH C 638)</param>
    /// <param name="ts">Int from 1 - 8 representing a certain timeslot</param>
    /// <returns>True if room was successfully booked, false if it wasn't.</returns>
    public bool BookRoom(string name, int ts)
    {
        return _gl.bookRoom(name, ts);
    }

}
