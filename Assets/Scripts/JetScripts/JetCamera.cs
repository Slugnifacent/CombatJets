using UnityEngine;
using System.Collections;

public class JetCamera : MonoBehaviour {
	
	public Transform TargetTransform;
	public JetController Jet;
	public float distance;
	public float linearSpeed;
	public float speedTurn;
	public float height;
	public float maxHeight;
	public float minHeight;
	float heightSpace;
	float JetSpeedSpace;
	
	// Use this for initialization
	void Start() {
		JetSpeedSpace = Jet.MaxSpeed - Jet.minSpeed;
		maxHeight = height;
		heightSpace = height - minHeight;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 back = -TargetTransform.forward * distance;
		
		Quaternion TargetOrientation = Quaternion.Euler(TargetTransform.eulerAngles);
        Vector3 TargetPosition = back + TargetTransform.position;
		float speedPercentage = (Jet.speed - Jet.minSpeed)/JetSpeedSpace;
		height = maxHeight - heightSpace*speedPercentage;
		TargetPosition += TargetTransform.up * height;
		
        transform.rotation = Quaternion.Slerp(transform.rotation,TargetTransform.rotation, Time.time * speedTurn);
        transform.position = Vector3.Lerp(transform.position,TargetPosition,Time.time * linearSpeed);
		

	}
}
