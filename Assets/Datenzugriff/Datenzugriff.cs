/**
 * Class for handling all the necessary database operations for the application
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using MongoDB.Bson;
using MongoDB.Driver;

namespace RaumfinderEMM.Datenzugriff
{
    public class Datenzugriff : IDatenzugriff
    {
        private string connectionUrl = "mongodb://localhost:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.6.1";
        private string dbName = "RaumfinderDB";
        private string collectionNameRaumverfuegbarkeit = "Raumverfuegbarkeit";
        private string collectionNameRauminfos = "Rauminformationen";

        public Datenzugriff()
        {

        }


        public List<RaumVerfuegbarkeitsModel> GetAllRooms()
        {
            //Establish db connection
            var client = new MongoClient(connectionUrl);
            var db = client.GetDatabase(dbName);
            var raumverfuegbarkeitCollection = db.GetCollection<RaumVerfuegbarkeitsModel>(collectionNameRaumverfuegbarkeit);

            var results = raumverfuegbarkeitCollection.Find(_ => true);

            List<RaumVerfuegbarkeitsModel> alleRaeume = new List<RaumVerfuegbarkeitsModel>();

            foreach (var result in results.ToList())
            {
                alleRaeume.Add(result);
            }

            return alleRaeume;

        }

    
        public List<RaumModel> GetAllRoomInfo()
        {
            //Establish db connection
            var client = new MongoClient(connectionUrl);
            var db = client.GetDatabase(dbName);
            var rauminfoCollection = db.GetCollection<RaumModel>(collectionNameRauminfos);

            var results = rauminfoCollection.Find(_ => true);

            List<RaumModel> alleRaumInformationen = new List<RaumModel>();

            foreach (var result in results.ToList())
            {
                alleRaumInformationen.Add(result);
            }

            return alleRaumInformationen;
        }


        public bool BookRoom(string roomName, int timeslot)
        {
            //Establish db connection
            var client = new MongoClient(connectionUrl);
            var db = client.GetDatabase(dbName);
            var raumverfuegbarkeitCollection = db.GetCollection<RaumVerfuegbarkeitsModel>(collectionNameRaumverfuegbarkeit);

            var result = raumverfuegbarkeitCollection.Find(x => x.raumname == roomName).ToList();

            //Check if room is currently free, else return false
            RaumVerfuegbarkeitsModel rv = result.First();
            if (rv.isFree(timeslot) == false)
            {
                return false;
            }

            var filter = Builders<RaumVerfuegbarkeitsModel>.Filter.Eq("raumname", roomName);
            var update = Builders<RaumVerfuegbarkeitsModel>.Update.Set(IntToTS(timeslot), false);
            raumverfuegbarkeitCollection.UpdateOne(filter, update);

            //Check if room isn't free anymore
            result = raumverfuegbarkeitCollection.Find(x => x.raumname == roomName).ToList();
            rv = result.First();
            if (rv.isFree(timeslot) == true)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Transforms the int representation of the passed timeslot into a string with the correct format to interact with the database.
        /// </summary>
        /// <param name="timeslot">Int representation of the timeslot.</param>
        /// <returns>String representation of the passed timeslot.</returns>
        private string IntToTS(int timeslot)
        {
            return "ts" + timeslot.ToString();
        }

    }
}

