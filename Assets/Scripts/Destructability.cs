using UnityEngine;
using System.Collections;

public class Destructability : MonoBehaviour {
	Camera main_camera;
	public float epsilon = 0.1f;
	public float myTargetPitch;
	public int instrument;
	float minPitch = 0f; //to be determined by the instrument applicable 
	float maxPitch = 1f; //to this destructible
	public GameObject boom;
	public GameObject onFreq;
	GameObject particles;
	Color thisColor;

	// Use this for initialization
	void Start () {
		//int instr_num = (int)Random.Range (0, NUM_INSTRUMENTS);

		main_camera = Camera.main;

		Instrument i = FindObjectOfType<ScoreController> ().soundInstruments [instrument];

		minPitch = i.minPitch;
		maxPitch = i.maxPitch;
		epsilon = i.epsilon;
		thisColor = i.col;

		//print ("instrument.name: "+instrument.name);

		myTargetPitch = Random.Range (minPitch, maxPitch);
	}
	
	// Update is called once per frame
	void Update () {
		jitterWithoutCollision ();
	}

	/*
	void OnCollisionEnter(Collision collision){
		for (int i=0; i < collision.contacts.GetLength(0); i++) {
			if (collision.contacts[i].otherCollider.GetType()==typeof(Camera) // WAVE 
			    && Mathf.Abs(main_camera.GetComponent<SoundController>().sound.pitch - myTargetPitch)<epsilon){
				if (Vector3.Distance(collision.contacts[i].otherCollider.GetComponent<Transform>().position,
				                     this.GetComponent<Transform>().position)<THRESHHOLD_FOR_DESTROY){
					DestructionSequence();
				}
				else{
					//emit particles
					GetComponent<Jitter>().jitter();
				}
			}
		}
	}
	*/

	void TESTDestructionWithoutCollision(){
		if (Mathf.Abs (main_camera.GetComponent<SoundController> ().sound.pitch - myTargetPitch) < epsilon) {
			DestructionSequence();
		}
	}

	void jitterWithoutCollision(){
		if (Mathf.Abs (main_camera.GetComponent<SoundController> ().sound.pitch - myTargetPitch) < epsilon
		    	&& main_camera.GetComponent<SoundController>().sound.isPlaying
		    	&& main_camera.GetComponent<SoundController>().current_inst.type == instrument) {

			if (particles == null){
				particles = Instantiate(onFreq, transform.position, Quaternion.identity) as GameObject;
				Debug.Log ("instantiating jitter particles");
				particles.GetComponent<ParticleSystem>().startColor = thisColor;
				if (particles.GetComponent<rotateAndColor>() != null)
					particles.GetComponent<rotateAndColor>().col = thisColor;
			}
		}
		else if (particles != null ) {
			Destroy (particles);
			particles = null;
		}
	}

	public void DestructionSequence(){
		print ("KaBOOM!");

		if (particles != null) {
			Destroy (particles);
		}

		GameObject explosion = Instantiate (boom, transform.position, Quaternion.identity) as GameObject;
		explosion.GetComponent<ParticleSystem>().startColor = thisColor;
		Destroy (gameObject);

	}
	
}