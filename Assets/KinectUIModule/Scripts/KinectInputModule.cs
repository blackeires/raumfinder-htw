using UnityEngine;
using UnityEngine.EventSystems;
using Windows.Kinect;

/**
 * KinectInputModule nimmt die Input Daten der Kinect entgegen und wandelt die in die richtigen Commands um, um das UI zu bedienen.
 * https://docs.unity3d.com/460/Documentation/ScriptReference/EventSystems.BaseInputModule.html
 */
[AddComponentMenu("Kinect/Kinect Input Module")]
[RequireComponent(typeof(EventSystem))]
public class KinectInputModule : BaseInputModule
{
    // eingehende input Daten aus der Kinect
    public KinectInputData[] _inputData = new KinectInputData[0];

    // Parameter
    [SerializeField]
    private float _scrollTreshold = .5f;

    [SerializeField]
    private float _scrollSpeed = 3.5f;

    [SerializeField]
    private float _waitOverTime = 2f;

    PointerEventData _handPointerData;

    static KinectInputModule _instance = null;

    /// <summary>
    /// Gibt Instance vom KinectInputModule zurück, sofern vorhanden.
    /// </summary>
    public static KinectInputModule instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(KinectInputModule)) as KinectInputModule;

                if (!_instance)
                {
                    if (EventSystem.current){
                        EventSystem.current.gameObject.AddComponent<KinectInputModule>();
                    }
                    else
                        Debug.LogWarning("UI muss erst erschaffen werden");
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// Nimmt die Body - Daten entgegen, um updated die Kinect Body Components.
    /// Sorgt dafür, dass Gesten und Darstellung synchronisiert sind
    /// </summary>
    public void TrackBody(Body body)
    {
        for (int i = 0; i < _inputData.Length; i++)
        {
            _inputData[i].UpdateComponent(body);
        }
    }


    /// <summary>
    /// Gibt die Pointer Event Data zurück, um Screen Position zu ermitteln.
    /// </summary>
    private PointerEventData GetLookPointerEventData(Vector3 componentPosition)
    {
        // erschaffe Daten, falls null
        if (_handPointerData == null)
        {
            _handPointerData = new PointerEventData(eventSystem);
        }

        // bereite Daten vor
        _handPointerData.Reset();
        _handPointerData.delta = Vector2.zero;
        _handPointerData.position = componentPosition;
        _handPointerData.scrollDelta = Vector2.zero;
        eventSystem.RaycastAll(_handPointerData, m_RaycastResultCache);
        _handPointerData.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        m_RaycastResultCache.Clear();

        return _handPointerData;
    }
   
    public override void Process()
    {
        ProcessHover();
        ProcessPress();
        ProcessDrag();
        ProcessWaitOver();
    }

    /// <summary>
    /// Verarbeite "WaitOver" - Event.
    /// </summary>
    private void ProcessWaitOver()
    {
        for (int j = 0; j < _inputData.Length; j++)
        {
            // Überspringe, falls weder Hovering noch WaitOver erkannt wird
            if (!_inputData[j].IsHovering || _inputData[j].ClickGesture != KinectUIClickGesture.WaitOver)
            {
                continue;
            }

            // Berechne WaitOver - Time
            _inputData[j].WaitOverAmount = (Time.time - _inputData[j].HoverTime) / _waitOverTime;

            // Falls die WaitOver Time überschritten worden ist, prozessiere das Event
            if (Time.time >= _inputData[j].HoverTime + _waitOverTime)
            {
                // lade die Daten des Pointers
                PointerEventData lookData = GetLookPointerEventData(_inputData[j].GetHandScreenPosition());

                // ermittle das ausgewählte GameObject
                GameObject go = lookData.pointerCurrentRaycast.gameObject;

                // führe event auf dem GameObject aus
                // https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.ExecuteEvents.ExecuteHierarchy.html
                ExecuteEvents.ExecuteHierarchy(go, lookData, ExecuteEvents.submitHandler);

                // reset timer
                _inputData[j].HoverTime = Time.time;
            }
        }
    }

    /// <summary>
    /// Verarbeite "Drag" - Event.
    /// </summary>
    private void ProcessDrag()
    {
        for (int i = 0; i < _inputData.Length; i++)
        {
            // Überspringe, falls wir die "Maus" nicht gedrückt halten, sprich die richtige Geste ausführen
            if (!_inputData[i].IsPressing)
            {
                continue;
            }


            // Ermittle, ob wir noch am "draggen" sind anhand des festgelegten Threshold in den Parametern
            _inputData[i].IsDraging = Mathf.Abs(_inputData[i].TempHandPosition.x - _inputData[i].HandPosition.x) > _scrollTreshold || Mathf.Abs(_inputData[i].TempHandPosition.y - _inputData[i].HandPosition.y) > _scrollTreshold;

            // Falls wir uns gerade am "draggen" sind verarbeite Event
            if (_inputData[i].IsDraging)
            {
                // lade die Daten des Pointers
                PointerEventData lookData = GetLookPointerEventData(_inputData[i].GetHandScreenPosition());

                // setze ausgewähltes GameObject auf null
                eventSystem.SetSelectedGameObject(null);

                // lade neues GameObject anhand des Pointers
                GameObject go = lookData.pointerCurrentRaycast.gameObject;

                // erschaffe Event - Data anhand des EventSystems und setze dragging Daten ein
                PointerEventData pEvent = new PointerEventData(eventSystem);
                pEvent.dragging = true;
                pEvent.scrollDelta = (_inputData[i].TempHandPosition - _inputData[i].HandPosition) * _scrollSpeed;
                pEvent.useDragThreshold = true;

                // führe event auf dem GameObject aus
                // https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.ExecuteEvents.ExecuteHierarchy.html
                ExecuteEvents.ExecuteHierarchy(go, pEvent, ExecuteEvents.scrollHandler);
            }
        }
    }

    /// <summary>
    ///  Verarbeite "Press" - Event.
    /// </summary>
    private void ProcessPress()
    {
        for (int i = 0; i < _inputData.Length; i++)
        {
            // Überspringe, falls wir uns nicht im HoverState befinden oder falls bei der Click Geste kein State erkannt wird
            if (!_inputData[i].IsHovering || _inputData[i].ClickGesture != KinectUIClickGesture.HandState)
            {
                continue;
            }

            // Falls unsere Hand nicht getrackt wird resette den State
            if (_inputData[i].CurrentHandState == HandState.NotTracked)
            {
                _inputData[i].IsPressing = false;
                _inputData[i].IsDraging = false;
            }

            // Falls wir die Press Geste ausführen (Hand Schließen) und isPressing noch nicht auf true gesetzt ist, dann setze es auf true
            if (!_inputData[i].IsPressing && _inputData[i].CurrentHandState == HandState.Closed)
            {
                _inputData[i].IsPressing = true;
            }

            // Falls isPressing erkannt wird, aber die HandGeste als "Open" erfasst ist, dann führe ein "click" - Event aus
            else if (_inputData[i].IsPressing && (_inputData[i].CurrentHandState == HandState.Open))
            {
                // lade die Daten des Pointers
                PointerEventData lookData = GetLookPointerEventData(_inputData[i].GetHandScreenPosition());

                // setze ausgewähltes GameObject auf null
                eventSystem.SetSelectedGameObject(null);

                // Falls der Pointer ein GameObject hat und wir uns nicht im Drag - Modus befinden,
                // dann lade das GameObject vom Pointer und führe das Event aus.
                if (lookData.pointerCurrentRaycast.gameObject != null && !_inputData[i].IsDraging)
                {
                    GameObject go = lookData.pointerCurrentRaycast.gameObject;
                    // https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.ExecuteEvents.ExecuteHierarchy.html
                    ExecuteEvents.ExecuteHierarchy(go, lookData, ExecuteEvents.submitHandler);
                }

                // setzte am Ende isPressing wieder auf false
                _inputData[i].IsPressing = false;
            }
        }
    }

    /// <summary>
    ///  Verarbeite "Press" - Event.
    /// </summary>
    private void ProcessHover()
    {
        for (int i = 0; i < _inputData.Length; i++)
        {
            // lade die Daten des Pointers
            PointerEventData pointer = GetLookPointerEventData(_inputData[i].GetHandScreenPosition());

            // lade GameObject von Pointer
            GameObject go = _handPointerData.pointerCurrentRaycast.gameObject;

            // verarbeite event
            // https://docs.unity3d.com/2018.1/Documentation/ScriptReference/EventSystems.BaseInputModule.HandlePointerExitAndEnter.html
            HandlePointerExitAndEnter(pointer, go);

            // setzt isHovering state
            _inputData[i].IsHovering = go != null;
            
            // setze erkanntest Hover Object
            _inputData[i].HoveringObject = go;
        }
    }

    /// <summary>
    /// Lädt die Daten der getrackten Hand.
    /// </summary>
    public KinectInputData GetHandData(KinectUIHandType handType)
    {
        for (int i = 0; i < _inputData.Length; i++)
        {
            if (_inputData[i].trackingHandType == handType)
                return _inputData[i];
        }
        return null;
    }
}

