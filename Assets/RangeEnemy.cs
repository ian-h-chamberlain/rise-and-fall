using UnityEngine;
using System.Collections;

public class RangeEnemy : MonoBehaviour {
	
	public Transform target;
	public Player player;
	public float aggro_range;
	Transform t;
	NavMeshAgent agent;
	int attack_counter;
	Vector3 wander_target;
	int wander_waiting;
	GameObject projectile;
	Vector3 oldPos;
	
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		attack_counter = 0;
		t = GetComponent<Transform> ();
		wander_target = Vector3.zero;
		wander_waiting = 0;
		projectile = (GameObject) Resources.Load ("EnemyProjectile");
		oldPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float curSpeed = (transform.position - oldPos).magnitude / Time.deltaTime;

		oldPos = transform.position;
		GetComponentInChildren<Animator>().SetFloat("Velocity", curSpeed / agent.speed);

		if ((target.position - t.position).sqrMagnitude < aggro_range * aggro_range){
			wander_target = Vector3.zero;
			wander_waiting = 0;
			agent.SetDestination (target.position);
			if ((t.position - target.position).sqrMagnitude <= agent.stoppingDistance * agent.stoppingDistance) {
				attack_counter += 1;
				if (attack_counter >= 90){
					GameObject temp = Instantiate(projectile, t.position, t.rotation) as GameObject;
					temp.transform.Rotate(90f, 0, 0);
					temp.transform.position += new Vector3(0, 0.3f, 0);
					attack_counter = 0;
				}
			} 
			else {
				attack_counter = 0;
			}
		}
		else{
			if (wander_target == Vector3.zero){
				if (wander_waiting <= 0){
					wander_target = new Vector3(t.position.x + Random.Range (-20, 20), t.position.y, t.position.z + Random.Range (-20, 20));
					agent.SetDestination(wander_target);
					wander_waiting = 1200;
				}
				else{
					wander_waiting -= 1;
				}
			}
			else{
				wander_waiting -= 1;
				if ((t.position - wander_target).sqrMagnitude <= agent.stoppingDistance * agent.stoppingDistance || wander_waiting <= 0) {
					wander_target = Vector3.zero;
					wander_waiting = Random.Range (30, 300);
				}
			}
		}
	}
}
