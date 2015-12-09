using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour {
	
	public List<GUIText> words;
	int slide;
	int delay;
	int timer;
	int reader;
	bool reading;
	string words_text;
	
	// Use this for initialization
	void Start () {
		slide = 0;
		delay = 2;
		Reset ();
	}
	
	void Reset(){
		if (slide < 0) {
			slide = 0;
		}
		else if (slide >= words.Count){
			MusicPlayer.current = null;
			MusicPlayer.ending = null;
			Application.LoadLevel("MainMenu");
			return;
		}
		words_text = words [slide].text;
		words [slide].text = "";
		timer = delay;
		reader = 0;
		reading = true;
		words[slide].enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (reading) {
			timer -= 1;
			if (timer <= 0){
				timer = delay;
				words[slide].text += words_text[reader];
				reader += 1;
			}
			if (reader >= words_text.Length){
				reading = false;
			}
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Return)){
				reading = false;
				words[slide].text = words_text;
			}
		}
		else{
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)){
				words[slide].enabled = false;
				slide += 1;
				Reset();
			}
			if (Input.GetKeyDown (KeyCode.Backspace)){
				words[slide].enabled = false;
				slide -= 1;
				Reset();
			}
		}
		
	}
}
