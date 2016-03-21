using UnityEngine;
using System.Collections;

public class TutWheel : MonoBehaviour {
	public Texture red;
	public Texture grey;
	public Texture blue;
	public Texture gold;
	
	
	public static int ambientLight=3;
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
	private Rect tex1;
	private Rect tex2;
	private Rect tex3;
	private Rect tex4;
	private Rect bg0;
	private Rect bg1;
	private Rect bg2;
	private Rect bg3;
	private Rect bg4;
	private float actionNode1timer=0f;
	private float actionNode2timer=0f;
	private float actionNode3timer=0f;
	private float actionNode4timer=0f;
	private Rect actionNode1a;
	private Rect actionNode11a;
	private Rect actionNode12a;
	private Rect actionNode13a;
	private Rect actionNode14a;
	private float actionNode1atimer=0f;
	private Rect actionNode1b;
	private Rect actionNode11b;
	private Rect actionNode12b;
	private Rect actionNode13b;
	private Rect actionNode13aonb;
	private Rect actionNode14b;

	private float actionNode1btimer=0f;
	private Rect actionNode1c;
	private float actionNode1ctimer=0f;
	private Rect actionNode1d;
	private float actionNode1dtimer=0f;
	
	private Rect actionNode2a;
	private Rect actionNode2b;
	private Rect actionNode2c;
	private Rect actionNode2d;

	
	
	private Rect actionNode3a;
	private Rect actionNode3b;
	private Rect actionNode3c;
	private Rect actionNode3d;
	private Rect actionNode3d2;
	private Rect actionNode3d3;
	private Rect actionNode3e;
	private Rect actionNode31;
	private Rect actionNode32;
	private Rect actionNode33;
	private Rect actionNode34;
	
	private Rect actionNode3f;
	private Rect actionNode3f2;
	private Rect actionNode3f3;
	
	
	private Rect actionNode3g;
	private Rect actionNode3g2;
	private Rect actionNode3g3;
	
	private int thoughtChoice=0;
	
	private Rect actionNode4a;
	private Rect actionNode4a1;
	private Rect actionNode4a2;
	
	
	private Rect actionNode4b;
	private Rect actionNode4b1;
	private Rect actionNode4b2;
	private Rect actionNode4c;
	private Rect actionNode4c1;
	private Rect actionNode4c2;
	private Rect actionNode4d;
	private Rect actionNode4d1;
	private Rect actionNode4d2;
	
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
	public static int emotion=1;
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
	
	//Civilian
	public static bool activeCiv=false;
	public static GameObject civilian;
	public static bool angryCiv=false;
	public static bool happyCiv=false;
	public static bool sadCiv=false;

	
	
	//statue 
	public static bool activeStatue=false;
	public static GameObject statue;
	public static bool angryStatue=false;
	public static bool happyStatue=false;
	public static bool sadStatue=false;
	
	
	public GameObject civDialogue;
	
	public GameObject angryDialogue;
	public GameObject sadDialogue;
	public GameObject happyDialogue;
	
	//talking grave
	public static bool activeGrave=false;
	public static GameObject grave;

	
	//public Transform screen;
	private float giveUpTimer=0f;
	
	public static bool chestActive=false;
	public static GameObject chest;
	
	public static bool keyActive=false;
	public static GameObject keyNear;
	
	public static bool openChest=false;
	
	
	public GameObject sadGroup;
	public GameObject happyGroup;
	public GameObject angryGroup;
	
	private bool treeSee=false;
	public static bool deadOak=false;
	public static bool otherside=false;
	
	private float treeTimer=0f;
	
	public GameObject treeCam;
	public GameObject treeDead;
	
	private float civTimer=0f;
	public GameObject oceanCam;

