using UnityEngine;
using System.Collections;

public class DreamWheel : MonoBehaviour {
	public Texture red;
	public Texture grey;
	public Texture blue;
	public Texture gold;

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
	
	
	private int thoughtChoice=0;
	
	
	public bool justOnce=true;

	
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
	
 public static bool grass=false;
	
	private Rect quitGame;
private float quitTimer=0f;
	public static Vector3 targetVect;
	
	public static bool family=false;
	public static GameObject familyActive;
	
	public static bool armyBoss=false;
	public static GameObject armyBossActive;
	
	public static bool chosen=false;
	private bool close=false;
	private float closeTimer=0f;
	
	
	// Use this for initialization
	void Start () {
		
		screenWidth=Screen.width/2f;
		screenHeight=Screen.height/2f;
		player=transform.parent.gameObject;
		mo=player.GetComponent<MouseLook>();
	//	bg0=new Rect(screenWidth-50f,screenHeight,50f,50f);
		
		
		//bg1=new Rect(0f,0f,screenWidth-50f,screenHeight-50f);
	
		
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
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (randThought);
//		Debug.Log (thoughtChoice);
	//Debug.Log (InteractionScript.artist);
/*		if(chosen)
		{
		closeTimer+=Time.deltaTime;
		if(closeTimer>0.3f)
			{
				
				close=true;
				chosen=false;
				closeTimer=0f;
				
			}
		}
		
		*/
		
		if(ButtonAppear.active)
		{
			GetComponent<MouseLook>().enabled=false;
		}
		else
		{
			GetComponent<MouseLook>().enabled=true;
		}
		
		if(!reset)
			{
			resetTimer+=Time.deltaTime;
				if(resetTimer>0.3f)
				{
					close=false;
				}
				//Debug.Log (resetTimer);
			if(resetTimer>2f)
			{
				family=false;
				armyBoss=false;
	/*			actionNode1timer=0f;
				activeNode=0;
				actionNode2timer=0f;
				actionNode3timer=0f;
				actionNode4timer=0f;*/
					fairyRed=false;
					fairyBlue=false;
					fairyGold=false;
					fairyGrey=false;
					ResetScript.lastPos=transform.position;
					randOnce=true;
					randDialogue=0;
					InteractionScript.bull=false;
					InteractionScript.mirrorSelf=false;
					InteractionScript.billboard=false;
				resetTimer=0f;
				reset=false;
			}
			}
	}
	
