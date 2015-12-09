using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {

	public AudioSource sound;
	AudioClip current_sound;
	public Image marker;
	public Image sliderback;
	bool markerUp = true;
	int waiting_to_switch_dir = 0;

	public Instrument current_inst;

	public ParticleSystem boom;

	public GameObject targetDestr;
	public bool sliderActive = false;
	bool fade_sound_and_jitter;

	public AudioSource secret_2nd_audio;

	int WAIT_TIME = 50;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();
		sound.pitch = 1;

		current_inst = GameObject.FindObjectOfType<ScoreController>().soundInstruments[0];

		current_sound = current_inst.sound;
		setPitchRelatedVars ();
		sliderback.color= current_inst.col;
		secret_2nd_audio.GetComponent<SecondAudio> ().SetBrackets (current_inst.minPitch, 
		                                                           current_inst.maxPitch, 
		                                                           current_inst.sound);

	}
	
	// Update is called once per frame
	void Update () {

		// checkForInstrumentSwitch ();

		if (Input.GetMouseButtonDown(1))
			PitchSwitch ();

		if (sliderActive){
		
			moveMarker ();

		}

		if (fade_sound_and_jitter) {
			sound.volume-=0.1f;
		}

	}

	public void switchInstrument(Instrument inst) {
		print("Instrument " + inst.type.ToString() + " selected");
		current_inst = inst;
		current_sound = inst.sound;
		setPitchRelatedVars();
		sliderback.color = inst.col;
		secret_2nd_audio.GetComponent<SecondAudio> ().SetBrackets (current_inst.minPitch, 
		                                                           current_inst.maxPitch, 
		                                                           current_inst.sound);
	}

	void setPitchRelatedVars(){
		marker.GetComponent<MarkerBehavior>().instrumentMax = current_inst.maxPitch;
		marker.GetComponent<MarkerBehavior>().instrumentMin = current_inst.minPitch;
	}

	void moveMarker(){
		if (markerUp && sound.pitch < current_inst.maxPitch) {//for example
			sound.pitch = Mathf.Lerp (sound.pitch, sound.pitch + 0.1f, 0.05f);
			marker.GetComponent<MarkerBehavior>().moveUp();
		} else if ( !markerUp && sound.pitch > current_inst.minPitch) {//for example
			sound.pitch = Mathf.Lerp (sound.pitch, sound.pitch - 0.1f, 0.05f);
			marker.GetComponent<MarkerBehavior>().moveDown();
		}
		//quick checks
		if (sound.pitch > current_inst.maxPitch)
			sound.pitch = current_inst.maxPitch;
		else if (sound.pitch < current_inst.minPitch) {
			sound.pitch = current_inst.minPitch;
		}
		
		checkToReverse ();
	}
	
	void checkToReverse(){
		if ( ( sound.pitch==current_inst.maxPitch || sound.pitch==current_inst.minPitch) && waiting_to_switch_dir == 0) {
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

	void PitchSwitch(){
		// print ("it's pitch switch time!");

		if (!sliderActive) {
			sliderActive = true;
			sound.clip = current_sound;
			if (!sound.isPlaying) sound.Play ();
		} 
		else {
			sliderActive=false;
			StartCoroutine("WaitThenPauseSound");
			secret_2nd_audio.GetComponent<SecondAudio>().fadeSound();

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


}