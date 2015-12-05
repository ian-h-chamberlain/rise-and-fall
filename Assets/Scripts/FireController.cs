using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

	public float frequency;
	public int instrument;

	void Start() {
		gameObject.GetComponent<Frequency>().instrument = instrument;
	}

	void OnTriggerStay (Collider other) {
		if (other.gameObject.CompareTag("ItemCapsule")
		    	&& Mathf.Abs(other.gameObject.GetComponentInParent<Frequency>().frequency - frequency) < 5.0f
		    	&& other.gameObject.GetComponentInParent<Frequency>().instrument == instrument) {
			Destroy(other.gameObject);
		}
	}
}
