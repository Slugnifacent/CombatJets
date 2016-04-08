using UnityEngine;
using System.Collections;

public static class Utilities {
	
	#region Wrap
	public static sbyte Wrap(sbyte Number, sbyte Min, sbyte Max){
		if(Number < Min) return Max;
		if(Number > Max) return Min;
		return Number;
	}
	
	public static byte Wrap(byte Number, byte Min, byte Max){
		if(Number < Min) return Max;
		if(Number > Max) return Min;
		return Number;
	}
	
	public static int Wrap(int Number, int Min, int Max){
		if(Number < Min) return Max;
		if(Number > Max) return Min;
		return Number;
	}
	
	public static uint Wrap(uint Number, uint Min, uint Max){
		if(Number < Min) return Max;
		if(Number > Max) return Min;
		return Number;
	}
	
	public static long Wrap(long Number, long Min, long Max){
		if(Number < Min) return Max;
		if(Number > Max) return Min;
		return Number;
	}
	
	public static ulong Wrap(ulong Number, ulong Min, ulong Max){
		if(Number < Min) return Max;
		if(Number > Max) return Min;
		return Number;
	}
		
	public static double Wrap(double Number, double Min, double Max){
		if(Number < Min) return Max;
		if(Number > Max) return Min;
		return Number;
	}
	#endregion Wrap
	
	
}
