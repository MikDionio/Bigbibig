using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

	public float scrollSpeed;
	private float sceneWidth;
	// Use this for initialization
	void Start () {
		sceneWidth = GetComponent<SpriteRenderer> ().bounds.size.x;
		Debug.Log ("Background width: " + sceneWidth);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-scrollSpeed * Time.deltaTime, 0, 0));
		if (transform.position.x < -sceneWidth) {
			transform.position = (Vector3)transform.position + new Vector3 (2f * sceneWidth, 0, 0);
		}
	}
}
