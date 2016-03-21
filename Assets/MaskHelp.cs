using UnityEngine;
using System.Collections;

public class MaskHelp : MonoBehaviour {
	
	public TextMesh dialogue;
	public static bool giveUpWarning=false;
	public static bool quitGameWarning=false;
	private float warningTimer=0f;
	private float quitTimer=0f;
	public static bool bombPoint=false;
	
	public static bool tutorial=false;
	public static bool startWarning=false;
	public static bool quitAllow=false;
	public static bool interaction=false;
	public static bool general=false;
	private GameObject player;
	private bool once=true;
	private float dialogueTimer=0f;
	private float startTimer=0f;
	private int randGeneral=0;
	private int randDialogue=0;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable()
	{
		dialogueTimer=0f;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		
		if(once)
		{
			player=GameObject.FindGameObjectWithTag ("Player");
			once=false;
		}
		
		if(tutorial)
		{
			
		}
		
		
		if(startWarning)
		{
			startTimer+=Time.deltaTime;
			
			//City Start
		if(ResetScript.sceneChoice==0)	
			{
			if(startTimer<6f)
			{
				dialogue.text="Borne out of your own prejudice";
			}
			
			if(startTimer>6f && startTimer<9f)
			{
				dialogue.text="A shadow walks in the light";
			}
				if(startTimer>9f && startTimer<12f)
			{
				dialogue.text="You know who it is";
			}
				
				if(startTimer>12f && startTimer<15f)
			{
				dialogue.text="But do you even wish to find that out?";
			}
				
				if(startTimer>15f)
				{
					startTimer=0f;
					startWarning=false;
				}
				
			}
			
			//Desert Starter
			
			else if(ResetScript.sceneChoice==1)
			{
				if(startTimer<3f)
			{
				dialogue.text="Many futures exist at this crossroads";
			}
			
			if(startTimer>3f && startTimer<6f)
			{
				dialogue.text="One key, but many chests";
			}
				
				if(startTimer>6f && startTimer<9f)
			{
				dialogue.text="Only one opens to the real";
			}
			
			if(startTimer>9f && startTimer<12f)
			{
				dialogue.text="While others eventually grow empty";
			}
				
			if(startTimer>12f && startTimer<15f)
			{
				dialogue.text="But Time flows by unflinchingly";
			}
			
			if(startTimer>15f && startTimer<18f)
			{
				dialogue.text="Drowning everything in its sands";
			}
				
				if(startTimer>18f && startTimer<21f)
			{
				dialogue.text="What was once a future shall become a forgotten relic";
			}
				
			if(startTimer>21f)
			{
					startTimer=0f;
				startWarning=false;
					
			}
				
				
			}
		}
		
		if(giveUpWarning)
		{
			//speak about the warning
			warningTimer+=Time.deltaTime;
			if(warningTimer<3f)
			dialogue.text="Giving up so soon?";
			if(warningTimer>3f && warningTimer<6f)
			dialogue.text="Happiness does exist, you know";
					
			
			if(warningTimer>6f)
			dialogue.text="Or maybe it's a myth to give our lives some purpose";
			
			if(warningTimer>9f)
			{
				warningTimer=0f;
				giveUpWarning=false;
			}
		}
		else if(ResetScript.sceneChoice==0)
		{
			
			dialogueTimer+=Time.deltaTime;
			
			if(general)
			{
			
			if(InteractionScript.anarchist)
			{
				dialogue.text="The dissident speaks grey truths";
			}
			
			else if(InteractionScript.pyramid)
			{
				dialogue.text="In the heart of the glass lies a reflection of your Answer";
			}
			
			else if(InteractionScript.glassCase)
			{
				dialogue.text="We bury those we judge as misfits deep in the ground";
			}
			
			else if(InteractionScript.chairJudge)
			{
				dialogue.text="Money and power. But what came first?";
			}
			
			else if(InteractionScript.angry)
			{
				dialogueTimer+=Time.deltaTime;
				if(dialogueTimer<3f)
				dialogue.text="Anger gets you closer to your hateful heart";
				if(dialogueTimer>3f && dialogueTimer<6f)
					dialogue.text="But what of the destruction it leaves in its wake";
				if(dialogueTimer>8f)
				{
					dialogueTimer=0f;
				}
			}
				else
				{
					if(dialogueTimer<0.2f)
					randGeneral=Random.Range (0,3);
					
					
					if(MaskScript.changeTimer>2.3f)
					{
						randGeneral=Random.Range(0,3);
					}
					if(randGeneral==0)
					dialogue.text="Sounds help you. Keep your ears open for audio cues.";
					
					if(randGeneral==1)
					dialogue.text="Every single thing around you may be a hint to find The Answer";
					
					if(randGeneral==2)
						dialogue.text="Memories in dreams may be volatile but they are also permanent";
				}
			}
			
			else if(interaction)
			{
				if(dialogueTimer<0.2f)
				randDialogue=Random.Range (0,8);
				
				if(MaskScript.changeTimer>2.3f)
					{
						randDialogue=Random.Range(0,8);
					}
				
				
				if(dialogueTimer>0.5f && dialogueTimer<8f)
				{
					if(randDialogue==0)
					dialogue.text="Each quarter signifies a specific part of your subconscious";
					
					if(randDialogue==1)
					dialogue.text="The more you 'think', the deeper your thought processes go";
					
					if(randDialogue==2)
					dialogue.text="Your surroundings and thoughts influence one another";
					
					
					if(randDialogue==3)
					dialogue.text="Emotions can subtly alter the way the world functions";
					
					if(randDialogue==4)
					dialogue.text="Subconscious is where your core and the world outside intertwine";
					
					
					if(randDialogue==5)
					dialogue.text="Every single thing around you may be a hint to find The Answer";
					
					
					if(randDialogue==6)
					dialogue.text="Certain changes are made instantly the moment you think about them";
					
					if(randDialogue==7)
					dialogue.text="Sounds are your friends. Keep your ears open for audio cues.";
					
				}
			}
			
			
		}
		else if(ResetScript.sceneChoice==1)
		{
			dialogueTimer+=Time.deltaTime;
			if(general)
			{
				
				
			if(InteractionScript.artist)
			{
					dialogue.text="That artist seemed to have quite a peculiar painting";
			}
				
			else if(InteractionScript.family)
			{
					dialogue.text="Something must have unsettled the scale's balance";
			}
				
			else if(InteractionScript.casket)
			{
					dialogue.text="Living and dying by the gun";
			}
				
				
			else if(InteractionScript.noose)
			{
					dialogue.text="Mirror,Mirror,where do thee hide your secrets?";
			}
				
				
			else if(InteractionScript.desk)
			{
					dialogue.text="Freedom is premium when you're in a cage";
			}
				
			else if(InteractionScript.guide)
			{
					dialogue.text="You could have been quite an intelligent lecturer";
			}
				
				else
				{
					
					if(dialogueTimer<0.2f)
					randGeneral=Random.Range (0,6);
					
					if(MaskScript.changeTimer>2.3f)
					{
						randGeneral=Random.Range(0,6);
					}
					
					if(randGeneral==0)
					dialogue.text="Sounds help you. Keep your ears open for audio cues.";
					
					if(randGeneral==1)
					dialogue.text="Every single thing around you may be a hint to find The Answer";
					
					if(randGeneral==2)
						dialogue.text="Memories in dreams may be volatile but they are also permanent";
					
					if(randGeneral==3)
						dialogue.text="This sandstorm shall bury your Answer....eventually";
					
					if(randGeneral==4)
						dialogue.text="You can Give Up on this mythical search for Happiness anytime";
					
					if(randGeneral==5)
						dialogue.text="One key, so many chests. But which holds your true Happiness?";
				}
				
			}
			
			
			
			
			else if(interaction)
			{
				if(dialogueTimer<0.2f)
				randDialogue=Random.Range (0,8);
						
				
				if(MaskScript.changeTimer>2.3f)
					{
						randDialogue=Random.Range(0,8);
					}
				
				if(dialogueTimer>0.5f && dialogueTimer<8f)
				{
					if(randDialogue==0)
					dialogue.text="Each quarter signifies a specific part of your subconscious";
					
					if(randDialogue==1)
					dialogue.text="The more you 'think', the deeper your thought processes go";
					
					if(randDialogue==2)
					dialogue.text="Your surroundings and thoughts influence one another";
					
					
					if(randDialogue==3)
					dialogue.text="Emotions can subtly alter the way the world functions";
					
					if(randDialogue==4)
					dialogue.text="Subconscious is where your core and the world outside intertwine";
					
					
					if(randDialogue==5)
					dialogue.text="Every single thing around you may be a hint to find The Answer";
					
					
					if(randDialogue==6)
					dialogue.text="Certain changes are made instantly the moment you think about them";
					
					if(randDialogue==7)
					dialogue.text="Sounds are your friends. Keep your ears open for audio cues.";
					
				}
			}
			
			else if(Player.chestOpen)
			{
				dialogueTimer+=Time.deltaTime;
				if(dialogueTimer<3f)
				dialogue.text="There is no Happiness to be found here";
				
				if(dialogueTimer>3f && dialogueTimer<6f)
					dialogue.text="You can still look, it's never too late";
				
				if(dialogueTimer>6f && dialogueTimer<9f)
					dialogue.text="Or is it?";
				
				if(dialogueTimer>9f)
					dialogueTimer=0f;
			}
			
		
			
		}
		
		if(quitGameWarning)
		{
			quitTimer+=Time.deltaTime;
			if(quitTimer<3f)
			{
				dialogue.text="Are you sure you want to wake up?";
			}
			if(quitTimer>3f)
			{
				dialogue.text="";
				quitAllow=true;
			}
		}
		transform.LookAt (player.transform);
	}
	
}
