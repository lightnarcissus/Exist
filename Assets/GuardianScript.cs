using UnityEngine;
using System.Collections;

public class GuardianScript : MonoBehaviour {

		
	public TextMesh dialogue;
	private float dialogueTimer=0f;
	// Use this for initialization
	void Start () {
		dialogue.text="";
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(WheelScript.peopleChoice!=5 && WheelScript.peopleChoice!=4)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<5f)
			{
				dialogue.text="It is dangerous to go outside";
			}
			if(dialogueTimer>5f && dialogueTimer<10f)
			{
				dialogue.text="Stay safe within these walls";
			}
			if(dialogueTimer>10f && dialogueTimer<15f)
			{
				dialogue.text="These walls protect you from the darkness that lurks outside"; //new dialogue here
			}
			if(dialogueTimer>20f && dialogueTimer<25f)
			{
				dialogue.text="You are truly free within these walls";
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
		
		
		
	}
}