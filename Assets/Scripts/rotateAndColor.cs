using UnityEngine;
using System.Collections;

public class rotateAndColor : MonoBehaviour {
	public float rate=1;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Transform> ().Rotate(0,0,rate);
	}
}
