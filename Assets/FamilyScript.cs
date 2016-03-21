using UnityEngine;
using System.Collections;

public class FamilyScript : MonoBehaviour {

		
	private GameObject player;
	private bool once=true;
	public TextMesh dialogue;
	public TextMesh impDialogue;
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
		
		if(WheelScript.peopleChoice!=31 && WheelScript.peopleChoice!=32)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<5f)
			{
				dialogue.text="Why do we fight?";
			}
			if(dialogueTimer>5f && dialogueTimer<10f)
			{
				impDialogue.text="Because echoes only exist in empty rooms";
			}
			if(dialogueTimer>10f && dialogueTimer<15f)
			{
				dialogue.text="How much of an individual should be sacrificed for the family?"; //new dialogue here
			}
			if(dialogueTimer>20f && dialogueTimer<25f)
			{
				impDialogue.text="As much as it takes for the space between us to collapse";
			}
			
			if(dialogueTimer>25f)
				dialogue.text="";
			if(dialogueTimer>30f)
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