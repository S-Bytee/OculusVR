using UnityEngine;
using System.Collections;

public class CheckSFXVolume : MonoBehaviour {
	public void  Start (){
		GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume");
		Debug.Log(PlayerPrefs.GetFloat("SFXVolume"));
	}

	public void UpdateVolume (){
		GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume");
	}
}