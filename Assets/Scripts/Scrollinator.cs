using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollinator : MonoBehaviour {

	public float scrollSpeed;
	private float scene1Width;
	private float scene2Width;
	private Transform scenery1;
	private Transform scenery2;

	void Start () {
		scenery1 = transform.Find ("Scenery1");
		scenery2 = transform.Find ("Scenery2");
		scene1Width = scenery1.GetComponent<SpriteRenderer> ().bounds.size.x;
		scene2Width = scenery2.GetComponent<SpriteRenderer> ().bounds.size.x;
		Debug.Log ("Background width: " + scene1Width);
	}

	// Update is called once per frame
	void Update () {
		scenery1.Translate (new Vector3 (-scrollSpeed * Time.deltaTime, 0, 0));
		if (scenery1.position.x < -scene1Width) {
			scenery1.position = (Vector3)scenery1.position + new Vector3 (scene1Width+scene2Width, 0, 0);
		}

		scenery2.Translate (new Vector3 (-scrollSpeed * Time.deltaTime, 0, 0));
		if (scenery2.position.x < -scene1Width) {
			scenery2.position = (Vector3)scenery2.position + new Vector3 (scene1Width+scene2Width, 0, 0);
		}
	}
}
