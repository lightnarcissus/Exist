using UnityEngine;
using System.Collections;

public class DreamSuccessDesk : MonoBehaviour {

		
	private GameObject player;
	private bool once=true;
	public TextMesh dialogue;
	private float dialogueTimer=0f;
	// Use this for initialization
	void Start () {
		dialogue.text="";
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(once)
		{
			player=GameObject.FindGameObjectWithTag ("Player");
			once=false;
		}
		
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<10f)
			{
				dialogue.text="Congrats on your promotion!";
			}
			if(dialogueTimer>10f && dialogueTimer<20f)
			{
				dialogue.text="But the top is another flight up the stairs";
			}

			
			if(dialogueTimer>20f)
				dialogue.text="";
			if(dialogueTimer>25f)
				dialogueTimer=0f;
		
		
		transform.LookAt (player.transform);
	}
}