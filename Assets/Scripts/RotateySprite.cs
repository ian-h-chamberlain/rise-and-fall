using UnityEngine;
using System.Collections;

public class RotateySprite : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(new Vector3(0f, 2f, 0f));
	}
}
