using UnityEngine;
using System.Collections;

public class BalanceBlackScript : MonoBehaviour {

		
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
			if(dialogueTimer>5f && dialogueTimer<15f)
			{
				dialogue.text="For the colorblind,there's only one color";
			}
			if(dialogueTimer>25f && dialogueTimer<35f)
			{
				dialogue.text="You say be a part of the system";
			}
			if(dialogueTimer>45f && dialogueTimer<55f)
			{
				dialogue.text="But what can we do when the flow's against us"; //new dialogue here
			}
			if(dialogueTimer>65f && dialogueTimer<75f)
			{
				dialogue.text="We try escaping our destinies";
			}
			if(dialogueTimer>95f && dialogueTimer<105f)
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