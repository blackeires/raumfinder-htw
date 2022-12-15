/**
 * Class for the definition of the structure of a RaumVerfuegbarkeit object in the database
 * A RaumVerfuegbarkeit Object stores all information about availability of the room during timeslots 1 - 8
 * A timeslot (or ts) field being filled with the value "true" represents the room being free during that time
 */
using System;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RaumfinderEMM.Datenzugriff
{
	public class RaumVerfuegbarkeitsModel
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string raumname { get; set; }
        public bool ts1 { get; set; }
        public bool ts2 { get; set; }
        public bool ts3 { get; set; }
        public bool ts4 { get; set; }
        public bool ts5 { get; set; }
        public bool ts6 { get; set; }
        public bool ts7 { get; set; }
        public bool ts8 { get; set; }

        /// <summary>
        /// Checks whether a room is free or occupied during a given timeslot.
        /// </summary>
        /// <param name="ts">Int representation of the timeslot.</param>
        /// <returns>True if the room is free during the specified timeslot, false if it isn't.</returns>
        public bool isFree(int ts)
        {
            //'true' in db means that the room is free, false means room is occupied
            bool free = true;
            switch (ts)
            {
                case 1:
                    if (ts1 == false)
                    {
                        free = false;
                    }
                    break;
                case 2:
                    if (ts2 == false)
                    {
                        free = false;
                    }
                    break;
                case 3:
                    if (ts3 == false)
                    {
                        free = false;
                    }
                    break;
                case 4:
                    if (ts4 == false)
                    {
                        free = false;
                    }
                    break;
                case 5:
                    if (ts5 == false)
                    {
                        free = false;
                    }
                    break;
                case 6:
                    if (ts6 == false)
                    {
                        free = false;
                    }
                    break;
                case 7:
                    if (ts7 == false)
                    {
                        free = false;
                    }
                    break;
                case 8:
                    if (ts8 == false)
                    {
                        free = false;
                    }
                    break;
            }

            return free;
        }

    }

}

