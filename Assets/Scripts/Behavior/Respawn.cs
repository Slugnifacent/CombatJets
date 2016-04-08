using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
	public Transform RespawnLocation;
	public float DistanceFromSpawnPoint;
	public static bool Shutdown = false;
	public static bool Reload = false;
	
	void OnDestroy(){
		if(!Shutdown && !Reload){
			Spawn();
		}
	}
	
	void Spawn(){
		GameObject newObject = (GameObject)Instantiate(gameObject);
		newObject.transform.position = RespawnLocation.position;
		newObject.transform.position += (Random.onUnitSphere*DistanceFromSpawnPoint);
		newObject.name = "Respawn";
		newObject.GetComponent<Flee>().enabled = true;
		newObject.GetComponent<Targetable>().enabled = true;
	}
	
	void OnLevelWasLoaded(){
		GameObject[] clones = GameObject.FindGameObjectsWithTag ("TargetAble");
    	for(int index = 0; index < clones.Length; index++){
        	if(clones[index].name == "Respawn"){
				Reload = true;
				Destroy(clones[index]);
			}
   		}
	}
	
	void OnApplicationQuit(){
		Shutdown = true;
	}
}
