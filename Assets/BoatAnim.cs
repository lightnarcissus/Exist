using UnityEngine;
using System.Collections;

public class BoatAnim : MonoBehaviour {
	
	public static bool boatAllow=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(boatAllow)
		{
			Debug.Log("MOVE BOAT 4REALZ");
			gameObject.animation.Play ("LoadBoat");
			boatAllow=false;
		}
	
	}
}
