using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public GameObject civ;
	public bool once=true;
	//public MouseLook mouseLook;
	private float fix=0f;
	//private CharacterMotor character;
	public static int guessChance=3;
	public Camera cam;
	private Transform bomber;
	private float bombDistance=0f;
	public static int terrainChoose=0;
	public static bool bombOnce=true;
	public static bool hasMoney=true;
	
	public static int ambientLight=0;
	public static bool boatChange=false;
	public static bool getOff=true;
	public GameObject boat;
	public static int playerState=0; // 0 -- on ground, 1 on boat
	private bool resetOnce=true;
	private bool boatOnce=true;
	
	public static bool confront=false;
	private float confrontTimer=0f;
	public static bool shoot=false;
	private float shootTimer=0f;
	
	public static bool throwBag=false;
	private float throwBagTimer=0f;
	
	public static bool giveUp=false;
	public GameObject bloodpool;
	private bool bloodOnce=true;
	private GameObject bag;
	
	public GameObject explosion;
	private bool explodeOnce=true;
	private int explodeCount=0;
	
	public GameObject hazeCam;
	public GameObject blastScene;
	private GameObject currentBlast;
	public static bool doIt=false;
	private bool blastOnce=true;
	private GameObject bombCam;
	
	private bool shootOnce=true;
	private bool confrontOnce=true;
	private bool throwOnce=true;
	public GameObject inter;
	public static bool chestOpen=false;
	private float chestOpenTimer=0f;
	public static bool realChest=false;
	private float realChestTimer=0f;
	private float giveUpTimer=0f;
	private float startTimer=0f;
	public GameObject mask;
	public GameObject permaDiag;
	private GameObject currentDiag;
	
	public static int cracking=0;
	
	
	private bool cityWarn=true;
	private bool desertWarn=true;
	
	
	// Use this for initialization
	void Start () {
		Screen.showCursor=false;
		  float[] distances = new float[32];
        distances[10] = 13;
		distances[15] = 10;
        cam.layerCullDistances = distances;
		//LoadSave.theObject=gameObject;
//		boat.GetComponent<MouseLook>().enabled=false;
	//	boat.GetComponent<CharacterMotor>().canControl=false;
		
	//	targetPos=new Vector3(Random.Range (0f,10f),0f,Random.Range (0f,10f));
	 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
/*		if(InteractCiv.interact)
		{
			var mouseLook=GetComponent<MouseLook>();
		var character=GetComponent<CharacterMotor>();
			if(mouseLook!=null)
			mouseLook.enabled=false;
			civ=InteractCiv.civActive;
			if(character!=null)			
			character.canControl=false;
			transform.LookAt (civ.transform);
		
			if(Input.GetKeyDown(KeyCode.Return))
			{
				
				InteractCiv.interact=false;
				transform.LookAt (new Vector3(0f,transform.position.y,0f));
			}
		}
		
		else
		{
			
		//	mouseLook.enabled=true;
		//	character.canControl=true;
			
			
		}*/
		
	//	StarterScript.ready=true;
		
		
		if(StarterScript.ready)
		{
		if(once)
		{
			
		}
		
			
			if(ResetScript.sceneChoice==0)
		{
			if(cityWarn)
				{
				startTimer+=Time.deltaTime;
				if(startTimer<10f)
				{
						mask.SetActive(true);
					MaskHelp.startWarning=true;
				}
					else
					{
						startTimer=0f;
						cityWarn=false;
					}
				}
			
		}
			
			
			if(ResetScript.sceneChoice==1)
		{
			if(desertWarn)
				{
				startTimer+=Time.deltaTime;
				if(startTimer<7f)
				{
						mask.SetActive(true);
					MaskHelp.startWarning=true;
						
				}
					else
					{
						startTimer=0f;
						cityWarn=false;
					}
				}
			
		}
			
		if(ambientLight==0)
		{
			RenderSettings.ambientLight=new Color(0.539f,0.5046f,0.5046f);
		}
		
		if(ambientLight==1)
		{
			RenderSettings.ambientLight=new Color(0.26f,0.262f,0.262f);
		}
		
		if(ambientLight==2)
		{
			RenderSettings.ambientLight=new Color(0f,0f,0f);
		}
		
	//Debug.Log (bombOnce);
		
		if(confront)
		{
			
			bomber=GameObject.FindGameObjectWithTag ("Bomber").transform;
				
			bag=GameObject.FindGameObjectWithTag ("Bag");
				
				
			shootTimer+=Time.deltaTime;
				
			//speak--So will you punish me for a crime I haven't committed yet?
			if(shootTimer<3f)
			{
			//bomber.GetComponent<BomberMovement>().enabled=false;
			bomber.transform.LookAt(transform);
			bomber.gameObject.animation.Play ("Idle");
			bomber.transform.FindChild ("Dialogue").gameObject.GetComponent<TextMesh>().text="But it continues to tick down, each thought making it worse";			
						confront=false;
			}
		}
			//Debug.Log (shoot);
		if(shoot)
		{
			bomber=GameObject.FindGameObjectWithTag ("Bomber").transform;
				
			bag=GameObject.FindGameObjectWithTag ("Bag");
				
			if(shootTimer>3f && shootTimer<4f)
			{
			transform.FindChild ("Gun").gameObject.SetActive (true);
				bomber.transform.LookAt(transform);
				bomber.gameObject.animation.Play ("Idle");
				bomber.transform.FindChild ("Dialogue").gameObject.GetComponent<TextMesh>().text="So, this is how the cycle repeats itself...";
					PlayerAnim.lift=true;
				currentDiag=Instantiate(permaDiag,bomber.position,Quaternion.identity)as GameObject;
				currentDiag.transform.FindChild ("Dialogue").gameObject.GetComponent<TextMesh>().text="";
				
			}
			shootTimer+=Time.deltaTime;
			
			if(shootTimer>4f && shootTimer<4.5f)
			{
				Time.timeScale=0.3f;
			//blood splatter
			bomber.gameObject.animation.Play("Fall Dead");
			//dying animation
			}
			if(shootTimer>4.5f)
			{
				//Debug.Log (bomber.gameObject);
				bomber.gameObject.animation.Play("RemainDead");
				if(bloodOnce)
				{
				transform.FindChild ("Gun").gameObject.SetActive (true);	
				Instantiate (bloodpool,new Vector3(bomber.transform.position.x,bomber.transform.position.y-0.1f,bomber.transform.position.z),Quaternion.identity);
				bloodOnce=false;
				PlayerAnim.lift=false;
				}
			
			}
			
			
			//speak--Who is the criminal here? Where does the hate begin and where does it end?
			if(shootTimer>6f)
			{
				transform.FindChild ("Gun").gameObject.SetActive (false);
				
			}
				//shoot=false;	
			
		}
			
	//	Debug.Log(shoot);
			if(Bomber.boom)
			{
					if(throwOnce)
				{
				bomber=GameObject.FindGameObjectWithTag ("Bomber").transform;
				
				Debug.Log ("YHEA!");
			throwBagTimer+=Time.deltaTime;
			//explosion
			if(throwBagTimer>3f && throwBagTimer<4f)
			{
				if(explodeOnce)
				{
				Instantiate(explosion,bag.transform.position,Quaternion.identity);
					explodeCount++;
					
					if(explodeCount>20)
						explodeOnce=false;
				}
				
				//fade out instantly
		//		PenaltyScript.bombAffected=true;
				GetComponent<CharacterController>().enabled=false;
			
				//gameObject.animation.enabled=false;
				((CharacterMotor)gameObject.GetComponent<CharacterMotor>()).enabled = false;
			}
			
			if(throwBagTimer>3.5f && throwBagTimer<4f)
			{
				if(blastOnce)
				{
				currentBlast=Instantiate (blastScene,new Vector3(bag.transform.position.x,bag.transform.position.y+0.8f,bag.transform.position.z),Quaternion.identity)as GameObject;
					blastOnce=false;
				}
				transform.FindChild ("Main Camera").camera.enabled=false;
				hazeCam.camera.enabled=true;
				
			}
			
			if(throwBagTimer>4f && throwBagTimer<12f)
			{
				bombCam=GameObject.FindGameObjectWithTag ("BombCam");
				if(bombCam!=null)
				bombCam.camera.enabled=true;
				hazeCam.camera.enabled=false;
					bomber.gameObject.SetActive (false);
		//		blastScene.transform.FindChild ("BombCam").gameObject.camera.enabled=true;
			}
			
			if(throwBagTimer>12f && throwBagTimer<14f)
			{
				doIt=true;
				if(ResetScript.sceneChoice==1)
				{
					Debug.Log("MAKE IT HAPPEN!");
					Time.timeScale=1f;
					GetComponent<CharacterController>().enabled=true;
				//gameObject.animation.enabled=false;
				((CharacterMotor)gameObject.GetComponent<CharacterMotor>()).enabled = true;
					blastScene.transform.FindChild ("BombCam").gameObject.camera.enabled=false;
					transform.FindChild ("Main Camera").camera.enabled=true;
				}
			}
					throwOnce=false;
				}
			
			
		}
		
			
		if(throwBag)
		{
				if(bombOnce)
				{
				bomber=GameObject.FindGameObjectWithTag ("Bomber").transform;
				
			bag=GameObject.FindGameObjectWithTag ("Bag");
			//	Debug.Log ("YHEA!");
			throwBagTimer+=Time.deltaTime;
			if(throwBagTimer<2f)
			{
			bag.transform.parent=null;
			bag.transform.position=Vector3.Lerp (bag.transform.position,transform.position+transform.forward*6f,Time.deltaTime);
			}
			
			//explosion
			if(throwBagTimer>3f && throwBagTimer<4f)
			{
				if(explodeOnce)
				{
				Instantiate(explosion,bag.transform.position,Quaternion.identity);
					explodeCount++;
					
					if(explodeCount>20)
						explodeOnce=false;
				}
				
				//fade out instantly
		//		PenaltyScript.bombAffected=true;
				GetComponent<CharacterController>().enabled=false;
			
				//gameObject.animation.enabled=false;
				((CharacterMotor)gameObject.GetComponent<CharacterMotor>()).enabled = false;
			}
			
			if(throwBagTimer>3.5f && throwBagTimer<4f)
			{
				if(blastOnce)
				{
				currentBlast=Instantiate (blastScene,new Vector3(bag.transform.position.x,bag.transform.position.y+0.8f,bag.transform.position.z),Quaternion.identity)as GameObject;
					blastOnce=false;
				}
				transform.FindChild ("Main Camera").camera.enabled=false;
				hazeCam.camera.enabled=true;
				
			}
			
			if(throwBagTimer>4f && throwBagTimer<12f)
			{
				bombCam=GameObject.FindGameObjectWithTag ("BombCam");
				if(bombCam!=null)
				bombCam.camera.enabled=true;
				hazeCam.camera.enabled=false;
					bomber.gameObject.SetActive (false);
		//		blastScene.transform.FindChild ("BombCam").gameObject.camera.enabled=true;
			}
			
			if(throwBagTimer>12f && throwBagTimer<14f)
			{
				doIt=true;
				if(ResetScript.sceneChoice==1)
				{
					Debug.Log("MAKE IT HAPPEN!");
					Time.timeScale=1f;
					GetComponent<CharacterController>().enabled=true;
				//gameObject.animation.enabled=false;
				((CharacterMotor)gameObject.GetComponent<CharacterMotor>()).enabled = true;
					blastScene.transform.FindChild ("BombCam").gameObject.camera.enabled=false;
					transform.FindChild ("Main Camera").camera.enabled=true;
				}
			}
					bombOnce=false;
				}
			
			
		}
		
		if(chestOpen)		//wrong chest
		{
			
			if(chestOpenTimer>9f)
			{
				WheelScript.maskHelp=false;
				chestOpenTimer=0f;
				chestOpen=false;
			}
			
		}
		
		if(realChest)
		{
			realChestTimer+=Time.deltaTime;
			if(realChestTimer<4f)
			{
				transform.FindChild ("Main Camera").camera.enabled=false;
				transform.FindChild ("Camera").gameObject.SetActive(true);
			}
			
			if(realChestTimer>4f)
			{
				transform.FindChild ("Camera").gameObject.SetActive(false);
				InterScript.final=true;
				inter.SetActive(true);
				gameObject.SetActive(false);
				
				
			}
		}
		//give up
		
		if(giveUp)
		{
			giveUpTimer+=Time.deltaTime;
			
			((CharacterMotor)gameObject.GetComponent<CharacterMotor>()).enabled = false;
			
			if(giveUpTimer>6f && giveUpTimer<7f)
			{
				transform.FindChild ("Main Camera").camera.enabled=false;
				hazeCam.gameObject.camera.enabled=true;
				((CharacterMotor)gameObject.GetComponent<CharacterMotor>()).enabled =true;
				ResetScript.giveUp=true;
			}
			if(giveUpTimer>12f)
			{
				giveUp=false;
			}
			//Time.timeScale=80f;
		}
		
		
		
		if(playerState==0)			//on ground
		{
			if(resetOnce)
			{
				transform.position+=new Vector3(5f,3f,5f);
				gameObject.GetComponent<CharacterController>().radius=0.5f;
			gameObject.GetComponent<CharacterController>().center=new Vector3(0f,1f,0f);
//			boat.GetComponent<MouseLook>().enabled=false;
		//	((CharacterMotor)boat.GetComponent<CharacterMotor>()).enabled=false;
		//	boat.GetComponent<CharacterController>().enabled=false;
		
				
				boatOnce=true;
				resetOnce=false;
			}
			
		}
		
		if(playerState==1)		//on boat
		{
			if(boatOnce)
			{
			transform.position=new Vector3(boat.transform.position.x,boat.transform.position.y,boat.transform.position.z);
			transform.eulerAngles=new Vector3(0f,0f,0f);
			boat.GetComponent<BoxCollider>().enabled=true; //was earlier gameObject
				
			//boat.transform.parent=transform;
			gameObject.GetComponent<CharacterController>().radius=6f;
			gameObject.GetComponent<CharacterController>().center=new Vector3(0f,0f,0f);
				resetOnce=true;
				boatOnce=false;
				
			}
			boat.GetComponent<MouseLook>().enabled=true;
			boat.GetComponent<CharacterController>().enabled=true;
		boat.GetComponent<CharacterMotor>().canControl=true;
			boat.transform.position=new Vector3(transform.position.x,transform.position.y-0.5f,transform.position.z);
			if(Input.GetKey (KeyCode.W))
			{
			boat.transform.eulerAngles=transform.eulerAngles;
			}
		//	boat.transform.FindChild ("Core").eulerAngles=transform.FindChild ("Main Camera").eulerAngles;
		//	boat.transform.FindChild ("Core").eulerAngles=new Vector3(0,transform.FindChild ("Main Camera").eulerAngles.y,0);
			//play floating animation
		}
		
		
		
	/*	if(terrainChoose==0)		//city
		{
			
		}
	*/	
		 //rain.MoveTarget.VectorTarget=targetPos;

	}
	}
}
