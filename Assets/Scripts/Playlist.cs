using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class Playlist : MonoBehaviour {
	AudioClip[] sources;
	public AudioClip One;
	public AudioClip Two;
	public AudioClip Three;
	public AudioClip Four;
	public AudioClip Five;
	int CurrentSong;
	// Use this for initialization
	void Start () {
		sources = new AudioClip[5];
		sources[0] = One;
		sources[1] = Two;
		sources[2] = Three;
		sources[3] = Four;
		sources[4] = Five;
		GetComponent<AudioSource>().clip = sources[0];
		GetComponent<AudioSource>().Play();
		CurrentSong = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!GetComponent<AudioSource>().isPlaying){
			CurrentSong++;
			if(CurrentSong >= sources.Length) CurrentSong = 0;
			GetComponent<AudioSource>().clip = sources[CurrentSong];
			GetComponent<AudioSource>().Play();
		}
	}
}
