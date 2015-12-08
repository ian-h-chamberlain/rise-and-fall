using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

	public Frequency freq;

	void OnTriggerStay (Collider other) {
		Destructability d = other.gameObject.GetComponentInParent<Destructability> ();

		if (other.gameObject.CompareTag("ItemCapsule")
		    	&& d != null
		    	&& Mathf.Abs(d.myTargetPitch - Camera.main.GetComponent<SoundController>().sound.pitch) < d.epsilon
		    	&& d.instrument == Camera.main.GetComponent<SoundController>().current_inst.type) {

			other.gameObject.GetComponent<Destructability>().DestructionSequence();
		}
	}

	void Start(){
		GameObject notes = GameObject.Find ("NoteAudioSource");
		AudioSource my_audio = GetComponent<AudioSource> ();
		my_audio.clip = notes.GetComponent<AudioSource> ().clip;
		my_audio.Play ();
	}
}
