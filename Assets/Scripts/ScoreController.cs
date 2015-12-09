using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		if (o != null) {
			instruments.Add(other.gameObject.GetComponentInParent<InstContainer>().inst);
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
					GetComponent<TrebleCharacter>().AnimateFire();
					curTime = 0.0f;
				}
			}
		}
	
		// allow the player to switch instruments
		if (Input.GetKeyDown ("1")) {
			lastInst = currentInst;
			currentInst = 0;
			Camera.main.GetComponent<SoundController>().switchInstrument(soundInstruments[0]);
			print("instruments.count="+instruments.Count);
		} else if (Input.GetKeyDown ("2") && instruments.Count >= 2) {
			lastInst = currentInst;
			currentInst = 1;
			Camera.main.GetComponent<SoundController>().switchInstrument(soundInstruments[1]);
			//print ("switching to "+soundInstruments[1].sound.name);
		} else if (Input.GetKeyDown ("q")) {
			int tmp = currentInst;
			currentInst = lastInst;
			lastInst = tmp;
			Camera.main.GetComponent<SoundController>().switchInstrument(soundInstruments[currentInst]);
		}

		if (isFiring) {
			// render the cone
			
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
