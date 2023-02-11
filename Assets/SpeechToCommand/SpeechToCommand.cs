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
    [SerializeField] private Buchungsuebersicht buchungsuebersicht;
    [SerializeField] private Kriteriensuche kriteriensuche;
    [SerializeField] private SuchergebnisKS suchergebnis;
    [SerializeField] private Sprachauswahl sprachauswahl;
    [SerializeField] private Bedienungshilfe bedienungshilfe;

    [SerializeField] private Click click;




    private KeywordRecognizer keywordRecognizer;

    //Links speech input to corresponding function
    private Dictionary<string, Action> commandToAction = new Dictionary<string, Action>();

    private void Start()
    {
        SetupCommandsStartMenu();
    }

    /// <summary>
    /// Calls function based on the recognized voice input
    /// </summary>
    /// <param name="speechCommand">voice input</param>
    private void RecognizedSpeech(PhraseRecognizedEventArgs speechCommand)
    {
        commandToAction[speechCommand.text].Invoke();
        click.activateOnActivity();

    }

    /// <summary>
    /// Sets up the keyword recognizer
    /// </summary>
    private void SetupKeywordRecognizer()
    {
        keywordRecognizer = null;
        keywordRecognizer = new KeywordRecognizer(commandToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    /// <summary>
    /// Sets up the voice commands for the start page
    /// </summary>
    public void SetupCommandsStartMenu()
    {
        commandToAction.Clear();
        commandToAction.Add("Start", ActivateScreen);
        commandToAction.Add("Schnellsuche", startmenu.Suchen);
        commandToAction.Add("Kriteriensuche", startmenu.Kriteriensuche);
        commandToAction.Add("Hilfe", bedienungshilfe.openMenu);
        commandToAction.Add("Schließen", bedienungshilfe.closeMenu);
        commandToAction.Add("Deutsch", sprachauswahl.changeSystemLanguageToGerman);
        commandToAction.Add("Englisch", sprachauswahl.changeSystemLanguageToEnglish);
        SetupKeywordRecognizer();
    }

    /// <summary>
    /// Sets up the voice commands for the filtered search page
    /// </summary>
    public void SetupCommandsKriteriensuche()
    {
        commandToAction.Clear();
        commandToAction.Add("Start", ActivateScreen);
        commandToAction.Add("Zurück", kriteriensuche.Back);
        commandToAction.Add("Gebäude", kriteriensuche.OpenGebaeudeDD);
        commandToAction.Add("Kapazität", kriteriensuche.OpenKapazitaetDD);
        commandToAction.Add("Ausstattung", kriteriensuche.OpenAusstattungDD);
        commandToAction.Add("Zeitfenster", kriteriensuche.OpenZeitfensterDD);
        commandToAction.Add("Zurück zur Suche", kriteriensuche.HideErrorPopUp);
        commandToAction.Add("Suchen", kriteriensuche.Search);
        commandToAction.Add("Hoch", kriteriensuche.NavigateUpInActiveDD);
        commandToAction.Add("Runter", kriteriensuche.NavigateDownInActiveDD);
        commandToAction.Add("Wählen", kriteriensuche.selectOptionInActiveDD);
        commandToAction.Add("Hilfe", bedienungshilfe.openMenu); 
        commandToAction.Add("Schließen", bedienungshilfe.closeMenu);
        commandToAction.Add("Hauptmenü", kriteriensuche.Back);

        SetupKeywordRecognizer();
    }

    /// <summary>
    /// sets up the voice commands for the rearch result page
    /// </summary>
    public void SetupCommandsSuchergebnis()
    {
        commandToAction.Clear();
        commandToAction.Add("Start", ActivateScreen);
        commandToAction.Add("Zurück", suchergebnis.Back);
        commandToAction.Add("Weitere Räume", suchergebnis.OpenWeitereRaeumeDD);
        commandToAction.Add("Hoch", suchergebnis.NavigateUpInActiveDD);
        commandToAction.Add("Runter", suchergebnis.NavigateDownInActiveDD);
        commandToAction.Add("Wählen", suchergebnis.selectOptionInActiveDD);
        commandToAction.Add("Jetzt buchen", suchergebnis.BookRoom);
        commandToAction.Add("Hilfe", bedienungshilfe.openMenu); 
        commandToAction.Add("Schließen", bedienungshilfe.closeMenu);
        commandToAction.Add("Hauptmenü", suchergebnis.openMainMenu);
        SetupKeywordRecognizer();
    }

    /// <summary>
    /// Sets up the voice commands for the booking summary page
    /// </summary>
    public void SetupCommandsBuchungsuebersicht()
    {
        commandToAction.Clear();
        commandToAction.Add("Start", ActivateScreen);
        commandToAction.Add("Buchung stornieren", buchungsuebersicht.BuchungAbschliessen);
        commandToAction.Add("Vorgang abschließen", buchungsuebersicht.BuchungAbschliessen);
        commandToAction.Add("Hilfe", bedienungshilfe.openMenu); 
        commandToAction.Add("Schließen", bedienungshilfe.closeMenu);

        SetupKeywordRecognizer();
    }

    /// <summary>
    /// Empty function that triggers speech to command invocation function, causing the screen saver to be stopped
    /// </summary>
    private void ActivateScreen()
    {

    }
}
