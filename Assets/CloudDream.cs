using UnityEngine;
using System.Collections;

public class CloudDream : MonoBehaviour {
	
	public static int treatment=0;
	
	private float burnTimer=0f;
	private bool once=true;
	
	public Material skybox;
	
	public GameObject lostChild;
	
	
	// Use this for initialization
	void Start () {
	
					}
	
	void OnEnable()
	{
		RenderSettings.skybox=skybox;
		//DreamTracker.dream=14;
		//DreamTracker.currentCam=gameObject;
//		BlankDialogue.player=gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
			if(ButtonAppear.active)
			{
		if(InteractionScript.casket)
		{				
				if(ThoughtManager.activeID==3)
			{
			
					ThoughtManager.thoughtID=2;
					ThoughtManager.show=true;
								
				if(ThoughtManager.mainActive2)
					{
						transform.LookAt (lostChild.transform);
						ThoughtManager.mainThought3="there was nothing that I could do";	
					}
					else
						ThoughtManager.mainThought3="I am sorry....";
			}
				
				if(ThoughtManager.activeID==1)
			{
			
					ThoughtManager.thoughtID=1;
					ThoughtManager.show=true;
								
				if(ThoughtManager.mainActive1)
					{
						transform.LookAt (lostChild.transform);	
					}
					else
						ThoughtManager.mainThought2="What is he doing here?";
			}
				
				if(ThoughtManager.activeID==2)
			{
			
					ThoughtManager.thoughtID=1;
					ThoughtManager.show=true;
								
				if(ThoughtManager.mainActive1)
					{
						ThoughtManager.mainThought3="Or is it something more complex...";
						ThoughtManager.mainThought2="";
						StartCoroutine ("Transport",1);
					}
					else
						ThoughtManager.mainThought2="Has my guilt brought them here?";
			}
				
			}
		}
		
		
		
		
	}
	
	IEnumerator Transport(int val)
	{
		if(val==1)	//grill
		{
			//dreamtracker number
			DreamTracker.dream=5;
			DreamTracker.change=true;
			yield break;
		}
		
		yield return null;
	}
}
		
/*		if(moveFast)
		{
			gameObject.GetComponent<CharacterMotor>().movement.maxForwardSpeed=8f;
			gameObject.GetComponent<CharacterMotor>().movement.maxSidewaysSpeed=8f;
			moveSlow=false;
		}
		
		if(moveSlow)
		{
			gameObject.GetComponent<CharacterMotor>().movement.maxForwardSpeed=2f;
			gameObject.GetComponent<CharacterMotor>().movement.maxSidewaysSpeed=2f;
			moveFast=false;
			
		}
		
		
		checkTimer+=Time.deltaTime;
		
		if(checkTimer>5f)
		{
			
			if(stairsCam.transform.position.y<611f)
			{
				stairsCam.transform.position=new Vector3(stairsCam.transform.position.x,lastPos,stairsCam.transform.position.z);
			}
			else
			{
				lastPos=stairsCam.transform.position.y;
			}
			checkTimer=0f;
		}
		
		
		
		if(HistoryScript.gender!=1 || HistoryScript.race!=2)	//not male or white
		{
			treatment=1;
		}
		
		if(InteractionScript.billboard)	//burn
		{
			if(once)
			{
			burnTimer+=Time.deltaTime;
			if(burnTimer>2f && burnTimer<3f)
			{
				gameObject.camera.enabled=false;
				interCam.SetActive(true);				
			}
			if(burnTimer>3f && burnTimer<4f)
			{
				interCam.SetActive (false);
				stairsCam.SetActive (true);
			}
			if(burnTimer>4f)
			{
				once=false;
				burnTimer=0f;
			}
			}
		}
		else
		{
			once=true;
		}
		
		if(InteractionScript.mirrorSelf)
		{
			if(waitOnce)
			{
			waitTimer+=Time.deltaTime;
			if(waitTimer>10f)
			{				
				stairs1.SetActive(true);
					waitOnce=false;
					waitTimer=0f;
			}
			}
			
		}
		
		if(DreamWheel.armyBoss)
		{
			if(waitTwice)
			{
				waitTimer+=Time.deltaTime;
				if(waitTimer>2f)
				{
					if(HistoryScript.gender!=1 && HistoryScript.race!=2)
					{
					if(countPromotion<=1)
					{
					dialogueSlave.text="You will have to wait till you go any higher";
					Instantiate (promotionMWhite,locSpawn,Quaternion.identity);
					countPromotion++;
					}
					if(HistoryScript.race!=1)
						{
						dialogueSlave.text="Wait! There are more deserving people ahead of you";
						if(countPromotion>=2 && countPromotion<=3)
						{
						Instantiate (promotionFWavy,locSpawn,Quaternion.identity);
						countPromotion++;
						}
						if(countPromotion>=3 && countPromotion<=4)
						{
						Instantiate (promotionMBlack,locSpawn,Quaternion.identity);
						countPromotion++;
						}
						if(countPromotion>=4 && countPromotion<=5)
						{
						Instantiate (promotionMWhite,locSpawn,Quaternion.identity);
						countPromotion++;
								
						}
							if(countPromotion==5)
							{
								allow=true;
							}
						}
						else
						{
							if(countPromotion<=5)
							{
							dialogueSlave.text="Wait! There are more deserving people ahead of you";
							Instantiate (promotionMWhite,locSpawn,Quaternion.identity);
							countPromotion++;
								allow=true;
							}
						}
					}
					else if(HistoryScript.gender==0)
					{
						if(countPromotion<=4)
							{
							dialogueSlave.text="Wait! There are more deserving people ahead of you";
							Instantiate (promotionMWhite,locSpawn,Quaternion.identity);
							countPromotion++;
							allow=true;
							}
					}
					else
					{
						if(countPromotion<=2)
							{
							dialogueSlave.text="Just wait and you'll be allowed to go higher";
							Instantiate (promotionMWhite,locSpawn,Quaternion.identity);
							countPromotion++;
							allow=true;
							}
					}
					waitTimer=0f;
				}
				if(allow)
				{
					dialogueSlave.text="You are now eligible for a Promotion!";
					invisibleWall.SetActive (false);
					waitTwice=false;
				}
			}
		}
		
	*/