using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public int score = 0;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Item")) {
			score++;
			Destroy (other.gameObject);
		}
	}
}
