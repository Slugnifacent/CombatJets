using UnityEngine;
using System.Collections;

public static class Pathing {
	public static float Approach(float Position, float Target, float speed){
		float direction = (Target - Position);
		return Position + direction*speed;
	}
	
	public static Vector2 Approach(Vector2 Position, Vector2 Target, float speed){
		Vector2 direction = (Target - Position);
		return Position + direction*speed;
	}
	
	public static Vector3 Approach(Vector3 Position, Vector3 Target, float speed){
		Vector3 direction = (Target - Position);
		return Position + direction*speed;
	}
	
	public static Vector4 Approach(Vector4 Position, Vector4 Target, float speed){
		Vector4 direction = (Target - Position);
		return Position + direction*speed;
	}

}
