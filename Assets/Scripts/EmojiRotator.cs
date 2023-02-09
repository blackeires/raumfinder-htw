using UnityEngine;
using System.Collections;

public class EmojiRotator : MonoBehaviour {
	public float speed = 5f;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * -speed);
	}
}