	// Use this for initialization
	void Start () {
		
		
		sadDialogue.GetComponent<TextMesh>().text="";
		happyDialogue.GetComponent<TextMesh>().text="";
		angryDialogue.GetComponent<TextMesh>().text="";
		
		
		treeCam.camera.enabled=false;
		treeDead.SetActive (false);
		
		float[] distances = new float[32];
        distances[10] = 13;
		distances[15] = 10;
        gameObject.camera.layerCullDistances = distances;
		
		screenWidth=Screen.width/2f;
		screenHeight=Screen.height/2f;
		player=GameObject.FindGameObjectWithTag ("Player");
		mo=gameObject.GetComponent<MouseLook>();
		bg0=new Rect(screenWidth-50f,screenHeight,50f,50f);
		
		
		angryGroup.SetActive (false);
		happyGroup.SetActive (false);
		sadGroup.SetActive (true);
		
		
		//bg1=new Rect(0f,0f,screenWidth-50f,screenHeight-50f);
		actionNode1d=new Rect(screenWidth+250f,screenHeight+200f,80f,40f);
		actionNode1c=new Rect(screenWidth-250f,screenHeight+200f,80f,40f);
		actionNode1b=new Rect(screenWidth+200f,screenHeight-250f,80f,40f);
		actionNode1a=new Rect(screenWidth-400f,screenHeight-150f,80f,40f);
		//For 1a -- Alter
		actionNode11a=new Rect(screenWidth-300f,screenHeight-50f,100f,40f);
		actionNode12a=new Rect(screenWidth-300f,screenHeight,100f,40f);
		actionNode13a=new Rect(screenWidth-500f,screenHeight+100f,100f,40f);
		actionNode13aonb=new Rect(screenWidth-500f,screenHeight+150f,100f,40f);
		actionNode13b=new Rect(screenWidth-500f,screenHeight+200f,100f,40f);
		actionNode14a=new Rect(screenWidth-300f,screenHeight+100f,100f,40f);
		
		//For 1b--Create
		actionNode11b=new Rect(screenWidth+150f,screenHeight-200f,100f,100f);
		actionNode12b=new Rect(screenWidth+350f,screenHeight-200f,30f,30f);
	
		//bg2=new Rect(screenWidth+50f,0f,screenWidth-50f,screenHeight-50f);
		actionNode2a=new Rect(screenWidth-350f,screenHeight+100f,80f,40f);
		actionNode2b=new Rect(screenWidth-250f,screenHeight-230f,80f,40f);
		actionNode2c=new Rect(screenWidth+300f,screenHeight+200f,80f,40f);
		actionNode2d=new Rect(screenWidth+350f,screenHeight-150f,80f,40f);
		
	/*	actionNode2e1=new Rect(screenWidth,screenHeight-300f,80f,40f);
		actionNode2e2=new Rect(screenWidth,screenHeight-275f,80f,40f);
		actionNode2e3=new Rect(screenWidth-50f,screenHeight-250f,80f,40f);
		actionNode2e4=new Rect(screenWidth,screenHeight-225f,80f,40f);
		actionNode2e5=new Rect(screenWidth+50f,screenHeight-200f,80f,40f);
*/				
		//bg3=new Rect(screenWidth+50f,screenHeight+50f,screenWidth-50f,screenHeight-50f);
		actionNode3a=new Rect(screenWidth+250f,screenHeight,80f,40f);
		actionNode3b=new Rect(screenWidth+150f,screenHeight+100f,80f,40f);
		actionNode3c=new Rect(screenWidth+350f,screenHeight+100f,80f,40f);
		actionNode3d=new Rect(screenWidth+250f,screenHeight-150f,80f,40f);
		actionNode3d2=new Rect(screenWidth+200f,screenHeight-100f,80f,40f);
		actionNode3d3=new Rect(screenWidth+350f,screenHeight-100f,80f,40f);
		
		
		actionNode3e=new Rect(screenWidth+150f,screenHeight+150f,80f,40f);
		
		actionNode3f=new Rect(screenWidth,screenHeight,80f,40f);
		actionNode3f2=new Rect(screenWidth+50f,screenHeight+100f,80f,40f);
		actionNode3f3=new Rect(screenWidth-50f,screenHeight+100f,80f,40f);
		
		actionNode3g=new Rect(screenWidth+200f,screenHeight-100f,80f,40f);
		actionNode3g2=new Rect(screenWidth+250f,screenHeight-50f,80f,40f);
		actionNode3g3=new Rect(screenWidth+150f,screenHeight-50f,80f,40f);
		
		actionNode31=new Rect(screenWidth+200f,screenHeight+200f,80f,40f);
		actionNode32=new Rect(screenWidth+300f,screenHeight+200f,80f,40f);
		actionNode33=new Rect(screenWidth+250f,screenHeight+250f,80f,40f);
		actionNode34=new Rect(screenWidth+250f,screenHeight+150f,80f,40f);
		
		//bg4=new Rect(0f,screenHeight+50f,screenWidth-50f,screenHeight-50f);
		actionNode4a=new Rect(screenWidth-350f,screenHeight+100f,250f,40f);
		actionNode4a1=new Rect(screenWidth-350f,screenHeight+150f,250f,40f);
		actionNode4a2=new Rect(screenWidth-350f,screenHeight+200f,250f,40f);
		
		
		actionNode4b=new Rect(screenWidth+150f,screenHeight+50f,150f,40f);
		actionNode4b1=new Rect(screenWidth+150f,screenHeight+100f,150f,40f);
		actionNode4b2=new Rect(screenWidth+150f,screenHeight+150f,150f,40f);
		
		actionNode4c=new Rect(screenWidth+150f,screenHeight-200f,150f,40f);
		actionNode4c1=new Rect(screenWidth+150f,screenHeight-150f,150f,40f);
		actionNode4c2=new Rect(screenWidth+150f,screenHeight-100f,150f,40f);
		
		actionNode4d=new Rect(screenWidth-350f,screenHeight+150f,150f,40f);
		actionNode4d1=new Rect(screenWidth-400f,screenHeight+200f,80f,40f);
		actionNode4d2=new Rect(screenWidth-300f,screenHeight+200f,80f,40f);
		
		tex1=new Rect((screenWidth)-150f,(screenHeight)+50f,100f,100f);
		tex2=new Rect((screenWidth)+50f,(screenHeight)+50f,100f,100f);
		tex3=new Rect((screenWidth)+50f,(screenHeight)-150f,100f,100f);
		tex4=new Rect((screenWidth)-150f,(screenHeight)-150f,100f,100f);
		
		goldSign =new Rect((screenWidth)-150f,(screenHeight)+50f,100f,100f);
		blueSign=new Rect((screenWidth)+50f,(screenHeight)+50f,100f,100f);
		greySign=new Rect((screenWidth)+50f,(screenHeight)-150f,100f,100f);
		redSign=new Rect((screenWidth)-150f,(screenHeight)-150f,100f,100f);
		
		help=new Rect((screenWidth)-50f,(screenHeight)-300f,100f,100f);
		helpGUI=new Rect((screenWidth)+50f,(screenHeight)-250f,100f,100f);
		helpGeneral=new Rect((screenWidth)-150f,(screenHeight)-250f,100f,100f);
		key=new Rect((screenWidth)-50f,(screenHeight)+200f,100f,100f);
		giveUp=new Rect((screenWidth)-50f,(screenHeight)+200f,100f,100f);
		
		
		
	}
	
