using UnityEngine;
using System.Collections;

public class Frequency: MonoBehaviour {

	public int instrument;
	public int frequency;

	void Start() {
		gameObject.GetComponent<Renderer>().material.SetColor("_Emission", UnityEditor.EditorGUIUtility.HSVToRGB(instrument / 8.0f, 1.0f, 1.0f)); 
	}
}
