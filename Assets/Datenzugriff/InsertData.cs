/*
//Establish db connection
using MongoDB.Driver;
using RaumfinderEMM.Datenzugriff;
using System.Xml.Linq;

string connectionUrl = "mongodb://localhost:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.6.1";
string dbName = "RaumfinderDB";
string collectionNameRaumverfuegbarkeit = "Raumverfuegbarkeit";
string collectionNameRauminfos = "Rauminformationen";

var client = new MongoClient(connectionUrl);
var db = client.GetDatabase(dbName);
var rauminfoCollection = db.GetCollection<RaumModel>(collectionNameRauminfos);

string[] ausstattung1 = { "Beamer", "Tafel", "Mikro" };
string[] ausstattung2 = { "Beamer", "Tafel" };
string[] ausstattung3 = { "Beamer" };

var raum220 = new RaumModel { raumname = "WH C 220", gebaeude = 'C', etage = 2, kapazitaet = 10, ausstattung = ausstattung1  };
var raum221 = new RaumModel { raumname = "WH C 221", gebaeude = 'C', etage = 2, kapazitaet = 20, ausstattung = ausstattung2 };
var raum222 = new RaumModel { raumname = "WH C 222", gebaeude = 'C', etage = 2, kapazitaet = 30, ausstattung = ausstattung3 };
var raum223 = new RaumModel { raumname = "WH C 223", gebaeude = 'C', etage = 2, kapazitaet = 40, ausstattung = ausstattung1 };
var raum224 = new RaumModel { raumname = "WH C 224", gebaeude = 'C', etage = 2, kapazitaet = 50, ausstattung = ausstattung2 };
var raum225 = new RaumModel { raumname = "WH C 225", gebaeude = 'C', etage = 2, kapazitaet = 60, ausstattung = ausstattung3 };
var raum226 = new RaumModel { raumname = "WH C 226", gebaeude = 'C', etage = 2, kapazitaet = 70, ausstattung = ausstattung1 };
var raum227 = new RaumModel { raumname = "WH C 227", gebaeude = 'C', etage = 2, kapazitaet = 80, ausstattung = ausstattung1 };

rauminfoCollection.InsertOne(raum220);
rauminfoCollection.InsertOne(raum221);
rauminfoCollection.InsertOne(raum222);
rauminfoCollection.InsertOne(raum223);
rauminfoCollection.InsertOne(raum224);
rauminfoCollection.InsertOne(raum225);
rauminfoCollection.InsertOne(raum226);
*/





