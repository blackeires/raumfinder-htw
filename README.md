# HTW Raumfinder

HTW Raumfinder Projekt von Gruppe 4 im Fach Entwicklung von Multimedia. Mit dem Raumfinder lassen sich freie Räume an der HTW nach bestimmten Kriterien finden und anschließend in einem ausgewählten Zeitfenster buchen. 

## Installation

**Systemvoraussetzungen:**
* Unity
* Windows 10
* Cortana (Deutsch)
* MongoDB
* Kinect SDK
* Kinect v2

**MongoDB Setup:** 

Für die Verwendung des Programms wird eine lokal laufende MongoDB auf dem Port 27017 (default) benötigt. 
Nach der Installation muss eine neue Datenbank mit dem Namen "RaumfinderDB" erstellt werden. In dieser Datenbank müssen die Collections "Raumverfuegbarkeit" und "Rauminformationen" hinzugefügt werden.

Die Collections können (bspw. mit MongoCompass) mit Beispiel-Daten aus dem Ordner "SampleData" gefüllt werden. Hierfür muss die jeweilige gleichnamige JSON Datei bei der entsprechenden Collection importiert werden.