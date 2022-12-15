using System;
using System.Collections.Generic;

namespace RaumfinderEMM.Geschaeftslogik
{
    public interface IGeschaeftslogik
	{
        /// <summary>
        /// Searches for free rooms matching the specified criteria during the passed timeslot.
        /// </summary>
        /// <param name="timeslot">Int from 1 - 8 representing a certain timeslot.</param>
        /// <param name="gebaeude">Char corresponding to the building the room should be in.</param>
        /// <param name="kapazitaet">The desired capacity of the room.</param>
        /// <param name="ausstattung">An array of strings containing the requested equipment.</param>
        /// <returns>A List containing all free rooms matching the specified criteria.</returns>
        List<Raum> getFreeRooms(int timeslot, char gebaeude, int kapazitaet, string[] ausstattung);

        /// <summary>
        /// Searches for free rooms during the passed timeslot.
        /// </summary>
        /// <param name="timeslot">Int from 1 - 8 representing a certain timeslot.</param>
        /// <returns>A List containing all free rooms during the passed timeslot.</returns>
        List<Raum> getFreeRooms(int timeslot);

        /// <summary>
        /// Gets the room information of the room with the passed name.
        /// </summary>
        /// <param name="roomname">Name of the room.</param>
        /// <returns>A Raum object containing the information on the room with the passed name.</returns>
        Raum getRoomInformation(string roomname);

        /// <summary>
        /// Books a room within a specific timeslot.
        /// </summary>
        /// <param name="roomName">String containing the complete name of the room (e.g. WH C 638)</param>
        /// <param name="timeslot">Int from 1 - 8 representing a certain timeslot</param>
        /// <returns>True if room was successfully booked, false if it wasn't.</returns>
        bool bookRoom(string roomName, int timeslot);

    }
}
