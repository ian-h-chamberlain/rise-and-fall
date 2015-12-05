using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreController : MonoBehaviour {

	public float fireTime;
	public float scaleRate;
	public float moveRate;

	public int notesNeeded;
	private int completion = 0;

	public GameObject soundCone;
	private GameObject soundConePrefab;

	private float frequency = 130.0f;
	private float curTime;
	private bool isFiring = false;

	private int currentInst = 0;
	private int lastInst = 0;
	private List<int> instruments;

	void Start() {
		soundConePrefab = soundCone;
		instruments = new List<int>();
		instruments.Add (0);
	}

	void OnTriggerEnter(Collider other) {
		GameObject o = FindParentWithTag (other.gameObject, "Item");
		if (o != null) {
			completion++;
			Debug.Log ("completion: " + completion.ToString() + "/" + notesNeeded.ToString());
			Destroy (o);
		}
		o = FindParentWithTag (other.gameObject, "Instrument");
		if (o != null) {
			instruments.Add(other.gameObject.GetComponentInParent<Instrument>().type);
			currentInst = instruments.Count - 1;
			Destroy (other.gameObject);
		}
	}

	void Update() {
		// activate the firing process if the mouse button is pressed
		if (Input.GetMouseButtonDown(0) && !isFiring) {
			foreach (Transform child in transform) { 
				if (child.gameObject.CompareTag("SightCone")) {
					soundCone = Instantiate(soundCone, child.transform.position, child.transform.rotation) as GameObject;
					soundCone.transform.localScale = child.localScale;
					soundCone.GetComponent<FireController>().frequency = frequency;
					soundCone.GetComponent<FireController>().instrument = instruments[currentInst];
					isFiring = true;
					curTime = 0.0f;
				}
			}
		}
		
		if (Input.GetKeyDown("[") || Input.mouseScrollDelta.y < 0) {
			frequency -= 5.0f;
			if (frequency < 130.0f)
				frequency = 130.0f;
			Debug.Log ("frequency: " + frequency.ToString());
		}
		else if (Input.GetKeyDown("]") || Input.mouseScrollDelta.y > 0) {
			frequency += 5.0f;
			if (frequency > 987.0f)
				frequency = 987.0f;
			Debug.Log ("frequency: " + frequency.ToString());
		}

		// allow the player to switch instruments
		if (Input.GetKeyDown ("1")) {
			lastInst = currentInst;
			currentInst = 0;
		} else if (Input.GetKeyDown ("2") && instruments.Count >= 2) {
			lastInst = currentInst;
			currentInst = 1;
		} else if (Input.GetKeyDown ("3") && instruments.Count >= 3) {
			lastInst = currentInst;
			currentInst = 2;
		} else if (Input.GetKeyDown ("4") && instruments.Count >= 4) {
			lastInst = currentInst;
			currentInst = 3;
		} else if (Input.GetKeyDown ("q")) {
			int tmp = currentInst;
			currentInst = lastInst;
			lastInst = tmp;
		}

		if (isFiring) {
			// render the cone
			soundCone.GetComponent<MeshRenderer>().enabled = true;;
			
			Vector3 scale = soundCone.transform.localScale;
			// scale the cone over time according to the scale rate
			soundCone.transform.localScale = new Vector3(scale.x * scaleRate, scale.y * scaleRate, scale.z * scaleRate);
			
			soundCone.transform.Translate(new Vector3(0, moveRate, 0));
			
			// add to the timer and check whether or not we should be done firing
			curTime += Time.deltaTime;
			if (curTime >= fireTime) {
				isFiring = false;
			}
		}
		else if (!soundCone.Equals(soundConePrefab)) {
			Destroy(soundCone);
			soundCone = soundConePrefab;
		}
	}

	public static GameObject FindParentWithTag(GameObject childObject, string tag)
	{
		Transform t = childObject.transform;
		while (t.parent != null)
		{
			if (t.parent.tag == tag)
			{
				return t.parent.gameObject;
			}
			t = t.parent.transform;
		}
		return null; // Could not find a parent with given tag.
	}
}
