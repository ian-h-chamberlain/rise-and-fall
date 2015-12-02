using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public int score = 0;
	public int instrument = 0;

	public float fireTime;
	public float scaleRate;
	public float moveRate;

	public GameObject soundCone;
	private GameObject soundConePrefab;

	private int frequency;
	private float curTime;
	private bool isFiring = false;

	void Start() {
		soundConePrefab = soundCone;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Item")) {
			score++;
			Destroy (other.gameObject);
		}
		else if (other.gameObject.CompareTag("Instrument")) {
			instrument = other.gameObject.GetComponent<Instrument>().type;
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
					soundCone.GetComponent<FireController>().instrument = instrument;
					isFiring = true;
					curTime = 0.0f;
				}
			}
		}
		
		if (Input.GetKeyDown("[") || Input.mouseScrollDelta.y < 0) {
			frequency--;
			if (frequency < 0)
				frequency = 0;
			Debug.Log ("frequency: " + frequency.ToString());
		}
		else if (Input.GetKeyDown("]") || Input.mouseScrollDelta.y > 0) {
			frequency++;
			if (frequency > 3)
				frequency = 3;
			Debug.Log ("frequency: " + frequency.ToString());
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
}
