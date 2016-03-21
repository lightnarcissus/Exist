using UnityEngine;
using System.Collections;

public class TentScript : MonoBehaviour {

		
	private GameObject player;
	private bool once=true;
	public TextMesh dialogue;
	private float dialogueTimer=0f;
	
	public static bool tentTop=false;
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
		
		if(WheelScript.peopleChoice!=6 && WheelScript.peopleChoice!=7)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<10f)
			{
				if(transform.parent.gameObject.name=="FemBL")
				dialogue.text="My ways led to our undoing";
				
				if(transform.parent.gameObject.name=="MaleBL")
				dialogue.text="Do not blame the unchangeable";
			}
			if(dialogueTimer>10f && dialogueTimer<20f)
			{
				if(transform.parent.gameObject.name=="FemBL")
				dialogue.text="Why do we keep repeating the same mistakes?";
				
				if(transform.parent.gameObject.name=="MaleBL")
				dialogue.text="Because our imperfections give us purpose";
			}
			if(dialogueTimer>20f && dialogueTimer<30f)
			{
				if(transform.parent.gameObject.name=="FemBL")
				dialogue.text="I regret the decisions we made";
				
				if(transform.parent.gameObject.name=="MaleBL")
				dialogue.text="Regrets are thorny reminders to promises that never bloomed";
			}
					
			if(dialogueTimer>30f)
				dialogue.text="";
			if(dialogueTimer>35f)
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