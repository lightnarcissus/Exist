using UnityEngine;
using System.Collections;

public class BlinkScript : MonoBehaviour {
	
	private int randThought=0;
	private string thought;
	private float blinkTimer=0f;
	private int chainedThought=0;
	public GUIStyle style;
	private int connected=0;
	private Rect randRect;
	
	private bool blink=false;
	private float blackoutTimer=0f;
	
	public GameObject blackScreen;
	
	
	public GameObject sfx;
	public AudioClip click;
	public AudioClip scareDrone;
	private float threshold=2f;

	

	// Use this for initialization
	void Start () {
		
//	SoundManager.SetSFXCap (1);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		blinkTimer+=Time.deltaTime;
		
		if(Input.GetMouseButtonDown(0))
		{
		//	SoundManager.PlaySFX (sfx,click);
		}
	}
	
	void OnGUI()
	{
		//SoundManager.PlaySFX(scareDrone);
		
		if(blinkTimer>=threshold)
		{
			//SoundManager.PlaySFX(sfx,scareDrone);
			if(connected!=1)
			{
			blink=true;
			blinkTimer=0f;
			threshold-=0.02f;
			}
			
			randThought=Random.Range(0,12);
			
			if(SkinSelect.skinChoose==2)
			{	
			if(randThought==0)
			{
				thought="Why don't you have one color?";
			}
			if(randThought==1)
			{
				thought="I do not understand your kind";
			}
			if(randThought==2)
			{
				thought="Must be tragic to be colorblind";
			}	
			if(randThought==3)
			{
				thought="Differences define us";
			}	
			if(randThought==4)
			{
				thought="Only the fittest survive";
			}	
			if(randThought==5)
			{
				thought="You discriminate as much as I do";
			}	
			if(randThought==6)
			{
				thought="Why do you stare at me?";
			}	
			if(randThought==7)
			{
				thought="I am not like you";
			}	
			if(randThought==8)
			{
				thought="I don't sympathize for any";
			}	
			if(randThought==9)
			{
				thought="My eyes see my truth";
			}	
			if(randThought==10)
			{
				thought="Stop looking down at me";
			}	
			if(randThought==11)
			{
				thought="I will never be like you";
			}	
			}
			
			
			else
			{	
			if(randThought==0)
			{
				thought="How can you be blind to it?";
			}
			if(randThought==1)
			{
				thought="Ignorance won't solve anything";
			}
			if(randThought==2)
			{
				thought="History shapes our thinking";
			}	
			if(randThought==3)
			{
				thought="Differences define us";
			}	
			if(randThought==4)
			{
				thought="Why do you refuse to see the obvious?";
			}	
			if(randThought==5)
			{
				thought="Blaming the victim is part of the problem";
			}	
			if(randThought==6)
			{
				thought="Why do you stare at me?";
			}	
			if(randThought==7)
			{
				thought="I am not like you";
			}	
			if(randThought==8)
			{
				thought="We don't ask for sympathy";
			}	
			if(randThought==9)
			{
				thought="We are more than our skin";
			}	
			if(randThought==10)
			{
				thought="Stop looking down at me";
			}	
			if(randThought==11)
			{
				thought="I will never be like you";
			}	
			}
			randRect=new Rect(Random.Range (10f,Screen.width),Random.Range (10f,Screen.height),150f,150f);
			GUI.Label(randRect,thought,style);
			connected=0;
		
		}
		if(blink)
		{
			if(blackoutTimer<=0.6f)
			{
			gameObject.camera.enabled=false;
			blackScreen.camera.enabled=true;
			blackoutTimer+=Time.deltaTime;
				
			}
			else
			{
			blackoutTimer=0f;
				blink=false;
			gameObject.camera.enabled=true;
			blackScreen.camera.enabled=false;
			}
			
		}
		
		
		GUI.Label(randRect,thought,style);
		
		
		
		if(randRect.Contains (Event.current.mousePosition))
		{
			connected=1;
		Debug.Log("YES!!");
	//			SoundManager.PlaySFX (sfx,click);
			GUI.Label(randRect,"",style);
		}
		
	
	}
}
