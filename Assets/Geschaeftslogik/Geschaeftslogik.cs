using System;
using System.Collections.Generic;
using System.Linq;
using RaumfinderEMM.Datenzugriff;

namespace RaumfinderEMM.Geschaeftslogik
{
    //TODO: COMMENT CLASS
    public class Geschaeftslogik : IGeschaeftslogik
	{
        private Datenzugriff.Datenzugriff d = new Datenzugriff.Datenzugriff();
        private List<Raum> alleRaeume;

        //Constructor
		public Geschaeftslogik()
		{
            alleRaeume = GetAllRooms();
		}

        public bool bookRoom(string roomName, int timeslot)
        {
            bool status = d.BookRoom(roomName, timeslot);
            return status;
        }

        public List<Raum> getFreeRooms(int timeslot, char gebaeude, int kapazitaet, string[] ausstattung)
        {
            List<Raum> freieRaeume = getFreeRooms(timeslot);
            List<Raum> gefilterteFreieRaeume = new List<Raum>();
            foreach(Raum r in freieRaeume)
            {
                
                if (r.GetGebaeude() == gebaeude && r.GetKapazitaet() >= kapazitaet && r.GetKapazitaet() < (kapazitaet+10) && r.IstAusstattungVorhanden(ausstattung))
                {
                    gefilterteFreieRaeume.Add(r);
                }

            }

            return gefilterteFreieRaeume;
        }

        public List<Raum> getFreeRooms(int timeslot)
        {
            List<string> freieRaumnummern = GetFreeRoomnumbers(timeslot);
            List<Raum> result = alleRaeume.Where(x => freieRaumnummern.Contains(x.GetRaumname())).ToList();
            return result;
        }

        public Raum getRoomInformation(string roomname)
        {
            if (alleRaeume.Find(x => x.GetRaumname() == roomname) != null)
            {
                Raum gesuchterRaum = alleRaeume.Find(x => x.GetRaumname() == roomname);
                return gesuchterRaum;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }


        
        /// <summary>
        /// Gets list of type RaumModel from the db and transforms it into a list with all rooms as Raum objects
        /// </summary>
        /// <returns>A List of Raum objects containing all rooms from the database.</returns>
        private List<Raum> GetAllRooms()
        {
            List<Raum> alleRaeume = new List<Raum>();
            List<RaumModel> alleRaumModelle = d.GetAllRoomInfo();
            foreach(RaumModel m in alleRaumModelle)
            {
                Raum r = new Raum(m);
                alleRaeume.Add(r);
            }

            return alleRaeume;

        }

        /// <summary>
        /// Creates a list of the room numbers of all free rooms during a given timeslot.
        /// </summary>
        /// <param name="timeslot">Int from 1 - 8 representing a certain timeslot.</param>
        /// <returns>A list of strings containing all room numbers of rooms that are free during the passed timeslot.</returns>
        private List<string> GetFreeRoomnumbers(int timeslot)
        {
            List<string> freieRaumnummern = new List<string>();

            List<RaumVerfuegbarkeitsModel> raumVerfuegbarkeit = d.GetAllRooms();
            foreach (RaumVerfuegbarkeitsModel v in raumVerfuegbarkeit)
            {
                if (v.isFree(timeslot) == true)
                {
                    freieRaumnummern.Add(v.raumname);
                }
            }

            return freieRaumnummern;
        }

    }
}

