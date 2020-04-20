﻿using UnityEngine;
using System.Collections;

public class CheckMusicVolume : MonoBehaviour {
	public void  Start (){
		GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
	}

	public void UpdateVolume (){
		GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
	}
}