using UnityEngine;
using System.Collections;

public class JetThrustVectorController : MonoBehaviour {
	
	public JetThrustVector vectorOne;
	public JetThrustVector vectorTwo;
	byte ThrustBoundary = 90;
	
	public void OnGUI(){
		// 1 = left side
		// 2 = right side
		// both sides = 3;
		int AfterBurner = 0;
		foreach(Touch touch in Input.touches){
			if(touch.position.x < ThrustBoundary && AfterBurner != 1){
				AfterBurner += 1;
			}
			if(touch.position.x > Screen.width - ThrustBoundary && AfterBurner != 2){
				AfterBurner += 2;
			}	
			if(AfterBurner == 3) break;
		}
		
		if (AfterBurner == 3) {
			vectorOne.ApplyAfterBurner();
			vectorTwo.ApplyAfterBurner();
		}
	}
}
