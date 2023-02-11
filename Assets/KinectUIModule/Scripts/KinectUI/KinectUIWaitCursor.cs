using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Implementation der abstrakten Class vom Cursor für den Wait State
/// </summary>
public class KinectUIWaitCursor : AbstractKinectUICursor {


    /// <summary>
    /// Stelle den Cursor dar im Waiting State
    /// </summary>
    public override void Start()
    {
        base.Start();
        _image.type = Image.Type.Filled;
        _image.fillMethod = Image.FillMethod.Radial360;
        _image.fillAmount = 0f;
    }

    public override void ProcessData()
    {
        // Position aktualisieren
        transform.position = _data.GetHandScreenPosition();

        // Falls der Cursor im State Hovering sich befindet setze den richtigen fillAmount anhand der WaitOverAmount - Zeit
        if (_data.IsHovering)
        {
            _image.fillAmount = _data.WaitOverAmount;
        }

        // Falls wir nicht im Hovering State sind ist auch noch keine Waiting Time vergangen und fillAmount muss 0 sein
        else
        {
            _image.fillAmount = 0f;
        }
    }
}
