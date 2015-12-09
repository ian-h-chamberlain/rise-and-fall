using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicPlayer : MonoBehaviour {

	AudioSource musicer;

	public static AudioClip mountainkingclip;
	public static AudioClip grandolflagclip;
	public static AudioClip moonlightsonataclip;
	public static AudioClip entrygladiatorclip;
	public static AudioClip cottoneyejoeclip;

	AudioClip A0;
	AudioClip AS0;
	AudioClip B0;

	AudioClip C1;
	AudioClip CS1;
	AudioClip D1;
	AudioClip DS1;
	AudioClip E1;
	AudioClip F1;
	AudioClip FS1;
	AudioClip G1;
	AudioClip GS1;
	AudioClip A1;
	AudioClip AS1;
	AudioClip B1;

	AudioClip C2;
	AudioClip CS2;
	AudioClip D2;
	AudioClip DS2;
	AudioClip E2;
	AudioClip F2;
	AudioClip FS2;
	AudioClip G2;
	AudioClip GS2;
	AudioClip A2;
	AudioClip AS2;
	AudioClip B2;

	AudioClip C3;
	AudioClip CS3;
	AudioClip D3;
	AudioClip DS3;
	AudioClip E3;
	AudioClip F3;
	AudioClip FS3;
	AudioClip G3;
	AudioClip GS3;
	AudioClip A3;
	AudioClip AS3;
	AudioClip B3;

	AudioClip C4;
	AudioClip CS4;
	AudioClip D4;
	AudioClip DS4;
	AudioClip E4;
	AudioClip F4;
	AudioClip FS4;
	AudioClip G4;
	AudioClip GS4;
	AudioClip A4;
	AudioClip AS4;
	AudioClip B4;

	AudioClip C5;
	AudioClip CS5;
	AudioClip D5;
	AudioClip DS5;
	AudioClip E5;
	AudioClip F5;
	AudioClip FS5;
	AudioClip G5;
	AudioClip GS5;
	AudioClip A5;
	AudioClip AS5;
	AudioClip B5;

	AudioClip C6;

	int progress;

	public static AudioClip[] MountainKing;
	public static AudioClip[] GrandOlFlag;
	public static AudioClip[] MoonlightSonata;
	public static AudioClip[] EntryGladiator;
	public static AudioClip[] CottonEyeJoe;

	public static AudioClip[] current;
	public static AudioClip ending;

	public static int win;
	

	// Use this for initialization
	void Start () {

		musicer = GetComponent<AudioSource> ();

		mountainkingclip = (AudioClip) Resources.Load ("MountainKing");
		grandolflagclip = (AudioClip) Resources.Load ("GrandOlFlag");
		moonlightsonataclip = (AudioClip) Resources.Load ("MoonlightSonata");
		entrygladiatorclip = (AudioClip)Resources.Load ("EntryoftheGladiators");
		cottoneyejoeclip = (AudioClip)Resources.Load ("CottonEyeJoe");

		A0 = (AudioClip) Resources.Load ("Notes/A0");
		AS0 = (AudioClip) Resources.Load ("Notes/A#0");
		B0 = (AudioClip) Resources.Load ("Notes/B0");

		C1 = (AudioClip) Resources.Load ("Notes/C1");
		CS1 = (AudioClip) Resources.Load ("Notes/C#1");
		D1 = (AudioClip) Resources.Load ("Notes/D1");
		DS1 = (AudioClip) Resources.Load ("Notes/D#1");
		E1 = (AudioClip) Resources.Load ("Notes/E1");
		F1 = (AudioClip) Resources.Load ("Notes/F1");
		FS1 = (AudioClip) Resources.Load ("Notes/F#1");
		G1 = (AudioClip) Resources.Load ("Notes/G1");
		GS1 = (AudioClip) Resources.Load ("Notes/G#1");
		A1 = (AudioClip) Resources.Load ("Notes/A1");
		AS1 = (AudioClip) Resources.Load ("Notes/A#1");
		B1 = (AudioClip) Resources.Load ("Notes/B1");

		C2 = (AudioClip) Resources.Load ("Notes/C2");
		CS2 = (AudioClip) Resources.Load ("Notes/C#2");
		D2 = (AudioClip) Resources.Load ("Notes/D2");
		DS2 = (AudioClip) Resources.Load ("Notes/D#2");
		E2 = (AudioClip) Resources.Load ("Notes/E2");
		F2 = (AudioClip) Resources.Load ("Notes/F2");
		FS2 = (AudioClip) Resources.Load ("Notes/F#2");
		G2 = (AudioClip) Resources.Load ("Notes/G2");
		GS2 = (AudioClip) Resources.Load ("Notes/G#2");
		A2 = (AudioClip) Resources.Load ("Notes/A2");
		AS2 = (AudioClip) Resources.Load ("Notes/A#2");
		B2 = (AudioClip) Resources.Load ("Notes/B2");

		C3 = (AudioClip) Resources.Load ("Notes/C3");
		CS3 = (AudioClip) Resources.Load ("Notes/C#3");
		D3 = (AudioClip) Resources.Load ("Notes/D3");
		DS3 = (AudioClip) Resources.Load ("Notes/D#3");
		E3 = (AudioClip) Resources.Load ("Notes/E3");
		F3 = (AudioClip) Resources.Load ("Notes/F3");
		FS3 = (AudioClip) Resources.Load ("Notes/F#3");
		G3 = (AudioClip) Resources.Load ("Notes/G3");
		GS3 = (AudioClip) Resources.Load ("Notes/G#3");
		A3 = (AudioClip) Resources.Load ("Notes/A3");
		AS3 = (AudioClip) Resources.Load ("Notes/A#3");
		B3 = (AudioClip) Resources.Load ("Notes/B3");

		C4 = (AudioClip) Resources.Load ("Notes/C4");
		CS4 = (AudioClip) Resources.Load ("Notes/C#4");
		D4 = (AudioClip) Resources.Load ("Notes/D4");
		DS4 = (AudioClip) Resources.Load ("Notes/D#4");
		E4 = (AudioClip) Resources.Load ("Notes/E4");
		F4 = (AudioClip) Resources.Load ("Notes/F4");
		FS4 = (AudioClip) Resources.Load ("Notes/F#4");
		G4 = (AudioClip) Resources.Load ("Notes/G4");
		GS4 = (AudioClip) Resources.Load ("Notes/G#4");
		A4 = (AudioClip) Resources.Load ("Notes/A4");
		AS4 = (AudioClip) Resources.Load ("Notes/A#4");
		B4 = (AudioClip) Resources.Load ("Notes/B4");

		C5 = (AudioClip) Resources.Load ("Notes/C5");
		CS5 = (AudioClip) Resources.Load ("Notes/C#5");
		D5 = (AudioClip) Resources.Load ("Notes/D5");
		DS5 = (AudioClip) Resources.Load ("Notes/D#5");
		E5 = (AudioClip) Resources.Load ("Notes/E5");
		F5 = (AudioClip) Resources.Load ("Notes/F5");
		FS5 = (AudioClip) Resources.Load ("Notes/F#5");
		G5 = (AudioClip) Resources.Load ("Notes/G5");
		GS5 = (AudioClip) Resources.Load ("Notes/G#5");
		A5 = (AudioClip) Resources.Load ("Notes/A5");
		AS5 = (AudioClip) Resources.Load ("Notes/A#5");
		B5 = (AudioClip) Resources.Load ("Notes/B5");

		C6 = (AudioClip) Resources.Load ("Notes/C6");

		progress = 0;

		MountainKing = new AudioClip[52] {A2, B2, C3, D3, E3, C3, E3, DS3, B2, DS3, 
											D3, AS2, D3, A2, B2, C3, D3, E3, C3, E3,
											A3, G3, E3, C3, E3, G3,
											A2, B2, C3, D3, E3, C3, E3, DS3, B2, DS3, 
											D3, AS2, D3, A2, B2, C3, D3, E3, C3, E3,
											A3, G3, E3, C3, E3, G3};

		GrandOlFlag = new AudioClip[37] {C4, A3, F3, F3, F3, D3, C3, F3, G3, E3, F3, D3, 
											C3, F3, D3, C3, F3, D3, C3, E3, C3, D3, E3, F3,
											G3, C3, F3, G3, A3, F3, G3, A3, F3, G3, A3, F3, G3};

		MoonlightSonata = new AudioClip[48] {GS2, CS3, E3, GS2, CS3, E3, GS2, CS3, E3, GS2, CS3, E3, 
											GS2, CS3, E3, GS2, CS3, E3, GS2, CS3, E3, GS2, CS3, E3,
											A2, CS3, E3, A2, CS3, E3, A2, D3, FS3, A2, D3, FS3,
											GS3, C3, FS3, GS3, CS3, E3, GS3, CS3, DS3, FS3, C3, D3};

		EntryGladiator = new AudioClip[44] {C5, B4, AS4, B4, AS4, A4, GS4, G4, FS4, G4,
											A4, GS4, G4, GS4, G4, FS4, F4, E4, DS4, E4,
											G4, F4, F4, CS4, D4, G4, F4, F4, CS4, D4,
											B3, C4, CS4, D4, DS4, E4, F4, FS4, G4, GS4, A4, B4, A4, G4};

		CottonEyeJoe = new AudioClip[] {};

		DontDestroyOnLoad (gameObject);

	}

	public void Play(){
		musicer.clip = current [progress];
		musicer.Play ();
		progress++;
		if (progress >= current.Length) {
			win = 60;
		}

		GameObject.FindObjectOfType<ProgressBehavior>().setProgress(progress * 1.0f / current.Length * 1.0f);
	}

	public void Play(AudioClip clip) {
		musicer.clip = clip;
		musicer.Play ();
	}

	public void PlayEnding(){
		musicer.clip = ending;
		musicer.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (win > 0) {
			win -= 1;
			if (win == 0){
				Application.LoadLevel("GameOver");
				PlayEnding ();
			}
			return;
		}
		if (Input.GetKeyDown (KeyCode.M)){
			musicer.clip = current[progress];
			musicer.Play ();
			progress++;
			if (progress >= current.Length) {
				win = 60;
			}
		}
	}
}
