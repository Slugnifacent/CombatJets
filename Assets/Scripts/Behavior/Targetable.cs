using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour {
	Vector3 ScreenCoordinates;
	Vector3 targetCoordinates;
	public Texture2D TargetBox;
	public Texture2D TargetBoxLocked;
	public float DetectableDistance;
	bool Lock = false;
	bool targetAble = true;
	Vector3 textureCoordinate;
	float lockQuality;
	
	// Use this for initialization
	void Start() {
		ScreenCoordinates = Vector3.zero;
		textureCoordinate = new Vector3(Random.Range(0,Screen.width),Random.Range(0,Screen.height));
		lockQuality = .05f;
	}
	
	// Update is called once per frame
	void Update() {
				
		ScreenCoordinates = Camera.main.WorldToScreenPoint(GetComponent<BoxCollider>().bounds.center);

		targetAble = false;
		if(OnScreen()){
			Vector3 CamToThis =  transform.position - Camera.main.transform.position;
			CamToThis.Normalize();
			Vector3 forwardVector = Camera.main.transform.TransformDirection(Vector3.forward);
			forwardVector.Normalize();
			float dotAngle = Vector3.Dot(forwardVector,CamToThis);
			
			
			if(dotAngle > .90f){
				if((Vector3.Distance(Camera.main.transform.position, transform.position) < DetectableDistance)){
					targetAble = true;
				}else targetAble = false;
			}
		}
	}
			
	
	void OnGUI(){
		if(targetAble){
			targetCoordinates = new Vector3(ScreenCoordinates.x - (TargetBox.width/2),
			                                Screen.height - ScreenCoordinates.y - (TargetBox.height/2),
			                                0);
			textureCoordinate = Pathing.Approach(textureCoordinate,targetCoordinates,lockQuality);
			if(Vector3.Distance(textureCoordinate,targetCoordinates) > 7){
				GUI.Label(new Rect(textureCoordinate.x,textureCoordinate.y, 
			                   TargetBox.width,TargetBox.height),TargetBox);
				Lock = false;
			}else{
				GUI.Label(new Rect(textureCoordinate.x,textureCoordinate.y, 
			        TargetBox.width,TargetBox.height),TargetBoxLocked);
				textureCoordinate.x += Random.Range(-30,30);
				textureCoordinate.y += Random.Range(-30,30);
				lockQuality = Pathing.Approach(lockQuality,1,.01f);
				Lock = true;
			}
		}
	}
	
	bool OnScreen(){
		if(ScreenCoordinates.x < 0 || ScreenCoordinates.x > Screen.width ||
		   ScreenCoordinates.y < 0 || ScreenCoordinates.y > Screen.height){
			return false;
		}
		return true;
	}
	
	public bool LockedOn(){
		return Lock;
	}
}
