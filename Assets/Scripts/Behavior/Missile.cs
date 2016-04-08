using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]

public class Missile : MonoBehaviour {
 	GameObject target;
	public float speed;
	Vector3 velocity;
	float Timer = float.NaN;
	float TimerMax = 10;
	
	AudioSource soundSource;
	
	// Use this for initialization
	void Start () {
		speed = 5;
	}
	
	// Update is called once per frame
	void Update (){
		if(target != null){
		    transform.FindChild("Particle System").gameObject.GetComponent<ParticleEmitter>().maxEmission = 50;
			if((TimerMax - Timer) > 2){
				Vector3 direction = target.GetComponent<Collider>().bounds.center - transform.position;
				direction.Normalize();
				velocity += direction*.03f;
				velocity.Normalize();
				transform.localRotation = Quaternion.LookRotation(velocity);
			}
		}
		if (Timer != float.NaN){
			Timer -= Time.deltaTime;
		}
		if(Timer <= 0){
			Destroy(gameObject);
		}
		transform.Translate(velocity*speed,Space.World);
	}
	
	public void OnGUI(){
		/*
		float degree = transform.rotation.eulerAngles.y;
		GUI.Label(new Rect(4,35,400,30), "x: " + transform.rotation.eulerAngles.x.ToString());
		GUI.Label(new Rect(4,55,400,30), "y: " + transform.rotation.eulerAngles.y.ToString());
		GUI.Label(new Rect(4,75,400,30), "z: " + transform.rotation.eulerAngles.z.ToString());
		GUI.Label(new Rect(4,95,400,30), "Position: " + transform.position.ToString());
		GUI.Label(new Rect(4,115,400,30), "Velocity: " + velocity.ToString());
		*/
	}
	
	public void AssignTarget(GameObject Target, Transform Location){
		target = Target;
		transform.position  = Location.position;
		transform.eulerAngles = Location.rotation.eulerAngles;
		velocity = Location.TransformDirection(Vector3.forward);
		soundSource = (AudioSource)GetComponent<AudioSource>();
		soundSource.PlayOneShot(soundSource.clip);
		Timer = TimerMax;
	}

    void OnTriggerEnter(Collider other) {

    }
	
	void OnCollision(){
		Destroy(this);
	}
	
}
