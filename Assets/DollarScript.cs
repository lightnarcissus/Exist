using UnityEngine;
using System.Collections;

public class DollarScript : MonoBehaviour {
	
	private int action=0;
	private float checkTimer=0f;
	public GameObject member1;
	public GameObject member2;
	public GameObject member3;
	public GameObject member4;
	public GameObject member5;
	public GameObject member6;
	public TextMesh dialogue;
	private float dialogueTimer=0f;
	
	
	// Use this for initialization
	void Start () {
		
		
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		
		if(WheelScript.peopleChoice!=4 && WheelScript.peopleChoice!=5 && WheelScript.peopleChoice!=6)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<10f)
			{
				dialogue.text="Burdens of our fathers we carry";
			}
			if(dialogueTimer>10f && dialogueTimer<20f)
			{
				dialogue.text="Of empires built on debts";
			}
			if(dialogueTimer>20f && dialogueTimer<30f)
			{
				dialogue.text="Whose careless rulers we become"; //new dialogue here
			}
			if(dialogueTimer>30f && dialogueTimer<40f)
			{
				dialogue.text="Trading our future for Day One happiness,one note at a time";
			}
			if(dialogueTimer>40f && dialogueTimer<50f)
			{
				dialogue.text="We dug our own graves with folded hands"; //new dialogue here
			}
			
			if(dialogueTimer>50f)
				dialogue.text="";
			if(dialogueTimer>60f)
				dialogueTimer=0f;
		}
	
			member1.animation.Play ("CarryWeight");	
			member2.animation.Play ("CarryWeight");		
			member3.animation.Play ("CarryWeight");		
			member4.animation.Play ("CarryWeight");	
			member5.animation.Play ("CarryWeight");	
			member6.animation.Play ("CarryWeight");	
	
	}
}
