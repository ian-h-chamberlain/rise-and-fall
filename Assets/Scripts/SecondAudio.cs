using UnityEngine;
using System.Collections;

public class SecondAudio : MonoBehaviour {
	ArrayList divs; // = new ArrayList();
	SoundController sc;
	AudioClip instrument;
	float current_min;
	float current_max;
	bool fade_sound;

	/*
	 * To add this to a project:
	 * 		add a reference to this SecretSecondAudio object to SoundController on MainCamera
	 * 		and add calls to SetBrackets() to each instrument's block in SetInstrument and 
	 * 		in Start()
	 * 		In SoundController.PitchSwitch(), add [reference to this code].fadeSound() after
	 * 		StartCoroutine("WaitForSeconds")
	 * */

	void Awake() {
		divs = new ArrayList();
		
		for (int i = 0; i<8; i++) {
			float d = 0.0f;
			divs.Add (d);
		}
	}

	// Use this for initialization
	void Start () {
		sc = Camera.main.GetComponent<SoundController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (sc.sliderActive) {
			if (sc.sound.volume != 0) {
				sc.sound.mute = true;
			} 
			playNote ();
		}

		if (fade_sound) {
			GetComponent<AudioSource>().volume-=0.1f;
		}
	}

	public void SetBrackets(float min, float max, AudioClip ins){
		//called when a new instrument is chosen
		for (int i = 0; i<8; i++) {
			Debug.Log ("divs is " + divs.Count);
			divs[i] = (float)(max-min)*((float)i/8)+min;

		}
		instrument = ins;
		GetComponent<AudioSource> ().clip = instrument;
		print ("Max" + max + ",Min" + min);
		for (int x=0; x<divs.Count; x++)
			print (divs [x]);

		current_min = min;
		current_max = max;
	}

	public void playNote(){
//		for (int i = 7; i>=0; i--) {
//			if (i < 7) {
//				if (sc.sound.pitch > (float) divs [i] && sc.sound.pitch <(float) divs [i + 1]) {
//					GetComponent<AudioSource> ().pitch = (float) divs [i];
//					if (!GetComponent<AudioSource> ().isPlaying)
//						GetComponent<AudioSource> ().Play ();
//				}
//			} else {
//				if (sc.sound.pitch > (float) divs [i]) {
//					GetComponent<AudioSource> ().pitch = (float) divs [i];
//					if (!GetComponent<AudioSource> ().isPlaying)
//						GetComponent<AudioSource> ().Play ();
//				}
//			}
//		}

	
		for (int i = 7; i>=0; i--) {
			if (i < 7) {
				if (sc.sound.pitch > (float)divs [i] && sc.sound.pitch < (float)divs [i + 1]) {
					GetComponent<AudioSource> ().pitch = current_min * Mathf.Pow(1.05946f , (float) i+1f);
					if (!GetComponent<AudioSource> ().isPlaying)
						GetComponent<AudioSource> ().Play ();
				}
			} else {
				if (sc.sound.pitch > (float)divs [i]) {
					GetComponent<AudioSource> ().pitch = current_min * Mathf.Pow(1.05946f , (float) i+1f);
					if (!GetComponent<AudioSource> ().isPlaying)
						GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}

	IEnumerator WaitThenPauseSound(){
		yield return new WaitForSeconds(1.75f);
		
		fade_sound = true;
		
		yield return new WaitForSeconds (.25f);
		
		fade_sound = false;
		if (!sc.sliderActive) GetComponent<AudioSource>().Pause ();
		GetComponent<AudioSource>().volume = 1;
		
	}

	public void fadeSound(){
		StartCoroutine("WaitThenPauseSound");
	}

}
