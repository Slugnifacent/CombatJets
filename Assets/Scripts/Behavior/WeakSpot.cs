using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Targetable))]

public class WeakSpot : MonoBehaviour {
	public GameObject Explosion;
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag == "Missile"){
			GameObject newExplosion = (GameObject)Instantiate(Explosion);
			ParticleEmitter emitter = (ParticleEmitter)newExplosion.GetComponent<ParticleEmitter>();
			emitter.emit = true;
			ParticleAnimator animator = (ParticleAnimator)newExplosion.GetComponent<ParticleAnimator>();
			animator.autodestruct = true;
			AudioSource explosionSound = (AudioSource)newExplosion.GetComponent<AudioSource>();
			explosionSound.Play();
			
			newExplosion.transform.position = gameObject.transform.position;
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
	}

}
