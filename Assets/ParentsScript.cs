﻿using UnityEngine;
using System.Collections;

public class ParentsScript : MonoBehaviour {

		
	private GameObject player;
	private bool once=true;
	public TextMesh dialogue;
	private float dialogueTimer=0f;
	// Use this for initialization
	void Start () {
		dialogue.text="I'm trapped!";
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(once)
		{
			player=GameObject.FindGameObjectWithTag ("Player");
			once=false;
		}
		
	//	if(WheelScript.peopleChoice!=31 && WheelScript.peopleChoice!=32)
	//	{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<5f)
			{
				dialogue.text="We expect great things from you!";
			}
			if(dialogueTimer>5f && dialogueTimer<10f)
			{
				dialogue.text="Would you kindly fulfill our incomplete dreams?";
			}
			if(dialogueTimer>10f && dialogueTimer<15f)
			{
				dialogue.text="You should do what we say, as we have seen the world more than you have"; //new dialogue here
			}
		
			if(dialogueTimer>20f)
				dialogue.text="";
			if(dialogueTimer>25f)
				dialogueTimer=0f;
	//	}
		
	/*	else
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer>25f)
			{
				dialogueTimer=0f;
				WheelScript.peopleChoice=0;
			}
		}
	*/	
		
		
		
		
		transform.LookAt (player.transform);
	}
}