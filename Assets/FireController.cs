using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {
	
	void OnTriggerStay (Collider other) {
		if (Input.GetMouseButton(0) && other.gameObject.CompareTag("ItemCapsule")) {
			Destroy(other.gameObject);
		}
	}

	void Update() {
		if (Input.GetMouseButton(0)) {
			gameObject.GetComponent<MeshRenderer>().enabled = true;
		}
		else {
			gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
	}
}
