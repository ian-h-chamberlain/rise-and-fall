using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBehavior : MonoBehaviour {
	public Image circle;
	public Sprite whole;
	public Sprite half;
	public Sprite quarter;
	public Sprite eighth;

	//Health is in Player -Dan

	// Use this for initialization
	void Start () {
		SetHealth (4);
	}
	
	// Update is called once per frame
	void Update () {
		/*TEST STUFF
		if (Input.GetKeyDown (KeyCode.W)) {
			SetHealth (4);
		}else if (Input.GetKeyDown (KeyCode.H)) {
			SetHealth(3);
		}else if (Input.GetKeyDown (KeyCode.Q)) {
			SetHealth(2);
		}else if (Input.GetKeyDown (KeyCode.E)) {
			SetHealth(1);
		}
		*/

	}

	public void SetHealth(int health){
		if (health == 4) {
			GetComponent<Image> ().sprite = whole;
			circle.color = Color.green;
		} else if (health == 3) {
			GetComponent<Image> ().sprite = half;
			circle.color = Color.yellow;
		} else if (health == 2) {
			GetComponent<Image> ().sprite = quarter;
				circle.color = new Color(1f, .62f, 0f);
		} else if (health == 1) {
			GetComponent<Image>().sprite = eighth;
				circle.color = Color.red;
		}
	}

}
