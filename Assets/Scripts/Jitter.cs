using UnityEngine;
using System.Collections;

public class Jitter : MonoBehaviour {
	float saved_x;
	float saved_y;
	float saved_z;
	bool do_jitter= false;
	int t;

	// Use this for initialization
	void Start () {
		saved_x = transform.position.x;
		saved_y = transform.position.y;
		saved_z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (do_jitter) {
			jitter ();
		}
	}

	public void jitter(){
		transform.position = Random.insideUnitSphere * .07f;
		//prevent wandering
		if (Time.time % 100 == 0)
			transform.position = new Vector3 (saved_x, saved_y, saved_z);
	}

	public void jitterFor(int x){
		do_jitter = true;
		t = x;
		StartCoroutine ("JitterCountdown");
	}

	IEnumerator JitterCountdown(){
		yield return new WaitForSeconds(t);
		do_jitter = false;
	}
}

/*
What I'd like to see:
	-	once you've got the right frequency, a clearish soundwave shoots out at the object and 
		makes it explode

	-	some penalty for missing the frequency







 */