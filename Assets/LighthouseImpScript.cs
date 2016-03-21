using UnityEngine;
using System.Collections;

public class LighthouseImpScript : MonoBehaviour {
	
	private GameObject player;
	private bool once=true;
	private float jumpTimer=0f;
	public static bool jump=false;
	public TextMesh dialogue;
	public static bool argue=false;
	
	private float dialogueTimer=0f;
	// Use this for initialization
	void Start () {
		
		
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		
		dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<5f)
			{
				dialogue.text="If only you weren't so hateful";
			}
			
			if(dialogueTimer>5f && dialogueTimer<10f)
			{
				dialogue.text="We may have shared a future together";
			}
		if(dialogueTimer>10f && dialogueTimer<15f)
			{
				dialogue.text="The lighthouse led you astray";
			}
		
			if(dialogueTimer>10f && dialogueTimer<15f)
			{
				dialogue.text="With the promise of light,leading you to your own ruin";
			}
			
			
			if(dialogueTimer>15f)
				dialogue.text="";
			if(dialogueTimer>20f)
				dialogueTimer=0f;
	
		
		if(once)
		{
			player=GameObject.FindGameObjectWithTag ("Player");
			once=false;
			
		}
		
		
		if(argue)
		{
			//play out dialogue
		}
		
		
		if(jump)
		{
			
			transform.position=Vector3.Lerp (transform.position,new Vector3(239.61f,83.127f,486.66f),Time.deltaTime); 
			jumpTimer+=Time.deltaTime;
			if(jumpTimer>3f)
			{
				//Spawn empty crime scene
				Destroy (gameObject);
			}
		}
	}
}