/**
 * KinectInputData beschreibt der Daten, die aus der Kinect kommen und trackt die verschiedenen Hände.
 */
[System.Serializable]
public class KinectInputData
{
    // Welche Hand wird getrackt (default: rechts)
    public KinectUIHandType trackingHandType = KinectUIHandType.Right;  

    // Normalisiert die Kamera - Position
    public float handScreenPositionMultiplier = 5f;

    // status IsPressing
    private bool _isPressing;

    // Object über welches gerade gehovert wird
    private GameObject _hoveringObject;

    // Gibt den richtig handType zurück
    public JointType handType
    {
        get
        {
            if (trackingHandType == KinectUIHandType.Right)
                return JointType.HandRight;
            else
                return JointType.HandLeft;
        }
    }
   
    // Getter und Setter für das momentane gehoverte Object
    public GameObject HoveringObject
    {
        get
        { 
            return _hoveringObject;
        }
        set
        {
            if (value != _hoveringObject)
            {
                HoverTime = Time.time;

                _hoveringObject = value;

                // falls gerade kein hovering Object erkannt wird mach nichts
                if (_hoveringObject == null)
                { 
                    return;
                }

                // falls wir eine WaitOver Component hovern setze ClickGesture auf WaitOver
                if (_hoveringObject.GetComponent<KinectUIWaitOverButton>())
                {
                    ClickGesture = KinectUIClickGesture.WaitOver;
                }

                // andernfalls setze ClickGesture einfach auf HandState
                else
                {
                    ClickGesture = KinectUIClickGesture.HandState;
                }

                // setze WaitOverAmount auf 0
                WaitOverAmount = 0f;
            }
        }
    }

