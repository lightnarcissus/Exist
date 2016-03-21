using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour {
	
	public static bool dead=false;
	
	public static bool lift=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetButton ("Forward"))
		{
			gameObject.animation.Play ("walk");
		}
		else if(!Player.shoot || !Player.confront && !lift)
		{
			//Debug.Log("Idle");
			gameObject.animation.Play ("Idle");
		}
		else 
		{
			
			if(lift)
			gameObject.animation.Play ("LiftGun");
		}
		
		
		
		if(dead)
		{
			gameObject.animation.Play ("RemainDead");
		}
	
	}
}
