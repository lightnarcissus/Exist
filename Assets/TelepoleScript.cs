using UnityEngine;
using System.Collections;

public class TelepoleScript : MonoBehaviour {

		
	public TextMesh dialogue;
	private float dialogueTimer=0f;
	public static bool tentTop=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		
		if(WheelScript.peopleChoice!=11 && WheelScript.peopleChoice!=12)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<10f)
			{
				if(transform.parent.gameObject.name=="SkinHeadWhite1")
				dialogue.text="Sins of our fathers haunting us";
				
				if(transform.parent.gameObject.name=="SkinHeadWhite2")
				dialogue.text="No regrets";
				
				if(transform.parent.gameObject.name=="SkinHeadWhite3")
				dialogue.text="Why do we repeat the same mistakes?";
			}
			if(dialogueTimer>10f && dialogueTimer<20f)
			{
				if(transform.parent.gameObject.name=="SkinHeadWhite1")
				dialogue.text="A taint we never wanted to inherit";
				
				if(transform.parent.gameObject.name=="SkinHeadWhite2")
				dialogue.text="We deserve it. We have helped others so much";
				
				if(transform.parent.gameObject.name=="SkinHeadWhite3")
				dialogue.text="Born in shadows,people call you names";
			}
					
			if(dialogueTimer>20f)
				dialogue.text="";
			if(dialogueTimer>25f)
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
		
		
		
	}
}