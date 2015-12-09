using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickInstrumentForUI : MonoBehaviour {
	public Sprite flute;
	public Sprite trumpet;
	public Sprite violin;
	public Sprite saxophone;
	public Sprite drum;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetInstrument(int ins){
		if (ins == 0) {
			GetComponent<Image>().sprite = flute;
		}
		if (ins == 1) {
			GetComponent<Image>().sprite = trumpet;
		}
		if (ins == 2) {
			GetComponent<Image>().sprite = violin;
		}
		if (ins == 3) {
			GetComponent<Image>().sprite = saxophone;
		}
		if (ins == 4) {
			GetComponent<Image>().sprite = drum;
		}
	}
}
