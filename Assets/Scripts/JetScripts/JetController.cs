using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class JetController : MonoBehaviour {
	Quaternion rotation;
	public float speed;
	public float minSpeed;
	public float MaxSpeed;
	public float pitchSpeed;
	public float rollSpeed;
    float roll;
	float pitch; 
	float yaw; 
	Vector3 dir = Vector3.zero;
	bool loading;
	bool destroyed;
	float restartTimer = 2;
	public GUIStyle ScrollingCompass;
	public GUIStyle ClearButton;
	public Texture2D HealthJet;
	public int bulletCount;
	public int missileCount;
	// Use this for initialization
	void Start () {
		rotation = transform.rotation;
		roll = 0;
		pitch = 0;
		minSpeed = 1;
		MaxSpeed = 5;
		Screen.sleepTimeout = 0; 
	}
	
	// Update is called once per frame
	void Update () {
		if(destroyed){
			restartTimer -= Time.deltaTime;
			GetComponent<Rigidbody>().isKinematic = false;
			Vector3 temp = transform.TransformDirection(Vector3.forward)*speed;
			GetComponent<Rigidbody>().AddForce(temp);
			speed -= .002f;
			speed = Mathf.Clamp(speed,0,MaxSpeed);
			if(restartTimer <= 0){
				Application.LoadLevel("cool");
			}
			CharacterController chartroller = (CharacterController)GetComponent("CharacterController");
			
			Vector3 movem = transform.TransformDirection(Vector3.forward)*speed;
			movem.y = -.2f;
			chartroller.Move(movem);
			Quaternion TargetOri = rotation* Quaternion.Euler(new Vector3(0,0,-(restartTimer+1)*5));
			rotation = Quaternion.Slerp(rotation,TargetOri, Time.deltaTime * 100f);
			transform.rotation = rotation;
			return;
		}
		
		roll   = Input.acceleration.y * 2;
		pitch  = (Input.acceleration.z + .35f) * 2;
		
		/*
		roll   = Input.GetAxis("Horizontal") * 5;
		pitch  = Input.GetAxis("Vertical");
		*/
		Quaternion TargetOrientation = rotation* Quaternion.Euler(new Vector3(-pitch,yaw,roll));
		// TargetOrientation = Input.gyro.attitude;
		rotation = Quaternion.Slerp(rotation,TargetOrientation, Time.deltaTime * 100f);

		transform.rotation = rotation;
		CharacterController charController = (CharacterController)GetComponent("CharacterController");
		Vector3 movement = transform.TransformDirection(Vector3.forward)*speed;
		charController.Move(movement);
		dir.x = Input.acceleration.x;
		dir.y = roll;
		dir.z = pitch;
		speed -= .001f;
		speed = Mathf.Clamp(speed,minSpeed,MaxSpeed);
		//speed = 0;
	}
	
	public void OnGUI(){
		float degree = transform.rotation.eulerAngles.y;
		/*
		GUI.Label(new Rect(4,Screen.height - 35,400,30), "yaw: " + transform.rotation.eulerAngles.x.ToString(),ScrollingCompass);
		GUI.Label(new Rect(4,Screen.height - 55,400,30), "roll: " + transform.rotation.eulerAngles.y.ToString(),ScrollingCompass);
		GUI.Label(new Rect(4,Screen.height - 75,400,30), "pitch: " + transform.rotation.eulerAngles.z.ToString(),ScrollingCompass);
		GUI.Label(new Rect(4,Screen.height - 95,400,30), "Position: " + transform.position,ScrollingCompass);
		*/
		
		GUI.Label(new Rect(Screen.width - 210,Screen.height - 100,200,200),HealthJet);
		
		GUI.Label(new Rect(Screen.width - 150,Screen.height - 60,400,30), "MSSL: " + missileCount,ScrollingCompass);
		GUI.Label(new Rect(Screen.width - 150,Screen.height - 90,400,30), "GUN: " + bulletCount,ScrollingCompass);
		CharacterController charController = (CharacterController)GetComponent("CharacterController");
		
		
		
		//Button to Reset to center position
		string direction = "";
		float yawAngle = transform.rotation.eulerAngles.y;
		if(yawAngle < 45 || yawAngle > 315){
			direction = "N";
		} 
		if(yawAngle < 135 && yawAngle > 45){
			direction = "E";
		} 
		if(yawAngle < 225 && yawAngle > 135){
			direction = "S";
		} 
		if(yawAngle < 315 && yawAngle > 225){
			direction = "W";
		} 
		
		GUI.Label(new Rect(20,0, 120, 50),direction,ScrollingCompass);

		//Button to exit program
		if (GUI.Button (new Rect(Screen.width /2  - 60, Screen.height - 50, 120, 50), "Exit Game")) {
			Application.Quit();
		}
		yaw = 0;
		//Button to exit program
		if (GUI.RepeatButton (new Rect(Screen.width - 120, 90, 120, Screen.height - 90), "Strafe",ClearButton)) {
			yaw += .1f;
		}
		if (GUI.RepeatButton (new Rect(0, 90, 120, Screen.height - 90), "Strafe",ClearButton)) {
			yaw -= .1f;
		}

	}
	
	public void OnTriggerEnter(Collider collision){
		if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Missile"){
			
			return;
		}
		GameObject newExplosion = GameObject.Find("Explosion");
		ParticleEmitter emitter = (ParticleEmitter)newExplosion.GetComponent<ParticleEmitter>();
		emitter.emit = true;
		ParticleAnimator animator = (ParticleAnimator)newExplosion.GetComponent<ParticleAnimator>();
		animator.autodestruct = true;
		AudioSource explosionSound = (AudioSource)newExplosion.GetComponent<AudioSource>();
		explosionSound.Play();
			
		newExplosion.transform.position = gameObject.transform.position;
		Destroy(collision.gameObject);
		destroyed = true;
	}
	

}
