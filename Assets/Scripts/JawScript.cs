using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawScript : MonoBehaviour {

	public GameObject MicInput;

	private float loudness;
	private float origPos;
	public float centerLineY;
	// Use this for initialization
	void Start () {
		origPos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		loudness = MicInput.GetComponent<MicInputScript> ().MicLoudness;
		if (loudness < 0.01f) {
			loudness = 0;
		}

		move (loudness);
	}

	void move(float loudness){
		float openSpeed = 100f;
		float closeSpeed = 10f;

		loudness = openSpeed * loudness;
		if (this.transform.position.y > centerLineY) {
			if (loudness > 0) {
				if (transform.position.y < (origPos-centerLineY)*2) {
					transform.Translate (new Vector3 (0.0f, loudness * Time.deltaTime, 0.0f));
				}
			} else {
				if (transform.position.y > (origPos-centerLineY)) {
					transform.Translate (new Vector3 (0.0f, closeSpeed * Time.deltaTime * -1, 0.0f));
				}
			}
		} else {			
			if (loudness > 0) {
				if (transform.position.y > (origPos-centerLineY)*2) {
					transform.Translate (new Vector3 (0.0f, loudness * Time.deltaTime * -1, 0.0f));
				}
			} else {
				if (transform.position.y < (origPos-centerLineY)) {
					transform.Translate (new Vector3 (0.0f, closeSpeed * Time.deltaTime, 0.0f));
				}
			}
		}
	}
}
