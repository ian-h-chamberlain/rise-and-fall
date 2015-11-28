using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

	private bool isFiring;
	private float curTime;
	private int frequency;

	public float fireTime;
	public float scaleRate;
	private Vector3 originalScale;

	void Start() {
		originalScale = gameObject.transform.localScale;
		frequency = 2;
	}

	void OnTriggerStay (Collider other) {
		if (isFiring && other.gameObject.CompareTag("ItemCapsule/Caps" + frequency.ToString())) {
			Destroy(other.gameObject);
		}
	}

	void Update() {
		// activate the firing process if the mouse button is pressed
		if (Input.GetMouseButtonDown(0) && !isFiring) {
			isFiring = true;
			curTime = 0.0f;
		}

		if (Input.GetKeyDown("[")) {
			frequency--;
			Debug.Log ("frequency: " + frequency.ToString());
		}
		else if (Input.GetKeyDown("]")) {
			frequency++;
			Debug.Log ("frequency: " + frequency.ToString());
		}

		if (isFiring) {
			// render the cone
			gameObject.GetComponent<MeshRenderer>().enabled = true;

			Vector3 scale = gameObject.transform.localScale;
			// scale the cone over time according to the scale rate
			gameObject.transform.localScale = new Vector3(scale.x * scaleRate, scale.y * scaleRate, scale.z * scaleRate);

			// add to the timer and check whether or not we should be done firing
			curTime += Time.deltaTime;
			if (curTime >= fireTime) {
				isFiring = false;
			}
		}
		else {
			gameObject.GetComponent<MeshRenderer>().enabled = false;
			gameObject.transform.localScale = originalScale;
		}
	}
}
