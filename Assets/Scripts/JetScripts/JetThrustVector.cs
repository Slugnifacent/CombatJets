using UnityEngine;
using System.Collections;


[RequireComponent(typeof(ParticleEmitter))]

public class JetThrustVector : MonoBehaviour {
	Rect buttonRectangle;
	public JetController jetCotroller;
	public ParticleEmitter emitter;
	public Transform JetTransform;
	float minEnergy;
	float maxEnergy;
	float maxEmission;
	bool  AfterBurner;
	public AudioSource Engine;
	public AudioSource afterBurner;
	void Start(){
		buttonRectangle = new Rect(Screen.width - 120, Screen.height - 50, 120, 50);
		minEnergy = emitter.minEnergy;
		maxEnergy = emitter.maxEnergy;
		maxEmission = emitter.maxEmission;
		emitter.maxEmission = 0;
	}
	
	public void Update(){
		transform.position = JetTransform.position;
		if (AfterBurner) {
			jetCotroller.speed += .004f;
			emitter.maxEnergy = 1.1f;
			emitter.maxEmission = maxEmission;
			if(!afterBurner.isPlaying){
				afterBurner.Play();
			}
		}else{
			emitter.maxEnergy = maxEnergy;
			emitter.maxEmission = 0;
			if(!Engine.isPlaying){
				Engine.Play();
			}
			if(afterBurner.isPlaying){
				afterBurner.Stop();
			}
			
		}
		AfterBurner = false;
	}
	
	public void ApplyAfterBurner(){
		AfterBurner = true;
	}
	
}
