using UnityEngine;
using System.Collections;

public class DisplayScript : MonoBehaviour {

		
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
		
		if(EmotionScript.emotion==4)
		{
			dialogue.text="Riots have broken out.\n Stay tuned for more!";
		}
		
		else if(WheelScript.peopleChoice!=8 && WheelScript.peopleChoice!=9)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<10f)
			{
				dialogue.text="Colored man commits crime.\n Should you be scared?";
			}
			if(dialogueTimer>10f && dialogueTimer<20f)
			{
				dialogue.text="New virus discovered.\n Could you be its next victim?";
			}
			if(dialogueTimer>20f && dialogueTimer<30f)
			{
				if(Bomber.bomb)
				{
					if(Bomber.bombSite==GameObject.FindGameObjectWithTag ("Rally"))
					{
						dialogue.text="Large crowd gathers at a big \n political rally";
					}
					if(Bomber.bombSite==GameObject.FindGameObjectWithTag ("War"))
					{
						dialogue.text="Controversial hearing on racial \n crimes is underway";
					}
				}
				else
				dialogue.text="Is your food being adulterated \n by foreign traders?"; 
			}
			if(dialogueTimer>30f && dialogueTimer<40f)
			{
				if(Bomber.loc1 && !Bomber.bomb)
				{
					if(Bomber.location1==GameObject.FindGameObjectWithTag ("Rally"))
					{
						dialogue.text="Large crowd gathers at a big \n political rally";
					}
					if(Bomber.location1==GameObject.FindGameObjectWithTag ("War"))
					{
						dialogue.text="Controversial hearing on racial \n crimes is underway";
					}
				}
				else
				dialogue.text="Government continues to exist \n in its non-existence";
			}
			if(dialogueTimer>40f && dialogueTimer<50f)
			{
				dialogue.text="Why are our children so violent? \n We find out"; 
			}
			
			if(dialogueTimer>50f && dialogueTimer<60f)
			{
				if(Bomber.loc1 && !Bomber.bomb)
				{
					if(Bomber.location1==GameObject.FindGameObjectWithTag ("Rally"))
					{
						dialogue.text="Large crowd gathers at a \n big political rally";
					}
					if(Bomber.location1==GameObject.FindGameObjectWithTag ("War"))
					{
						dialogue.text="Controversial hearing on \n racial crimes is underway";
					}
				}
				else
				dialogue.text="Would you be employed if immigration \n policies were changed?";
			}
			if(dialogueTimer>60f && dialogueTimer<70f)
			{
				dialogue.text="Leader threatens foreign leader \n with War that won't involve them"; 
			}
			
			if(dialogueTimer>70f && dialogueTimer<80f)
			{
				if(Bomber.bomb)
				{
					if(Bomber.bombSite==GameObject.FindGameObjectWithTag ("Rally"))
					{
						dialogue.text="Large crowd gathers at \n a big political rally";
					}
					if(Bomber.bombSite==GameObject.FindGameObjectWithTag ("War"))
					{
						dialogue.text="Controversial hearing \n on racial crimes is underway";
					}
				}
				else
				dialogue.text="Is your privacy being invaded by spies?\n We investigate"; 
			}
			
			if(dialogueTimer>80f && dialogueTimer<90f)
			{
				dialogue.text="Terror warning issued.\n We discuss the possible suspects"; 
			}
			
			if(dialogueTimer>90f)
			{
				dialogue.text="";
				dialogueTimer=0f;
			}
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
		
	//	transform.LookAt(player.transform);
		
		
		
		
	}
}