	void OnDisable()
	{
	//	LoadSave.theObject=gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		Debug.Log (((DepthOfFieldScatter)gameObject.GetComponent<DepthOfFieldScatter>()).enabled);
		//Debug.Log (randThought);
//		Debug.Log (thoughtChoice);
	//Debug.Log (InteractionScript.artist);
	//	Debug.Log (mo);
		
//		Debug.Log (statue);
		
		
		if(deadOak || otherside)
		{
			treeDead.SetActive (true);
		}
		
		if(ambientLight==0)
		{
			RenderSettings.ambientLight=new Color(0.739f,0.7046f,0.7046f);
		}
		
		if(ambientLight==1)
		{
			RenderSettings.ambientLight=new Color(0.326f,0.3262f,0.3262f);
		}
		
		if(ambientLight==2)
		{
			RenderSettings.ambientLight=new Color(0f,0f,0f);
		}
		
		if(ambientLight==3)
		{
			RenderSettings.ambientLight=new Color(0.15f,0.15f,0.15f);
		}
		
		if(treeSee)
		{
			treeCam.camera.enabled=true;
			gameObject.camera.enabled=false;
			
			treeTimer+=Time.deltaTime;
			
			if(treeTimer>3f)
			{
				treeTimer=0f;
				treeSee=false;
			}
		}
		else
		{
			treeCam.camera.enabled=false;
			gameObject.camera.enabled=true;
		}
		
		if(openChest)
		{
			chest.transform.FindChild("Cap").transform.eulerAngles=new Vector3(330.5901f,91.7968f,-88.01086f);
					oceanCam.camera.enabled=true;
			((DepthOfFieldScatter)gameObject.GetComponent<DepthOfFieldScatter>()).enabled=true;
			
		}
	}
	
