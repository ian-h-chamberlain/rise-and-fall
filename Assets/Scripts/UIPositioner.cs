using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPositioner : MonoBehaviour {
	public float x_offset;
	public float y_offset;
	public string note = "Offsets are the fraction of the way up and across the screen the object is";
	public Camera cam;
	public Image marker =null;

	// Use this for initialization
	void Start () {
		float x_pos = x_offset * Screen.width;
		float y_pos = y_offset * Screen.height;
		transform.position = new Vector3(x_pos, y_pos, 0);

		if (name == "SlideBackBW") {
			//let Marker know we're all set
			marker.GetComponent<MarkerBehavior> ().go = true;
		} else {
		}
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
