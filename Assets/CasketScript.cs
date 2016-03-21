using UnityEngine;
using System.Collections;

public class CasketScript : MonoBehaviour {

		
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
		
		if(WheelScript.peopleChoice!=31 && WheelScript.peopleChoice!=32)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<5f)
			{
				dialogue.text="Heroes for some, murderers for another";
			}
			if(dialogueTimer>5f && dialogueTimer<10f)
			{
				dialogue.text="Can these honors and ornaments wash away our sins";
			}
			if(dialogueTimer>10f && dialogueTimer<15f)
			{
				dialogue.text="For when I close my eyes, I'm still trapped in the nightmare"; //new dialogue here
			}
		
			if(dialogueTimer>20f)
				dialogue.text="";
			if(dialogueTimer>25f)
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