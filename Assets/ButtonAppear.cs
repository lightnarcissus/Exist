using UnityEngine;
using System.Collections;

public class ButtonAppear : MonoBehaviour {
	
	public GameObject orgButton;
	public GameObject glowButton;
	public GameObject outerSprite;
	
	private Rect bg1;
	private Rect bg2;
	private Rect bg3;
	private Rect bg4;
	
	public UILabel typeThought;
	
	public UIButton helpThought;
	public UIButton menuThought;
	
	private float actionNode1timer;
	private float actionNode2timer;
	private float actionNode3timer;
	private float actionNode4timer;
	
	public Texture redback;
	public Texture greenback;
	public Texture blueback;
	public Texture goldback;
	
	private float screenHeight;
	public static bool active=false;
	private float screenWidth;
	
	private int buttonType=0;
	public static int activeButton=0;
	
	private bool once=true;
	private float activeWaitTimer=0f;
	private Vector3 orgSize=new Vector3(380f,270f,0f);
	private Vector3 finalSize=new Vector3(Screen.width*1.5f,Screen.height*1.5f,0f);
	private float growTimer=0f;
	
	public static bool starter=false;
	
	public static bool convo=false;
	// Use this for initialization
	void Start () {
		
		glowButton.SetActive (false);
		outerSprite.SetActive (false);
		
		screenWidth=Screen.width/2f;
		screenHeight=Screen.height/2f;

		helpThought.gameObject.SetActive (false);
		menuThought.gameObject.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (activeButton);
		//Debug.Log (active);
		if(!convo)
		{
		if(!active)
		{
		if(Input.GetMouseButtonDown(0))
		{
			active=true;
			once=true;
		}
		}
		}
		
		
		if(active)
		{
			if(once)
			{
			orgButton.SetActive (true);
			glowButton.SetActive (false);
			outerSprite.SetActive (false);
			once=false;
			}
			
			if(activeWaitTimer<1.5f)
		activeWaitTimer+=Time.deltaTime;
			
			if(activeWaitTimer>1f)
			{
			if(Input.GetMouseButtonDown(0))
			{
				active=false;
			}
			}
		}
		else
		{
			activeWaitTimer=0f;
			orgButton.SetActive (false);
		glowButton.SetActive (false);
		outerSprite.SetActive (false);
		}
		
		
			if(active)
		{
			if(activeButton==0)
			{
				if(!starter)
				{
				helpThought.gameObject.SetActive (true);
				menuThought.gameObject.SetActive (true);
				
				if(helpThought.GetComponent<ButtonThought>().active)
				{
					
				}
				if(menuThought.GetComponent<ButtonThought>().active)
				{
					
				}
					
				}
				
			}
			else
			{
				if(!starter)
				{
				helpThought.gameObject.SetActive (false);
				menuThought.gameObject.SetActive (false);
				}
			}
						typeThought.enabled=true;	
			
		if(orgButton.transform.parent.gameObject.name=="RedButton")
		{
			buttonType=3;
		}
		
		if(orgButton.transform.parent.gameObject.name=="GreenButton")
		{
			buttonType=2;
				
		}
		if(orgButton.transform.parent.gameObject.name=="BlueButton")
		{
			buttonType=1;
		}
		if(orgButton.transform.parent.gameObject.name=="YellowButton")
		{
			buttonType=4;
			
		}
			
			if(buttonType==activeButton)
				{
				if(buttonType==1)
				{
				ThoughtManager.blueActive=true;
				ThoughtManager.greenActive=false;
				ThoughtManager.redActive=false;
				ThoughtManager.yellowActive=false;
					
				typeThought.text="People";
				
				}
				else if(buttonType==2)
				{
				ThoughtManager.greenActive=true;
				ThoughtManager.redActive=false;
				ThoughtManager.blueActive=false;
				ThoughtManager.yellowActive=false;
					
					typeThought.text="Abstract";
				}
				else if(buttonType==3)
				{
				ThoughtManager.redActive=true;
				ThoughtManager.greenActive=false;
				ThoughtManager.blueActive=false;
				ThoughtManager.yellowActive=false;
					
					typeThought.text="Environment";
				
				}
				else if(buttonType==4)
				{
				ThoughtManager.yellowActive=true;
				ThoughtManager.greenActive=false;
				ThoughtManager.redActive=false;
				ThoughtManager.blueActive=false;
					
					typeThought.text="Self";
				}
		orgButton.SetActive (false);
		glowButton.SetActive (true);
		outerSprite.SetActive (true);
				
				growTimer+=Time.deltaTime;
				if(growTimer>3f)
				{
					growTimer=3f;
				}
				
		outerSprite.transform.localScale=Vector3.Lerp (orgSize,finalSize,growTimer/3f);
				}
				else
				{
					orgButton.SetActive (true);
					glowButton.SetActive (false);
					
				growTimer-=Time.deltaTime;
				//Debug.Log ("GrowTimer"+growTimer);
				outerSprite.transform.localScale=Vector3.Lerp (finalSize,orgSize,1f-growTimer/3f);
				if(growTimer<=0f)
				{
					outerSprite.SetActive (false);
					growTimer=0f;
				}
				
				}
		
		//Debug.Log(buttonType);
	
	}
		else
		{
			typeThought.enabled=false;
			activeButton=0;
		}
	}
	void OnHover(bool isOver)
	{
		if(active)
		{
		if(isOver)
		{	
		if(buttonType==1)
				{
					activeButton=1;
				}
		else if(buttonType==2)
				{
					activeButton=2;
				}
		else if(buttonType==3)
				{
					activeButton=3;
				}
		else
				{
					activeButton=4;
				}
		}
		}
	}
	
	void OnConversationStart()
	{
		convo=true;
	}
	void OnConversationEnd()
	{
		convo=false;
	}
	
	
}
