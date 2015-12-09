using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MarkerBehavior : MonoBehaviour {
	public bool go = false;
	public Image sliderback;
	public GameObject sphere;
	float sliderTop_y;
	float sliderBottom_y;
	public float instrumentMax;
	public float instrumentMin;
	public Camera sc;

	// Use this for initialization
	void Start () {
		sliderTop_y = sliderback.transform.position.y + sliderback.GetComponent<RectTransform> ().rect.height / 2;
		sliderBottom_y = sliderback.transform.position.y - sliderback.GetComponent<RectTransform> ().rect.height / 2;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (go) {
			starrt();
		}

		//getInstrumentMinMax ();
	}
 
	void starrt(){
		go = false;
		transform.position = new Vector3(sliderback.transform.position.x /*- sliderback.GetComponent<RectTransform>().rect.width / 2*/,
		                      sliderback.transform.position.y /*- sliderback.GetComponent<RectTransform> ().rect.height / 2*/,
		                      0);
	}

	public void moveUp(){
		mapToInstrumentRange ();
		/*
		float destination = MapVals (instrumentMin, instrumentMax, sliderBottom_y, sliderTop_y, transform.position.y+50);
		print ("Destination=" + destination);
		transform.position = new Vector3 (transform.position.x, 
		                                  Mathf.Lerp(transform.position.y,destination, 0.05f), 
		                                  0);
		                                  */
	}

	public void moveDown(){
		mapToInstrumentRange ();
		/*
		transform.position = new Vector3 (transform.position.x, 
		                                  Mathf.Lerp(transform.position.y,transform.position.y-50, 0.05f), 
		                                  0);
		                                  */
	}

	float MapVals(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
		     
		return(NewValue);
	}

	void getInstrumentMinMax(){
		instrumentMax = sc.GetComponent<SoundController> ().current_inst.maxPitch;
		instrumentMin = sc.GetComponent<SoundController> ().current_inst.minPitch;
	}

	void mapToInstrumentRange(){
		float current_pitch = sc.GetComponent<SoundController> ().sound.pitch;
		float percentage_to_maxPitch = (current_pitch-instrumentMin) / (instrumentMax-instrumentMin);
		// print ("percentage to maxPitch =" + percentage_to_maxPitch + ",instrumentMin="+instrumentMin+",instrumentMax="+instrumentMax);
		transform.position = new Vector3 (transform.position.x,
		                                 percentage_to_maxPitch*(sliderTop_y-sliderBottom_y)*5+sliderBottom_y+10,
		                                 0);
		//if (transform.position.y < sliderBottom_y) {
		//	transform.position = new Vector3 (transform.position.x, sliderBottom_y+3, 0);
		//}
	}
}
