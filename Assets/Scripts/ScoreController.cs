using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public float fireTime;
	public float scaleRate;
	public float moveRate;

	public int notesNeeded;
	private int completion = 0;

	private GameObject soundCone;
	public GameObject soundConePrefab;

	private float curTime;
	private bool isFiring = false;

	private int currentInst = 0;
	private int lastInst = 0;
	private List<int> instruments;
	public List<Instrument> soundInstruments;

	public GameObject uiInstrumentPicture;

	void Start() {
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
		if (o != null && other.gameObject.GetComponentInParent<InstContainer>() != null) {
			instruments.Add(other.gameObject.GetComponentInParent<InstContainer>().inst);
			currentInst = instruments.Count - 1;
			Destroy (other.gameObject);
		}
	}

	void Update() {
		// activate the firing process if the mouse button is pressed
		if (Input.GetMouseButtonDown(0) && !isFiring) {
			foreach (Transform child in transform) { 
				if (child.gameObject.CompareTag("SoundCone")) {
					soundCone = Instantiate(soundConePrefab, child.transform.position, child.transform.rotation) as GameObject;
					soundCone.transform.localScale = child.localScale;
					soundCone.GetComponent<FireController>().freq.instrument = currentInst;
					isFiring = true;
					curTime = 0.0f;
				}
			}
		}
	
		// allow the player to switch instruments
		if (Input.GetKeyDown ("1")) {
			lastInst = currentInst;
			currentInst = 0;
			Camera.main.GetComponent<SoundController> ().switchInstrument (soundInstruments [0]);
			uiInstrumentPicture.GetComponent<PickInstrumentForUI>().SetInstrument(0);
		} else if (Input.GetKeyDown ("2") && instruments.Count >= 2) {
			lastInst = currentInst;
			currentInst = 1;
			Camera.main.GetComponent<SoundController> ().switchInstrument (soundInstruments [1]);
			uiInstrumentPicture.GetComponent<PickInstrumentForUI>().SetInstrument(1);
		} else if (Input.GetKeyDown ("3") && instruments.Count >= 3) {
			lastInst = currentInst;
			currentInst = 2;
			Camera.main.GetComponent<SoundController> ().switchInstrument (soundInstruments [2]);
			uiInstrumentPicture.GetComponent<PickInstrumentForUI>().SetInstrument(2);
		} else if (Input.GetKeyDown ("4") && instruments.Count >= 4) {
			lastInst = currentInst;
			currentInst = 3;
			Camera.main.GetComponent<SoundController> ().switchInstrument (soundInstruments [3]);
			uiInstrumentPicture.GetComponent<PickInstrumentForUI>().SetInstrument(3);
		} else if (Input.GetKeyDown ("5") && instruments.Count >= 5) {
			lastInst = currentInst;
			currentInst = 4;
			Camera.main.GetComponent<SoundController>().switchInstrument(soundInstruments[4]);
			uiInstrumentPicture.GetComponent<PickInstrumentForUI>().SetInstrument(4);
		} else if (Input.GetKeyDown ("q")) {
			int tmp = currentInst;
			currentInst = lastInst;
			lastInst = tmp;
			Camera.main.GetComponent<SoundController>().switchInstrument(soundInstruments[currentInst]);
			uiInstrumentPicture.GetComponent<PickInstrumentForUI>().SetInstrument(currentInst);
		}

		if (isFiring) {
			// render the cone
			soundCone.GetComponent<MeshRenderer>().enabled = true;
			
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
		if (!isFiring && soundCone != null) {
			Destroy(soundCone);
			soundCone = null;
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
