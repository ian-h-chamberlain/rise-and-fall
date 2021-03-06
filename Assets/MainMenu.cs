﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	int position;
	int slide;
	public GameObject bullet1;
	public GameObject bullet2;
	public GUIText startgame;
	public GUIText exitgame;

	public GUIText mountainking;
	public GUIText grandolflag;
	public GUIText moonlight;
	public GUIText entryofthegladiators;
	public GUIText cottoneyejoe;
	public GUIText carolofthebells;
	public GameObject song1;
	public GameObject song2;
	public GameObject song3;
	public GameObject song4;
	public GameObject song5;
	public GameObject song6;

	// Use this for initialization
	void Start () {
		bullet1.SetActive (true);
		bullet2.SetActive (false);
		position = 1;
		slide = 1;
	}

	void Switcheh(){
		if (position == 1) {
			position = 2;
			bullet1.SetActive(false);
			bullet2.SetActive(true);
		}
		else{
			position = 1;
			bullet1.SetActive(true);
			bullet2.SetActive(false);
		}
	}

	void Switcheh (char dir){
		if (position == 1) {
			song1.SetActive(false);
		}
		else if (position == 2){
			song2.SetActive(false);
		}
		else if (position == 3){
			song3.SetActive(false);
		}
		else if (position == 4){
			song4.SetActive(false);
		}
		else if (position == 5){
			song5.SetActive(false);
		}
		else if (position == 6){
			song6.SetActive(false);
		}
		if (dir == 'u') {
			position -= 1;
			if (position == 0){
				position = 6;
			}
		}
		else{
			position += 1;
			if (position == 7){
				position = 1;
			}
		}
		if (position == 1) {
			song1.SetActive(true);
		}
		else if (position == 2){
			song2.SetActive(true);
		}
		else if (position == 3){
			song3.SetActive(true);
		}
		else if (position == 4){
			song4.SetActive(true);
		}
		else if (position == 5){
			song5.SetActive(true);
		}
		else if (position == 6){
			song6.SetActive(true);
		}
	}

	void SwitchehSlide(){
		if (slide == 1) {
			position = 1;
			startgame.enabled = false;
			exitgame.enabled = false;
			bullet1.SetActive(false);
			bullet2.SetActive(false);
			slide = 2;
			mountainking.enabled = true;
			grandolflag.enabled = true;
			moonlight.enabled = true;
			entryofthegladiators.enabled = true;
			cottoneyejoe.enabled = true;
			carolofthebells.enabled = true;
			song1.SetActive(true);
		}
		else{
			position = 1;
			startgame.enabled = true;
			exitgame.enabled = true;
			bullet1.SetActive(true);
			slide = 1;
			mountainking.enabled = false;
			grandolflag.enabled = false;
			moonlight.enabled = false;
			entryofthegladiators.enabled = false;
			cottoneyejoe.enabled = false;
			carolofthebells.enabled = false;
			song1.SetActive(false);
			song2.SetActive(false);
			song3.SetActive(false);
			song4.SetActive(false);
			song5.SetActive(false);
			song6.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && slide == 1) {
			Switcheh();
		}
		else if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))){
			Switcheh('u');
		}
		else if ((Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow))){
			Switcheh('d');
		}
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)){
			if (slide == 1){
				if (position == 1){
					SwitchehSlide();
				}
				else{
					Application.Quit();
				}
			}
			else{
				if (position == 1){
					MusicPlayer.current = MusicPlayer.MountainKing;
					MusicPlayer.ending = MusicPlayer.mountainkingclip;
				}
				else if (position == 2){
					MusicPlayer.current = MusicPlayer.GrandOlFlag;
					MusicPlayer.ending = MusicPlayer.grandolflagclip;
				}
				else if (position == 3){
					MusicPlayer.current = MusicPlayer.MoonlightSonata;
					MusicPlayer.ending = MusicPlayer.moonlightsonataclip;
				}
				else if (position == 4){
					MusicPlayer.current = MusicPlayer.EntryGladiator;
					MusicPlayer.ending = MusicPlayer.entrygladiatorclip;
				}
				else if (position == 5){
					MusicPlayer.current = MusicPlayer.CottonEyeJoe;
					MusicPlayer.ending = MusicPlayer.cottoneyejoeclip;
				}
				else if (position == 6){
					MusicPlayer.current = MusicPlayer.CaroloftheBells;
					MusicPlayer.ending = MusicPlayer.carolofthebellsclip;
				}
				Application.LoadLevel("Introduction");
			}
		}
		if (Input.GetKeyDown (KeyCode.Backspace) && slide == 2) {
			SwitchehSlide();
		}
	}
}
