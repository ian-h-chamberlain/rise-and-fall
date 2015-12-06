using UnityEngine;
using System.Collections;

public class rotateAndColor : MonoBehaviour {
	public float rate=1;
	public Color col;
	
	// Use this for initialization
	void Start () {
		GetComponent<Light> ().color = col;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Transform> ().Rotate(0,0,rate);
	}
}
