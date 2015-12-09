using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

	int lifespan;
	public float scaleRate;
	public float moveRate;
	Player player;
	Transform t;

	// Use this for initialization
	void Start () {
		lifespan = 120;
		t = GetComponent<Transform> ();
		player = FindObjectOfType<Player> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")) {
			player.Damage();
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		t.localScale = new Vector3(t.localScale.x * scaleRate, t.localScale.y * scaleRate, t.localScale.z * scaleRate);
		t.Translate(new Vector3(0, moveRate, 0));
		lifespan -= 1;
		if (lifespan <= 0){
			Destroy(gameObject);
		}
	
	}
}
