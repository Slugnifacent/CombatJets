using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GameObject))]
public class Flee : MonoBehaviour {
	public Transform AvoidTransform;
	public float speed;
	public float fleeDistance;
 	Vector3 velocity;
	float Timer  = 3;
	float Decision;
	
	// Use this for initialization
	void Start () {
		velocity = new Vector3((Random.value-.5f),(Random.value-.5f),(Random.value-.5f));
		velocity.Normalize();
		Decision = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		if(Timer  <= 0){
			if(Decision < .05f){
				velocity += transform.TransformDirection(Vector3.right);
			}
			if(Decision > .95f){
				velocity += transform.TransformDirection(Vector3.left);
			}
			Timer = 3;
		}
		
		if(Vector3.Distance(AvoidTransform.position,transform.position) < fleeDistance){
			Vector3 avoidVector = transform.position  - AvoidTransform.position;
			avoidVector.Normalize();

			velocity += avoidVector*.04f;
			velocity.Normalize();
			transform.position += velocity * speed;
		}
		
		Timer -= Time.time;
	}
}
