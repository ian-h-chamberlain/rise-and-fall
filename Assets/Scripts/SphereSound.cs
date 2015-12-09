using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SphereSound : MonoBehaviour {
	
	public float scale = Mathf.Pow (2f,1.0f/12f);
	AudioSource sound;
	public AudioClip mario;
	public AudioClip flute;
	public Image marker;
	bool markerUp = true;
	int waiting_to_switch_dir = 0;


	public float maxPitch = 1.909999f;
	public float minPitch = 0.9450001f;
	float targetPitch;

	bool destroySequence = false;
	int countdown_to_destruction = 70;
	public ParticleSystem boom;
	/*capture desired min and max
	public float A;
	public float B;
	*/

	int WAIT_TIME = 50; 

	void Start(){}

	void Update(){}
}
//	
//	
//	void Start () {  
//		
//		sound = GetComponent<AudioSource> ();
//		sound.Play ();
//		sound.pitch = 1;
//
//		targetPitch = Random.Range (minPitch, maxPitch);
//	}
//
//	void Update(){
//		if (destroySequence) {
//			countdown_to_destruction--;
//			GetComponent<Jitter>().jitter();
//			if (countdown_to_destruction == 0) {
//				Instantiate(boom, transform.position, Quaternion.identity);
//				transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
//			}
//			if (countdown_to_destruction < 0 && countdown_to_destruction > -50){
//				sound.volume-=0.1f;
//			}
//			if (countdown_to_destruction == -50){
//				sound.Pause();
//			}
//		} 
//
//		else {
//
//			moveMarker ();
//
//			checkForTarget ();
//		}
//
//			/*capture desired min and max
//		if (Input.GetKeyDown (KeyCode.A)) {
//			A = sound.pitch;
//		}
//		else if (Input.GetKeyDown (KeyCode.B)) {
//			B = sound.pitch;
//		}
//		*/
//
//		
//	}
//
//	public void playMario(){
//		if (sound.clip != mario) {
//			sound.clip = mario;
//			sound.pitch=1;
//			sound.Play ();
//		}
//	}
//
//	public void playFlute(){
//		if (sound.clip != flute) {
//			sound.clip = flute;
//			sound.pitch=1;
//			sound.Play ();
//		}
//	}
//
//	void moveMarker(){
//		if (markerUp && sound.pitch < maxPitch) {//for example
//			sound.pitch = Mathf.Lerp (sound.pitch, sound.pitch + 0.1f, 0.05f);
//			marker.GetComponent<MarkerBehavior>().moveUp();
//		} else if ( !markerUp && sound.pitch > minPitch) {//for example
//			sound.pitch = Mathf.Lerp (sound.pitch, sound.pitch - 0.1f, 0.05f);
//			marker.GetComponent<MarkerBehavior>().moveDown();
//		}
//		//quick checks
//		if (sound.pitch > maxPitch)
//			sound.pitch = maxPitch;
//		else if (sound.pitch < minPitch) {
//			sound.pitch = minPitch;
//		}
//
//		checkToReverse ();
//	}
//
//	void checkToReverse(){
//		if ( ( sound.pitch==maxPitch || sound.pitch==minPitch) && waiting_to_switch_dir == 0) {
//			waiting_to_switch_dir = WAIT_TIME;
//		}
//		if (waiting_to_switch_dir == 1) {
//			if (markerUp) markerUp = false;
//			else markerUp = true; 
//		}
//		waiting_to_switch_dir--;
//		if (waiting_to_switch_dir < 0)
//			waiting_to_switch_dir = 0;
//	}
//
//	void checkForTarget(){
//		if (Mathf.Abs (sound.pitch - targetPitch)<0.05f) {
//			GetComponent<Jitter>().jitter ();
//			if (Input.GetKeyDown(KeyCode.Space))
//				destroySequence = true;
//		}
//	}
//
//
//	float MapVals(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
//		     
//		float OldRange = (OldMax - OldMin);
//		float NewRange = (NewMax - NewMin);
//		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
//		     
//		return(NewValue);
//	}
//
//	
//}