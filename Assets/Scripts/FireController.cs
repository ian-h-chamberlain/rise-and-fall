using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

	public Frequency freq;
	
	void OnTriggerStay (Collider other) {
		if (other.gameObject.CompareTag("ItemCapsule")
		    	&& Mathf.Abs(other.gameObject.GetComponentInParent<Frequency>().frequency - freq.frequency) < 5.0f
		    	&& other.gameObject.GetComponentInParent<Frequency>().instrument == freq.instrument) {
			Destroy(other.gameObject);
		}
	}
}
