using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour {

	public static AudioManger Instance;
	public AudioSource Music;
	public AudioSource Sound;
	// Use this for initialization
	void Start () {
		Instance = this;
	}


	public void PlayMusic(string musicName){
		if (!Music.isPlaying) {
			AudioClip clicp = Resources.Load<AudioClip> (musicName);
			Music.clip = clicp;
			Music.Play ();
		}
	}

	public void StopMusic(){
		Music.Stop ();
	}
	public void SwitchPlayState(){
		if (Music.isPlaying) {
			Music.Pause ();
		} else {
			Music.Play();
		}
	}

	public void PlaySound(string soundName){
		AudioClip clicp = Resources.Load<AudioClip> (soundName);
		Sound.PlayOneShot (clicp);
	}
		

	// Update is called once per frame
	void Update () {
		
	}
}
