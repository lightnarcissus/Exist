using UnityEngine;
using System.Collections;

public class ArgumentScript : MonoBehaviour {

		
	public GameObject player;
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
		
		if(WheelScript.peopleChoice!=8 && WheelScript.peopleChoice!=9)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<10f)
			{
				dialogue.text="In the Kingdom of Free,the puppets were the kings";
			}
			if(dialogueTimer>10f && dialogueTimer<20f)
			{
				dialogue.text="Their power handicapped by their own greed,one vice for the other";
			}
			if(dialogueTimer>20f && dialogueTimer<30f)
			{
				dialogue.text="Slaves they become of their undoing"; //new dialogue here
			}
			if(dialogueTimer>30f && dialogueTimer<40f)
			{
				dialogue.text="Ruling over a kingdom blinded by an illusion";
			}
			if(dialogueTimer>40f && dialogueTimer<50f)
			{
				dialogue.text="Being controlled by strings that never were"; //new dialogue here
			}
			
			if(dialogueTimer>50f)
				dialogue.text="";
			if(dialogueTimer>60f)
				dialogueTimer=0f;
		}
		
		else
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer>25f)
			{
				dialogueTimer=0f;
				WheelScript.peopleChoice=0;
			}
		}
		
		
		
		
		
		transform.LookAt (player.transform);
	}
}