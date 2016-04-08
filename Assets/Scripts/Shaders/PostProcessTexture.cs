using UnityEngine;
using System.Collections;

public class PostProcessTexture : MonoBehaviour {
	public RenderTexture texture;
	Rect ScreenTexture = new Rect(0,0,Screen.width,Screen.height);
	void OnGUI(){
		GUI.DrawTexture(ScreenTexture,texture);
	}
}
