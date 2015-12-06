using UnityEngine;
using System.Collections;

public class Destructability : MonoBehaviour {
	public Camera main_camera;
	int THRESHHOLD_FOR_DESTROY = 10;
	float epsilon = 0.1f;
	int NUM_INSTRUMENTS=1;
	float myTargetPitch;
	public AudioClip instrument;//the instrument I need to be destroyed by
	float minPitch = 0f; //to be determined by the instrument applicable 
	float maxPitch = 1f; //to this destructible
	public ParticleSystem boom;
	public ParticleSystem onFreq;
	int particleWaitTime= 50;
	int waitForMoreParticles = 0;

	// Use this for initialization
	void Start () {
		//int instr_num = (int)Random.Range (0, NUM_INSTRUMENTS);

		SoundController sc = main_camera.GetComponent<SoundController> ();

		if (instrument == sc.instrument1) {
			minPitch = sc.Instr1MinPitch;
			maxPitch = sc.Instr1MaxPitch;
			epsilon = sc.Instr1Epsilon;

		}

		if (instrument == sc.instrument2) {
			minPitch = sc.Instr2MinPitch;
			maxPitch = sc.Instr2MaxPitch;
			epsilon = sc.Instr2Epsilon;
		}

		//print ("instrument.name: "+instrument.name);

		myTargetPitch = Random.Range (minPitch, maxPitch);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			TESTDestructionWithoutCollision ();
		}
		jitterWithoutCollision ();
	}

	void OnCollisionEnter(Collision collision){
		for (int i=0; i < collision.contacts.GetLength(0); i++) {
			if (collision.contacts[i].otherCollider.GetType()==typeof(Camera) /*WAVE*/
			    && Mathf.Abs(main_camera.GetComponent<SoundController>().sound.pitch - myTargetPitch)<epsilon){
				/*if (Vector3.Distance(collision.contacts[i].otherCollider.GetComponent<Transform>().position,
				                     this.GetComponent<Transform>().position)<THRESHHOLD_FOR_DESTROY){*/
					DestructionSequence();
				/*}
				else{*/
					//emit particles
					/*GetComponent<Jitter>().jitter();*/
				/*}*/
			}
		}
	}

	void TESTDestructionWithoutCollision(){
		if (Mathf.Abs (main_camera.GetComponent<SoundController> ().sound.pitch - myTargetPitch) < epsilon) {
			DestructionSequence();
		}
	}

	void jitterWithoutCollision(){
		if (Mathf.Abs (main_camera.GetComponent<SoundController> ().sound.pitch - myTargetPitch) < epsilon
		    && main_camera.GetComponent<SoundController>().sound.isPlaying) {
			GetComponent<Jitter>().jitter();
			if(waitForMoreParticles==0){ 
				Instantiate(onFreq, transform.position, Quaternion.identity);
				waitForMoreParticles = particleWaitTime;
			}
			else{
				waitForMoreParticles--;
			}

		}
	}

	void DestructionSequence(){
		print ("KaBOOM!");
		Instantiate (boom, transform.position, Quaternion.identity);
		Destroy (gameObject);

	}
	
}