# HTW Raumfinder

HTW Raumfinder Projekt von Gruppe 4 im Fach Entwicklung von Multimedia. Mit dem Raumfinder lassen sich freie Räume an der HTW nach bestimmten Kriterien finden und anschließend in einem ausgewählten Zeitfenster buchen. 

## Installation

**Systemvoraussetzungen:**
* Unity
* Windows 10
* Cortana (Deutsch)
* [MongoDB](https://www.mongodb.com/docs/manual/administration/install-community/)
* Kinect v2

**MongoDB Setup:** 

Für die Verwendung des Programms wird eine lokal laufende MongoDB auf dem Port 27017 (default) benötigt. 
Nach der Installation muss eine neue Datenbank mit dem Namen "RaumfinderDB" erstellt werden. In dieser Datenbank müssen die Collections "Raumverfuegbarkeit" und "Rauminformationen" hinzugefügt werden.

Die Collections können (bspw. mit MongoCompass) mit Beispiel-Daten aus dem Ordner [SampleData](https://github.com/blackeires/raumfinder-htw/tree/development/SampleData) gefüllt werden. Hierfür muss die jeweilige gleichnamige JSON Datei bei der entsprechenden Collection importiert werden.

**Kinect Setup:**

Die Kinect sollte sich automatisch installieren sobald diese mit dem Rechner verbunden wurde. Wichtig: Nicht das SDK installieren! Mit dem SDK wird unter Umständen eine veraltete Version der Kinect Environment installiert, welche dafür Sorgen könnte, dass die Kinect nicht richtig erkannt wird. Falls das nicht funktionieren sollte kann immer noch das SDK heruntergeladen werden: [Kinect SDK](https://www.microsoft.com/en-us/download/details.aspx?id=44561)

## Dokumentation 

Weitere Dokumentation liegt in Form von Quellcodekommentaren in den jeweiligen Code-Dateien vor bzw. einige Ordner beinhalten noch README.md - Dateien.

### DoxyGen

Die mit DoxyGen generierte Dokumentation befindet sich als html und Latex Version im Ordner [BackendDokuDoxygen](https://github.com/blackeires/raumfinder-htw/tree/development/BackendDokuDoxygen). 