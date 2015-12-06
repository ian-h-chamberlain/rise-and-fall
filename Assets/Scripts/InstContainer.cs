using UnityEngine;
using System.Collections;

public class InstContainer : MonoBehaviour {
	public Instrument inst;
}

[System.Serializable]
public class Instrument {

	public int type;
	public AudioClip sound;
	public Color col;
	public float maxPitch;
	public float minPitch;
	public float epsilon;
}