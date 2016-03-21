using UnityEngine;
using System.Collections;

public class DebrisScript : MonoBehaviour {
	
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
			dialogue.text="So many broken dreams";
		}
		
		if(randSelect==1)
		{
			dialogue.text="Broken reminders of what could have been";
		}
		
		if(randSelect==2)
		{
			dialogue.text="Could things have been any different?";
		}
	}
	void OnDisable()
	{
		randSelect=0;
	}
}
