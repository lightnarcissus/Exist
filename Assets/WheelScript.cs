using UnityEngine;
using System.Collections;

public class WheelScript : MonoBehaviour {
	public Texture red;
	public Texture grey;
	public Texture blue;
	public Texture gold;
	private MouseLook natMo;
	public float dialogueTimer=0f;
	public Rect dialogueRect;
	public GUIStyle dialogue;
	public bool justOnce=true;
	
	public Texture redback;
	public Texture greyback;
	public Texture goldback;
	public Texture blueback;
	public Texture bg;
	public Texture node;
	public Material mat1;
	private MouseLook mo;
	private GameObject player;
	private Ray ray;
	private RaycastHit hit;


	

	
	
	private Rect actionNode3g;
	private Rect actionNode3g2;
	private Rect actionNode3g3;
	
	private int thoughtChoice=0;
	
	
	private int active=0;
	public static bool box1;
	public static bool box2;
	public static bool box3;
	public static bool box4;
	private float screenWidth=0f;
	private float screenHeight=0f;
	public GUIStyle progress_empty;
	public Texture empty;
	public GUIStyle progress_full;
	public Texture full;
	public GUIStyle style;
	public GUIStyle env;
	public GUIStyle people;
	public GUIStyle self;
	public GUIStyle abs;
	public GameObject stairs;
	private bool stairsCreate=false;
	public GameObject displayGuy;
	private GameObject createActive;
	private bool doOnce=true;
	private Quaternion fromRotation;
	public static int activeNode=0;
	private Quaternion toRotation;
	private float xDeg;
	private float yDeg;
	public GameObject dialogueText;
	public GameObject permaDialogue;
	private GameObject currentDialogue;
	public static int peopleChoice=0;
	private bool dialogueOnce=true;
	public static int emotion=0;
	private float dChoice=0;
	private bool reflectOnce=true;
	private float resetTimer=0f;
	private bool reset=false;
	private bool switch12a=false;
	private int randDialogue=0;
	
	private int talkChoice=0;
	private int dialogueChoice=0;
	
	private bool randOnce=true;
	public static int randThought=0;
	private float thoughtTimer=0f;
	private int thoughtSelect=0;
	private bool bullOnce=true;
	private bool tentOnce=true;
	private bool warOnce=true;
	private bool scaleOnce=true;
	private bool bomberOnce=true;
	
	public Texture fairyDust;
	
	
	public static bool fairyRed=false;
	public static bool fairyBlue=false;
	public static bool fairyGold=false;
	public static bool fairyGrey=false;
	
	private Rect redSign;
	private Rect blueSign;
	private Rect goldSign;
	private Rect greySign;
	
	private Rect help;
	private Rect helpGUI;
	private Rect helpGeneral;
	public GUIStyle helpStyle;
	private Rect giveUp;
	public GUIStyle giveUpStyle;
	private Rect key;
	public GUIStyle useStyle;
	public GameObject mask;
	public static bool maskHelp=false;
	public static bool keyGot=false;
	public static bool usableKey=false;
	
	public Texture redGlow;
	public Texture blueGlow;
	public Texture goldGlow;
	public Texture greyGlow;
	
	private bool decisionOnce=false;
	
	public GameObject money;
	
	private bool proposeOnce=true;
	
	private float giveUpTimer=0f;
	
	public AudioClip notification;
	public AudioSource aud;
	
		
	public static bool chosen=false;
	private bool close=false;
	private float closeTimer=0f;
	
	private Rect quitGame;
	
	
private float quitTimer=0f;
	
	private bool onceStart=true;
	public static Vector3 targetVect;

	// Use this for initialization
	void Start () {
		
		screenWidth=Screen.width/2f;
		screenHeight=Screen.height/2f;
		player=GameObject.FindGameObjectWithTag ("Player");
		
		goldSign =new Rect((screenWidth)-150f,(screenHeight)+50f,100f,100f);
		blueSign=new Rect((screenWidth)+50f,(screenHeight)+50f,100f,100f);
		greySign=new Rect((screenWidth)+50f,(screenHeight)-150f,100f,100f);
		redSign=new Rect((screenWidth)-150f,(screenHeight)-150f,100f,100f);
		
		help=new Rect((screenWidth)-50f,(screenHeight)-300f,100f,100f);
		helpGUI=new Rect((screenWidth)+50f,(screenHeight)-250f,100f,100f);
		helpGeneral=new Rect((screenWidth)-150f,(screenHeight)-250f,100f,100f);
		key=new Rect((screenWidth)-50f,(screenHeight)+200f,100f,100f);
		giveUp=new Rect((screenWidth)-50f,(screenHeight)+200f,100f,100f);
		quitGame=new Rect((screenWidth)+400,(screenHeight)-300f,100f,100f);

		
	}
	
	void OnDisable()
	{
	//	LoadSave.theObject=gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//Debug.Log (natMo);
	//	Debug.Log (mo);
			mo=player.GetComponent<MouseLook>();
			natMo=gameObject.GetComponent<MouseLook>();
		
		if(fairyRed || fairyGrey || fairyBlue || fairyGold)
		{
			aud.clip=notification;
			
		}
		else
		{
			aud.clip=null;
			
		}
		
		if(chosen)
		{
		closeTimer+=Time.deltaTime;
		if(closeTimer>0.3f)
			{
				
				close=true;
				chosen=false;
				closeTimer=0f;
				
			}
		}
			
		
		
		
		//Debug.Log (randThought);
//		Debug.Log (thoughtChoice);
		//Debug.Log(justOnce);
		//Debug.Log(peopleChoice);
	//Debug.Log (InteractionScript.artist);
	}
	