    /**
     * Einfache Getter und Setter. ---------------------------
     */
    public HandState CurrentHandState { get; private set; }
    public KinectUIClickGesture ClickGesture { get; private set; }
    public bool IsTracking { get; private set; }
    public bool IsHovering { get; set; }
    public bool IsDraging { get; set; }
    public bool IsPressing
    {
        get 
        { 
            return _isPressing;
        }
        set
        {
            _isPressing = value;
            if (_isPressing)
            {
                TempHandPosition = HandPosition;
            }
        }
    }
    public Vector3 HandPosition { get; private set; }
    public Vector3 TempHandPosition { get; private set; }
    public float HoverTime { get; set; }
    public float WaitOverAmount { get; set; }
    /**
     *  -------------------------------------------------------
     */

    /// <summary>
    /// Update die Componente anhand der überlieferten Body Daten.
    /// </summary>
    public void UpdateComponent(Body body)
    {
        HandPosition = GetVector3FromJoint(body.Joints[handType]);
        CurrentHandState = GetStateFromJointType(body, handType);
        IsTracking = true;
    }

    /// <summary>
    /// Berechne die Position der Hand auf dem Screen.
    /// </summary>
    public Vector3 GetHandScreenPosition()
    {
        return Camera.main.WorldToScreenPoint(new Vector3(HandPosition.x, HandPosition.y, HandPosition.z - handScreenPositionMultiplier));
    }
    
    /// <summary>
    /// Gib den aktuellen State des übermittelten Joint zurück.
    /// </summary>
    private HandState GetStateFromJointType(Body body, JointType type)
    {
        switch (type)
        {
            case JointType.HandLeft:
                return body.HandLeftState;
            case JointType.HandRight:
                return body.HandRightState;
            default:
                return body.HandRightState;
        }
    }
    
    /// <summary>
    /// Ermittelt Vector anhand der Joints. Die Werte müssen bei der Kinect immer x10 gerechnet werden.
    /// </summary>
    private Vector3 GetVector3FromJoint(Windows.Kinect.Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}

public enum KinectUIClickGesture
{
    HandState, Push, WaitOver
}
public enum KinectUIHandType
{
    Right,Left
}