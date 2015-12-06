using UnityEngine;
using System.Collections;

public class Frequency: MonoBehaviour {

	public int instrument;
	public float frequency;
	public AudioClip soundInstrument;

	void Start() {
		// set color according to instrument
		if (gameObject.CompareTag("ItemCapsule") || gameObject.CompareTag("SoundCone"))
			gameObject.GetComponent<Renderer>().material.SetColor("_Emission", UnityEditor.EditorGUIUtility.HSVToRGB(instrument / 8.0f, 1.0f, 1.0f));
		
		foreach (Transform child in transform) {
			if (child.CompareTag("ItemCapsule") || child.CompareTag("SoundCone"))
				child.gameObject.GetComponent<Renderer>().material.SetColor("_Emission", UnityEditor.EditorGUIUtility.HSVToRGB(instrument / 8.0f, 1.0f, 1.0f));
	    }
	}
}
