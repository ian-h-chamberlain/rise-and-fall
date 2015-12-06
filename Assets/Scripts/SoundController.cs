using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {
	//hardcode instrument-specific 
	//values here:
	public float Instr1MaxPitch= 1.909999f;
	public float Instr1MinPitch= 0.9450001f;
	public float Instr1Epsilon = 0.05f;
	public Color Instr1Color = Color.blue;

	public float Instr2MaxPitch= 1.04f;
	public float Instr2MinPitch= 0.725f;
	public float Instr2Epsilon = 0.02f;
	public Color Instr2Color = Color.red;
	//-----------------------


	public AudioSource sound;
	public AudioClip instrument1;
	public AudioClip instrument2;
	AudioClip current_sound;
	public Image marker;
	public Image sliderback;
	bool markerUp = true;
	int waiting_to_switch_dir = 0;
	
	public float maxPitch = 1.909999f;
	public float minPitch = 0.9450001f;
	public float epsilon = 0.05f;
	float targetPitch;
	
	bool destroySequence = false;
	int countdown_to_destruction = 70;
	public ParticleSystem boom;

	public GameObject targetDestr;
	public bool sliderActive = false;
	bool fade_sound_and_jitter;

	public float A;
	public float B;

	int WAIT_TIME = 50;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();
		sound.pitch = 1;
		current_sound = instrument1;

		choosePitchRange ();
		setPitchRelatedVars ();
		sliderback.color= Instr1Color;

	}
	
	// Update is called once per frame
	void Update () {

		checkForInstrumentSwitch ();

		if (Input.GetMouseButtonDown(1))
			PitchSwitch ();

		if (sliderActive){
		
			moveMarker ();
			
			checkForTarget ();

		}

		if (fade_sound_and_jitter) {
			sound.volume-=0.1f;
		}
		

	}

	void checkForInstrumentSwitch(){
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			print("Instrument 1 selected");
			current_sound = instrument1;
			setPitchRelatedVars();
			sliderback.color= Instr1Color;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)){
			print("Instrument 2 selected");
			current_sound = instrument2;
			choosePitchRange ();
			setPitchRelatedVars();
			sliderback.color = Instr2Color;
		}
	}

	void setPitchRelatedVars(){
		choosePitchRange ();
		marker.GetComponent<MarkerBehavior>().instrumentMax = maxPitch;
		marker.GetComponent<MarkerBehavior>().instrumentMin = minPitch;
	}

	void moveMarker(){
		if (markerUp && sound.pitch < maxPitch) {//for example
			sound.pitch = Mathf.Lerp (sound.pitch, sound.pitch + 0.1f, 0.05f);
			marker.GetComponent<MarkerBehavior>().moveUp();
		} else if ( !markerUp && sound.pitch > minPitch) {//for example
			sound.pitch = Mathf.Lerp (sound.pitch, sound.pitch - 0.1f, 0.05f);
			marker.GetComponent<MarkerBehavior>().moveDown();
		}
		//quick checks
		if (sound.pitch > maxPitch)
			sound.pitch = maxPitch;
		else if (sound.pitch < minPitch) {
			sound.pitch = minPitch;
		}
		
		checkToReverse ();
	}
	
	void checkToReverse(){
		if ( ( sound.pitch==maxPitch || sound.pitch==minPitch) && waiting_to_switch_dir == 0) {
			waiting_to_switch_dir = WAIT_TIME;
		}
		if (waiting_to_switch_dir == 1) {
			if (markerUp) markerUp = false;
			else markerUp = true; 
		}
		waiting_to_switch_dir--;
		if (waiting_to_switch_dir < 0)
			waiting_to_switch_dir = 0;
	}
	
	void checkForTarget(){
		if (Mathf.Abs (sound.pitch - targetPitch)<epsilon) {
			GetComponent<Jitter>().jitter ();
			if (Input.GetKeyDown(KeyCode.Space))
				destroySequence = true;
		}
	}

	void PitchSwitch(){
		print ("it's pitch switch time!");

		if (!sliderActive) {
			sliderActive = true;
			sound.clip = current_sound;
			if (!sound.isPlaying) sound.Play ();
		} 
		else {
			sliderActive=false;
			StartCoroutine("WaitThenPauseSound");

		}
	}

	IEnumerator WaitThenPauseSound(){
		yield return new WaitForSeconds(1.75f);

		fade_sound_and_jitter = true;

		yield return new WaitForSeconds (.25f);

		fade_sound_and_jitter = false;
		if (!sliderActive) sound.Pause ();
		sound.volume = 1;

	}

	void choosePitchRange(){
		if (current_sound == instrument1) {
			//flute
			maxPitch = Instr1MaxPitch;
			minPitch = Instr1MinPitch;
			epsilon = Instr1Epsilon;
		} 
		else if (current_sound == instrument2) {
			//yodel
			minPitch = Instr2MinPitch;
			maxPitch = Instr2MaxPitch;
			epsilon = Instr2Epsilon;
		}
	}


}


























