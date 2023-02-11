using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Windows.Kinect;

/// <summary>
/// Implementation der abstrakten Class vom Cursor
/// </summary>
public class KinectUICursor : AbstractKinectUICursor
{
    // Properties mit default - Werten
    // Setzt die Farben der unterschiedlichen States bzw. Aktionen.
    public Color normalColor = new Color(1f, 1f, 1f, 0.5f);
    public Color hoverColor = new Color(1f, 1f, 1f, 1f);
    public Color clickColor = new Color(1f, 1f, 1f, 1f);
    public Vector3 clickScale = new Vector3(.8f, .8f, .8f);

    private Vector3 _initScale;

    /// <summary>
    /// Stelle den Cursor dar mit Start Farbe (neutrale Aktion)
    /// </summary>
    public override void Start()
    {
        base.Start();
        _initScale = transform.localScale;
        _image.color = new Color(1f, 1f, 1f, 0f);
    }

    /// <summary>
    /// Update die Position des Cursor anhand der Hand - Daten und aktualisere die Farbe anhand der ausgeführten Aktion.
    /// </summary>
    public override void ProcessData()
    {
        // Position aktualisieren
        transform.position = _data.GetHandScreenPosition();

        // Falls isPressing erkannt wird
        if (_data.IsPressing)
        {
            _image.color = clickColor;
            _image.transform.localScale = clickScale;
            return;
        }

        // Falls isHovering erkannt wird
        if (_data.IsHovering)
        {
            _image.color = hoverColor;
        }

        // Falls keine besondere Aktion erkannt wird, stelle sicher, dass die Farbe auf den neutralen Wert gesetzt wird
        else
        {
            _image.color = normalColor;
        }

        // setze den scale immer wieder auf den Anfangswert zurück, um Veränderung des Bildes zu vermeiden
        // https://docs.unity3d.com/ScriptReference/Transform-localScale.html
        _image.transform.localScale = _initScale;
    }
}
