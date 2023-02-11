using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Windows.Kinect;


/// <summary>
/// UI Komponente für den Cursor.
/// </summary>
[RequireComponent(typeof(CanvasGroup), typeof(Image))]
public abstract class AbstractKinectUICursor : MonoBehaviour {

    [SerializeField]
    protected KinectUIHandType _handType;
    protected KinectInputData _data;
    protected Image _image;

    public virtual void Start()
    {
        Setup();
    }

    /// <summary>
    /// Setup des Cursors anahnd der hinterlegten Hand Daten und des hinterlegten Cursor Bilds.
    /// </summary>
    protected void Setup()
    {
        // lade die Hand - Daten anhand des Hand - Types (rechts oder links)
        _data = KinectInputModule.instance.GetHandData(_handType);

        // raycasts dürfen nicht geblockt werden
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        GetComponent<CanvasGroup>().interactable = false;

        // setze Cursor Image
        _image = GetComponent<Image>();
    }

    /// <summary>
    /// Update die Daten des Cursors, sofern das Tracking erkannt wird.
    /// </summary>
    public virtual void Update()
    {
      
        if (_data == null || !_data.IsTracking) return;
        ProcessData();
    }

    public abstract void ProcessData();
}
