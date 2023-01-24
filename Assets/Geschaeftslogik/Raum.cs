using System;
using System.Linq;

namespace RaumfinderEMM.Geschaeftslogik
{
    public class Raum
	{

        private string _raumname;
        private char _gebaeude;
        private int _etage;
        private int _kapazitaet;
        private string[] _ausstattung;

        //Constructor with normal arguments
        public Raum(string raumname, char gebaeude, int etage, int kapazitaet, string[] ausstattung)
        {
            _raumname = raumname;
            _gebaeude = gebaeude;
            _etage = etage;
            _kapazitaet = kapazitaet;
            _ausstattung = ausstattung;
        }

        //Constructor with RaumModel as argument
        public Raum(Datenzugriff.RaumModel raummodel)
        {
            _raumname = raummodel.raumname;
            _gebaeude = raummodel.gebaeude;
            _etage = raummodel.etage;
            _kapazitaet = raummodel.kapazitaet;
            _ausstattung = raummodel.ausstattung;
        }

        /// <summary>
        /// Getter for _raumname.
        /// </summary>
        /// <returns>A string with the value of _raumname.</returns>
        public string GetRaumname()
        {
            return _raumname;
        }

        /// <summary>
        /// Getter for _gebaeude.
        /// </summary>
        /// <returns>A char with the value of _gebaeude.</returns>
        public char GetGebaeude()
        {
            return _gebaeude;
        }

        /// <summary>
        /// Getter for _etage.
        /// </summary>
        /// <returns>An in with the value of _etage.</returns>
        public int GetEtage()
        {
            return _etage;
        }

        /// <summary>
        /// Getter for _kapazitaet.
        /// </summary>
        /// <returns>An int with the value of _kapazitaet.</returns>
        public int GetKapazitaet()
        {
            return _kapazitaet;
        }

        /// <summary>
        /// Getter for _ausstattung.
        /// </summary>
        /// <returns>A string[] with the value of _ausstattung.</returns>
        public string[] getAusstattung()
        {
            return _ausstattung;
        }

        //Get Ausstattung as single string
        /// <summary>
        /// Gets Ausstattung as a single string.
        /// </summary>
        /// <returns>A string made of the elements of the _ausstattung array seperated by commata.</returns>
        public string getAusstattungAsString()
        {
            string str = "";
            int i = 1;
            foreach(string s in _ausstattung)
            {
                str += s;
                if (i != _ausstattung.Count())
                {
                    str += ", ";
                }
                i++;
            }
            return str;
        }

        
        /// <summary>
        /// Checks whether this room conatins the equipment specified in the passed array or not.
        /// </summary>
        /// <param name="ausstattung">An array with all equipment that should be present in the room.</param>
        /// <returns>returns true, if all the equipment is present, false if not</returns>
        public bool IstAusstattungVorhanden(string[] ausstattung)
        {
            bool ausstattungVorhanden = true;
            foreach(string s in ausstattung)
            {
                
                if(_ausstattung.Contains(s) == false)
                {
                    ausstattungVorhanden = false;
                    
                }
            }
            return ausstattungVorhanden;
        }

    }
}

