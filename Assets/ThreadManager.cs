using UnityEngine;
using System.Collections;

public class ThreadManager : MonoBehaviour {
	
	public static int threadSelect=0;
	public static int instanceNumber=0;
	private int currentInstance=0;
	public static bool levelChange=true;
	// Use this for initialization
	void Start () {
		
		instanceNumber=0; //or leave it upto the player to choose
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(levelChange)
		{
			currentInstance=instanceNumber;
		}
		
		if(currentInstance!=instanceNumber)
		{
			PreBirthScript.flag=true;
			levelChange=true;
			
		}
		//player chooses thread/level via the menu
	
	}
}
