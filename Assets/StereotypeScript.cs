using UnityEngine;
using System.Collections;

public class StereotypeScript : MonoBehaviour {

		
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
		
		if(WheelScript.peopleChoice!=16 || WheelScript.peopleChoice!=17)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<10f)
			{
				dialogue.text="I'm trapped!";
			}
			if(dialogueTimer>10f && dialogueTimer<20f)
			{
				dialogue.text="What defines cages me";
			}
			if(dialogueTimer>20f && dialogueTimer<30f)
			{
				dialogue.text="What defines cages me"; //new dialogue here
			}
			if(dialogueTimer>35f)
			{
				dialogue.text="";
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