﻿using UnityEngine;
using System.Collections;

public class Frequency: MonoBehaviour {

	public int instrument;
	public float frequency;

	void Awake() {
		if (gameObject.CompareTag("Item") || gameObject.CompareTag("Joke")) {
			instrument = Random.Range (0, 5);
			GetComponentInChildren<Destructability>().instrument = instrument;
		}
	}


	void Start() {
		ScoreController sc = GameObject.FindObjectOfType<ScoreController>();

		// set color according to instrument
		if (gameObject.CompareTag("ItemCapsule") || gameObject.CompareTag("SoundCone"))
			gameObject.GetComponent<Renderer>().material.SetColor("_Emission", sc.soundInstruments[instrument].col);
		
		foreach (Transform child in transform) {
			if (child.CompareTag("ItemCapsule") || child.CompareTag("SoundCone"))
				child.gameObject.GetComponent<Renderer>().material.SetColor("_Emission", sc.soundInstruments[instrument].col);
	    }
	}
}
