using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour {
	
	public Texture2D texture;
	RenderTexture renderTexture;
	public Shader RadarShader;
	// Use this for initialization
	Material Resize;
	
	void Start () {
		Resize = new Material(RadarShader);
		Resize.SetTexture("_MainTex",texture);
		Resize.SetColor("_Color",Color.white);
	}
	
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		
		Graphics.Blit(texture,destination,Resize);
	}
}
