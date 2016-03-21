using UnityEngine;
using System.Collections;

public class DrownScript : MonoBehaviour {
	
	private GameObject currentGroup;
	private float timerFactor;
	private bool once=true;
	// Use this for initialization
	void Start () {
	timerFactor=0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//				Debug.Log (transform.position.y);
		if(timerFactor<12f)
		timerFactor+=Time.deltaTime;
		if(ResetScript.sceneChoice==1)
		{
		if(timerFactor>10f)
		{
		transform.position=new Vector3(transform.position.x,transform.position.y+0.11f,transform.position.z);
		timerFactor=0f;
		}
			
			if(Player.giveUp)
			{
				transform.position=new Vector3(transform.position.x,transform.position.y+0.005f,transform.position.z);
				
			}
	
		}
	
	}
}
