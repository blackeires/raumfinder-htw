using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class SpeechToCommand : MonoBehaviour
{

    //Setup application pages
    [SerializeField] private Startmenu startmenu;
    [SerializeField] private Buchungsübersicht buchungsuebersicht;
    [SerializeField] private Kriteriensuche kriteriensuche;
    [SerializeField] private SuchergebnisKS suchergebnis;
    [SerializeField] private Sprachauswahl sprachauswahl;
    [SerializeField] private Bedienungshilfe bedienungshilfe;




    private KeywordRecognizer keywordRecognizer;

    //Links speech input to corresponding function
    private Dictionary<string, Action> commandToAction = new Dictionary<string, Action>();

    private void Start()
    {
        SetupCommandsStartMenu();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speechCommand)
    {
        commandToAction[speechCommand.text].Invoke();
    }

    private void SetupKeywordRecognizer()
    {
        keywordRecognizer = new KeywordRecognizer(commandToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    public void SetupCommandsStartMenu()
    {
        commandToAction.Clear();
        commandToAction.Add("Schnellsuche", startmenu.Suchen);
        commandToAction.Add("Kriteriensuche", startmenu.Kriteriensuche);
        commandToAction.Add("Hilfe", bedienungshilfe.openMenu);
        commandToAction.Add("Schließen", bedienungshilfe.closeMenu);
        commandToAction.Add("Deutsch", sprachauswahl.changeSystemLanguageToGerman);
        commandToAction.Add("Englisch", sprachauswahl.changeSystemLanguageToEnglish);
        SetupKeywordRecognizer();
    }

    public void SetupCommandsKriteriensuche()
    {
        commandToAction.Clear();
        commandToAction.Add("Zurück", kriteriensuche.Back);
        commandToAction.Add("Gebäude", kriteriensuche.OpenGebaeudeDD);
        commandToAction.Add("Kapazität", kriteriensuche.OpenKapazitaetDD);
        commandToAction.Add("Ausstattung", kriteriensuche.OpenAusstattungDD);
        commandToAction.Add("Zeitfenster", kriteriensuche.OpenZeitfensterDD);
        commandToAction.Add("Zurück zur Suche", kriteriensuche.HideErrorPopUp);
        commandToAction.Add("Suchen", kriteriensuche.Search);

        SetupKeywordRecognizer();
    }

    public void SetupCommandsSuchergebnis()
    {
        commandToAction.Clear();
        commandToAction.Add("Zurück", suchergebnis.Back);
        //commandToAction.Add("Weitere Räume", suchergebnis.OpenWeitereRaeumeDD);
        commandToAction.Add("Jetzt buchen", suchergebnis.BookRoom);
        SetupKeywordRecognizer();
    }

    public void SetupCommandsBuchungsuebersicht()
    {
        commandToAction.Clear();
        commandToAction.Add("Buchung stornieren", buchungsuebersicht.BuchungStornieren);
        commandToAction.Add("Vorgang abschließen", buchungsuebersicht.BuchungAbschließen);
    }


}