	void OnGUI()
	{
		Debug.Log (activeCiv);
		if(activeCiv)
		{
			civTimer+=Time.deltaTime;
			if(civTimer<2.5f)
			{
			GUI.Label (new Rect(100f,Screen.height-100f,100f,100f),"This is a THOUGHT sequence. It can be explored and interacted with",style);
			}
			if(civTimer>2.5f && civTimer<5f)
			GUI.Label (new Rect(100f,Screen.height-100f,100f,100f),"A THOUGHT sequence has can have multiple entries and exits that may lead to different THOUGHT sequences",style);
		
			if(civTimer>5f)
				civTimer=0f;
		}
		
		if(Input.GetMouseButton(0))
		{
		
			//Debug.Log (activeNode);
			
			//GUI.DrawTexture (bg0,bg);
			//ray=Camera.main.ViewportPointToRay (Input.mousePosition);
			//if(Physics.Raycast(ray,out hit,10f))
			//{
				
			//}
			Screen.showCursor=true;
			if(!activeCiv)
			((DepthOfFieldScatter)gameObject.GetComponent<DepthOfFieldScatter>()).enabled=true;
			Time.timeScale=0.2f;
			
			mo.enabled=false;

			//transform.LookAt (screen);
			
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
			GUI.DrawTexture (tex4,red);
			
			GUI.DrawTexture (tex3,grey);
			
			GUI.DrawTexture (tex2,blue);
			
			GUI.DrawTexture (tex1,gold);
			
			
				
		/*		GUI.Label(help,"Seek Help",helpStyle);
			
			
			if(help.Contains (Event.current.mousePosition))
			{
				GUI.DrawTexture (help,fairyDust);
					GUI.Label(help,"Seek Help",helpStyle);
				
				activeNode=61;
				active=6;
			
				
				
			}
			
			if(maskHelp)
			{
					player.transform.LookAt (mask.transform);						
						player.transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
			}
			
			*/
			
			if(emotion==2)		//sad
			{
				//play sad music
				sadGroup.SetActive (true);
				happyGroup.SetActive (false);
				angryGroup.SetActive (false);
				
				sadCiv=true;
				happyCiv=false;
				angryCiv=false;
				
			}
			
			if(emotion==3)		//happy
			{
				//play happy music
				happyGroup.SetActive (true);
				sadGroup.SetActive (false);
				angryGroup.SetActive (false);
				
				happyCiv=true;
				angryCiv=false;
				sadCiv=false;
			}
			
			if(emotion==4)		//angry
			{
				//play angry music
				angryGroup.SetActive (true);
				happyGroup.SetActive (false);
				sadGroup.SetActive (false);
				
				angryCiv=true;
				happyCiv=false;
				sadCiv=false;
				
				
			}
			
			
			
			
			
			//key and chest
			
				
			if(chestActive && keyGot)
				{
				GUI.Label (key,"The Dreaded Truth",helpStyle);
				
				if(key.Contains(Event.current.mousePosition))
				{
					transform.LookAt (chest.transform);
					GUI.DrawTexture (key,fairyDust);
					openChest=true;
					
				}
				}
			
			if(keyActive && !keyGot)
			{
				GUI.Label (key,"Pick Up Key",helpStyle);
				
				if(key.Contains (Event.current.mousePosition))
			{
					transform.LookAt (keyNear.transform);
					GUI.DrawTexture (key,fairyDust);
					GUI.Label (key,"Pick Up Key",helpStyle);
			
				keyGot=true;
				keyNear.transform.parent.gameObject.renderer.enabled=false;
				
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
				bg1=new Rect(0f,0f,screenWidth-50f+(480f*actionNode1timer),screenHeight-50f+(300f*actionNode1timer));
				actionNode1timer+=Time.deltaTime;
				}
				
				GUI.DrawTexture (bg1,redback);
				
				
				TutorialScript.envYes=true;
			
				
				//GUI.DrawTexture (actionNode1d,node);
				
			}
				
			if(actionNode1timer>=0f && active!=1)
			{
				actionNode1timer-=Time.deltaTime;
				bg1=new Rect(0f,0f,screenWidth-50f+(480f*actionNode1timer),screenHeight-50f+(300f*actionNode1timer));
				GUI.DrawTexture (bg1,redback);
				
			}
			if(actionNode1timer>0.05f)
			{
				
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
				if(emotion==4)
				{
					GUI.Label (actionNode2d,"You Are Angry",abs);
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

				}
				}
			}
		
			if(actionNode2timer>0.65f)
			{
				if(emotion==2)
				{
					GUI.Label (actionNode2d,"You Are Sad",abs);
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

				}
				}
			}
			if(actionNode2timer>0.85f)
			{
				if(emotion==3)
				{
					GUI.Label (actionNode2d,"You Are Happy",abs);
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

				}
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
					ambientLight=0;
				}
				if(actionNode13aonb.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode13aonb,fairyDust);		
				GUI.Label (actionNode13aonb,"Medium",env);
					ambientLight=1;
				}
				
				if(actionNode13b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode13b,fairyDust);		
					GUI.Label (actionNode13b,"Dark",env);
					ambientLight=2;
				}
			}
			
		
			
			if(activeNode==22&& active==2)		//Feel Sad
			{
				RenderSettings.ambientLight=new Color(0.166f,0.1662f,0.1762f);
				emotion=2;
			}
			
			if(activeNode==23 && active==2)		//happy
			{
				RenderSettings.ambientLight=new Color(0.7f,0.7f,0.7f);
				emotion=3;
			}
			
			
			if(activeNode==24 && active==2) //angry
			{
				RenderSettings.ambientLight=new Color(1f,0f,0f);
				emotion=4;
			}
			
			
					if(active==3)
			{
				
				
				if(actionNode3timer<=1.25f)
				{
				bg3=new Rect(screenWidth+50f-(480f*actionNode3timer),screenHeight+50f-(300f*actionNode3timer),screenWidth-50f+(480f*actionNode3timer),screenHeight-50f+(300f*actionNode3timer));
				actionNode3timer+=Time.deltaTime;
				}
				GUI.DrawTexture (bg3,blueback);
				active=3;
			
			}
			if(actionNode3timer>=0.5f)
			{		
				if(activeCiv)
				{
					GUI.Label(actionNode3a,"Someone",people);
					if(actionNode3a.Contains (Event.current.mousePosition))
					{
					transform.LookAt(civilian.transform);
		//			transform.eulerAngles=new Vector3(0,civilian.transform.eulerAngles.y,0);
						GUI.DrawTexture (actionNode3a,fairyDust);		
					activeNode=31;
					}
				}
				
				if(activeStatue)
				{
					if(emotion==2)
						{
							GUI.Label(actionNode3a,"Weeping Man",people);
						transform.LookAt(sadDialogue.transform);
					transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
						}
						if(emotion==3)
						{
							transform.LookAt(happyDialogue.transform);
					transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
							GUI.Label(actionNode3a,"Statue of Comfort",people);
						}
						if(emotion==4)
						{
							transform.LookAt(angryDialogue.transform);
					transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
							GUI.Label(actionNode3a,"Guardian of Hate",people);
						}
					if(actionNode3a.Contains (Event.current.mousePosition))
					{
						GUI.DrawTexture (actionNode3a,fairyDust);		
					activeNode=32;
					}
				}	
			
			}
			
			
		/*		if(activeGrave)
				{
					if(actionNode31.Contains (Event.current.mousePosition))
					{
					GUI.Label(actionNode3a,"Grave",people);
					activeNode=33;
					}
				}
		*/
		
			
			
			if(actionNode3timer>=0f && active!=3)
			{
				actionNode3timer-=Time.deltaTime;
				bg3=new Rect(screenWidth+50f-(480f*actionNode3timer),screenHeight+50f-(300f*actionNode3timer),screenWidth-50f+(480f*actionNode3timer),screenHeight-50f+(300f*actionNode3timer));
				GUI.DrawTexture (bg3,blueback);
			}
			
			
