using UnityEngine;
using System.Collections;

/// <summary>
/// Script für den WaitOver Button
/// </summary>
public class KinectUIWaitOverButton : MonoBehaviour {

	// Initialiseren den Button
	void Start () {
        if (transform.childCount == 0)
        {
            return;
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.AddComponent<KinectUIWaitOverButton>();
        }
	}
}
