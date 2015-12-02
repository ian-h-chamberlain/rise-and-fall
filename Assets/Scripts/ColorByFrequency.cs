using UnityEngine;
using System.Collections;

public class ColorByFrequency : MonoBehaviour {

	public int frequency;

	void Start() {
		gameObject.GetComponent<Renderer>().material.SetColor("_Emission", UnityEditor.EditorGUIUtility.HSVToRGB(frequency / 7.0f, 1.0f, 1.0f)); 
	}
}
