using UnityEngine;
using System.Collections;

public class BomberScript : MonoBehaviour {

		
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
		
		if(BomberMovement.caught)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<3f)
			{
				dialogue.text="Yes, this was inevitable";
			}
			
			if(dialogueTimer>3f && dialogueTimer<7f)
			{
				dialogue.text="Will you punish me for a crime we all commit?";
			}
			
			
			if(dialogueTimer>7f)
				dialogue.text="";
			if(dialogueTimer>10f)
				dialogueTimer=0f;
		}
		
		else if(Player.confront || Player.shoot)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<6f)
			{
				dialogue.text="So...this is how the cycle repeats";
			}
			
			
			if(dialogueTimer>6f)
				dialogue.text="";
			if(dialogueTimer>60f)
				dialogueTimer=0f;
		}
	
		
		
		
		transform.LookAt (player.transform);
	}
}