	void OnGUI()
	{
		
		
		if(Input.GetMouseButton(0))
		{
	
			//Debug.Log (activeNode);
			
			//GUI.DrawTexture (bg0,bg);
			//ray=Camera.main.ViewportPointToRay (Input.mousePosition);
			//if(Physics.Raycast(ray,out hit,10f))
			//{
				
			//}
			Screen.showCursor=true;
			((DepthOfFieldScatter)gameObject.GetComponent<DepthOfFieldScatter>()).enabled=true;
			Time.timeScale=0.2f;
			natMo.enabled=false;
			mo.enabled=false;
			
			
			resetTimer=0f;
			reset=false;
			
	/*		if(active==1)
			{
			//	GUI.DrawTexture (bg1,redback);
			}
			if(active==2)
			{
			//	GUI.DrawTexture (bg2,greyback);
			}
			if(active==3)
			{
				//GUI.DrawTexture (bg3,blueback);
			}
			if(active==4)
			{
			//	GUI.DrawTexture (bg4,goldback);
			}*/
		/*	GUI.DrawTexture (tex4,red);
			
			GUI.DrawTexture (tex3,grey);
			
			GUI.DrawTexture (tex2,blue);
			
			GUI.DrawTexture (tex1,gold);
			
			GUI.Label (quitGame,"Wake Up",helpStyle);
			*/
		
			
			//Memory Scenes
		
				
			
	/*			GUI.Label(help,"Seek Help",helpStyle);
			
			
			if(help.Contains (Event.current.mousePosition))
			{
				GUI.DrawTexture (help,fairyDust);
					GUI.Label(help,"Seek Help",helpStyle);
				
				activeNode=61;
				active=6;
			
				
				
			}
				
				
					if(quitGame.Contains (Event.current.mousePosition))
			{
				GUI.DrawTexture (quitGame,fairyDust);
					if(MaskHelp.quitAllow)
					{
						quitTimer+=Time.deltaTime;
						
						if(quitTimer>0.5f)
						{
						ResetScript.quit=true;
						maskHelp=false;
							mask.SetActive(false);
						}
					}
					else
					{
					MaskHelp.quitGameWarning=true;
					mask.SetActive (true);
					maskHelp=true;
					}
					
			}
			
			if(maskHelp)
			{
					player.transform.LookAt (mask.transform);						
						player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
			}
			
			if(ResetScript.sceneChoice==0)
			{
			if(decisionOnce)
			{
				GUI.Label (key,"Throw the Bag",helpStyle);
				if(key.Contains (Event.current.mousePosition))
			{
					GUI.DrawTexture (key,fairyDust);
					GUI.Label (key,"Throw the Bag",helpStyle);
					Player.throwBag=true;
			}
				
			}
			}
			//Debug.Log(InteractionScript.chest);
				
			//give up
			
			if((ResetScript.sceneChoice==1) && (!InteractionScript.key && !InteractionScript.chest))
			{
				GUI.Label (key,"Give Up",helpStyle);
				if(key.Contains (Event.current.mousePosition))
			{
					
					GUI.DrawTexture (key,fairyDust);
					if(MaskHelp.giveUpWarning)
					{
						giveUpTimer+=Time.deltaTime;
						
						if(giveUpTimer>0.5f)
						{
						Player.giveUp=true;
						maskHelp=false;
							mask.SetActive(false);
						}
					}
					else
					{
						MaskHelp.giveUpWarning=true;
					mask.SetActive (true);
					maskHelp=true;
					}
					//start give up sequence
				
			}
			}
			
			
			
			
			//key and chest
			
			if((InteractionScript.chest || InteractionScript.real) && keyGot)
				{
					usableKey=true;
				}
				
			
			if(InteractionScript.key && !keyGot)
			{
				InteractionScript.active=InteractionScript.keyActive;
				GUI.Label (key,"Pick Up Key",helpStyle);
				
				if(key.Contains (Event.current.mousePosition))
			{
					GUI.DrawTexture (key,fairyDust);
					GUI.Label (key,"Pick Up Key",helpStyle);
			
				keyGot=true;
				InteractionScript.keyActive.renderer.enabled=false;
				
			}
			}
			
			if(keyGot && usableKey)
			{
				GUI.Label (key,"Use Key",helpStyle);
				
				if(key.Contains (Event.current.mousePosition))
			{
					GUI.DrawTexture (key,fairyDust);
					GUI.Label (key,"Use Key",helpStyle);
				if(InteractionScript.chest)
					{
						InteractionScript.chestActive.transform.parent.FindChild ("Cylinder01").gameObject.SetActive (false);
						Player.chestOpen=true;
						maskHelp=true;
						mask.SetActive (true);
					}
					else if(InteractionScript.real)
					{
						InteractionScript.realActive.transform.parent.FindChild ("Cylinder01").gameObject.SetActive (false);
						Player.realChest=true;
						
					}
				
			}
			}
			
			
			if(tex1.Contains (Input.mousePosition))
			{
				//Debug.Log ("First!");
				active=1;
				
					
			}
			if(tex2.Contains (Input.mousePosition))
			{
				//Debug.Log ("Second!");
				active=2;
			}
			if(tex3.Contains (Input.mousePosition))
			{
				//Debug.Log ("Third!");
				active=3;
			}
			if(tex4.Contains (Input.mousePosition))
			{
				//Debug.Log ("Fourth!");
				active=4;
			}
			
			if(active==1)
			{
				
				if(actionNode1timer<=1.25f)
				{
				bg1=new Rect(0f,0f,screenWidth-50f+(480f*actionNode1timer),screenHeight-50f+(350f*actionNode1timer));
				actionNode1timer+=Time.deltaTime;
				}
				
				GUI.DrawTexture (bg1,redback);
				
				
				
			
				
				//GUI.DrawTexture (actionNode1d,node);
				
			}
				
			if(actionNode1timer>=0f && active!=1)
			{
				actionNode1timer-=Time.deltaTime;
				bg1=new Rect(0f,0f,screenWidth-50f+(480f*actionNode1timer),screenHeight-50f+(350f*actionNode1timer));
				GUI.DrawTexture (bg1,redback);
				
			}
			if(actionNode1timer>0.05f)
			{
				if(ResetScript.sceneChoice==0)
				{
				if(InteractionScript.chalkboard || InteractionScript.billboard || InteractionScript.TVBox || InteractionScript.chairJudge || InteractionScript.scale || InteractionScript.lightHouseGate || InteractionScript.direction || InteractionScript.tentPeople|| InteractionScript.bull)		//insert unique alter environment bools here
				{
						
					GUI.Label (actionNode1a,"Alter",env);
	
					if(actionNode1a.Contains (Event.current.mousePosition))
				{
							GUI.DrawTexture (actionNode1a,fairyDust);
					GUI.Label (actionNode1a,"Alter",env);
							active=1;
							activeNode=11;
				
				}
				}
					
					else if(InteractionScript.money)
					{
						GUI.DrawTexture (actionNode3c,fairyDust);
						GUI.Label (actionNode1a,"Free(*) Money",env);

					if(actionNode1a.Contains (Event.current.mousePosition))
				{
								GUI.DrawTexture (actionNode1a,fairyDust);
						GUI.Label (actionNode1a,"Free(*) Money",env);
							active=1;
							activeNode=11;
				}
					}
				
				else if(InteractionScript.pyramid)
				{
						
					GUI.Label (actionNode1a,"The Dark Side",env);

					if(actionNode1a.Contains (Event.current.mousePosition))
				{
							GUI.DrawTexture (actionNode1a,fairyDust);
					GUI.Label (actionNode1a,"The Dark Side",env);
							active=1;
							activeNode=11;
				}
					
				}
			
				
				else if(InteractionScript.mirrorSelf)
				{
						
					GUI.Label (actionNode1a,"Change Destiny",env);
					
					if(actionNode1a.Contains (Event.current.mousePosition))
				{
							GUI.DrawTexture (actionNode1a,fairyDust);
					GUI.Label (actionNode1a,"Change Destiny",env);
					
							active=1;
					//
					activeNode=11;
				}
			}
			}
				else if(ResetScript.sceneChoice==1)
				{
				}
				
				else if(ResetScript.sceneChoice==2)
				{
					if(InteractionScript.boat)
					{
					if(Player.playerState==0)		//On ground
					GUI.Label (actionNode1a,"Boat",env);
					if(Player.playerState==1)
					GUI.Label(actionNode11a,"Get Off",env);
						
					if(actionNode1a.Contains (Event.current.mousePosition))
				{
							GUI.DrawTexture (actionNode1a,fairyDust);
					if(Player.playerState==0)		//On ground
					GUI.Label (actionNode1a,"Boat",env);
							if(Player.playerState==0)		//get on boat
							Player.playerState=1;
							
							
				
				}
						
						if(actionNode11a.Contains (Event.current.mousePosition))
						{
							GUI.DrawTexture (actionNode11a,fairyDust);
					if(Player.playerState==1)
					GUI.Label(actionNode11a,"Get Off",env);
							if(Player.playerState==1)
							Player.playerState=0;
						}
					}
				}
			}
				if(actionNode1timer>0.55f)
			{
				GUI.Label (actionNode1b,"Create",env);
					if(actionNode1b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1b,fairyDust);
				GUI.Label (actionNode1b,"Create",env);
					active=1;
					activeNode=12;
					
				}
				
			}
			
	
				if(actionNode1timer>0.85f)
			{
			//	if(InteractionScript.table)
			//	{
				//	GUI.DrawTexture (actionNode1c,fairyDust);
				//	GUI.Label(actionNode1c,"Bag Seller",env);
			//	}
			//	else
			//	{
					
				GUI.Label (actionNode1c,"Lights",env);
			//	}
				if(actionNode1c.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1c,fairyDust);
				//	if(InteractionScript.table)
			//	{
				//	GUI.Label(actionNode1c,"Bag Seller",env);
			//	}
			//		else
			//	{
				GUI.Label (actionNode1c,"Lights",env);
			//	}
						
					active=1;
					activeNode=13;		//put non-unique environment alterable bools here
					
				}	
			}
				if(actionNode1timer>0.95f)
			{
			
				GUI.Label (actionNode1d,"Destroy",env);
				if(actionNode1d.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1d,fairyDust);
			
				GUI.Label (actionNode1d,"Destroy",env);
					active=1;
					activeNode=14;
				
					//Destroy Stairs
					var destroy=GameObject.FindGameObjectsWithTag("Escalator");
					for(int i=0;i<destroy.Length;i++)
					{
						Destroy (destroy[i]);
					}
				}	
			}
			
			if(actionNode2timer>0.05f)
			{
				if(EmotionScript.emotion==3)
					GUI.Label (actionNode2c,"You Are Feeling Angry",env);	
				else
				{
				GUI.Label (actionNode2d,"Feel Angry",abs);
				if(actionNode2d.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode2d,fairyDust);
				GUI.Label (actionNode2d,"Feel Angry",abs);
					active=2;
					activeNode=24;
					emotion=3;
					EmotionScript.emotion=3;
					EmotionScript.once=true;
				}
				}
			}
		
			if(actionNode2timer>0.65f)
			{
				if(EmotionScript.emotion==1)
					GUI.Label (actionNode2c,"You Are Feeling Sad",env);	
				else
				{
				GUI.Label (actionNode2b,"Feel Sad",abs);
					if(actionNode2b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode2b,fairyDust);
				GUI.Label (actionNode2b,"Feel Sad",abs);
					active=2;
					activeNode=22;
					EmotionScript.emotion=1;
					EmotionScript.once=true;
				}
				}
			}
			if(actionNode2timer>0.85f)
			{
				if(EmotionScript.emotion==2)
					GUI.Label (actionNode2c,"You Are Feeling Happy",env);	
				else
				{
				GUI.Label (actionNode2c,"Feel Happy",abs);	
				if(actionNode2c.Contains(Event.current.mousePosition))
				{
				
					GUI.DrawTexture (actionNode2c,fairyDust);
				GUI.Label (actionNode2c,"Feel Happy",abs);	
					active=2;
					activeNode=23;
					EmotionScript.emotion=2;
					EmotionScript.once=true;
				}
				}
			
				
			}
			
			
				
			
				
				
						
			
			if(active==2)
			{
				
				if(actionNode2timer<=1.25f)
				{
				bg2=new Rect(screenWidth+50f-(480f*actionNode2timer),0f,screenWidth-50f+(480f*actionNode2timer),screenHeight-50f+(350f*actionNode2timer));
				actionNode2timer+=Time.deltaTime;
				}
				GUI.DrawTexture (bg2,greyback);
				
				
			}
			
			
			if(actionNode2timer>=0f && active!=2)
			{
				actionNode2timer-=Time.deltaTime;
				bg2=new Rect(screenWidth+50f-(480f*actionNode2timer),0f,screenWidth-50f+(480f*actionNode2timer),screenHeight-50f+(350f*actionNode2timer));
				GUI.DrawTexture (bg2,greyback);
			}
			
			
			
			if(active==3)
			{
				
				
				if(actionNode3timer<=1.25f)
				{
				bg3=new Rect(screenWidth+50f-(480f*actionNode3timer),screenHeight+50f-(300f*actionNode3timer),screenWidth-50f+(480f*actionNode3timer),screenHeight-50f+(350f*actionNode3timer));
				actionNode3timer+=Time.deltaTime;
				}
				GUI.DrawTexture (bg3,blueback);
				active=3;
				
			
				
				if(InteractionScript.white)
					GUI.Label (actionNode3a,"What is he doing here?",people);
				if(InteractionScript.chairFWh)
					GUI.Label (actionNode3a,"Hopeful White",people);
					
				if(InteractionScript.wavy)
				GUI.Label (actionNode3b,"Wavy",people);	
				if(InteractionScript.chairFW)
					GUI.Label (actionNode3b,"Hopeful Wavy",people);
				
				if(InteractionScript.black)
					GUI.Label (actionNode3c,"Black",people);
				if(InteractionScript.chairFB)
					GUI.Label (actionNode3c,"Hopeful Black",people);
				
				if(InteractionScript.sitting)
					GUI.Label (actionNode3d,"Sitting Person",people);
				if(InteractionScript.chalkGeek)
					GUI.Label (actionNode3d,"Genetically Genius",people);
				if(InteractionScript.anarchist)
					GUI.Label (actionNode3d,"Operatic Anarchist",people);
				if(InteractionScript.dollar)
					GUI.Label (actionNode3d,"Our Future",people);
				if(InteractionScript.glassCase)
					GUI.Label (actionNode3d,"Our Guardians",people);
				if(InteractionScript.guardian)
					GUI.Label (actionNode3d,"Our Guardians",people);
				
				
				if(InteractionScript.balanceBlack && scaleOnce)
					GUI.Label (actionNode3d2,"Criminal (?)",people);
				if(InteractionScript.balanceWhite && scaleOnce)
				GUI.Label (actionNode3d3,"Victim (?)",people);
				if(InteractionScript.talkGroup || InteractionScript.talkGroupWavy)
					GUI.Label (actionNode3d2,"Group",people);
				if(InteractionScript.talkGroupFem)
					GUI.Label (actionNode3d2,"Female Group",people);
				
				if(InteractionScript.lightHouseTop)
				{
				if(MirrorScript.gender==0)
				GUI.Label (actionNode3d2,"Him",people);
				if(MirrorScript.gender==1)
				GUI.Label (actionNode3d2,"Her",people);	
				}
				
				
				
				if(InteractionScript.bomberWhite && bomberOnce)
					GUI.Label (actionNode3e,"White",people);
				if(InteractionScript.bomberBlack && bomberOnce)
				GUI.Label (actionNode3e,"Black",people);
				if(InteractionScript.bomberWavy && bomberOnce)
					GUI.Label (actionNode3e,"Wavy",people);
				
				
				
					if(InteractionScript.stereotype)
					GUI.Label (actionNode3f,"Labelled",people);
					if(InteractionScript.telepole)
					{
						GUI.Label (actionNode3f,"The Burnt",people);	
					}

				if(actionNode3timer>0.6f)
				
				
				
				//scene two
				
				if(InteractionScript.impPerson)
				{
					if(MirrorScript.gender==1)
					GUI.Label(actionNode3e,"Her",people);
				else
					GUI.Label(actionNode3e,"Him",people);
				}
				
				if(InteractionScript.artist)
				GUI.Label (actionNode3a,"A Forgotten Passion",people);
				
				if(InteractionScript.desk)
				GUI.Label (actionNode3a,"Bonded to Work",people);
				
				if(InteractionScript.noose)
				GUI.Label (actionNode3a,"The End",people);
				
				if(InteractionScript.family)
				GUI.Label (actionNode3a,"Devoted to Family(?)",people);
				
				if(InteractionScript.guide)
				GUI.Label (actionNode3a,"The Lost Shepard",people);
				
				if(InteractionScript.casket)
				GUI.Label (actionNode3a,"The Hero(?)",people);
				
				
				
				
			
				if(actionNode3a.Contains (Event.current.mousePosition) && (InteractionScript.casket || InteractionScript.guide || InteractionScript.noose || InteractionScript.family|| InteractionScript.desk || InteractionScript.artist || InteractionScript.desk || InteractionScript.white || InteractionScript.chairFWh))
				{
					GUI.DrawTexture (actionNode3a,fairyDust);
					if(InteractionScript.artist)
				GUI.Label (actionNode3a,"A Forgotten Passion",people);
				
				if(InteractionScript.desk)
				GUI.Label (actionNode3a,"Bonded to Work",people);
				
				if(InteractionScript.noose)
				GUI.Label (actionNode3a,"The End",people);
				
				if(InteractionScript.family)
				GUI.Label (actionNode3a,"Devoted to Family(?)",people);
				
				if(InteractionScript.guide)
				GUI.Label (actionNode3a,"The Lost Shepard",people);
				
				if(InteractionScript.casket)
				GUI.Label (actionNode3a,"The Hero(?)",people);
				
					
					if(InteractionScript.white)
					GUI.Label (actionNode3a,"White",people);
				if(InteractionScript.chairFWh)
					GUI.Label (actionNode3a,"Hopeful White",people);
					
					
					active=3;
					activeNode=31;
					
					if(InteractionScript.white)
					{
					//GUI.Label (bg0,"White",center);
					InteractionScript.active=InteractionScript.whiteActive;
					}
						if(InteractionScript.chairFWh)
					{
					//	GUI.Label (bg0,"Hopeful White",center);
						InteractionScript.chairWhite=true;
					InteractionScript.active=InteractionScript.chairActive;
						
					}
					
				}
				
			
				
				if(actionNode3b.Contains (Event.current.mousePosition)&&(InteractionScript.wavy || InteractionScript.chairFW) )
				{
					GUI.DrawTexture (actionNode3b,fairyDust);
					if(InteractionScript.wavy)
				GUI.Label (actionNode3b,"Wavy",people);	
				if(InteractionScript.chairFW)
					GUI.Label (actionNode3b,"Hopeful Wavy",people);
					//Debug.Log ("Wavy 2b");
					active=3;
					activeNode=32;
				
					
						if(InteractionScript.wavy)
					{
						//GUI.Label (bg0,"Wavy",center);
						InteractionScript.active=InteractionScript.wavyActive;
						
					}
					if(InteractionScript.chairFW)
					{
						//GUI.Label (bg0,"Hopeful Wavy",center);
						InteractionScript.chairWavy=true;
						InteractionScript.active=InteractionScript.chairActive;
						
					}
					
					
				
				}
				
				if(actionNode3c.Contains (Event.current.mousePosition) && (InteractionScript.black || InteractionScript.chairFB))
				{
					GUI.DrawTexture (actionNode3c,fairyDust);
					if(InteractionScript.black)
					GUI.Label (actionNode3c,"Black",people);
				if(InteractionScript.chairFB)
					GUI.Label (actionNode3c,"Hopeful Black",people);
					active=3;
					activeNode=33;
					//Debug.Log ("Black 2c");
					
						if(InteractionScript.black)
					{
					//GUI.Label (bg0,"Black",center);
					InteractionScript.active=InteractionScript.blackActive;
					}
					if(InteractionScript.chairFB)
					{
						//GUI.Label (bg0,"Hopeful Black",center);
						InteractionScript.chairBlack=true;
					InteractionScript.active=InteractionScript.chairActive;
					}
				}
				
				if(actionNode3d.Contains (Event.current.mousePosition) &&(InteractionScript.sitting||InteractionScript.chalkGeek || InteractionScript.anarchist || InteractionScript.glassCase || InteractionScript.guardian || InteractionScript.dollar))
				{
					GUI.DrawTexture (actionNode3d,fairyDust);
					if(InteractionScript.sitting)
					GUI.Label (actionNode3d,"Sitting Person",people);
				if(InteractionScript.chalkGeek)
					GUI.Label (actionNode3d,"Genetically Genius",people);
				if(InteractionScript.anarchist)
					GUI.Label (actionNode3d,"Operatic Anarchist",people);
				if(InteractionScript.dollar)
					GUI.Label (actionNode3d,"Our Future",people);
				if(InteractionScript.glassCase)
					GUI.Label (actionNode3d,"Our Guardians",people);
					if(InteractionScript.guardian)
					GUI.Label (actionNode3d,"Our Guardians",people);
				
					active=3;
					activeNode=34;
					
					
					if(InteractionScript.sitting)
					{
					//GUI.Label (bg0,"Sitting Person",center);
					InteractionScript.active=InteractionScript.sittingActive;
					}
					
					
					
					if(InteractionScript.chalkGeek)
					{
					//GUI.Label (bg0,"Genetically Genius",center);
					InteractionScript.active=InteractionScript.chalkGeekActive;
					}
					if(InteractionScript.anarchist)
					{
						//GUI.Label (bg0,"Operatic Anarchist",center);
						InteractionScript.active=InteractionScript.anarchistActive;
						
					}
					
					if(InteractionScript.dollar)
					{

						InteractionScript.active=InteractionScript.dollarActive;
						
					}
					
					
					
					
				}
				if(actionNode3d2.Contains (Event.current.mousePosition) && InteractionScript.balanceBlack && scaleOnce)
				{
					GUI.DrawTexture (actionNode3d2,fairyDust);
					
					if(InteractionScript.balanceBlack && scaleOnce)
					GUI.Label (actionNode3d2,"Criminal (?)",people);
				
					active=3;
					activeNode=34;
						//GUI.Label (bg0,"Criminal (?)",center);
							dChoice=2;
						InteractionScript.active=InteractionScript.balanceBlackActive;
						
				}
				
					if(actionNode3d2.Contains (Event.current.mousePosition) && (InteractionScript.talkGroup || InteractionScript.talkGroupWavy || InteractionScript.talkGroupFem))
				{
					GUI.DrawTexture (actionNode3d2,fairyDust);
					MusicScript.blipYes=true;
				if(InteractionScript.talkGroup || InteractionScript.talkGroupWavy)
					GUI.Label (actionNode3d2,"Group",people);
				if(InteractionScript.talkGroupFem)
					GUI.Label (actionNode3d2,"Female Group",people);
					active=3;
					activeNode=34;
						//GUI.Label (bg0,"Criminal (?)",center);
							dChoice=2;
					if(InteractionScript.talkGroup)
					transform.parent.LookAt (InteractionScript.talkGroupActive.transform);
					if(InteractionScript.talkGroupWavy)
					transform.parent.LookAt (InteractionScript.talkGroupWavyActive.transform);
					if(InteractionScript.talkGroupFem)
					transform.parent.LookAt (InteractionScript.talkGroupFemActive.transform);
				}
				
				
				
					if(actionNode3d3.Contains (Event.current.mousePosition)&& InteractionScript.balanceWhite && scaleOnce)
				{
					GUI.DrawTexture (actionNode3d3,fairyDust);
					
					if(InteractionScript.balanceWhite && scaleOnce)
				GUI.Label (actionNode3d3,"Victim (?)",people);
						active=3;
						activeNode=34;			
						//GUI.Label (bg0,"Victim (?)",center);
								dChoice=3;
						InteractionScript.active=InteractionScript.balanceWhiteActive;
						
				
				}
				
				if(actionNode3d2.Contains (Event.current.mousePosition)&& InteractionScript.lightHouseTop)
				{
					GUI.DrawTexture (actionNode3d2,fairyDust);
						if(InteractionScript.lightHouseTop)
				{
				if(MirrorScript.gender==0)
				GUI.Label (actionNode3d2,"Him",people);
				if(MirrorScript.gender==1)
				GUI.Label (actionNode3d2,"Her",people);	
				}
						active=3;
						activeNode=34;			
						player.transform.LookAt (InteractionScript.lightHouseTopActive.transform);						
						player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
						
				
				}
				if(actionNode3f.Contains (Event.current.mousePosition)&& InteractionScript.telepole)
				{
					GUI.Label (actionNode3d2,"The Burnt",people);	
						active=3;
						activeNode=36;			
						player.transform.LookAt (InteractionScript.telepoleActive.transform);						
						player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);	
				
				}
				
				
				
				if(actionNode3e.Contains (Event.current.mousePosition) && InteractionScript.impPerson)
				{
					GUI.DrawTexture (actionNode3e,fairyDust);
					if(MirrorScript.gender==1)
					GUI.Label(actionNode3e,"Her",people);
				else
					GUI.Label(actionNode3e,"Him",people);
					//Debug.Log ("AHA!!");
					active=3;
					activeNode=35;
				}
				
				if(actionNode3e.Contains (Event.current.mousePosition) && (InteractionScript.bomberBlack || InteractionScript.bomberWavy || InteractionScript.bomberWhite) && bomberOnce)
				{
					GUI.DrawTexture (actionNode3e,fairyDust);
					if(InteractionScript.bomberWhite && bomberOnce)
					GUI.Label (actionNode3e,"White",people);
				if(InteractionScript.bomberBlack && bomberOnce)
				GUI.Label (actionNode3e,"Black",people);
				if(InteractionScript.bomberWavy && bomberOnce)
					GUI.Label (actionNode3e,"Wavy",people);
					//Debug.Log ("White 2a");
					active=3;
					activeNode=35;
					
					if(InteractionScript.bomberWhite)
					{
						//GUI.Label (bg0,"White",center);
					InteractionScript.active=InteractionScript.bomberWhiteActive;
					}
					
					if(InteractionScript.bomberWavy)
					{
						//GUI.Label (bg0,"Wavy",center);
					InteractionScript.active=InteractionScript.bomberWavyActive;
					}
					
					if(InteractionScript.bomberBlack)
					{
						//GUI.Label (bg0,"Black",center);
					InteractionScript.active=InteractionScript.bomberBlackActive;
					}
				}
				if(actionNode3f.Contains (Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode3f,fairyDust);
				if(InteractionScript.stereotype)			
				{
						GUI.Label(actionNode3f,"Labelled",people);
						activeNode=36;
						active=3;
				}
				}
				
				if(actionNode3g.Contains (Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode3g,fairyDust);
				if(InteractionScript.queer)			
				{
						GUI.Label(actionNode3g,"The Third",people);
						activeNode=37;
						active=3;
				}
				}
				
			}
			
			if(actionNode3timer>=0f && active!=3)
			{
				actionNode3timer-=Time.deltaTime;
				bg3=new Rect(screenWidth+50f-(480f*actionNode3timer),screenHeight+50f-(300f*actionNode3timer),screenWidth-50f+(480f*actionNode3timer),screenHeight-50f+(350f*actionNode3timer));
				GUI.DrawTexture (bg3,blueback);
			}
			
			
			if(active==4)
			{
				
				if(actionNode4timer<=1.25f)
				{
				bg4=new Rect(0f,screenHeight+50f-(300f*actionNode4timer),screenWidth-50f+(480f*actionNode4timer),screenHeight-50f+(350f*actionNode4timer));
				actionNode4timer+=Time.deltaTime;
				}
				GUI.DrawTexture (bg4,goldback);
				
		
			}
			
	/*		if(actionNode4timer>=0f && active!=4)
			{
				actionNode4timer-=Time.deltaTime;
				bg4=new Rect(0f,screenHeight+50f-(300f*actionNode4timer),screenWidth-50f+(480f*actionNode4timer),screenHeight-50f+(350f*actionNode4timer));
				GUI.DrawTexture (bg4,goldback);
			}
			
					if(actionNode4timer>0.05f)
			{
				if(randOnce)
				{
					
					//randThought=2;
					randThought=Random.Range (0,9);
					randOnce=false;
				}
				if(randThought==0)		//first thoughts
				{
				GUI.Label (actionNode4a,"A bond cannot last without faith",self);		//broken marriage
				}
				else if(randThought==1)
				{
				GUI.Label (actionNode4a,"All men are pigs",self);		// cheating husband
				}
				else if(randThought==2)
				{
				GUI.Label (actionNode4a,"I feel uneasy among others",self);		// lonely
				}
				else if(randThought==3)
				{
				GUI.Label (actionNode4a,"Can I fall any further than this?",self); //depressive
				}
				
				
				else if(randThought==4)	
				{
				GUI.Label (actionNode4a,"A grave for my dreams",self);		//failed
				}
				else if(randThought==5)
				{
				GUI.Label (actionNode4a,"From foreign lands,they come",self);		// racist
				}
				
				
				
				else if(randThought==6)		//first thoughts
				{
				GUI.Label (actionNode4a,"From foreign lands,they come",self);		// racist
				}
				else if(randThought==7)
				{
				GUI.Label (actionNode4a,"A sinking ship I ride",self);		//money
				}
				else if(randThought==8)
				{
				GUI.Label (actionNode4a,"Cure Your Illness",self); //treatment
				}

				
				if(actionNode4a.Contains (Event.current.mousePosition))
				{
					if(randThought==8)
						{
							GUI.DrawTexture (actionNode4a,fairyDust);
							ResetScript.doIt=true;
							thoughtChoice=0;
							
							//targetVect=treatmentVect;
						}
				
					thoughtChoice=11;
					
				}
				
			if(thoughtChoice==11)
			{
					GUI.DrawTexture (actionNode4a,fairyDust);
					
				if(randThought==0)		//first thoughts
				{
				GUI.Label (actionNode4a1,"But where shall we find love again?",self);		//broken marriage
				}
				else if(randThought==1)
				{
				GUI.Label (actionNode4a1,"Trust and loyalty matters little",self);		// cheating husband
				}
				else if(randThought==2)
				{
				GUI.Label (actionNode4a1,"I wish to talk",self);		// lonely
				}
				else if(randThought==3)
				{
				GUI.Label (actionNode4a1,"Why should I do anything?",self); //depressive
						
				}
					
				else if(randThought==4)	
				{
				GUI.Label (actionNode4a1,"A requiem for the futures lost",self);		//failed
				}

				else if(randThought==5)
				{
				GUI.Label (actionNode4a1,"Trying to erode what was once ours",self);		// racist
				}
					
				else if(randThought==6)	
				{
				GUI.Label (actionNode4a1,"Trying to erode what was once ours",self);		// racist
				}
				else if(randThought==7)
				{
				GUI.Label (actionNode4a1,"No matter how much I gather",self);		//money
				}
			
					
					
					if(actionNode4a1.Contains (Event.current.mousePosition))
				{
					
				thoughtChoice=111;				
				}
					
			}
				
				if(thoughtChoice==111)
				{
						GUI.DrawTexture (actionNode4a1,fairyDust);
					
				if(randThought==0)		//first thoughts
				{
				GUI.Label (actionNode4a1,"But where shall we find love again?",self);		
				GUI.Label (actionNode4a2,"When we lose faith on our ownselves",self);		//broken marriage
				}
				else if(randThought==1)
				{
				GUI.Label (actionNode4a1,"Trust and loyalty matters little",self);
				GUI.Label (actionNode4a2,"Slaves to their whims, bruising others",self);		// cheating husband
				}
				else if(randThought==2)
				{
				GUI.Label (actionNode4a1,"I hope I can talk to someone",self);
				GUI.Label (actionNode4a2,"But I remain trapped in my tiny cage",self);		// lonely
				}
				else if(randThought==3)
				{
				GUI.Label (actionNode4a1,"Why should I do anything?",self);
				GUI.Label (actionNode4a2,"When we shall all eventually turn to ashes?",self); //depressive
						
				}
					
				else if(randThought==4)	
				{
				GUI.Label (actionNode4a1,"A requiem for the futures lost",self);		
				GUI.Label (actionNode4a2,"Say a prayer for me",self);		//failed
				}
				else if(randThought==5)
				{
				GUI.Label (actionNode4a1,"Trying to erode what was once ours",self);
				GUI.Label (actionNode4a2,"Taking away our rightful future",self);		// racist
				}
					
					
				else if(randThought==6)
				{
				GUI.Label (actionNode4a1,"Trying to erode what was once ours",self);
				GUI.Label (actionNode4a2,"Taking away our rightful future",self);		// racist
				
				}
				else if(randThought==7)
				{
				GUI.Label (actionNode4a1,"No matter how much I gather",self);
				GUI.Label (actionNode4a2,"I can never stop it from draining away",self);		// money
				}
					
					
					
					if(actionNode4a2.Contains (Event.current.mousePosition))
				{
						
						if(randThought==0)
						{
							ResetScript.doIt=true;
							//targetVect=marriageVect;
						}
						
						
						if(randThought==1)
						{
							ResetScript.doIt=true;
							thoughtChoice=0;
							
						//	targetVect=cheatingVect;
						}
						
						
						if(randThought==2)
						{
							//Debug.Log ("lonely!");
							ResetScript.doIt=true;
							thoughtChoice=0;
						//	targetVect=lonelyVect;
						}
						
						if(randThought==3)
						{
							ResetScript.doIt=true;
							thoughtChoice=0;
				//			targetVect=depressVect;
						}
						
							if(randThought==4)
						{
							ResetScript.doIt=true;
							thoughtChoice=0;
						//	targetVect=failedVect;
						}
						
						
			
						
						
						if(randThought==5)
						{
							ResetScript.doIt=true;
							
							thoughtChoice=0;
							//targetVect=racistVect;
						}
						
						
						if(randThought==6)
						{
							ResetScript.doIt=true;
							thoughtChoice=0;
						//	targetVect=racistVect;
						}
						
				
						
						
						if(randThought==7)
						{
							ResetScript.doIt=true;
							thoughtChoice=0;
						//	targetVect=moneyVect;
						}
				}
				}
				
			}*/
			
	/*			if(actionNode4timer>0.375f)
			{
				if(InteractionScript.reflection && reflectOnce)
				{
					GUI.Label (actionNode4b,"I look good",self);
				}
				else
				{
				GUI.Label (actionNode4b,"Think About Something",self);
				}
				if(actionNode4b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode4b,fairyDust);
					
					if(InteractionScript.reflection && reflectOnce)
				{
					GUI.Label (actionNode4b,"I look good",self);
				}
				else
				{
				GUI.Label (actionNode4b,"Think About Something",self);
				}
					active=4;
					activeNode=42;

				}
				
			}
				if(actionNode4timer>0.5f)
			{
				//GUI.DrawTexture (actionNode4c,node);
				if(InteractionScript.reflection && reflectOnce)
				{
					GUI.Label (actionNode4c,"I wish I looked good...",self);
				}
				
				if(actionNode4c.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode4c,fairyDust);
					GUI.Label (actionNode4c,"I wish I looked good...",self);
					active=4;
					activeNode=43;
				}
			}
				if(actionNode4timer>0.175f)
			{
				//GUI.DrawTexture (actionNode4d,node);
				GUI.Label (actionNode4d,"Don't think about a fear",self);
				if(actionNode4d.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode4d,fairyDust);
					GUI.Label (actionNode4d,"Don't think about a fear",self);
					active=4;
					activeNode=44;
				}
			
			
			}*/
							
			
		/*	if(activeNode==11 && active==1)
			{
				
				
				//Chalkboard
						if(InteractionScript.chalkboard)
						{
					
					fairyRed=true;
					GUI.Label (actionNode11a,"A Question",env);
						if(actionNode11a.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode11a,fairyDust);
						GUI.Label (actionNode11a,"A Question",env);
							InteractionScript.active=InteractionScript.chalkboardActive;
						}
						}
				
				//Billboard
					if(InteractionScript.billboard)
					{
					fairyRed=true;
					
					GUI.Label (actionNode12a,"Change is in the Air...",env);
					if(actionNode12a.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode12a,fairyDust);
					
						GUI.Label (actionNode12a,"Change is in the Air...",env);
						InteractionScript.active=InteractionScript.billActive;
						InteractionScript.active.renderer.material.SetColor("_Emission", Color.black);
					 }
					}
				
				if(InteractionScript.money)
					{
					fairyRed=true;					
					GUI.Label (actionNode12a,"Take",env);
					InteractionScript.active=InteractionScript.moneyActive;
					if(actionNode12a.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode3c,fairyDust);
					
					GUI.Label (actionNode12a,"Take",env);
						Player.hasMoney=true;
						Debug.Log (InteractionScript.moneyActive.transform.parent.parent.gameObject);
						InteractionScript.moneyActive.transform.parent.parent.gameObject.GetComponent<MoneyDesk>().tookMoney=true;
						Destroy (InteractionScript.moneyActive.transform.parent.gameObject);
						InteractionScript.money=false;
						
					 }
					}
				
				//Stereotype
				if(InteractionScript.stereotype)
					{
					fairyRed=true;
					GUI.Label (actionNode12a,"Query",env);
					if(actionNode12a.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode12a,fairyDust);			
						GUI.Label (actionNode12a,"Query",env);
						peopleChoice=15;
						dialogueOnce=true; justOnce=true;
						player.transform.LookAt (InteractionScript.stereotypeActive.transform);						
						player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					 }
					}
					
				
			
						
				//TV Box
				
						if(InteractionScript.TVBox)
						{
					fairyRed=true;
					GUI.Label (actionNode11a,"Weird Show",env);
						if(actionNode11a.Contains(Event.current.mousePosition))
						{	
						
						GUI.DrawTexture (actionNode11a,fairyDust);			
						GUI.Label (actionNode11a,"Weird Show",env);
						InteractionScript.active=InteractionScript.TVBoxActive;
						}
						}
						
				//Direction Sign
						if(InteractionScript.direction)
						{
					fairyRed=true;
					GUI.Label (actionNode11a,"Choose Your Future",env);
						if(actionNode11a.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode11a,fairyDust);			
						GUI.Label (actionNode11a,"Choose Your Future",env);
							InteractionScript.active=InteractionScript.directionActive;
						}
						}
				
				//Balance Scale
				if(InteractionScript.scale && warOnce)
						{
					fairyRed=true;
					GUI.Label (actionNode11a,"And Justice For All",env);
						if(actionNode11a.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode11a,fairyDust);			
						GUI.Label (actionNode11a,"And Justice For All",env);
							InteractionScript.active=InteractionScript.scaleActive;
						}
						}
				
				//Chair Judge
				if(InteractionScript.chairJudge && warOnce)
						{
					fairyRed=true;
					GUI.Label (actionNode12a,"Nobody",env);
					if(actionNode12a.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode12a,fairyDust);			
						GUI.Label (actionNode12a,"Nobody",env);
							InteractionScript.active=InteractionScript.chairJudgeActive;
							activeNode=51;
						}
						}
				
				if(InteractionScript.bull && bullOnce)
						{
					fairyRed=true;
					GUI.Label (actionNode11a,"Tormented Soul",env);
					GUI.Label (actionNode12a,"A Lost Faith",env);
					if(actionNode11a.Contains(Event.current.mousePosition))
						{	
						
						GUI.DrawTexture (actionNode11a,fairyDust);		
						GUI.Label (actionNode11a,"Tormented Soul",env);
						player.transform.LookAt (InteractionScript.bullActive.transform.parent.FindChild ("Man"));						
						player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
						}
					if(actionNode12a.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode12a,fairyDust);		
						GUI.Label (actionNode12a,"A Lost Faith",env);
							InteractionScript.active=InteractionScript.bullActive;
							GUI.Label (actionNode13a,"Sacrilege",env);
							GUI.Label (actionNode14a,"Worship",env);
						switch12a=true;
						}
					if(switch12a)
					{
						
						GUI.Label (actionNode13a,"Sacrilege",env);
							GUI.Label (actionNode14a,"Worship",env);
							if(actionNode13a.Contains (Event.current.mousePosition))
						{
							GUI.DrawTexture (actionNode13a,fairyDust);		
						GUI.Label (actionNode13a,"Sacrilege",env);
							InteractionScript.bullActive.transform.parent.FindChild ("Writing").gameObject.SetActive (true);
							bullOnce=false;
							switch12a=false;
						}
						if(actionNode14a.Contains (Event.current.mousePosition))
						{
							GUI.DrawTexture (actionNode14a,fairyDust);		
						GUI.Label (actionNode14a,"Worship",env);
							InteractionScript.bullActive.transform.parent.FindChild ("Offering").gameObject.SetActive (true);
							bullOnce=false;
							switch12a=false;
						}
						}
						}
				
				if(InteractionScript.lightHouseGate)
						{
					fairyRed=true;
					GUI.Label (actionNode11a,"The 'Impossible' Barrier",env);
					if(actionNode11a.Contains(Event.current.mousePosition))
						{	
							GUI.DrawTexture (actionNode11a,fairyDust);		
							GUI.Label (actionNode11a,"The 'Impossible' Barrier",env);
							InteractionScript.active=InteractionScript.lightGateActive;
						}
						}
				
				
				if(InteractionScript.pyramid)
						{
					fairyRed=true;
					
						player.transform.LookAt (InteractionScript.pyramidActive.transform);						
						player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
						}
						
	
				
				//Tent
						
						
						if(InteractionScript.tentPeople && !tentOnce)
						{
					fairyRed=true;
					GUI.Label (actionNode11a,"A Roof For Your Home",env);
					GUI.Label (actionNode12a,"Broken People in Broken Homes",env);
					
						if(actionNode11a.Contains(Event.current.mousePosition))
						{	
						
						GUI.DrawTexture (actionNode11a,fairyDust);		
						GUI.Label (actionNode11a,"A Roof For Your Home",env);
							InteractionScript.active=InteractionScript.tentPeopleActive;
							peopleChoice=6;
						tentOnce=true;
						}
					if(actionNode12a.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode12a,fairyDust);		
						GUI.Label (actionNode12a,"Broken People in Broken Homes",env);
							InteractionScript.active=InteractionScript.tentPeopleActive;
						peopleChoice=7;
						tentOnce=true;
						}
						}
						
			//Self Mirror	
						if(InteractionScript.mirrorSelf)
						{
					fairyRed=true;
					GUI.Label (actionNode11a,"Change Gender",env);
					GUI.Label (actionNode12a,"Change Race",env);
					
							if(actionNode1a.Contains(Event.current.mousePosition))
						{		
							InteractionScript.active=InteractionScript.mirrorSelfActive;
						}
					
						else if(actionNode11a.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode11a,fairyDust);		
						GUI.Label (actionNode11a,"Change Gender",env);
							MirrorScript.queerChange=true;
							
						}
						else if(actionNode12a.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode12a,fairyDust);		
						GUI.Label (actionNode12a,"Change Race",env);
						//burn the person in agony
						MirrorScript.burn=true;
						}	
						}
			}
			
			if(activeNode==12 && active==1)
			{
			
				GUI.Label (actionNode11b,"The Way Up",env);
				if(ResetScript.sceneChoice==0)
				GUI.Label (actionNode12b,"Eye of the Answer",env);
				if(actionNode11b.Contains(Event.current.mousePosition))
				{
				GUI.DrawTexture (actionNode11b,fairyDust);		
				GUI.Label (actionNode11b,"The Way Up",env);
					//Create/Rotate Stairs
					if(doOnce)
					{
					InteractionScript.active=Instantiate (stairs,transform.position+transform.forward*4f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
						
						doOnce=false;
						stairsCreate=true;
					
					}
						 xDeg -= Input.GetAxis("Mouse X") * 5f ;
        yDeg += Input.GetAxis("Mouse Y") * 5f;
						 fromRotation = transform.rotation;
        toRotation = Quaternion.Euler(yDeg,xDeg,0);
					if(InteractionScript.active!=null)
        InteractionScript.active.transform.rotation = Quaternion.Lerp(fromRotation,toRotation,5f);
				}
		else
				{

					
					//Debug.Log ("Destroy");
					
					if(stairsCreate)
					Destroy (InteractionScript.active);
					doOnce=true;
					stairsCreate=false;
					
				}
				if(ResetScript.sceneChoice==0)
				if(actionNode12b.Contains(Event.current.mousePosition))
				{
				GUI.DrawTexture (actionNode12b,fairyDust);		
				GUI.Label (actionNode12b,"Eye of the Answer",env);
				displayGuy.SetActive(true);
					
				}
		}
			
			if(activeNode==13 && active==1)
			{
				GUI.Label (actionNode13a,"Bright",env);
				GUI.Label (actionNode13aonb,"Medium",env);
				GUI.Label (actionNode13b,"Dark",env);
				
				if(actionNode13a.Contains(Event.current.mousePosition))
				{
				GUI.DrawTexture (actionNode13a,fairyDust);		
				GUI.Label (actionNode13a,"Bright",env);
					Player.ambientLight=0;
				}
				if(actionNode13aonb.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode13aonb,fairyDust);		
				GUI.Label (actionNode13aonb,"Medium",env);
					Player.ambientLight=1;
				}
				
				if(actionNode13b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode13b,fairyDust);		
					GUI.Label (actionNode13b,"Dark",env);
					Player.ambientLight=2;
				}
			}
			
			if(activeNode==31 && active==3)
			{
			
				//SCENE ONE
				
				
				//Normal White
				if(InteractionScript.white)
				{
					
					GUI.Label (actionNode31,"Talk",people);
					GUI.Label(actionNode32,"Insult",people);
					GUI.Label (actionNode33,"The Answer (?)",people);
					
					
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
						GUI.DrawTexture (actionNode31,fairyDust);		
					GUI.Label (actionNode31,"Talk",people);
		
						peopleChoice=1;
						InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().action=true;
						
						
						InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().playerTalk=true;
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);		
					GUI.Label(actionNode32,"Insult",people);
						peopleChoice=2;
						InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().action=true;
						InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().playerInsult=true;
						dialogueOnce=true; justOnce=true;
				}
					
					if(actionNode33.Contains(Event.current.mousePosition))
					{
						GUI.DrawTexture (actionNode33,fairyDust);		
					GUI.Label (actionNode33,"The Answer (?)",people);
						peopleChoice=3;
						InteractionScript.active.transform.parent.gameObject.GetComponent<AnimControl>().blame=true;
						dialogueOnce=true; justOnce=true;
					}
				
				}
				//Chair White
				if(InteractionScript.chairWhite)
				{
					fairyBlue=true;
					ChairScript.done=true;
					if(SkinSelect.skinChoose!=0)
					ChairScript.words="I'm not your Answer";
				
					else
					ChairScript.words="I'm part of your Answer";
					
					ChairScript.choose=2;
				}
				
				
				
				//SCENE TWO
				
				
				if(InteractionScript.artist)
				{
					fairyBlue=true;
					
					GUI.Label (actionNode3a,"A Forgotten Passion",people);
					GUI.Label (actionNode3b,"Talk",people);
					GUI.Label (actionNode3c,"Ask",people);
					
					player.transform.LookAt (InteractionScript.artistActive.transform);						
					player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					
					if(actionNode3b.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode3b,fairyDust);		
					GUI.Label (actionNode3b,"Talk",people);
						talkChoice=1;
						
				}
					
					if(actionNode3c.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode3c,fairyDust);		
					GUI.Label (actionNode3c,"Ask",people);
						talkChoice=2;
					//	InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().action=true;
					//	InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().playerInsult=true;
				}
					
					
					
					if(talkChoice==1)
					{
						GUI.Label(actionNode3e,"I made a tough decision",people);
						GUI.Label(actionNode31,"It was in the best interest of our future",people);
						
						if(actionNode3e.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode3e,fairyDust);		
				GUI.Label(actionNode3e,"I made a tough decision",people);
						peopleChoice=31;
							dialogueChoice=1;
						dialogueOnce=true; justOnce=true;
					}
						
						if(actionNode31.Contains(Event.current.mousePosition))
					{
							
							GUI.DrawTexture (actionNode31,fairyDust);	
					GUI.Label(actionNode31,"It was in the best interest of our future",people);
						peopleChoice=31;
							dialogueChoice=2;
						dialogueOnce=true; justOnce=true;
					}
						
					}
					
					
					if(talkChoice==2)
					{
						GUI.Label(actionNode3e,"Are you happy?",people);
						GUI.Label(actionNode31,"Why is the canvas empty?",people);
						
						if(actionNode3e.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode3e,fairyDust);		
						GUI.Label(actionNode3e,"Are you happy?",people);
						peopleChoice=32;
							dialogueChoice=1;
						dialogueOnce=true; justOnce=true;
					}
						
						if(actionNode31.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label(actionNode31,"Why is the canvas empty?",people);
						peopleChoice=32;
							dialogueChoice=2;
						dialogueOnce=true; justOnce=true;
					}
						
					}
					
				}
				
				
				
				if(InteractionScript.desk)
				{
					fairyBlue=true;
					GUI.Label (actionNode3a,"Bonded to Work",people);
					GUI.Label (actionNode3b,"Talk",people);
					GUI.Label (actionNode3c,"Ask",people);
					
					player.transform.LookAt (InteractionScript.deskActive.transform);						
					player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					
					if(actionNode3b.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode3b,fairyDust);		
						GUI.Label (actionNode3b,"Talk",people);
						peopleChoice=31;
						
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode3c.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode3c,fairyDust);		
						GUI.Label (actionNode3c,"Ask",people);
						peopleChoice=32;
						InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().action=true;
					//	InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().playerInsult=true;
						dialogueOnce=true; justOnce=true;
				}
					
						if(talkChoice==1)
					{
						GUI.Label(actionNode3e,"Safety must be a privilege few possess",people);
						GUI.Label(actionNode31,"I had to climb many stairs to reach here",people);
						
						if(actionNode3e.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode3e,fairyDust);		
				GUI.Label(actionNode3e,"Safety must be a privilege few possess",people);
						peopleChoice=31;
							dialogueChoice=1;
						dialogueOnce=true; justOnce=true;
					}
						
						if(actionNode31.Contains(Event.current.mousePosition))
					{
							
							GUI.DrawTexture (actionNode31,fairyDust);	
					GUI.Label(actionNode31,"I had to climb many stairs to reach here",people);
						peopleChoice=31;
							dialogueChoice=2;
						dialogueOnce=true; justOnce=true;
					}
						
					}
					
					
					if(talkChoice==2)
					{
						GUI.Label(actionNode3e,"Are you happy?",people);
						GUI.Label(actionNode31,"Why are you locked?",people);
						
						if(actionNode3e.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode3e,fairyDust);		
						GUI.Label(actionNode3e,"Are you happy?",people);
						peopleChoice=32;
							dialogueChoice=1;
						dialogueOnce=true; justOnce=true;
					}
						
						if(actionNode31.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label(actionNode31,"Why are you locked?",people);
						peopleChoice=32;
							dialogueChoice=2;
						dialogueOnce=true; justOnce=true;
					}
						
					}
					
					
				}
				
				
				if(InteractionScript.noose)
				{
					fairyBlue=true;
					GUI.Label (actionNode3a,"The End",people);
					GUI.Label (actionNode3b,"Ask",people);
					GUI.Label (actionNode3c,"Pay Respects",people);
					
					player.transform.LookAt (InteractionScript.nooseActive.transform);						
					player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					
					if(actionNode3b.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode3b,fairyDust);		
						GUI.Label (actionNode3b,"Ask",people);
						talkChoice=1;
						
				}
					
					if(actionNode3c.Contains(Event.current.mousePosition))
				{
						GUI.DrawTexture (actionNode3c,fairyDust);		
						GUI.Label (actionNode3c,"Pay Respects",people);
			
						talkChoice=2;
					//	InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().action=true;
					//	InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().playerInsult=true;
				}
					
					
					
					if(talkChoice==1)
					{
						GUI.Label(actionNode31,"O Mirror,what happened?",people);
						GUI.Label(actionNode33,"Did he ever find hope before losing it?",people);
						if(actionNode31.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label(actionNode31,"O Mirror,what happened?",people);
						peopleChoice=31;
							dialogueChoice=1;
						dialogueOnce=true; justOnce=true;
					}
						
						if(actionNode33.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode33,fairyDust);		
						GUI.Label(actionNode33,"Did he ever find hope before losing it?",people);
						peopleChoice=31;
							dialogueChoice=2;
						dialogueOnce=true; justOnce=true;
					}
						
					}
					
					
					if(talkChoice==2)
					{
						
						//TRIBUTE 
						
						GUI.Label(actionNode31,"Death...",people);
						GUI.Label(actionNode33,"What did the mirror reflect?",people);
						if(actionNode31.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label(actionNode31,"Death...",people);
						peopleChoice=32;
							dialogueChoice=1;
						dialogueOnce=true; justOnce=true;
					}
						
						if(actionNode33.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode33,fairyDust);		
						GUI.Label(actionNode33,"What did the mirror reflect?",people);
						peopleChoice=32;
							dialogueChoice=2;
						dialogueOnce=true; justOnce=true;
					}
						
					}
					
				}
				
				
				if(InteractionScript.family)
				{
					fairyBlue=true;
					GUI.Label (actionNode3a,"Devoted to Family(?)",people);
					GUI.Label (actionNode3b,"Talk",people);
					GUI.Label (actionNode3c,"Ask",people);
					
					player.transform.LookAt (InteractionScript.familyActive.transform);						
					player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					
					if(actionNode3b.Contains(Event.current.mousePosition))
				{	
						GUI.DrawTexture (actionNode3b,fairyDust);		
						GUI.Label (actionNode3b,"Talk",people);
		
						talkChoice=1;
						
				}
					
					if(actionNode3c.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode3c,fairyDust);		
						GUI.Label (actionNode3c,"Ask",people);
						talkChoice=2;
					//	InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().action=true;
					//	InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().playerInsult=true;
				}
					
					
					
					if(talkChoice==1)
					{
						GUI.Label(actionNode31,"Past mistakes never erode",people);
						GUI.Label(actionNode33,"An oasis of trust we never found",people);
						if(actionNode31.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label(actionNode31,"Past mistakes never erode",people);
						peopleChoice=31;
							dialogueChoice=1;
						dialogueOnce=true; justOnce=true;
					}
						
						if(actionNode33.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode33,fairyDust);		
						GUI.Label(actionNode33,"An oasis of trust we never found",people);
						peopleChoice=31;
							dialogueChoice=2;
						dialogueOnce=true; justOnce=true;
					}
						
					}
					
					
					if(talkChoice==2)
					{
						GUI.Label(actionNode31,"Are you happy?",people);
						GUI.Label(actionNode33,"Are both of you happy?",people);
						if(actionNode31.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label(actionNode31,"Are you happy?",people);
						peopleChoice=32;
							dialogueChoice=1;
						dialogueOnce=true; justOnce=true;
					}
						
						if(actionNode33.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode33,fairyDust);		
						GUI.Label(actionNode33,"Are both of you happy?",people);
						peopleChoice=32;
							dialogueChoice=2;
						dialogueOnce=true; justOnce=true;
					}
						
					}
					
				}
				
				
				if(InteractionScript.guide)
				{
					fairyBlue=true;
					GUI.Label (actionNode3a,"The Lost Shepard",people);
					GUI.Label (actionNode3b,"Talk",people);
					GUI.Label (actionNode3c,"Ask",people);
					
					player.transform.LookAt (InteractionScript.guideActive.transform);						
					player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					
					if(actionNode3b.Contains(Event.current.mousePosition))
				{	
						GUI.DrawTexture (actionNode3b,fairyDust);		
						GUI.Label (actionNode3b,"Talk",people);
		
						talkChoice=1;
						
				}
					
					if(actionNode3c.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode3c,fairyDust);		
						GUI.Label (actionNode3c,"Ask",people);
						talkChoice=2;
					//	InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().action=true;
					//	InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().playerInsult=true;
				}
					
					
					
					if(talkChoice==1)
					{
						GUI.Label(actionNode31,"Can a blind person guide others?",people);
						GUI.Label(actionNode33,"Must feel good to see others' dreams succeed",people);
						if(actionNode31.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label(actionNode31,"Can a blind person guide others?",people);
						peopleChoice=31;
							dialogueChoice=1;
						dialogueOnce=true; justOnce=true;
					}
						
						if(actionNode33.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode33,fairyDust);		
						GUI.Label(actionNode33,"Must feel good to see others' succeed",people);
						peopleChoice=31;
							dialogueChoice=2;
						dialogueOnce=true; justOnce=true;
					}
						
					}
					
					
					if(talkChoice==2)
					{
						GUI.Label(actionNode31,"Are you happy?",people);
						GUI.Label(actionNode33,"Are you jealous of your students?",people);
						if(actionNode31.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label(actionNode31,"Are you happy?",people);
						peopleChoice=32;
							dialogueChoice=1;
						dialogueOnce=true; justOnce=true;
					}
						
						if(actionNode33.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode33,fairyDust);		
						GUI.Label(actionNode33,"Are you jealous of your students?",people);
						peopleChoice=32;
							dialogueChoice=2;
						dialogueOnce=true; justOnce=true;
					}
						
					}
					
				}
				
				
				if(InteractionScript.casket)
				{
					fairyBlue=true;
					GUI.Label (actionNode3a,"The Hero",people);
					GUI.Label (actionNode3b,"Talk",people);
					GUI.Label (actionNode3c,"Ask",people);
					
					player.transform.LookAt (InteractionScript.casketActive.transform);						
					player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					
					if(actionNode3b.Contains(Event.current.mousePosition))
				{	
						GUI.DrawTexture (actionNode3b,fairyDust);		
						GUI.Label (actionNode3b,"Talk",people);
		
						talkChoice=1;
						
				}
					
					if(actionNode3c.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode3c,fairyDust);		
						GUI.Label (actionNode3c,"Ask",people);
						talkChoice=2;
					//	InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().action=true;
					//	InteractionScript.whiteActive.transform.parent.gameObject.GetComponent<AnimControl>().playerInsult=true;
				}
					
					
					
					if(talkChoice==1)
					{
						GUI.Label(actionNode31,"Pride and duties make us forget the pain",people);
						GUI.Label(actionNode33,"Murder is justified when it's the Other",people);
						if(actionNode31.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label(actionNode31,"Pride and duties make us forget the pain",people);
						peopleChoice=31;
							dialogueChoice=1;
						dialogueOnce=true; justOnce=true;
					}
						
						if(actionNode33.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode33,fairyDust);		
						GUI.Label(actionNode33,"Murder is justified when it's the Other",people);
						peopleChoice=31;
							dialogueChoice=2;
						dialogueOnce=true; justOnce=true;
					}
						
					}
					
					
					if(talkChoice==2)
					{
						GUI.Label(actionNode31,"Were you happy?",people);
						GUI.Label(actionNode33,"Did you ever find peace from the voices?",people);
						if(actionNode31.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label(actionNode31,"Were you happy?",people);
						peopleChoice=32;
							dialogueChoice=1;
						dialogueOnce=true; justOnce=true;
					}
						
						if(actionNode33.Contains(Event.current.mousePosition))
					{
							GUI.DrawTexture (actionNode33,fairyDust);		
						GUI.Label(actionNode33,"Did you ever find peace from the voices?",people);
						peopleChoice=32;
							dialogueChoice=2;
						dialogueOnce=true; justOnce=true;
					}
						
					}
					
				}
				
				
			}
			
			
			if(activeNode==32 && active==3)
			{
	
				
				//Normal Wavy
					if(InteractionScript.wavy)
				{

				GUI.Label (actionNode31,"Talk",people);
					GUI.Label(actionNode32,"Insult",people);
					GUI.Label (actionNode33,"The Answer (?)",people);
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=1;
						InteractionScript.wavyActive.transform.parent.gameObject.GetComponent<AnimControl>().action=true;
						InteractionScript.wavyActive.transform.parent.gameObject.GetComponent<AnimControl>().playerTalk=true;
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
						GUI.DrawTexture (actionNode32,fairyDust);		
						GUI.Label(actionNode32,"Insult",people);
			
						peopleChoice=2;
						InteractionScript.wavyActive.transform.parent.gameObject.GetComponent<AnimControl>().action=true;
						InteractionScript.wavyActive.transform.parent.gameObject.GetComponent<AnimControl>().playerInsult=true;
						dialogueOnce=true; justOnce=true;
				}
					
					if(actionNode33.Contains(Event.current.mousePosition))
					{
						GUI.DrawTexture (actionNode33,fairyDust);		
						GUI.Label (actionNode33,"The Answer (?)",people);
						peopleChoice=3;
						InteractionScript.wavyActive.transform.parent.gameObject.GetComponent<AnimControl>().blame=true;
						dialogueOnce=true; justOnce=true;
					}
				}
				
				//Chair Wavy
					if(InteractionScript.chairFW)
					{
					fairyBlue=true;
					//Debug.Log (InteractionScript.chairActive.transform.parent.parent.FindChild("Dialogue").FindChild("DialogueText"));
					ChairScript.done=true;
					if(SkinSelect.skinChoose!=1)
					ChairScript.words="I'm not your Answer";
				
					else
					ChairScript.words="I'm part of your Answer";	
				
					ChairScript.choose=1;
					}
				
			
			}
			
			if(activeNode==33 && active==3)
			{
		
				
				
				//Normal Black
					if(InteractionScript.black)
				{
					
					GUI.Label (actionNode31,"Talk",people);
					GUI.Label(actionNode32,"Insult",people);
					GUI.Label (actionNode33,"The Answer (?)",people);
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=1;
						InteractionScript.blackActive.transform.parent.gameObject.GetComponent<AnimControl>().action=true;
						InteractionScript.blackActive.transform.parent.gameObject.GetComponent<AnimControl>().playerTalk=true;
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);		
						GUI.Label(actionNode32,"Insult",people);
						peopleChoice=2;
						InteractionScript.blackActive.transform.parent.gameObject.GetComponent<AnimControl>().action=true;
						InteractionScript.blackActive.transform.parent.gameObject.GetComponent<AnimControl>().playerInsult=true;
						dialogueOnce=true; justOnce=true;
				}
					
					if(actionNode33.Contains(Event.current.mousePosition))
					{
						GUI.DrawTexture (actionNode33,fairyDust);		
						GUI.Label (actionNode33,"The Answer (?)",people);
						peopleChoice=3;
						InteractionScript.blackActive.transform.parent.gameObject.GetComponent<AnimControl>().blame=true;
						dialogueOnce=true; justOnce=true;
					}
				
				}
				
				//Chair Black
					if(InteractionScript.chairFB)
					{
					fairyBlue=true;
					ChairScript.done=true;
					if(SkinSelect.skinChoose!=2)
					ChairScript.words="I'm not your Answer";
				
					else
					ChairScript.words="I'm part of your Answer";
					
					ChairScript.choose=0;
				}
				
			
			}
			
			if(activeNode==34 && active==3)
			{
				
				
				//Sitting Person
				if(InteractionScript.sitting)
					{

					GUI.Label (actionNode31,"Talk",people);
					GUI.Label(actionNode32,"Insult",people);
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=1;
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);	
						GUI.Label(actionNode32,"Insult",people);
						peopleChoice=2;
						dialogueOnce=true; justOnce=true;
				}
				
				}
					
					//Chalk Geek
					
					if(InteractionScript.chalkGeek)
					{
					fairyBlue=true;
					GUI.Label (actionNode31,"Talk",people);
					GUI.Label(actionNode32,"Insult",people);
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=1;
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);	
						GUI.Label(actionNode32,"Insult",people);
						peopleChoice=2;
						dialogueOnce=true; justOnce=true;
				}
					
					
				
				}
				
				if(InteractionScript.lightHouseTop)
					{
					fairyBlue=true;
					GUI.Label (actionNode31,"Reminisce about Good Times",people);
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Reminisce about Good Times",people);
						GUI.Label(bg0,"Refuses To",people);
						LighthouseImpScript.argue=true;
						
				}
					
	
					}
				
				
				
						
				
				//Operatic Anarchist
				if(InteractionScript.anarchist)
					{
						fairyBlue=true;
					GUI.Label (actionNode31,"Join the Cause",people);
					GUI.Label(actionNode33,"Ask",people);
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=8;
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode33.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);	
						GUI.Label(actionNode32,"Ask",people);
						peopleChoice=9;
						dialogueOnce=true; justOnce=true;
				}
					
				
				
				}
				
				//Glass Case Guardians
				if(InteractionScript.glassCase)
					{
					fairyBlue=true;
					GUI.Label (actionNode31,"Release the 'Tainted'",people);
					GUI.Label (actionNode33,"Ask",people);
					player.transform.LookAt (InteractionScript.glassCaseActive.transform.parent);						
						player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					if(actionNode31.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Release the 'Tainted'",people);
						GlassScript.release=true;
						
					 	}
					
					if(actionNode33.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode33,fairyDust);	
						GUI.Label(actionNode33,"Ask",people);
							peopleChoice=5;
							dialogueOnce=true; justOnce=true;
						
					 	}
					}
				
				//Guardians at Gate 
				if(InteractionScript.guardian)
					{
					fairyBlue=true;
					GUI.Label (actionNode31,"Open the Gate",people);
					GUI.Label (actionNode33,"Ask",people);
					player.transform.LookAt (InteractionScript.guardianActive.transform.parent);						
						player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					if(actionNode31.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Open the Gate",people);
						peopleChoice=4;
						dialogueOnce=true; justOnce=true;
					 	}
					
					if(actionNode33.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode33,fairyDust);	
						GUI.Label(actionNode33,"Ask",people);
							peopleChoice=5;
							dialogueOnce=true; justOnce=true;
						
					 	}
					}
				
				//Dollar
				if(InteractionScript.dollar)
					{
					fairyBlue=true;
					GUI.Label (actionNode31,"Talk",people);
					GUI.Label (actionNode32,"Ask",people);
					GUI.Label(actionNode33,"Insult",people);
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=4;
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
						GUI.DrawTexture (actionNode32,fairyDust);	
						GUI.Label (actionNode32,"Ask",people);
			
						peopleChoice=5;
						dialogueOnce=true; justOnce=true;
				}
					
					if(actionNode33.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode33,fairyDust);	
						GUI.Label(actionNode33,"Insult",people);
						peopleChoice=6;
						dialogueOnce=true; justOnce=true;
				}
					
				
				}
				
				//Balance Black
				if(InteractionScript.balanceBlack && dChoice==2 && scaleOnce)
					{
					fairyBlue=true;
					GUI.Label (actionNode31,"Talk",people);
					if(WarScript.putMoney)
					GUI.Label(actionNode32,"Favour",people);	
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=23;
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);	
						if(WarScript.putMoney)
					GUI.Label(actionNode32,"Favour",people);	
						peopleChoice=22;
						dialogueOnce=true; justOnce=true;
				}
					
				}
				
				//Balance White
				if(InteractionScript.balanceWhite && dChoice==3 && scaleOnce)
					{
					fairyBlue=true;
					GUI.Label (actionNode31,"Talk",people);
					if(WarScript.putMoney)
					GUI.Label(actionNode32,"Favour",people);	
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=21;
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
						
						GUI.Label (actionNode31,"Talk",people);
					if(WarScript.putMoney)
					GUI.Label(actionNode32,"Favour",people);	
			
						peopleChoice=24;
						dialogueOnce=true; justOnce=true;
				}
				
				}
				
				if(InteractionScript.talkGroup && dChoice==2)
					{
					fairyBlue=true;
					GUI.Label (actionNode31,"Talk",people);
					GUI.Label(actionNode32,"Ask",people);
					
					player.transform.LookAt (InteractionScript.talkGroupActive.transform.parent);						
						player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=13;
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);	
						GUI.Label (actionNode32,"Ask",people);
						peopleChoice=14;
						dialogueOnce=true; justOnce=true;
				}
					
				
				}
				
				if(InteractionScript.talkGroupFem && dChoice==2)
					{
					fairyBlue=true;
					GUI.Label (actionNode31,"Talk",people);
					GUI.Label(actionNode32,"Ask",people);
					player.transform.LookAt (InteractionScript.talkGroupFemActive.transform.parent);						
						player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=13;
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);	
						GUI.Label (actionNode32,"Ask",people);
						peopleChoice=14;
						dialogueOnce=true; justOnce=true;
				}
					
				
				}
				
				if(InteractionScript.talkGroupWavy && dChoice==2)
					{
					fairyBlue=true;
					GUI.Label (actionNode31,"Talk",people);
					GUI.Label(actionNode32,"Ask",people);
					
					player.transform.LookAt (InteractionScript.talkGroupWavyActive.transform.parent);						
						player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Talk",people);
		
						peopleChoice=13;
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);	
						GUI.Label (actionNode32,"Ask",people);
						peopleChoice=14;
						dialogueOnce=true; justOnce=true;
				}
					
				
				}
					
					
				
			}
			
			
			if(activeNode==35 && active==3)
			{
				
				if(InteractionScript.impPerson)
				{
					fairyBlue=true;
					
				GUI.Label (actionNode3b,"Ask",people);
					
					player.transform.LookAt (InteractionScript.impPersonActive.transform);						
					player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
				if(actionNode3b.Contains(Event.current.mousePosition))
				{	
						talkChoice=1;
				}
					
					if(talkChoice==1)
					{
						if(proposeOnce)
						GUI.Label (actionNode31,"We can find it together",people);
						
						GUI.Label (actionNode33,"Who am I?",people);
					if(actionNode31.Contains(Event.current.mousePosition))
				{	
							GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"We can find it together",people);
						peopleChoice=40;
						dialogueOnce=true; justOnce=true;
				}
					
					if(actionNode33.Contains(Event.current.mousePosition))
				{	
							GUI.DrawTexture (actionNode33,fairyDust);	
						GUI.Label (actionNode33,"Who am I?",people);
						peopleChoice=41;
						dialogueOnce=true; justOnce=true;
				}
				}
				}
				
				
				//Bomber
				if(InteractionScript.bomberWavy && bomberOnce)
					{
					fairyBlue=true;
			//	GUI.Label (actionNode31,"Talk",people);
				GUI.Label(actionNode33,"The Answer (?)",people);
					
			/*	if(actionNode31.Contains(Event.current.mousePosition))
				{	
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=20;
						InteractionScript.active.transform.parent.gameObject.GetComponent<AnimControl>().playerTalk=true;
						dialogueOnce=true; justOnce=true;
						
						
				}
					*/
			/*		if(actionNode33.Contains(Event.current.mousePosition))
				{
						GUI.DrawTexture (actionNode33,fairyDust);	
						GUI.Label (actionNode33,"The Answer(?)",people);
						peopleChoice=20;
						bomberOnce=false;
						dialogueOnce=true; justOnce=true;
				}
				
				}
				
				if(InteractionScript.bomberWhite && bomberOnce)
					{
					fairyBlue=true;
			//	GUI.Label (actionNode31,"Talk",people);
				GUI.Label(actionNode33,"The Answer (?)",people);
					
			/*	if(actionNode31.Contains(Event.current.mousePosition))
				{	
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=20;
						InteractionScript.active.transform.parent.gameObject.GetComponent<AnimControl>().playerTalk=true;
						dialogueOnce=true; justOnce=true;
						
						
				}
					*/
			/*		if(actionNode33.Contains(Event.current.mousePosition))
				{
						GUI.DrawTexture (actionNode33,fairyDust);	
						GUI.Label (actionNode33,"The Answer(?)",people);
						peopleChoice=20;
						bomberOnce=false;
						dialogueOnce=true; justOnce=true;
				}
				
				}
				
				if(InteractionScript.bomberBlack && bomberOnce)
					{
					fairyBlue=true;
				//GUI.Label (actionNode31,"Talk",people);
				GUI.Label(actionNode33,"The Answer (?)",people);
					
			/*	if(actionNode31.Contains(Event.current.mousePosition))
				{	
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=19;
						InteractionScript.active.transform.parent.gameObject.GetComponent<AnimControl>().playerTalk=true;
						dialogueOnce=true; justOnce=true;
						
				}
					*/
			/*		if(actionNode33.Contains(Event.current.mousePosition))
				{
						GUI.DrawTexture (actionNode33,fairyDust);	
						GUI.Label (actionNode33,"The Answer(?)",people);
						peopleChoice=20;
						bomberOnce=false;
						dialogueOnce=true; justOnce=true;
				}
				
				}
			}
			
			if((InteractionScript.bomberWavy || InteractionScript.bomberWhite || InteractionScript.bomberBlack) && !bomberOnce && !decisionOnce)
			{
					fairyBlue=true;
				GUI.Label (actionNode3e,"Bomber",people);
				GUI.Label (actionNode31,"Confront",people);
				GUI.Label(actionNode32,"Shoot",people);
				
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Confront",people);
						Debug.Log("Confront");
						Player.confront=true;
						decisionOnce=true;
							
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
						GUI.DrawTexture (actionNode32,fairyDust);	
						GUI.Label (actionNode32,"Shoot",people);
						Debug.Log("Shoot");
						Player.shoot=true;
						decisionOnce=true;
				}
				
			}
				
				
				if(activeNode==36 && active==3)
			{
				
			
				if(InteractionScript.stereotype)
					{
						fairyBlue=true;
						GUI.Label (actionNode3f2,"Talk",people);
						GUI.Label(actionNode3f3,"Ask",people);
						if(actionNode3f2.Contains(Event.current.mousePosition))
						{
						GUI.DrawTexture (actionNode3f2,fairyDust);	
						GUI.Label (actionNode3f2,"Talk",people);
							peopleChoice=16;
							dialogueOnce=true; justOnce=true;
						}
						if(actionNode3f3.Contains(Event.current.mousePosition))
						{
						GUI.DrawTexture (actionNode3f3,fairyDust);	
						GUI.Label (actionNode3f3,"Ask",people);
							peopleChoice=17;
							dialogueOnce=true; justOnce=true;
						}
						
				
					}
				
					//Telepole
				if(InteractionScript.telepole)
					{
					fairyBlue=true;
					GUI.Label (actionNode3d2,"The Burnt",people);
					
				if(SkinSelect.skinChoose==2)
					GUI.Label (actionNode31,"Lament",people);
					
					if(SkinSelect.skinChoose==2)
						GUI.Label (actionNode32,"Chastise",people);
					else
						GUI.Label (actionNode32,"Complain",people);
					
					InteractionScript.active=InteractionScript.telepoleActive;
					
					if(actionNode11a.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode11a,fairyDust);			
						if(SkinSelect.skinChoose==2)
						GUI.Label (actionNode11a,"Chastise",people);
					else
						GUI.Label (actionNode11a,"Complain",people);
						peopleChoice=11;
						dialogueOnce=true; justOnce=true;
						
					 	}
					
					if(actionNode12a.Contains(Event.current.mousePosition))
						{	
						GUI.DrawTexture (actionNode12a,fairyDust);			
						if(SkinSelect.skinChoose==2)
					GUI.Label (actionNode12a,"Lament",env);
						peopleChoice=12;
						dialogueOnce=true; justOnce=true;
						
					 	}
					}
			}
			
			if(activeNode==37 && active==3)
			{
				
			
				if(InteractionScript.queer)
					{
						fairyBlue=true;
						GUI.Label (actionNode3g2,"Talk",people);
						GUI.Label(actionNode3g3,"Ask",people);
						player.transform.LookAt (InteractionScript.queerActive.transform.parent);						
						player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
						if(actionNode3g2.Contains(Event.current.mousePosition))
						{
						GUI.DrawTexture (actionNode3g2,fairyDust);	
						GUI.Label (actionNode3g2,"Talk",people);
							peopleChoice=18;
							dialogueOnce=true; justOnce=true;
						}
						if(actionNode3g3.Contains(Event.current.mousePosition))
						{
						GUI.DrawTexture (actionNode3g3,fairyDust);	
						GUI.Label (actionNode3g3,"Ask",people);
							peopleChoice=19;
							dialogueOnce=true; justOnce=true;
						}
						
				
					}
			}
			
			
			if(activeNode==41 && active==4)
			{
					if(MirrorScript.gender==0)
				{
					GUI.Label(bg0,"Him'",self);
				}
				
				else
				{
					GUI.Label(bg0,"Her'",self);
				}
			}
			
			if(activeNode==42 && active==4)
			{
				if(InteractionScript.reflection && reflectOnce)
					{
					if(!RAIN.Ontology.Aspect.HasAspect (player,"Beauty"))
					{
					RAIN.Ontology.Aspect.AddAspect(player,"Beauty","sight");
					currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
						currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="I feel good!";
					reflectOnce=false;
					}
					}
			}
			
			if(activeNode==43 && active==4)
			{
				if(InteractionScript.reflection && reflectOnce)
					{
					if(!RAIN.Ontology.Aspect.HasAspect (player,"Ugly"))
					{
					RAIN.Ontology.Aspect.AddAspect(player,"Ugly","sight");
						currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
						currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Staring eyes pierce you...";
					reflectOnce=false;
					}
					}
			
			}
			
			if(activeNode==44 && active==4)
			{
				//GUI.DrawTexture (actionNode4d,node);
				if(SkinSelect.skinChoose==0)
					{
					GUI.Label(bg0,"The 'Privileged'",self);
					}
				if(SkinSelect.skinChoose==1)
					{
						GUI.Label(bg0,"The Faithful",self);
					}
			
				if(SkinSelect.skinChoose==2)
					{
						GUI.Label(bg0,"Everyone",self);
					}
				//GUI.DrawTexture (actionNode4d1,node);
			//	GUI.DrawTexture (actionNode4d2,node);
				
			
					
					if(SkinSelect.skinChoose==0)
					{
						HighlightCivs.highlightGroup=5;
						//GUI.Label(bg0,"The 'Privileged'",center);
					}
					if(SkinSelect.skinChoose==1)
					{
						HighlightCivs.highlightGroup=4;
						//GUI.Label(bg0,"The Faithful",center);
					}
					if(SkinSelect.skinChoose==2)
					{
						HighlightCivs.highlightGroup=7;
					//	GUI.Label(bg0,"Everyone",center);
					}
			}
			
			if(activeNode==51)
			{
				GUI.Label (actionNode12a,"Nobody",env);
				if(Player.hasMoney)
				{
				GUI.Label (actionNode13a,"Give Money",env);
				if(actionNode13a.Contains (Event.current.mousePosition))
					{
						GUI.DrawTexture (actionNode13a,fairyDust);	
						GUI.Label (actionNode13a,"Give Money",env);
						Instantiate(money,new Vector3(InteractionScript.chairJudgeActive.transform.parent.position.x+0.408f,InteractionScript.chairJudgeActive.transform.parent.position.y-7.591f,InteractionScript.chairJudgeActive.transform.parent.position.z+4.63f),Quaternion.identity);
						Player.hasMoney=false;
						WarScript.putMoney=true;
						warOnce=false;
						activeNode=0;
					}
				
			}
			}
			
			if(activeNode==61 && active==6)
			{
				GUI.Label (helpGUI,"Interaction",helpStyle);
				GUI.Label (helpGeneral,"The Answer",helpStyle);
				
				if(helpGUI.Contains (Event.current.mousePosition))
				{
					GUI.DrawTexture (helpGUI,fairyDust);
					GUI.Label (helpGUI,"Interaction",helpStyle);
					MaskHelp.interaction=true;
					mask.SetActive (true);
					maskHelp=true;
					
				}
				if(helpGeneral.Contains (Event.current.mousePosition))
				{
					GUI.DrawTexture (helpGeneral,fairyDust);
					GUI.Label (helpGeneral,"Interaction",helpStyle);
					MaskHelp.general=true;
					mask.SetActive (true);
					maskHelp=true;
				}
			}
				else
				{
					HighlightCivs.highlightGroup=0;
				}
				
			if(fairyRed)
			GUI.DrawTexture (redSign,redGlow);
			if(fairyBlue)
			GUI.DrawTexture (blueSign,blueGlow);
			if(fairyGold)
			GUI.DrawTexture (goldSign,goldGlow);
			if(fairyGrey)
			GUI.DrawTexture (greySign,greyGlow);
					
			
			GUI.Label (tex4,"Environment",style);
			GUI.Label (tex1,"Self",style);
			GUI.Label (tex2,"People",style);
			GUI.Label (tex3,"Emotion",style);
			
			//Debug.Log (InteractionScript.active);
		}
		else
		{
			if(!PenaltyScript.bombAffected && PenaltyScript.randChoice!=1)
			((DepthOfFieldScatter)gameObject.GetComponent<DepthOfFieldScatter>()).enabled=false;
			Time.timeScale=1f;
			if(mo!=null)
			mo.enabled=true;
			
			if(!reset)
			{
			resetTimer+=Time.deltaTime;
				if(resetTimer>0.4f)
					close=false;
						
			if(resetTimer>3f)
			{
				actionNode1timer=0f;
				activeNode=0;
				actionNode2timer=0f;
				actionNode3timer=0f;
				actionNode4timer=0f;
					fairyRed=false;
					fairyBlue=false;
					fairyGold=false;
					fairyGrey=false;
					ResetScript.lastPos=transform.position;
					randOnce=true;
					randDialogue=0;
				resetTimer=0f;
				reset=true;
			}
			}
			
				//transform.rotation=Quaternion.identity;
			if(InteractionScript.active!=null)
			{
			InteractionScript.active.renderer.material.SetColor ("_OutlineColor",Color.black);
			InteractionScript.active.renderer.material.SetFloat ("_Outline",0.005f);
				//transform.rotation=Quaternion.identity;
				
				InteractionScript.active=null;
			}
			
			if(!InteractionScript.anarchist  && !InteractionScript.balanceBlack && !InteractionScript.balanceWhite && !InteractionScript.chalkGeek && !InteractionScript.money && !InteractionScript.dollar && !InteractionScript.glassCase)
			{
				if(peopleChoice==1)
			{
				/*if(dialogueOnce)
				{
						currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
				}*/
			/*		if(justOnce)
					{
					
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;
						
					 if(InteractionScript.white)
					{
							//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
						
								if(HistoryScript.gender==0)			//female
								{
									
									transform.LookAt (InteractionScript.whiteActive.transform);
									InteractionScript.whiteActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="This place is crowded because of them";
								}
								else if(HistoryScript.gender==3)	//queer
								{
									transform.LookAt (InteractionScript.whiteActive.transform);
									InteractionScript.whiteActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="Get away from me, freak!";
								}
						else if(HistoryScript.race==2)
						{
								if(dialogueOnce)
								{
								randDialogue=Random.Range (0,2);
								dialogueOnce=false;
								}
							if(randDialogue==0)
							{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Why is this place so crowded?";
								//	GUI.Label (dialogueRect,"Why is this place so crowded?",dialogue);
									transform.LookAt (InteractionScript.whiteActive.transform);
									InteractionScript.whiteActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="This place is crowded because of them";
							}
							else
							{
								//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Noticed anything strange?";
									GUI.Label (dialogueRect,"Noticed anything strange?",dialogue);
									transform.LookAt (InteractionScript.whiteActive.transform);
									InteractionScript.whiteActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="You are the strange one here";	
							
							}
						}
						else
						{
								if(dialogueOnce)
								{
									randDialogue=Random.Range (0,2);
									dialogueOnce=false;
								}
							if(randDialogue==0)
							{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="I'm looking for The Answer";
								
									GUI.Label (dialogueRect,"I'm looking for The Answer",dialogue);
									transform.LookAt (InteractionScript.whiteActive.transform);
									InteractionScript.whiteActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="Not helping you look for it then";	
							}
								else
								{		
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="This is a fascinating place";
								
									GUI.Label (dialogueRect,"This is a fascinating place",dialogue);
									transform.LookAt (InteractionScript.whiteActive.transform);
									InteractionScript.whiteActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="Without your kind, this place would be better";	
								}
							}
					}
					
					else if(InteractionScript.black)
					{
						
							//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
						
						if(SkinSelect.skinChoose==0)
						{
								if(dialogueOnce)
								{
							randDialogue=Random.Range (0,2);
								dialogueOnce=false;
								}
							if(randDialogue==0)
							{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Escape the shackles we made";
								
									GUI.Label (dialogueRect,"Escape the shackles we made",dialogue);
									transform.LookAt (InteractionScript.blackActive.transform);
									InteractionScript.blackActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="But where is the key?";	
							}
								else
							{
								//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Noticed anything strange?";
								
									GUI.Label (dialogueRect,"Noticed anything strange?",dialogue);
									transform.LookAt (InteractionScript.blackActive.transform);
									InteractionScript.blackActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="Pretty much everything";	
						
							}
						}
						else
						{
								if(dialogueOnce)
								{
									randDialogue=Random.Range (0,2);
									dialogueOnce=false;
								}
							if(randDialogue==0)
							{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="I'm looking for The Answer";
							
									GUI.Label (dialogueRect,"I'm looking for The Answer",dialogue);
									transform.LookAt (InteractionScript.blackActive.transform);
									InteractionScript.blackActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="I cannot help you";
							}
								else
							{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Your gaze stokes my insecurities";
							
									GUI.Label (dialogueRect,"Your gaze stokes my insecurities",dialogue);
									transform.LookAt (InteractionScript.blackActive.transform);
									InteractionScript.blackActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="";
						}
						}
					}
					
					else if(InteractionScript.wavy)
					{
						
							//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
						
						if(SkinSelect.skinChoose==1)
						{
								if(dialogueOnce)
								{
									randDialogue=Random.Range (0,2);
									dialogueOnce=false;
								}
							if(randDialogue==0)
							{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Do we look behind or ahead?";
							
									GUI.Label (dialogueRect,"Do we look behind or ahead?",dialogue);
									transform.LookAt (InteractionScript.wavyActive.transform);
									InteractionScript.wavyActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="This question tears our kind apart";
							}	
								else
							{
								//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Noticed anything strange?";
						
									GUI.Label (dialogueRect,"Noticed anything strange?",dialogue);
									transform.LookAt (InteractionScript.wavyActive.transform);
									InteractionScript.wavyActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="The news. They seem familiar";
							}
						}
						else
						{
								if(dialogueOnce)
								{
									randDialogue=Random.Range (0,2);
									dialogueOnce=false;
								}
							if(randDialogue==0)
							{
								//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="I'm looking for The Answer";
									
									GUI.Label (dialogueRect,"I'm looking for The Answer",dialogue);
									transform.LookAt (InteractionScript.wavyActive.transform);
									InteractionScript.wavyActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="Alas, I cannot help";
							}
								else
							{
								//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Actions of few tainting everyone";
									GUI.Label (dialogueRect,"Actions of few tainting everyone",dialogue);
									transform.LookAt (InteractionScript.wavyActive.transform);
									InteractionScript.wavyActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="But where should we point our fingers?";
							}
						}
					}
					
					else if(InteractionScript.chairWhite || InteractionScript.chairWavy || InteractionScript.chairBlack)
					{
							//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
								if(dialogueOnce)
								{
							randDialogue=Random.Range (0,2);
							dialogueOnce=false;
								}
							if(randDialogue==0)
								GUI.Label (dialogueRect,"I know it's tough",dialogue);
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="I know it's tough";
							else
								GUI.Label (dialogueRect,"Is this the future we worked for?",dialogue);
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Is this the future we worked for?";
						
						
					}
					
					else if(InteractionScript.sitting)
					{
						
						//	currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
						if(dialogueOnce)
								{
							randDialogue=Random.Range (0,2);
								dialogueOnce=false;
								}
							if(randDialogue==0)
								GUI.Label (dialogueRect,"I know it's tough",dialogue);
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="I know it's tough";
							else
								GUI.Label (dialogueRect,"Welcome to the machine",dialogue);
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Welcome to the machine";
						
					}
					
					
					else
					{
							GUI.Label (dialogueRect,"How do you do?",dialogue);
						//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="How do you do?";
					}
				}
					}
						if(dialogueTimer>=3f)
						{
							dialogueOnce=false;
							justOnce=false;
						peopleChoice=0;
							dialogueTimer=0f;
						}
				
			
			}
			
			if(peopleChoice==2)
			{
				//if(dialogueOnce)
				//{
					//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
					if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;		
					if(InteractionScript.dollar)
					{
						GUI.Label (dialogueRect,"Where did we all go wrong?",dialogue);
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Where did we all go wrong?";
					}
					
					else if(InteractionScript.sitting)
					{
						GUI.Label (dialogueRect,"You sold your freedom for safety",dialogue);
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="You sold your freedom for safety";
					}
				}
					}
				
					if(dialogueTimer>=3f)
						{
							dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
							dialogueTimer=0f;
						}
				}

			
			if(peopleChoice==3)
			{
		//	Debug.Log (InteractionScript.active);
				if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;		
					if(InteractionScript.white || InteractionScript.wavy || InteractionScript.black)
					{
						currentDialogue= Instantiate(permaDialogue,transform.position+transform.forward*2f,Quaternion.identity)as GameObject;
						currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Wrong";						
					}
						}
					}
					
			
					if(dialogueTimer>=3f)
						{
							dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
							dialogueTimer=0f;
						}			
			}
			
		if(peopleChoice==4)
			{
				if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
				if(InteractionScript.dollar)
				{
							GUI.Label (dialogueRect,"Aren't you worried about your future?",dialogue);
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Aren't you worried about your future?";
							transform.LookAt (InteractionScript.dollarActive.transform);
							InteractionScript.dollarActive.transform.parent.FindChild ("Dialogue").GetComponent<DollarScript>().dialogue.text="Only if we would look up";
				}
							if(InteractionScript.guardian)
					{
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Is what I seek inside the glass casket?";
							GUI.Label (dialogueRect,"What lies outside?",dialogue);
							transform.LookAt (InteractionScript.guardianActive.transform);
							InteractionScript.guardianActive.transform.parent.FindChild ("Dialogue").GetComponent<GuardianScript>().dialogue.text="The horrors you hide from";
					}
				}
					}
					if(dialogueTimer>=3f)
						{
							dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
							dialogueTimer=0f;
						}	
			}
			
			if(peopleChoice==5)
			{
				if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
				if(InteractionScript.dollar)
				{
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Can you help me find something?";
							GUI.Label (dialogueRect,"Can you help me find something?",dialogue);
							transform.LookAt (InteractionScript.dollarActive.transform);
							InteractionScript.dollarActive.transform.parent.FindChild ("Dialogue").GetComponent<DollarScript>().dialogue.text="You only need to look within to find The Answer";
				}
					
				if(InteractionScript.glassCase)
					{
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Is what I seek inside the glass casket?";
							GUI.Label (dialogueRect,"Is what I seek inside the glass casket?",dialogue);
							transform.LookAt (InteractionScript.glassCaseActive.transform);
							InteractionScript.glassCaseActive.transform.parent.FindChild ("Dialogue").GetComponent<GlassScript>().dialogue.text="No,our stern,watchful gazes keep the Tainted imprisoned";
					}
							
							if(InteractionScript.guardian)
					{
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Is what I seek inside the glass casket?";
							GUI.Label (dialogueRect,"Would you kindly open the Gate?",dialogue);
							transform.LookAt (InteractionScript.guardianActive.transform);
							InteractionScript.guardianActive.transform.parent.FindChild ("Dialogue").GetComponent<GuardianScript>().dialogue.text="But why do you want to go outside when it's safe here?";
					}
				}
						}
					if(dialogueTimer>=3f)
						{
							dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
							dialogueTimer=0f;
						}	
			}
			
			if(peopleChoice==6)
			{
				
				if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
				if(InteractionScript.dollar)
				{
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="You disappoint me";
							InteractionScript.dollarActive.transform.parent.FindChild ("Dialogue").GetComponent<DollarScript>().dialogue.text="So do we";
				}
				if(InteractionScript.tentPeople)
					{
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Can you help me find what I seek?";
						GUI.Label (dialogueRect,"Can you help me find what I seek?",dialogue);
							transform.LookAt (InteractionScript.tentPeopleActive.transform.parent);
							InteractionScript.tentPeopleActive.transform.parent.parent.FindChild ("Top").gameObject.SetActive (true);
						InteractionScript.tentPeopleActive.transform.parent.FindChild ("Dialogue").GetComponent<TentScript>().dialogue.text="The roof you built helps answer both our prayers";
						InteractionScript.tentPeopleActive.transform.parent.FindChild ("FemBL").FindChild("Dialogue").GetComponent<TentScript>().dialogue.text="";
						tentOnce=true;
					}
				}
						}
					if(dialogueTimer>=3f)
						{
							dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
							dialogueTimer=0f;
						}
			}
			
			if(peopleChoice==7)
			{
				if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
				if(InteractionScript.tentPeople)
					{
					//	currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Why couldn't we leave our habits?";
						GUI.Label (dialogueRect,"Why couldn't we leave our habits?",dialogue);
							transform.LookAt (InteractionScript.tentPeopleActive.transform.parent);
							InteractionScript.tentPeopleActive.transform.parent.FindChild ("Dialogue").GetComponent<TentScript>().dialogue.text="Because what we worshipped only made us weaker";
						InteractionScript.tentPeopleActive.transform.parent.FindChild ("FemBL").FindChild("Dialogue").GetComponent<TentScript>().dialogue.text="";
					}
		
				}
						}
					if(dialogueTimer>=3f)
						{
							dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
							dialogueTimer=0f;
						}
			}
			
			
			if(peopleChoice==9)
			{
					if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
				if(InteractionScript.anarchist)
					{
						randDialogue=Random.Range (0,2);
							if(randDialogue==0)
					{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Why are you angry?";
								GUI.Label (dialogueRect,"Why are you angry?",dialogue);
							transform.LookAt (InteractionScript.anarchistActive.transform.parent);
							InteractionScript.anarchistActive.transform.parent.FindChild ("Dialogue").GetComponent<AnarchistScript>().dialogue.text="Because I need a reason";
					}
							else
					{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Where does an individual end and a society begin?";
								GUI.Label (dialogueRect,"Where does an individual end and a society begin?",dialogue);
							transform.LookAt (InteractionScript.anarchistActive.transform.parent);
						InteractionScript.anarchistActive.transform.parent.FindChild ("Dialogue").GetComponent<AnarchistScript>().dialogue.text="At the altar of responsibility";
					}
						
					}
						}
					}
					if(dialogueTimer>=3f)
						{
							dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
							dialogueTimer=0f;
						}
			}
			
			if(peopleChoice==8)
			{
					if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
				if(InteractionScript.anarchist)
					{
					
						
							//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;

							
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Can you help me find what I seek?";
							GUI.Label (dialogueRect,"I wish to destroy the systems that bind us",dialogue);
							transform.LookAt (InteractionScript.anarchistActive.transform.parent);
								
								if(MirrorScript.gender==0)
								{
									InteractionScript.anarchistActive.transform.parent.FindChild ("Dialogue").GetComponent<AnarchistScript>().dialogue.text="A woman like you should destroy the chains that bind you";
								}
								else
								{
							InteractionScript.anarchistActive.transform.parent.FindChild ("Dialogue").GetComponent<AnarchistScript>().dialogue.text="May you find your purpose in the burning fires of chaos";
								
								}
					}
						}
					}
				if(dialogueTimer>=3f)
						{
							dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
							dialogueTimer=0f;
						}
			}
			
			
			if(peopleChoice==11)
			{
					if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
				if(InteractionScript.telepole)
					{
							//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
							if(SkinSelect.skinChoose==2)
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="You shame us all";
							GUI.Label (dialogueRect,"You shame us all",dialogue);
							transform.LookAt (InteractionScript.telepoleActive.transform.parent);
							InteractionScript.telepoleActive.transform.parent.FindChild ("Dialogue1").GetComponent<TelepoleScript>().dialogue.text="Is shame REALLY what you felt?";
						}
							else
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="All of your kind are the same";
							GUI.Label (dialogueRect,"All of your kind are the same",dialogue);
							transform.LookAt (InteractionScript.telepoleActive.transform.parent);
							InteractionScript.telepoleActive.transform.parent.FindChild ("Dialogue1").GetComponent<TelepoleScript>().dialogue.text="Would you have treated us any differently?";
						}
						}
						}
					}
				if(dialogueTimer>=3f)
						{
							dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
							dialogueTimer=0f;
						}
			}
			
			
			if(peopleChoice==12)
			{
					if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
				if(InteractionScript.telepole)
					{
		
							//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;

							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="I'm sorry for the sins of our fathers";
							GUI.Label (dialogueRect,"I'm sorry for the sins of our fathers",dialogue);
							transform.LookAt (InteractionScript.telepoleActive.transform.parent);
							InteractionScript.telepoleActive.transform.parent.FindChild ("Dialogue1").GetComponent<TelepoleScript>().dialogue.text="Your guilt changes nothing";
						
						}
						}
					}
				if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
							dialogueTimer=0f;
						}
			}
			
			if(peopleChoice==13)
			{
			
				
							if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
							if(InteractionScript.talkGroup)
						{
					
						//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
						if(SkinSelect.skinChoose==2)
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="This place was better before it got crowded";
							GUI.Label (dialogueRect,"This place was better before it got crowded",dialogue);
							transform.LookAt (InteractionScript.talkGroupActive.transform);
							InteractionScript.talkGroupActive.transform.FindChild ("Dialogue").GetComponent<TalkGroupScript>().dialogue.text="Amen brother";
							InteractionScript.talkGroupActive.transform.FindChild ("Dialogue").GetComponent<TalkGroupScript>().playerTalk=true;
						}
						else
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="This is a fascinating place";
							GUI.Label (dialogueRect,"This is a fascinating place",dialogue);
							transform.LookAt (InteractionScript.talkGroupActive.transform);
							InteractionScript.talkGroupActive.transform.FindChild ("Dialogue").GetComponent<TalkGroupScript>().dialogue.text="Leave us alone";
							InteractionScript.talkGroupActive.transform.FindChild ("Dialogue").GetComponent<TalkGroupScript>().playerTalk=true;
						}
					}
					
					if(InteractionScript.talkGroupWavy)
						{			
						//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
							if(SkinSelect.skinChoose==1)
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Personal ambitions divide us when traditions corrode";
							GUI.Label (dialogueRect,"Personal ambitions divide us when traditions corrode",dialogue);
							transform.LookAt (InteractionScript.talkGroupWavyActive.transform);	
							InteractionScript.talkGroupWavyActive.transform.FindChild ("Dialogue").GetComponent<TGWavyScript>().dialogue.text="Yet we can't look ahead without looking back";
							InteractionScript.talkGroupWavyActive.transform.FindChild ("Dialogue").GetComponent<TGWavyScript>().playerTalk=true;
						}
						else
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="I greatly respect your culture";
							GUI.Label (dialogueRect,"I greatly respect your culture",dialogue);
							transform.LookAt (InteractionScript.talkGroupWavyActive.transform);	
							InteractionScript.talkGroupWavyActive.transform.FindChild ("Dialogue").GetComponent<TGWavyScript>().dialogue.text="Wish we did too";
							InteractionScript.talkGroupWavyActive.transform.FindChild ("Dialogue").GetComponent<TGWavyScript>().playerTalk=true;
						}
					
						}
					
					if(InteractionScript.talkGroupFem)
						{
							
						//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
							if(MirrorScript.gender==0)
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Why the hate,sister?";
							GUI.Label (dialogueRect,"Why the hate,sister?",dialogue);
							transform.LookAt (InteractionScript.talkGroupFemActive.transform);	
							InteractionScript.talkGroupFemActive.transform.FindChild ("Dialogue").GetComponent<TGFemScript>().playerTalk=true;
							InteractionScript.talkGroupFemActive.transform.FindChild ("Dialogue").GetComponent<TGFemScript>().dialogue.text="Because they have held us back for too long";
						}
						else
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Hello ladies!";
							GUI.Label (dialogueRect,"Hello ladies!",dialogue);
							transform.LookAt (InteractionScript.talkGroupFemActive.transform);	
							InteractionScript.talkGroupFemActive.transform.FindChild ("Dialogue").GetComponent<TGFemScript>().playerTalk=true;
							InteractionScript.talkGroupFemActive.transform.FindChild ("Dialogue").GetComponent<TGFemScript>().dialogue.text="Shove off";
						}
						}
						}
					}
						
						if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
					
			}
			
			
			if(peopleChoice==14)
			{
			
					
						
							if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
							if(InteractionScript.talkGroup)
						{
						//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
						if(SkinSelect.skinChoose==2)
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Could you help me,man?";
							GUI.Label (dialogueRect,"Could you help me,man?",dialogue);
							transform.LookAt (InteractionScript.talkGroupActive.transform);	
							InteractionScript.talkGroupActive.transform.FindChild ("Dialogue").GetComponent<TalkGroupScript>().playerTalk=true;
							InteractionScript.talkGroupActive.transform.FindChild ("Dialogue").GetComponent<TalkGroupScript>().dialogue.text="What you hate is the key to The Answer";
						}
						else
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Hey, can you...";
							GUI.Label (dialogueRect,"Hey, can you...",dialogue);
							transform.LookAt (InteractionScript.talkGroupActive.transform);	
							InteractionScript.talkGroupActive.transform.FindChild ("Dialogue").GetComponent<TalkGroupScript>().playerTalk=true;
							InteractionScript.talkGroupActive.transform.FindChild ("Dialogue").GetComponent<TalkGroupScript>().dialogue.text="No,we will not help you";
						}
						}
					
						
						
					
					if(InteractionScript.talkGroupWavy)
						{
					
						//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
							if(SkinSelect.skinChoose==1)
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Could you help me,brothers?";
							GUI.Label (dialogueRect,"Could you help me,brothers?",dialogue);
							transform.LookAt (InteractionScript.talkGroupWavyActive.transform);	
							InteractionScript.talkGroupWavyActive.transform.FindChild ("Dialogue").GetComponent<TGWavyScript>().dialogue.text="Our collective fear of our own image gives a hint";
							InteractionScript.talkGroupWavyActive.transform.FindChild ("Dialogue").GetComponent<TGWavyScript>().playerTalk=true;
						}
						else
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Could you help me find what I seek?";
							GUI.Label (dialogueRect,"Could you help me find what I seek?",dialogue);
							transform.LookAt (InteractionScript.talkGroupWavyActive.transform);	
							InteractionScript.talkGroupWavyActive.transform.FindChild ("Dialogue").GetComponent<TGWavyScript>().playerTalk=true;
							InteractionScript.talkGroupWavyActive.transform.FindChild ("Dialogue").GetComponent<TGWavyScript>().dialogue.text="We would love to,if we only could";
						}
					
						}
					
					if(InteractionScript.talkGroupFem)
						{		
		
						//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
							if(MirrorScript.gender==0)
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Sisters,could you help me find what I seek?";
							GUI.Label (dialogueRect,"Sisters,could you help me find what I seek?",dialogue);
							transform.LookAt (InteractionScript.talkGroupFemActive.transform);	
							InteractionScript.talkGroupFemActive.transform.FindChild ("Dialogue").GetComponent<TGFemScript>().playerTalk=true;
							InteractionScript.talkGroupFemActive.transform.FindChild ("Dialogue").GetComponent<TGFemScript>().dialogue.text="We all despise them for putting us down";
						}
						else
						{
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Hey could you help me?";
							GUI.Label (dialogueRect,"Hey could you help me find what I seek?",dialogue);
							transform.LookAt (InteractionScript.talkGroupFemActive.transform);	
							InteractionScript.talkGroupFemActive.transform.FindChild ("Dialogue").GetComponent<TGFemScript>().playerTalk=true;
							InteractionScript.talkGroupFemActive.transform.FindChild ("Dialogue").GetComponent<TGFemScript>().dialogue.text="Why don't you use your superiority to find out yourself?";
						}
		
					}
						}
					}
						
						if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
			
			}
			
			if(peopleChoice==15)
			{
							if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
					if(InteractionScript.stereotype)
					{
					//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Why can't you break free?";
							GUI.Label (dialogueRect,"Why can't you break free?",dialogue);
							transform.LookAt (InteractionScript.stereotypeActive.transform);	
							InteractionScript.stereotypeActive.transform.FindChild ("Dialogue").GetComponent<StereotypeScript>().dialogue.text="Because I fear the eyes";
						
				}
						}
					}
				if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
			}
				
				if(peopleChoice==16)
			{
					
							if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
				if(InteractionScript.stereotype)
				{
					//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
							//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Why can't you break free?";
							GUI.Label (dialogueRect,"Why can't you break free?",dialogue);
							transform.LookAt (InteractionScript.stereotypeActive.transform);	
							InteractionScript.stereotypeActive.transform.FindChild ("Dialogue").GetComponent<StereotypeScript>().dialogue.text="Because I fear the eyes";
							Debug.Log ("CAGE SPEAKS");
						
				}
						}
					}
					if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
			}
			
			if(peopleChoice==17)
			{
					
					if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
				if(InteractionScript.stereotype)
				{	
					//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
					//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Can you help me?";
					GUI.Label (dialogueRect,"Can you help me?",dialogue);
					transform.LookAt (InteractionScript.stereotypeActive.transform);	
					InteractionScript.stereotypeActive.transform.FindChild ("Dialogue").GetComponent<StereotypeScript>().dialogue.text="No, but my cage can";
						Debug.Log ("CAGE SPEAKS");
						
				}
						}
					}
				if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
			}
			
			
			if(peopleChoice==18)
			{
				
				if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
					if(InteractionScript.queer)
							{
					Debug.Log (InteractionScript.queerActive);
					//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
					//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Are you free now?";
					GUI.Label (dialogueRect,"Are you free now?",dialogue);
					transform.LookAt (InteractionScript.queerActive.transform);	
					InteractionScript.queerActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="The shackles are broken but the marks remain";
						
				}
						}
					}
				if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
			}
			
			if(peopleChoice==19)
			{
				if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;		
				if(InteractionScript.queer)
					{
					//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.FromToRotation(Vector3.zero,transform.forward))as GameObject;
					//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Can you help me?";
					GUI.Label (dialogueRect,"Can you help me?",dialogue);
					transform.LookAt (InteractionScript.queerActive.transform);
					InteractionScript.queerActive.transform.parent.FindChild ("Dialogue").GetComponent<CivDialogue>().dialogue.text="You were always prejudiced towards those unlike you";
								}
								
				}
						}
				if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
			}
			
			if(peopleChoice==20)
			{
					if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;				
				if(InteractionScript.bomberWavy || InteractionScript.bomberWhite || InteractionScript.bomberBlack)
					{
						//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="We meet finally";
						GUI.Label (dialogueRect,"We finally meet",dialogue);
						BomberMovement.caught=true;
						
					}
				}
					}
					if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
			}
			
			if(peopleChoice==21)
			{
				if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
				if(InteractionScript.balanceWhite)
					{
						//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="What do you ask for?";
						GUI.Label (dialogueRect,"What do you ask for?",dialogue);
						transform.LookAt (InteractionScript.balanceWhiteActive.transform);
						InteractionScript.balanceWhiteActive.transform.parent.FindChild ("Dialogue").GetComponent<BalanceWhiteScript>().dialogue.text="Justice and to live free";
						
					}
				}
					}
				if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
			}
			
			if(peopleChoice==22)
			{
				if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;	
				if(InteractionScript.balanceBlack)
					{
						//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="You are free";
						GUI.Label (dialogueRect,"Justice shall be served to the privileged",dialogue);
						WarScript.favour=1;
						scaleOnce=false;
						activeNode=0;
						peopleChoice=0;
					}
				}
					}
				if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
			}
			
			if(peopleChoice==23)
			{
				if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;			
				if(InteractionScript.balanceBlack)
					{
						//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="What do you ask for?";
						GUI.Label (dialogueRect,"What do you ask for?",dialogue);
						transform.LookAt (InteractionScript.balanceBlackActive.transform);	
						InteractionScript.balanceBlackActive.transform.parent.FindChild ("Dialogue").GetComponent<BalanceBlackScript>().dialogue.text="Justice and to live free";
						
					}
				}
					}
					
				if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
			}
			
		if(peopleChoice==24)
			{
				if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;		
				if(InteractionScript.balanceWhite)
					{
						//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="You are free";
						GUI.Label (dialogueRect,"You are free",dialogue);
						WarScript.favour=2;
						scaleOnce=false;
						activeNode=0;
						peopleChoice=0;
					}
				}
					}
					if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
			}
			
			
			
			//SCENE TWO
			
				if(peopleChoice==31)
			{
				if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;		
					if(InteractionScript.artist)
					{
						if(dialogueChoice==1)
						{
						//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="I made a tough decision";
						GUI.Label (dialogueRect,"I made a tough decision",dialogue);
						transform.LookAt (InteractionScript.artistActive.transform);
									
						InteractionScript.artistActive.transform.FindChild ("Dialogue").GetComponent<ArtistScript>().dialogue.text="I sympathize with your state";
						}
						else
						{
							//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="It was in the best interest of our future";
						GUI.Label (dialogueRect,"It was in the best interest of our future",dialogue);
						transform.LookAt (InteractionScript.artistActive.transform);
						InteractionScript.artistActive.transform.FindChild ("Dialogue").GetComponent<ArtistScript>().dialogue.text="I sympathize with your state";
						}
					}
							
				if(InteractionScript.desk)
					{
						if(dialogueChoice==1)
						{
							//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*4f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Safety must be a privilege few possess";
						GUI.Label (dialogueRect,"Safety must be a privilege few possess",dialogue);
						transform.LookAt (InteractionScript.deskActive.transform);
						InteractionScript.deskActive.transform.FindChild ("Dialogue").GetComponent<DeskScript>().dialogue.text="Yet,it is essential for enjoying your life";
						}
						else
						{
						//	currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*4f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="I had to climb many stairs to reach here";
						GUI.Label (dialogueRect,"I had to climb many stairs to reach here",dialogue);
						transform.LookAt (InteractionScript.deskActive.transform);
						InteractionScript.deskActive.transform.FindChild ("Dialogue").GetComponent<DeskScript>().dialogue.text="So did I. But it was worth it,wasn't it?";
						}
					}
					
					if(InteractionScript.noose)
					{
						if(dialogueChoice==1)
						{
						//	currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*4f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="O Mirror,what happened?";
						GUI.Label (dialogueRect,"O Mirror,what happened?",dialogue);
						transform.LookAt (InteractionScript.nooseActive.transform);
						InteractionScript.nooseActive.transform.FindChild ("Dialogue").GetComponent<NooseScript>().dialogue.text="You died as you had lived";
						}
						else
						{
						//	currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*4f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Did he ever find hope before losing it?";
						GUI.Label (dialogueRect,"Did he ever find hope before losing it?",dialogue);
						transform.LookAt (InteractionScript.nooseActive.transform);
						InteractionScript.nooseActive.transform.FindChild ("Dialogue").GetComponent<NooseScript>().dialogue.text="What do you think...?";
						}
					}
					
					if(InteractionScript.family)
					{
						if(dialogueChoice==1)
						{
							//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*4f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Past mistakes never erode";
						GUI.Label (dialogueRect,"Past mistakes never erode",dialogue);
						transform.LookAt (InteractionScript.familyActive.transform);
						InteractionScript.familyActive.transform.FindChild ("ImpDialogue").GetComponent<FamilyScript>().dialogue.text="But our faith on this bond does";
							InteractionScript.familyActive.transform.FindChild ("Dialogue").GetComponent<FamilyScript>().dialogue.text="But our faith on this bond does";
						}
						else
						{
							//currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*4f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="An oasis of trust we never found";
							GUI.Label (dialogueRect,"An oasis of trust that we never found",dialogue);
							transform.LookAt (InteractionScript.familyActive.transform);
							InteractionScript.familyActive.transform.FindChild ("ImpDialogue").GetComponent<FamilyScript>().dialogue.text="Even as we fought while the sand buried us";
							InteractionScript.familyActive.transform.FindChild ("Dialogue").GetComponent<FamilyScript>().dialogue.text="Even as we fought while the sand buried us";
						}
					}
							
						}
					}
					if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
			}
			
			
			if(peopleChoice==32)
			{
				if(justOnce)
					{
					if(dialogueTimer<3f)
					{
						dialogueTimer+=Time.deltaTime;				
				if(InteractionScript.artist)
					{
						if(dialogueChoice==1)
						{
						//	currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Are you happy?";
						GUI.Label (dialogueRect,"Are you happy?",dialogue);
						transform.LookAt (InteractionScript.artistActive.transform);
						InteractionScript.artistActive.transform.FindChild ("Dialogue").GetComponent<ArtistScript>().dialogue.text="I don't really know";
						}
						else
						{
					//		currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.identity)as GameObject;
					//	currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Why won't you paint?";
						GUI.Label (dialogueRect,"Why won't you paint?",dialogue);
						transform.LookAt (InteractionScript.artistActive.transform);	
						InteractionScript.artistActive.transform.FindChild ("Dialogue").GetComponent<ArtistScript>().dialogue.text="Because my past has abandoned me for another";
						}
					}
					
					if(InteractionScript.desk)
					{
						if(dialogueChoice==1)
						{
						//	currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Are you happy?";
						GUI.Label (dialogueRect,"Are you happy?",dialogue);
						transform.LookAt (InteractionScript.deskActive.transform);
						InteractionScript.deskActive.transform.FindChild ("Dialogue").GetComponent<DeskScript>().dialogue.text="I'm safe, so I must be happy";
						}
						else
						{
						//	currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*2f,Quaternion.identity)as GameObject;
						//currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Why are you locked?";
						GUI.Label (dialogueRect,"Why are you locked?",dialogue);
						transform.LookAt (InteractionScript.deskActive.transform);
						InteractionScript.deskActive.transform.FindChild ("Dialogue").GetComponent<DeskScript>().dialogue.text="So I can remain safe";
						}
					}
					
					if(InteractionScript.noose)
					{
						if(dialogueChoice==1)
						{
					//		currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*4f,Quaternion.identity)as GameObject;
					//	currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Death....";
						GUI.Label (dialogueRect,"Death....",dialogue);
						transform.LookAt (InteractionScript.nooseActive.transform);
						InteractionScript.nooseActive.transform.FindChild ("Dialogue").GetComponent<NooseScript>().dialogue.text="A release from all the pain";
						}
						else
						{
					//		currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*4f,Quaternion.identity)as GameObject;
					//	currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="What does the mirror reflect?";
						GUI.Label (dialogueRect,"What does the mirror reflect?",dialogue);
						transform.LookAt (InteractionScript.nooseActive.transform);
						InteractionScript.nooseActive.transform.FindChild ("Dialogue").GetComponent<NooseScript>().dialogue.text="All your dreams hung dry";
						}
					}
					
					if(InteractionScript.family)
					{
						if(dialogueChoice==1)
						{
					//		currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*4f,Quaternion.identity)as GameObject;
					//	currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Are you happy?";
						GUI.Label (dialogueRect,"Are you happy?",dialogue);
						transform.LookAt (InteractionScript.familyActive.transform);
						InteractionScript.familyActive.transform.FindChild ("Dialogue").GetComponent<FamilyScript>().dialogue.text="I always believed I was";
						}
						else
						{
					//		currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*4f,Quaternion.identity)as GameObject;
					//	currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="Are both of you happy?";
							GUI.Label (dialogueRect,"Are both of you happy?",dialogue);
							transform.LookAt (InteractionScript.familyActive.transform);
							InteractionScript.familyActive.transform.FindChild ("Dialogue").GetComponent<FamilyScript>().dialogue.text="We never found the answer";
							InteractionScript.familyActive.transform.FindChild ("ImpDialogue").GetComponent<FamilyScript>().dialogue.text="We never found the answer";
						} 
					}
						}
					}
					if(dialogueTimer>=3f)
						{
						dialogueOnce=false;
						justOnce=false;
						peopleChoice=0;
						dialogueTimer=0f;
						}
			}
			
			
			if(peopleChoice==40)		//Marry me?
			{
				if(dialogueOnce)
				{
							
				if(InteractionScript.impPerson)
					{
						proposeOnce=false;
						ImpPersonScript.follow=true;
					}
				}
				dialogueOnce=false;
			}
			
			
			if(peopleChoice==41)	//Who am I?
			{
				if(dialogueOnce)
				{
							
				if(InteractionScript.impPerson)
					{
						//dialogue
					}
				}
				dialogueOnce=false;
			}
			*/
			
			
			

			
			((DepthOfFieldScatter)gameObject.GetComponent<DepthOfFieldScatter>()).enabled=false;
			Time.timeScale=1f;
			if(mo!=null)
			mo.enabled=true;
			Screen.showCursor=false;
				if(natMo!=null)
			natMo.enabled=true;
		
		}
	}

	
	void OnConversationStart()
	{
		Debug.Log ("OFF");
		gameObject.GetComponent<WheelScript>().enabled=false;
	}
	
	void OnConversationEnd()
	{
		Debug.Log ("ON");
		gameObject.GetComponent<WheelScript>().enabled=true;
	}
}
