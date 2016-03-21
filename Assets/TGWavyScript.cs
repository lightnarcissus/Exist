using UnityEngine;
using System.Collections;

public class TGWavyScript : MonoBehaviour {
	
	public GameObject member1;
	public GameObject member2;
	public GameObject member3;
	private float timer=0f;
	public TextMesh dialogue;
	private Quaternion orgRot1;
	private Quaternion orgRot2;
	private Quaternion orgRot3;
	public bool playerTalk=false;
	// Use this for initialization
	void Start () {
		orgRot1=member1.transform.rotation;
		orgRot2=member2.transform.rotation;
		orgRot3=member3.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		

		if((WheelScript.peopleChoice!=13 && WheelScript.peopleChoice!=14) || (!playerTalk))
		{
		
		timer+=Time.deltaTime;
		
		if(timer>0f && timer<6f)
		{
			member1.animation.Play ("Talk1");
			member2.animation.Play ("Idle");
			member3.animation.Play ("Idle");
				
			dialogue.text="Caught in a silent competition among ourselves";
		}
		if(timer>6f && timer<12f)
		{
			member1.animation.Play ("Idle");
			member2.animation.Play ("Talk1");
			member3.animation.Play ("Idle");
				
				dialogue.text="A legacy nobody wants to inherit";
		}
		if(timer>12f && timer<20f)
		{
			member1.animation.Play ("Idle");
			member2.animation.Play ("Idle");
			member3.animation.Play ("Talk1");
				
				dialogue.text="Sins of few tainting all our skins";
		}
			
		
		if(timer>=25f)
			{
			dialogue.text="";
			timer=0f;
			}
		}
		
		
		else
		{
			timer+=Time.deltaTime;
			timer+=Time.deltaTime;
			member1.animation.Play ("Idle");
			member2.animation.Play ("Idle");
			member3.animation.Play ("Idle");
			if(timer>25f)
			{
				timer=0f;
				member1.transform.rotation=orgRot1;
				member2.transform.rotation=orgRot2;
				member3.transform.rotation=orgRot3;
				playerTalk=false;
				WheelScript.peopleChoice=0;
			}
		}

	}
}
