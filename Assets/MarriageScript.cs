using UnityEngine;
using System.Collections;

public class MarriageScript : MonoBehaviour {
	
	public TextMesh dialogue;
	private int randSelect;
	// Use this for initialization
	void Start () {
		
	/*	aud.clip=cave;
		aud.time=40f;
		
		amb.clip=waves;
		amb.volume=0.3f;
	*/
	}
	
	// Update is called once per frame
	void OnEnable () {
		
		randSelect=Random.Range (0,3);
	
	}
	void FixedUpdate()
	{
		if(randSelect==0)
		{
			dialogue.text="You cared too much about your work";
		}
		
		if(randSelect==1)
		{
			dialogue.text="All those old promises forgotten";
		}
		
		if(randSelect==2)
		{
			dialogue.text="Were you ever there for us?";
		}
	}
	void OnDisable()
	{
		randSelect=0;
	}
}
