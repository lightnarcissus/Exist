using UnityEngine;
using System.Collections;

public class TVScript : MonoBehaviour {

		
	private GameObject player;
	private bool once=true;
	public TextMesh dialogue;
	private float dialogueTimer=0f;
	private int randDialogue=0;
	// Use this for initialization
	void Start () {
		dialogue.text="I'm trapped!";
		randDialogue=Random.Range (0,3);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(WheelScript.peopleChoice!=5)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<10f)
			{
				if(randDialogue==0)
				dialogue.text="This reeks of weirdness";
				if(randDialogue==1)
				dialogue.text="I just don't get it";
				if(randDialogue==2)
				dialogue.text="Is this even supposed to make sense?";
			}
			if(dialogueTimer>10f && dialogueTimer<20f)
			{
				if(randDialogue==0)
				dialogue.text="Is this 'art'?";
				if(randDialogue==1)
				dialogue.text="Is this a mute reflection of ourselves?";
				if(randDialogue==2)
				dialogue.text="Is this even supposed to make sense?";
			}
			if(dialogueTimer>20f && dialogueTimer<30f)
			{
				if(randDialogue==0)
				dialogue.text="This reeks of weirdness";
				if(randDialogue==1)
				dialogue.text="Strangely enchanting";
				if(randDialogue==2)
				dialogue.text="Is this a mute reflection of ourselves?";
			}
			if(dialogueTimer>30f && dialogueTimer<40f)
			{
				if(randDialogue==0)
				dialogue.text="Is this a mute reflection of ourselves?";
				if(randDialogue==1)
				dialogue.text="Is this a social commentary or a mime?";
				if(randDialogue==2)
				dialogue.text="Is this 'art'?";
			}
			if(dialogueTimer>40f && dialogueTimer<50f)
			{
				if(randDialogue==0)
				dialogue.text="This reeks of weirdness";
				if(randDialogue==1)
				dialogue.text="Is this 'art'?";
				if(randDialogue==2)
				dialogue.text="What are they doing?";
			}
			
			if(dialogueTimer>50f)
				dialogue.text="";
			if(dialogueTimer>60f)
			{
				randDialogue=Random.Range (0,3);
				dialogueTimer=0f;
				
			}
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