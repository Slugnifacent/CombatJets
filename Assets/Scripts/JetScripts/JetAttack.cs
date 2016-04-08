using UnityEngine;
using System.Collections;



public class JetAttack : MonoBehaviour {
	public GameObject missile;
	public GameObject bullet;
	float bulletTimer;
	bool fireBullet;
	bool missileFired;
	
	// Use this for initialization
	void Start () {
		Input.multiTouchEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		/**/
		if(Input.GetMouseButtonDown(0) && gameObject.GetComponent<JetController>().missileCount > 0){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit[] hits = Physics.RaycastAll(ray);
			if(hits.Length > 0){
				foreach(RaycastHit hit in hits){
					GameObject item = hit.collider.gameObject;
					if(item.tag == "TargetAble"){
						GameObject newMissile = (GameObject)Instantiate(missile);
						if(item.GetComponent<Targetable>().LockedOn()){
							newMissile.GetComponent<Missile>().AssignTarget(item,transform);
						}else {
							newMissile.GetComponent<Missile>().AssignTarget(null,transform);
						}
						gameObject.GetComponent<JetController>().missileCount--;
					}
				}
			}
		}
		fireBullet = false;
		int count = 0;
		foreach(Touch tuch in Input.touches){
				if(tuch.position.x > 200 && tuch.position.x < (Screen.width - 200)){
					fireBullet = true;
					count++;
				}
		}
		if(count == 0 ){
			missileFired = false;
		}
		if(Input.touchCount > 1 ){
			return;
		}
		
		if(Input.touchCount == 1 ){
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began && gameObject.GetComponent<JetController>().missileCount > 0){
				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit[] hits = Physics.RaycastAll(ray);
				if(hits.Length > 0){
					foreach(RaycastHit hit in hits){
						GameObject item = hit.collider.gameObject;
						if(item.tag == "TargetAble"){
						GameObject newMissile = (GameObject)Instantiate(missile);
							if(item.GetComponent<Targetable>().LockedOn()){
								newMissile.GetComponent<Missile>().AssignTarget(item,transform);
							}else {
								newMissile.GetComponent<Missile>().AssignTarget(null,transform);
							}
							fireBullet = false;
							missileFired = true;
							gameObject.GetComponent<JetController>().missileCount--;
						}
					}
				}
			}
		}
				
		if(fireBullet && !missileFired){
			if(bulletTimer <= 0 && gameObject.GetComponent<JetController>().bulletCount > 0){
				GameObject newBullet = (GameObject)Instantiate(bullet);
				newBullet.GetComponent<Bullet>().Fire(gameObject.transform);
				bulletTimer = .1f;
				gameObject.GetComponent<JetController>().bulletCount--;
			}
		}
		bulletTimer -= Time.deltaTime;
	}
	public void OnGUI(){
	GUI.Label(new Rect(4,Screen.height - 35,400,30), "Position: ");
		foreach(Touch touch in Input.touches){
			if(touch.position.x > 200 && touch.position.x < (Screen.width - 200)){
				GUI.Label(new Rect(4,Screen.height - 35,400,30), "Position: " + touch.position.ToString());
			}
		}
	}
}