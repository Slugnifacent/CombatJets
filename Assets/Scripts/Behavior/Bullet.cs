using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class Bullet : MonoBehaviour {
	public float speed;
	Vector3 velocity;
	float timer;
	
	void Start () {
		speed = 20;
		timer = 1;
	}
	
	public void Fire(Transform Location){
		transform.position = Location.position;
		transform.rotation = Location.rotation;
		velocity = Location.TransformDirection(Vector3.forward);
		velocity.Normalize();
		GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(timer <= 0){
			Destroy(gameObject);
		}
		transform.Translate(velocity*speed,Space.World);
		timer -= Time.deltaTime;
	}
}
