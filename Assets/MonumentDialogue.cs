using UnityEngine;
using System.Collections;

public class MonumentDialogue : MonoBehaviour {
	
	public TextMesh dialogue;
	public GameObject player;
	private float timer=0f;
	private bool once=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		transform.LookAt (player.transform);
		
		timer+=Time.deltaTime;
		
		if(timer<6f)
		{
			dialogue.text="They say this monument has strange powers";
		}
		
		if(timer>6f && timer<12f)
		{
			dialogue.text="If you can wrap your mind around it";
		}
		
		if(timer>12f && timer<18f)
		{
			dialogue.text="It can give you a glimpse of the Dark Forest";
		}
		if(timer>18f && timer<20f)
		{
			dialogue.text="";
		}
		if(timer>20f)
		{
			timer=0f;
		}
	
	}
}
