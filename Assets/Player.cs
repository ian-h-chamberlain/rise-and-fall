using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health;
	public int immunity_duration;
	int immune_timer;


	// Use this for initialization
	void Start () {
	
	}

	public void Damage(){
		if (immune_timer <= 0) {
			health -= 1;
			immune_timer = immunity_duration;
			Debug.Log ("Ouchie, you gave me a booboo");
		}
		else{
			Debug.Log ("Stahp hitting me, I was just bullied");
		}
		if (health <= 0) {
			Debug.Log ("GAME OVER");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (immune_timer > 0){
			immune_timer -= 1;
		}
	}
}
