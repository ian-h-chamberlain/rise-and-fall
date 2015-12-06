using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Transform target;
	public Player player;
	public float aggro_range;
	Transform t;
	NavMeshAgent agent;
	int attack_counter;
	Vector3 wander_target;
	int wander_waiting;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		attack_counter = 0;
		t = GetComponent<Transform> ();
		wander_target = Vector3.zero;
		wander_waiting = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ((target.position - t.position).sqrMagnitude < aggro_range * aggro_range){
			wander_target = Vector3.zero;
			wander_waiting = 0;
			agent.SetDestination (target.position);
			if ((t.position - target.position).sqrMagnitude <= agent.stoppingDistance * agent.stoppingDistance) {
				attack_counter += 1;
				if (attack_counter >= 60){
					player.Damage();
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
					wander_target = new Vector3(t.position.x + Random.Range (-5, 5), t.position.y, t.position.z + Random.Range (-5, 5));
					agent.SetDestination(wander_target);
					wander_waiting = 0;
				}
				else{
					wander_waiting -= 1;
				}
			}
			else{
				if ((t.position - wander_target).sqrMagnitude <= agent.stoppingDistance * agent.stoppingDistance) {
					wander_target = Vector3.zero;
					wander_waiting = Random.Range (10, 100);
				}
			}
		}
	}
}