	void OnGUI()
	{
		
		
		if(Input.GetMouseButton(0) && !DialogueSupervisor.talk)
		{
			
		
		
			//Debug.Log (activeNode);
			
			//GUI.DrawTexture (bg0,bg);
			//ray=Camera.main.ViewportPointToRay (Input.mousePosition);
			//if(Physics.Raycast(ray,out hit,10f))
			//{
				
			//}
			Screen.showCursor=true;
		//	((DepthOfFieldScatter)gameObject.GetComponent<DepthOfFieldScatter>()).enabled=true;
			Time.timeScale=0.2f;
			
	/*		if(DreamTracker.dream!=2) //DISALLOWED FOR SPECIFIC DREAMS
			GetComponent<MouseLook>().enabled=false;
			*/
			if(mo!=null)
			mo.enabled=false;
			
		
			
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
/*			GUI.DrawTexture (tex4,red);
			
			GUI.DrawTexture (tex3,grey);
			
			GUI.DrawTexture (tex2,blue);
			
			GUI.DrawTexture (tex1,gold);
			
			
			
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
				if(DreamTracker.dream==1)
				{
					if(VillageMemory.dreamVisit==0)
					{
						if(!VillageMemory.pickGun)
						{
						GUI.Label (actionNode1a,"Pick Up Gun",env);
							if(actionNode1a.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1a,fairyDust);
					transform.LookAt (player.GetComponent<VillageMemory>().gun.transform);
					transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);	
								chosen=true;
					VillageMemory.pickGun=true;
					
				}
						}
						
						if(InteractionScript.casket)
						{
							GUI.Label (actionNode1a,"Help Child",env);
							if(actionNode1a.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1a,fairyDust);
						ShootPlay.helpChild=true;
					chosen=true;
					
				}
						}
					}
					
					if(VillageMemory.dreamVisit==1)
					{
						if(InteractionScript.lightHouseGate)
						{
							GUI.Label (actionNode1a,"Burn the Tree",env);
							if(actionNode1a.Contains(Event.current.mousePosition))
						{
					GUI.DrawTexture (actionNode1a,fairyDust);
						LostSoldier.burn=true;
						chosen=true;
					
						}
						}
					}
				}
				
	
				
				
				if(DreamTracker.dream==2)		//FaceWar
				{
					if(!FaceWarScript.sheep && !FaceWarScript.skull && !FaceWarScript.soldier && !FaceWarScript.gun)
					{
						GUI.Label (actionNode1a,"Eyes of The Dead",env);
						GUI.Label (actionNode11a,"Eyes of The Damned",env);
						GUI.Label (actionNode12a,"Eyes of The Tainted",env);
						GUI.Label (actionNode13a,"Eyes of The Lost",env);
					if(actionNode1a.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1a,fairyDust);
				transform.LookAt (player.GetComponent<FaceWarScript>().skullCam.transform);
					transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);	
					FaceWarScript.skull=true;
					
				}
						if(actionNode11a.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode11a,fairyDust);
					transform.LookAt (player.GetComponent<FaceWarScript>().sheepCam.transform);
					transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);	
								FaceWarScript.sheep=true;
					
					
				}
						if(actionNode12a.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode12a,fairyDust);
					transform.LookAt (player.GetComponent<FaceWarScript>().gunCam.transform);
					transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);	
						FaceWarScript.gun=true;
					
				}
						if(actionNode13a.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode13a,fairyDust);
					transform.LookAt (player.GetComponent<FaceWarScript>().soldierCam.transform);
					transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);	
						FaceWarScript.soldier=true;
					
				}
				}
					
					if(FaceWarScript.skull)
					{
						GUI.Label (actionNode11a,"Eyes of The Observer",env);
						GUI.Label (actionNode12a,"Call out to the Children",env);
						
						if(actionNode11a.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode11a,fairyDust);	
					FaceWarScript.skull=false;
					
				}
						if(actionNode12a.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode12a,fairyDust);	
					FaceWarScript.skull=false;
					
				}
					}
					
					if(FaceWarScript.gun)
					{
						GUI.Label (actionNode1b,"Eyes of The Observer",env);
						
						if(actionNode1b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1b,fairyDust);	
					FaceWarScript.gun=false;
					
				}
					}
					if(FaceWarScript.sheep)
					{
						GUI.Label (actionNode1b,"Eyes of The Observer",env);
						
						if(actionNode1b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1b,fairyDust);	
					FaceWarScript.sheep=false;
					
				}
					}
					if(FaceWarScript.soldier)
					{
						GUI.Label (actionNode1b,"Eyes of The Observer",env);
						
						if(actionNode1b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1b,fairyDust);	
					FaceWarScript.soldier=false;
					
				}
					}
					
					
					
					
					
					
				}
				
				if(DreamTracker.dream==7)
				{
					GUI.Label (actionNode1a,"Dream About...",env);
					if(actionNode1a.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1a,fairyDust);
				GUI.Label (actionNode1a,"Dream About...",env);
					active=1;
					activeNode=11;
					
				}
					
				}
			
			}
				if(actionNode1timer>0.55f)
			{
				if(DreamTracker.dream==1)
				{
					if(VillageMemory.dreamVisit==0)
					{
						if(!ShootPlay.throwGun)
						{
						if(InteractionScript.casket)
						{
							GUI.Label (actionNode1b,"Throw Gun Away",env);
							if(actionNode1b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1b,fairyDust);
								chosen=true;
					ShootPlay.throwGun=true;
					
				}
						}
						}
					}
				}
				if(DreamTracker.dream==7)
				{
				GUI.Label (actionNode1b,"A Glimpse of The Outside",env);
					if(actionNode1b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1b,fairyDust);
				GUI.Label (actionNode1b,"A Glimpse of The Outside",env);
					active=1;
					activeNode=12;
					
				}
				}
				
			}
			
	
				if(actionNode1timer>0.85f)
			{
					
				GUI.Label (actionNode1c,"Lights",env);
				if(actionNode1c.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1c,fairyDust);
					
					
				GUI.Label (actionNode1c,"Lights",env);
						
					active=1;
					activeNode=13;		//put non-unique environment alterable bools here
					
				}	
			}
				if(actionNode1timer>0.95f)
			{
				if(DreamTracker.dream==7)
				{
				if(RazeScript.allow)
			{
				GUI.Label (actionNode1d,"Grow Up",env);
				if(actionNode1d.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode1d,fairyDust);
			
				GUI.Label (actionNode1d,"Grow Up",env);
					active=1;
					activeNode=14;
			}
				
				}
			}
			}
			
			if(actionNode2timer>0.05f)
			{
				if(DreamTracker.dream==2)
				{
					if(FaceWarScript.skull)
					{
						
					}
					
				}
				if(DreamTracker.dream==4)
				{
					GUI.Label (actionNode2d,"Feel Optimistic",abs);
					
				if(actionNode2d.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode2d,fairyDust);
					GUI.Label (actionNode2d,"Feel Optimistic",abs);
						CloudDream.moveFast=true;
						chosen=true;
						
				}
					
					
					
				}
				
				
				
				else
				{

				GUI.Label (actionNode2d,"Feel Angry",abs);
				if(actionNode2d.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode2d,fairyDust);
				GUI.Label (actionNode2d,"Feel Angry",abs);
					active=2;
					activeNode=24;
					emotion=4;
					EmotionScript.emotion=4;
					EmotionScript.once=true;
				}
				}
			}
		
			if(actionNode2timer>0.65f)
			{
				if(DreamTracker.dream==2)
				{
					
				}
				if(DreamTracker.dream==4)
				{
					GUI.Label (actionNode2b,"Feel Pessimistic",abs);
					if(actionNode2b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode2b,fairyDust);
					GUI.Label (actionNode2b,"Feel Pessimistic",abs);
						CloudDream.moveSlow=true;
						chosen=true;
				}
				}
				else
				{

				GUI.Label (actionNode2b,"Feel Sad",abs);
					if(actionNode2b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode2b,fairyDust);
				GUI.Label (actionNode2b,"Feel Sad",abs);
					active=2;
					activeNode=22;
					EmotionScript.emotion=2;
					EmotionScript.once=true;
				}
				}
			}
			if(actionNode2timer>0.85f)
			{
				if(DreamTracker.dream==2)
				{
					
				}
				else
				{

				GUI.Label (actionNode2c,"Feel Happy",abs);	
				if(actionNode2c.Contains(Event.current.mousePosition))
				{
				
					GUI.DrawTexture (actionNode2c,fairyDust);
				GUI.Label (actionNode2c,"Feel Happy",abs);	
					active=2;
					activeNode=23;
					EmotionScript.emotion=3;
					EmotionScript.once=true;
				}
				}
			
				
			}
			if(actionNode2timer>0.95f)
			{
				if(DreamTracker.dream==2)
				{
					
				}
				else
				{

				GUI.Label (actionNode2a,"Introspect",abs);
				if(actionNode2a.Contains (Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode2a,fairyDust);
				GUI.Label (actionNode2a,"Introspect",abs);
					active=2;
					activeNode=21;
					emotion=1;
					EmotionScript.emotion=1;
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
				
				if(DreamTracker.dream==1)
				{
					if(VillageMemory.dreamVisit==1)
					{
					if(InteractionScript.casket)
					{
						GUI.Label (actionNode3a,"The Orphaned",people);
					}
					if(InteractionScript.artist)
					{
						GUI.Label (actionNode3b,"The Lost",people);
					}
					}
					if(VillageMemory.dreamVisit==2)
					{
					if(family)
					{
						GUI.Label (actionNode3a,"Beloved",people);
					}
					if(armyBoss)
					{
						GUI.Label (actionNode3b,"Sergeant",people);
					}
					}
				}
				
				if(DreamTracker.dream==7)
				{
					if(armyBoss)
					{
						GUI.Label (actionNode3b,"Father",people);
					}
				}

				
			
				if(actionNode3a.Contains (Event.current.mousePosition))
				{
					
					
					if(family)
					{
						GUI.DrawTexture (actionNode3a,fairyDust);
						GUI.Label (actionNode3a,"Beloved",people);
							activeNode=31;
					}
					
					if(InteractionScript.casket)
					{
						GUI.DrawTexture (actionNode3a,fairyDust);
						GUI.Label (actionNode3a,"The Orphaned",people);
							activeNode=31;
					}
						
					
				}
			
					
				}
				
			
				
				if(actionNode3b.Contains (Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode3b,fairyDust);
					if(DreamTracker.dream==1)
				{
					if(VillageMemory.dreamVisit==2)
					{
					if(armyBoss)
						{
							GUI.DrawTexture (actionNode3b,fairyDust);
						GUI.Label (actionNode3b,"Sergeant",people);
							activeNode=32;
						}
						
						if(InteractionScript.artist)
						{
							GUI.DrawTexture (actionNode3b,fairyDust);
						GUI.Label (actionNode3b,"The Lost",people);
							activeNode=32;
						}
					}
				}
				
				if(DreamTracker.dream==7)
				{
					if(armyBoss)
						{
//						Debug.Log("YO!");
							GUI.DrawTexture (actionNode3b,fairyDust);
						GUI.Label (actionNode3b,"Father",people);
							activeNode=32;
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
				if(actionNode4timer>=0.25f)
				{
					if(DreamTracker.dream==1)
					{
						if(VillageMemory.dreamVisit==0)
						{
						GUI.Label (actionNode4a,"I want to protect my loved ones",self);
						GUI.Label (actionNode4b,"It's my moral duty to serve country",self);
						GUI.Label (actionNode4c,"This feeling...will pass",self);
						}
						if(VillageMemory.dreamVisit==1)
						{
						GUI.Label (actionNode4a,"I merely wanted to help..",self);
						GUI.Label (actionNode4b,"Am I the cause of their torment?",self);
						GUI.Label (actionNode4c,"These children....",self);
						}
						if(VillageMemory.dreamVisit==2)
						{
						GUI.Label (actionNode4a,"I am helping them",self);
						GUI.Label (actionNode4b,"It's a necessary evil",self);
						GUI.Label (actionNode4c,"A greater good is being achieved",self);
						}
						
					}
				}
				
				if(actionNode4timer<=1.25f)
				{
				bg4=new Rect(0f,screenHeight+50f-(300f*actionNode4timer),screenWidth-50f+(480f*actionNode4timer),screenHeight-50f+(350f*actionNode4timer));
				actionNode4timer+=Time.deltaTime;
				}
				GUI.DrawTexture (bg4,goldback);
				
		
			}
			
			if(actionNode4timer>=0f && active!=4)
			{
				actionNode4timer-=Time.deltaTime;
				bg4=new Rect(0f,screenHeight+50f-(300f*actionNode4timer),screenWidth-50f+(480f*actionNode4timer),screenHeight-50f+(350f*actionNode4timer));
				GUI.DrawTexture (bg4,goldback);
			}
			
				
			
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
				
				if(DreamTracker.dream==2)		//FaceWar
				{
					if(!FaceWarScript.sheep || !FaceWarScript.skull || !FaceWarScript.soldier || !FaceWarScript.gun)
					{
						
					}
				}
				
				
				if(DreamTracker.dream==7)		//Raze 
				{
					if(InteractionScript.bull) //Rocket
					{
					if(RazeScript.rocketAllow)
						{
						fairyRed=true;
					GUI.Label (actionNode11a,"Being an Astronaut",env);
						if(actionNode11a.Contains(Event.current.mousePosition))
						{	
								chosen=true;
						GUI.DrawTexture (actionNode11a,fairyDust);
						GUI.Label (actionNode11a,"Being an Astronaut",env);
						InteractionScript.active=InteractionScript.bullActive;
								RazeScript.dreamCount++;
								
							armyBossActive.transform.parent.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="You can dream of the space,dear";
							BlankDialogue.talk=true;
							transform.LookAt (armyBossActive.transform);						
						 transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);	
							RazeScript.rocketAllow=false;
						}
						}
						
					}
					if(InteractionScript.mirrorSelf)
					{
						if(RazeScript.bookAllow)
						{
						fairyRed=true;
					GUI.Label (actionNode12a,"Being an Author",env);
						if(actionNode12a.Contains(Event.current.mousePosition))
						{	
								chosen=true;
						GUI.DrawTexture (actionNode12a ,fairyDust);
						GUI.Label (actionNode11a,"Being an Author",env);
								RazeScript.dreamCount++;
								
								armyBossActive.transform.parent.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="Your words will make you famous one day,my dear";
							BlankDialogue.talk=true;
								transform.LookAt (armyBossActive.transform);						
						 transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
								
						InteractionScript.active=InteractionScript.mirrorSelfActive;
								RazeScript.bookAllow=false;
						}
						}
					}
					if(InteractionScript.billboard)
					{
							if(RazeScript.artistAllow)
						{
						fairyRed=true;
					GUI.Label (actionNode13a,"Being an Artist",env);
						if(actionNode13a.Contains(Event.current.mousePosition))
						{	
								chosen=true;
						GUI.DrawTexture (actionNode13a,fairyDust);
						GUI.Label (actionNode11a,"Being an Artist",env);
								RazeScript.dreamCount++;
								
							armyBossActive.transform.parent.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="Your works shall bring color in people's lives";
							BlankDialogue.talk=true;
								transform.LookAt (armyBossActive.transform);						
						 transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
								
						InteractionScript.active=InteractionScript.billActive;
								RazeScript.artistAllow=false;
						}
							}
					}
				}
			}
			
			if(activeNode==12 && active==1)
			{
				if(DreamTracker.dream==7)
				{
					chosen=true;
					transform.LookAt(GetComponent<RazeScript>().window.transform);
						
				}
			
			
			}
			
			if(activeNode==13 && active==1)
			{
				GUI.Label (actionNode13a,"Bright",env);
				GUI.Label (actionNode13aonb,"Medium",env);
				GUI.Label (actionNode13b,"Dark",env);
				
				if(actionNode13a.Contains(Event.current.mousePosition))
				{
					chosen=true;
				GUI.DrawTexture (actionNode13a,fairyDust);		
				GUI.Label (actionNode13a,"Bright",env);
					Player.ambientLight=0;
				}
				if(actionNode13aonb.Contains(Event.current.mousePosition))
				{
					
					GUI.DrawTexture (actionNode13aonb,fairyDust);		
				GUI.Label (actionNode13aonb,"Medium",env);
					Player.ambientLight=1;
					chosen=true;
				}
				
				if(actionNode13b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode13b,fairyDust);		
					GUI.Label (actionNode13b,"Dark",env);
					Player.ambientLight=2;
					chosen=true;
				}
			}
			
			if(activeNode==14 && active==1)
			{
				RazeScript.blow=true;
				chosen=true;
			}
			
			if(activeNode==31 && active==3)
			{
			
				if(DreamTracker.dream==1)
				{
					if(VillageMemory.dreamVisit==1)
					{
						if(InteractionScript.casket)
						{
						transform.parent.LookAt (InteractionScript.casketActive.transform);
						transform.parent.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					GUI.Label (actionNode31,"Console",people);
					GUI.Label(actionNode32,"Ask",people);
							
							if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label (actionNode31,"Console",people);
						InteractionScript.casketActive.transform.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="But will I ever see them again?";
							BlankDialogue.talk=true;
							chosen=true;

						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);		
						GUI.Label(actionNode32,"Ask",people);
						InteractionScript.casketActive.transform.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="The fire took them away";
							BlankDialogue.talk=true;
							chosen=true;
				}
							
						}
					}
					
					if(VillageMemory.dreamVisit==2)
					{
				
							if(family)
				{
					transform.parent.LookAt (familyActive.transform);
						transform.parent.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					GUI.Label (actionNode31,"Talk",people);
					GUI.Label(actionNode32,"Reassure",people);
						
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label (actionNode31,"Talk",people);
						familyActive.transform.parent.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="I will pray for your safe return";
							BlankDialogue.talk=true;
							chosen=true;

						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);		
						GUI.Label(actionNode32,"Reassure",people);
						familyActive.transform.parent.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="I won't change either";
							BlankDialogue.talk=true;
							chosen=true;
				}
					
				}
				}
				}
				
			}
			
			
			if(activeNode==32 && active==3)
			{
				if(DreamTracker.dream==1)
				{
					if(VillageMemory.dreamVisit==1)
					{
						if(InteractionScript.artist)
						{
						transform.parent.LookAt (InteractionScript.artistActive.transform);
						transform.parent.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					GUI.Label (actionNode31,"Reassure",people);
					GUI.Label(actionNode32,"Ask",people);
							
							if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label (actionNode31,"Reassure",people);
						InteractionScript.artistActive.transform.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="Things will never be the same";
							BlankDialogue.talk=true;
							chosen=true;

						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);		
						GUI.Label(actionNode32,"Ask",people);
						InteractionScript.artistActive.transform.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="You took away our dreams";
							BlankDialogue.talk=true;
							chosen=true;
				}
							
						}
					}
					if(VillageMemory.dreamVisit==2)
					{
				
							if(armyBoss)
				{
					transform.parent.LookAt (armyBossActive.transform);
						transform.parent.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
					GUI.Label (actionNode31,"Talk",people);
					GUI.Label(actionNode32,"Ask",people);
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label (actionNode31,"Talk",people);
						armyBossActive.transform.parent.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="Just follow your orders";
							BlankDialogue.talk=true;
							chosen=true;

						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);		
						GUI.Label(actionNode32,"Ask",people);
						armyBossActive.transform.parent.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="Because they need our help to solve their problems";
							BlankDialogue.talk=true;
							chosen=true;
				}
					
				}
				}
				}
					
					if(DreamTracker.dream==7)
				{
				
							if(armyBoss)
				{
					transform.LookAt (armyBossActive.transform);
						transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
						if(RazeScript.blow)
						{
							GUI.Label(actionNode31,"Ask",people);
							
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
								dialogueChoice=1;
				}
				if(dialogueChoice==1)
							{
								GUI.Label(actionNode32,"Dream of an Author",people);
								GUI.Label(actionNode33,"Dream of an Astronaut",people);
								GUI.Label(actionNode34,"Dream of an Artist",people);
						if(actionNode32.Contains(Event.current.mousePosition))
						{	
		
						GUI.DrawTexture (actionNode32,fairyDust);		
						armyBossActive.transform.parent.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="You have real responsibilities in society than some fancy writing ambition";
							BlankDialogue.talk=true;
							chosen=true;
						}
								if(actionNode33.Contains(Event.current.mousePosition))
						{	
		
						GUI.DrawTexture (actionNode33,fairyDust);		
						armyBossActive.transform.parent.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="Silly dreams are for kids, you have grown up now";
							BlankDialogue.talk=true;
							chosen=true;
						}
								if(actionNode34.Contains(Event.current.mousePosition))
						{	
		
						GUI.DrawTexture (actionNode34,fairyDust);		
						armyBossActive.transform.parent.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="Don't be so naive. What will They say?";
							BlankDialogue.talk=true;
							chosen=true;
						}
					}
					}
						else
						{
					GUI.Label(actionNode31,"Ask",people);
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);		
						GUI.Label (actionNode31,"Ask",people);
						armyBossActive.transform.parent.FindChild ("Dialogue").GetComponent<BlankDialogue>().dialogue.text="You can dream to be anything you wish";
							BlankDialogue.talk=true;
							chosen=true;

					}
				}
					
				}
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
					GUI.Label (actionNode31,"Talk",people);
					GUI.Label(actionNode32,"Ask",people);
					
				if(actionNode31.Contains(Event.current.mousePosition))
				{	
		
						GUI.DrawTexture (actionNode31,fairyDust);	
						GUI.Label (actionNode31,"Talk",people);
						peopleChoice=8;
						dialogueOnce=true; justOnce=true;
						
				}
					
					if(actionNode32.Contains(Event.current.mousePosition))
				{
			
						GUI.DrawTexture (actionNode32,fairyDust);	
						GUI.Label(actionNode32,"Ask",people);
						peopleChoice=9;
						dialogueOnce=true; justOnce=true;
				}
					
				
				
				}
				
				//Glass Case
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
		/*			if(actionNode33.Contains(Event.current.mousePosition))
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
		/*			if(actionNode33.Contains(Event.current.mousePosition))
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
			GUI.Label (tex3,"Abstract",style);
			
			//Debug.Log (InteractionScript.active);
		}
		else
		{
			if(!PenaltyScript.bombAffected && PenaltyScript.randChoice!=1)
		//	((DepthOfFieldScatter)gameObject.GetComponent<DepthOfFieldScatter>()).enabled=false;
			Time.timeScale=1f;
			if(mo!=null)
			mo.enabled=true;
			
			
			
				//transform.rotation=Quaternion.identity;

			
			
			*/

			
			((DepthOfFieldScatter)gameObject.GetComponent<DepthOfFieldScatter>()).enabled=false;
			Time.timeScale=1f;
			if(mo!=null)
			mo.enabled=true;
			Screen.showCursor=false;
			if(DreamTracker.dream!=2)	// DISALLOWED FOR SPECIFIC DREAMS
			{
			if(!DialogueSupervisor.talk)
			{
			if(GetComponent<MouseLook>()!=null)
			GetComponent<MouseLook>().enabled=true;
			}
			}
		}
	}
	
/*	void OnConversationStart()
	{
		Debug.Log ("OFF");
		gameObject.GetComponent<DreamWheel>().enabled=false;
	}
	
	void OnConversationEnd()
	{
		Debug.Log ("ON");
		gameObject.GetComponent<DreamWheel>().enabled=true;
	}*/
}
