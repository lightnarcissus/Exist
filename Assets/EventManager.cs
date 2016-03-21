using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {
	
	private int thread=0;
	public static int eventSequence=0;
	public static bool meteorAppear=false;
	public static bool meteorFall=false;
	public static bool bloodRain=false;
	public static bool riots=false;
	public static bool manFalling=false;
	private GameObject meteor;
	// Use this for initialization
	void Start () {
		
		meteor=GameObject.FindGameObjectWithTag ("Meteor");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(eventSequence==0)
		{
			if(PreBirthScript.timer<510f && PreBirthScript.timer>508f)
			{
				meteorAppear=true;
				meteor.SetActive (true);
			}
			
			if(PreBirthScript.timer<370f && PreBirthScript.timer>368f)
			{
				riots=true;
			}
			
			if(PreBirthScript.timer<210f && PreBirthScript.timer>208f)
			{
				bloodRain=true;
			}
			
			//fourth event
		}
		
	
	}
}
