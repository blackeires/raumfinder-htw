using System;
using System.Collections.Generic;

namespace RaumfinderEMM.Datenzugriff
{
    public interface IDatenzugriff
	{

        /// <summary>
        /// Gets a list of all rooms availability objects from the database.
        /// </summary>
        /// <returns>A list of RaumVerfuegbarkeitsModel.</returns>
        List<RaumVerfuegbarkeitsModel> GetAllRooms();

        /// <summary>
        /// Gets a list of all rooms information objects from the database.
        /// </summary>
        /// <returns>A list of RaumModel.</returns>
        List<RaumModel> GetAllRoomInfo();

        /// <summary>
        /// Marks the room with the passed name as booked during the specified timeslot.
        /// </summary>
        /// <param name="roomName">Name of the room that should be booked.</param>
        /// <param name="timeslot">Int representation of the timeslot during which the room should be booked.</param>
        /// <returns></returns>
        bool BookRoom(String raumname, int timeslot);
    }
}