/*			if(activeNode==33 && active==3)
			{
					fairyBlue=true;
					GUI.Label (actionNode3a,"Grave",people);
					GUI.Label (actionNode3b,"Talk",people);
					GUI.Label (actionNode3c,"Ask",people);
				
				if(actionNode3b.Contains(Event.current.mousePosition))
				{
					peopleChoice=1;
				}
				
				if(actionNode3c.Contains(Event.current.mousePosition))
				{
					peopleChoice=2;
				}
					
			}*/
				
			if(activeNode==31 && active==3)
			{
					fairyBlue=true;
					GUI.Label (actionNode3a,"Someone",people);
					GUI.Label (actionNode3b,"Talk",people);
					GUI.Label (actionNode3c,"Ask",people);
				
				if(actionNode3b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode3b,fairyDust);		
					peopleChoice=1;
				}
				
				if(actionNode3c.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode3c,fairyDust);		
					peopleChoice=2;
				}
					
			}
			
			if(activeNode==32 && active==3)
			{
					fairyBlue=true;
					GUI.Label (actionNode3b,"Talk",people);
					GUI.Label (actionNode3c,"Ask",people);
					
				if(actionNode3b.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode3b,fairyDust);		
					peopleChoice=1;
				}
				
				if(actionNode3c.Contains(Event.current.mousePosition))
				{
					GUI.DrawTexture (actionNode3c,fairyDust);		
					peopleChoice=2;
				}
			}
			
			if(peopleChoice==1)
			{
				if(angryCiv)
				{
					civDialogue.GetComponent<TextMesh>().text="Your hate the warmth of comfort";
				}
				if(happyCiv)
				{
					civDialogue.GetComponent<TextMesh>().text="What one seeks is never far from the warmth of the fire";
				}
				if(sadCiv)
				{
					civDialogue.GetComponent<TextMesh>().text="You were happy once before you stepped away from it";
				}
				
				if(angryStatue)
				{
					angryDialogue.GetComponent<TextMesh>().text="It lies in the shadow of your dead memories";
					otherside=true;
				}
				if(happyStatue)
				{
					happyDialogue.GetComponent<TextMesh>().text="You didn't venture far from the warmth";
					otherside=true;
				}	
				if(sadStatue)
				{
					sadDialogue.GetComponent<TextMesh>().text="You stepped into the darkness, away from the fire";
					otherside=true;
				}
				
		/*		if(angryGrave)
				{
					grave.transform.parent.FindChild ("DialogueText").gameObject.GetComponent<TextMesh>().text="But where should we point our fingers?";
				}
				if(happyGrave)
				{
					grave.transform.parent.FindChild ("DialogueText").gameObject.GetComponent<TextMesh>().text="But where should we point our fingers?";
				}
				if(sadGrave)
				{
					grave.transform.parent.FindChild ("DialogueText").gameObject.GetComponent<TextMesh>().text="But where should we point our fingers?";
				}
				*/
			}
			
				if(peopleChoice==2)
			{
				if(angryCiv)
				{
					civDialogue.GetComponent<TextMesh>().text="But where should we point our fingers?";
				}
				if(happyCiv)
				{
					civDialogue.GetComponent<TextMesh>().text="But where should we point our fingers?";
				}
				if(sadCiv)
				{
					civDialogue.GetComponent<TextMesh>().text="But where should we point our fingers?";
				}
				
				if(angryStatue)
				{
					angryDialogue.GetComponent<TextMesh>().text="But where should we point our fingers?";
				}
				if(happyStatue)
				{
					happyDialogue.GetComponent<TextMesh>().text="But where should we point our fingers?";
				}	
				if(sadStatue)
				{
					sadDialogue.GetComponent<TextMesh>().text="But where should we point our fingers?";
				}
				
		/*		if(angryGrave)
				{
					grave.transform.parent.FindChild ("DialogueText").gameObject.GetComponent<TextMesh>().text="But where should we point our fingers?";
				}
				if(happyGrave)
				{
					grave.transform.parent.FindChild ("DialogueText").gameObject.GetComponent<TextMesh>().text="But where should we point our fingers?";
				}
				if(sadGrave)
				{
					grave.transform.parent.FindChild ("DialogueText").gameObject.GetComponent<TextMesh>().text="But where should we point our fingers?";
				}
				*/
			}
			
				
				
						
			
			if(active==2)
			{
				
				if(actionNode2timer<=1.25f)
				{
				bg2=new Rect(screenWidth+50f-(480f*actionNode2timer),0f,screenWidth-50f+(480f*actionNode2timer),screenHeight-50f+(300f*actionNode2timer));
				actionNode2timer+=Time.deltaTime;
				}
				GUI.DrawTexture (bg2,greyback);
				if(TutorialScript.envYes)
				TutorialScript.absYes=true;
				
			}
			
			
			if(actionNode2timer>=0f && active!=2)
			{
				actionNode2timer-=Time.deltaTime;
				bg2=new Rect(screenWidth+50f-(480f*actionNode2timer),0f,screenWidth-50f+(480f*actionNode2timer),screenHeight-50f+(300f*actionNode2timer));
				GUI.DrawTexture (bg2,greyback);
			}
			
			
			
	
			
			if(active==4)
			{
				
				if(actionNode4timer<=1.25f)
				{
				bg4=new Rect(0f,screenHeight+50f-(300f*actionNode4timer),screenWidth-50f+(480f*actionNode4timer),screenHeight-50f+(300f*actionNode4timer));
				actionNode4timer+=Time.deltaTime;
				}
				GUI.DrawTexture (bg4,goldback);
				if(deadOak)
				{
					GUI.Label (actionNode4a,"All That Remains...",self);
					
					if(actionNode4a.Contains (Event.current.mousePosition))
					{
						GUI.DrawTexture (actionNode4a,fairyDust);		
						treeSee=true;
					}
				}
				else if(otherside)
				{
					GUI.Label (actionNode4a,"Suffocating Freedom",self);
					
					if(actionNode4a.Contains (Event.current.mousePosition))
					{
						GUI.DrawTexture (actionNode4a,fairyDust);		
						treeSee=true;
					}
				}
					
		
			}
			
			
			if(actionNode4timer>=0f && active!=4)
			{
				actionNode4timer-=Time.deltaTime;
				bg4=new Rect(0f,screenHeight+50f-(300f*actionNode4timer),screenWidth-50f+(480f*actionNode4timer),screenHeight-50f+(300f*actionNode4timer));
				GUI.DrawTexture (bg4,goldback);
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
			

			
			
		//	Screen.showCursor=false;
			
			//GetComponent<MouseLook>().enabled=true;
		
		}
		else
		{
			if(!activeCiv)
		((DepthOfFieldScatter)gameObject.GetComponent<DepthOfFieldScatter>()).enabled=false;
			
			Time.timeScale=1f;
			if(mo!=null)
			mo.enabled=true;
			
			if(!reset)
			{
			resetTimer+=Time.deltaTime;
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
					randOnce=true;
					randDialogue=0;
				resetTimer=0f;
				reset=true;
					
					angryCiv=false;
					happyCiv=false;
					sadCiv=false;
					
					angryStatue=false;
					happyStatue=false;
					sadStatue=false;
					
					activeCiv=false;
					activeStatue=false;
					chestActive=false;
			}
			}
		}
	}
}
