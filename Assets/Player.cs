using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health;
	public int immunity_duration;
	int immune_timer;
	GameObject projectile;
	Transform t;

	// Use this for initialization
	void Start () {
		projectile = (GameObject) Resources.Load ("EnemyProjectile");
		t = GetComponent<Transform> ();
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
			Application.LoadLevel("GameOver");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.J)) {
			GameObject temp = Instantiate(projectile, t.position, t.rotation) as GameObject;
			temp.transform.Rotate(90f, 0, 0);
			temp.transform.position += new Vector3(0, 1.2f, 0);
		}
		if (immune_timer > 0){
			immune_timer -= 1;
		}
	}
}
