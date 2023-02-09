using System;
using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using UnityEngine;

namespace RaumfinderEMM.Datenzugriff
{
    /// <summary>
    /// Class for the definition of the structure of a RaumModel object in the database
    /// A RaumModel Object stores all information about the room that is displayed to the user
    /// and used in search queries, but does NOT contain information about the availability
    /// </summary>
	public class RaumModel
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string raumname { get; set; }
        public char gebaeude { get; set; }
        public int etage { get; set; }
        public int kapazitaet { get; set; }
        public string[] ausstattung { get; set; }
    }
}

