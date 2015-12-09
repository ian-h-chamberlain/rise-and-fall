using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBehavior : MonoBehaviour {

	//Progress is in music player -Dan

	public Texture2D t;
	float full_scale;
	float actual_progress;
	
	// Use this for initialization
	void Start () {
		full_scale = GetComponent<RectTransform> ().localScale.x;
		actual_progress = 0;
		GetComponent<RectTransform> ().localScale = new Vector3 (0,
		                                                         GetComponent<RectTransform> ().localScale.y,
		                                                         GetComponent<RectTransform> ().localScale.z);
		
	}
	
	// Update is called once per frame
	void Update () {
		/*TEST STUFF
		if (Input.GetKeyDown(KeyCode.Alpha7)){
			setProgress(0.70f);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha0)){
			setProgress(1.0f);
		}
		*/

		Vector3 scale = GetComponent<RectTransform> ().localScale;

		GetComponent<RectTransform> ().localScale  = new Vector3(full_scale * actual_progress, scale.y, scale.z);

		/*
		if (GetComponent<RectTransform> ().localScale.x < full_scale * (actual_progress)) {
			GetComponent<RectTransform> ().localScale = new Vector3 (GetComponent<RectTransform> ().localScale.x + 0.1f,
			                                                         GetComponent<RectTransform> ().localScale.y,
			                                                         GetComponent<RectTransform> ().localScale.z);
		} else if (GetComponent<RectTransform> ().localScale.x > full_scale * (actual_progress)) {
			GetComponent<RectTransform> ().localScale = new Vector3( full_scale * (actual_progress),
			                                                        GetComponent<RectTransform> ().localScale.y,
			                                                        GetComponent<RectTransform> ().localScale.z);
		}
		*/
		
		
	}
	
	public void setProgress(float prog){
		actual_progress = prog;
		
	}
}
