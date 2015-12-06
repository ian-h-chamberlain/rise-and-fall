using UnityEngine;
using System.Collections;

public class Destructability : MonoBehaviour {
	Camera main_camera;
	int THRESHHOLD_FOR_DESTROY = 10;
	public float epsilon = 0.1f;
	int NUM_INSTRUMENTS=1;
	public float myTargetPitch;
	public int instrumentNum;
	public AudioClip instrument;//the instrument I need to be destroyed by
	float minPitch = 0f; //to be determined by the instrument applicable 
	float maxPitch = 1f; //to this destructible
	public ParticleSystem boom;
	public ParticleSystem onFreq;
	ParticleSystem particles;
	int particleWaitTime= 0;
	int waitForMoreParticles = 0;
	Color thisColor;

	// Use this for initialization
	void Start () {
		//int instr_num = (int)Random.Range (0, NUM_INSTRUMENTS);

		main_camera = Camera.main;

		Instrument i = FindObjectOfType<ScoreController> ().soundInstruments [instrumentNum];

		instrument = i.sound;
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
		    && main_camera.GetComponent<SoundController>().current_sound == instrument) {
			// GetComponentInParent<Jitter>().startJitter();
			if(particles == null){
				particles = (ParticleSystem) Instantiate(onFreq, transform.position, Quaternion.identity);
				particles.startColor = thisColor;
				particles.GetComponent<rotateAndColor>().col = thisColor;
				waitForMoreParticles = particleWaitTime;
			}
			else{
				// waitForMoreParticles--;
			}

		}
		else if (particles != null) {
			Destroy (particles.gameObject);
			Debug.Log ("destroying particleSystem " + particles.ToString());
			particles = null;
		}
	}

	public void DestructionSequence(){
		print ("KaBOOM!");

		if (particles != null) {
			Destroy (particles.gameObject);
		}

		particles = (ParticleSystem) Instantiate (boom, transform.position, Quaternion.identity);
		particles.startColor = thisColor;
		Destroy (gameObject);

	}
	
}