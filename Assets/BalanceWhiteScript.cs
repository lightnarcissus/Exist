using UnityEngine;
using System.Collections;

public class BalanceWhiteScript : MonoBehaviour {

		
	private GameObject player;
	private bool once=true;
	public TextMesh dialogue;
	private float dialogueTimer=0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(once)
		{
			player=GameObject.FindGameObjectWithTag ("Player");
			once=false;
		}
		
		if(WheelScript.peopleChoice!=21 && WheelScript.peopleChoice!=22)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<5f)
			{
				dialogue.text="Prejudice is not an excuse to be biased";
			}
			if(dialogueTimer>15f && dialogueTimer<25f)
			{
				dialogue.text="I merely ask for a fair trial";
			}
			if(dialogueTimer>35f && dialogueTimer<45f)
			{
				dialogue.text="This man hates me more than I do"; //new dialogue here
			}
			if(dialogueTimer>55f && dialogueTimer<65f)
			{
				dialogue.text="We all try escaping our destinies";
			}
			if(dialogueTimer>40f && dialogueTimer<50f)
			{
				dialogue.text="Only to be pushed back into it by the protectors"; //new dialogue here
			}
			
			if(dialogueTimer>105f)
				dialogue.text="";
			if(dialogueTimer>110f)
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