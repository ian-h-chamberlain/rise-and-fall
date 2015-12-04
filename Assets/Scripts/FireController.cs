using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

	public int frequency;
	public int instrument;

	void Start() {
		gameObject.GetComponent<Frequency>().instrument = instrument;
	}

	void OnTriggerStay (Collider other) {
		if (other.gameObject.CompareTag("ItemCapsule") && other.gameObject.GetComponent<Frequency>().frequency == frequency) {
			if (other.gameObject.GetComponent<Instrument>() == null)
				Destroy(other.gameObject);
			else if (instrument == other.gameObject.GetComponent<Instrument>().type && other.gameObject.GetComponent<Frequency>().frequency == frequency) {
				Destroy(other.gameObject);
			}
		}
	}
}
