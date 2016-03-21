using UnityEngine;
using System.Collections;

public class ExistStart : MonoBehaviour {
	
	private float startTimer=0f;
	public GUIStyle startStyle;
	
	public GameObject exitDoor;
	public GameObject exitCam;
	
	public GameObject newGame;
	public GameObject transCam;
	public GameObject newCam;
	
	public GameObject loadGame;
	public GameObject loadCam;
	
	public GameObject settings;
	public GameObject settingsCam;
	
	public Material skybox;
	
	private float turnOff=0f;
	
	private bool loadOnce=true;
	private bool newOnce=true;
	private bool quitOnce=true;
	private bool settingsOnce=true;

	public static bool start = false;
	
	private bool exitGame=false;
	private float exitSequence=0f;
	
	private bool newSelect=false;
	private float newSequence=0f;
	
	private Rect center;
	public static bool settingsActive=false;
	public static bool loadActive=false;
	private float resetTimer=0f;
	
	private Quaternion lookAtRotation;
	
	public UILabel promptMessage;
	public UIFilledSprite mouseIcon;
	
	public GameObject UISet;
	public GameObject boat;
	public GameObject oldBook;
	
	public static bool boatMove=false;
	
	private Vector3 prevDist;
	private Vector3 currentPos;
	private float checkTimer=0f;
	
	private bool overlayOn=true;
	public GameObject sinker;
	public GUIText footprintHelp;

	

	// Use this for initialization
	void Start () {
		
		RenderSettings.skybox=skybox;
		
		
		center=new Rect(Screen.width/2f,Screen.height/2f,100f,100f);
		gameObject.GetComponent<CharacterMotor>().canControl=false;
		gameObject.GetComponent<MouseLook>().enabled=false;
		gameObject.GetComponent<MouseLook>().enabled=false;
		gameObject.GetComponent<ScreenOverlay>().intensity=25f;
		
		
		transCam.SetActive (false);
		promptMessage.text="";
		settingsCam.SetActive(false);
		loadCam.SetActive (false);
		newCam.SetActive(false);
		exitCam.SetActive (false);
		oldBook.SetActive (false);
		UISet.SetActive (false);
		mouseIcon.enabled=false;
		
		ButtonAppear.starter=true;
		
		prevDist=gameObject.transform.position;
		
	
	}
	
	/*void OnGUI()
	{
		if(InteractionScript.artist)	//Exit
		{
			if(exitDoor.renderer.isVisible && !exitGame)
			GUI.Label (center,"Press Escape to Quit Game",startStyle);
		}
		
		
		else if(InteractionScript.billboard)	//Load Game
		{
			if(loadGame.renderer.isVisible && !loadActive)
			GUI.Label (center,"Press Space to Load a Saved Game",startStyle);
		}
		
		else if(DreamWheel.armyBoss) //New Game
		{
			if(newGame.renderer.isVisible && !newSelect)
			GUI.Label (center,"Press Enter to Start a New Game",startStyle);
		}
		
		else if(DreamWheel.family) //Settings
		{
			if (settings.renderer.isVisible && !settingsActive)
			GUI.Label (center,"Press Tab to Change Settings",startStyle);
		}
	 
		
		
	}*/
	
	// Update is called once per frame
	void Update () {
		
		if (!overlayOn) {
						if (Input.GetKeyDown (KeyCode.Return)) {
								overlayOn = true;
						}
				} else {
			if (Input.GetKeyDown (KeyCode.Return)) {
				overlayOn = false;
			}
		}

		if(gameObject.name=="Starter")
		{
			DreamTracker.dream=16;
		if(overlayOn)
			{
		startTimer+=Time.deltaTime;
		if(startTimer<5f)
		{
			gameObject.GetComponent<ScreenOverlay>().intensity-=Time.deltaTime*5f;
			
		}
		if(startTimer>5f && startTimer<6f)
		{
			gameObject.GetComponent<ScreenOverlay>().intensity=0f;
		gameObject.GetComponent<CharacterMotor>().canControl=true;
		gameObject.GetComponent<MouseLook>().enabled=true;
		gameObject.GetComponent<MouseLook>().enabled=true;
					overlayOn=false;
				start=true;
		}
		}
			else
			{
				startTimer=0f;
			}
		}
		
		if(InteractionScript.artist)	//Exit
		{
			Debug.Log ("Exit");
			
			turnOff=0f;
			if(quitOnce)
			{
			gameObject.GetComponent<SmoothLookAt>().target=exitDoor.transform;
			transform.eulerAngles=new Vector3(0f,transform.eulerAngles.y,0f);
				quitOnce=false;
			}
			
			if(exitDoor.renderer.isVisible)
			{
			promptMessage.enabled=true;
			//Debug.Log("YO!!!");
			if(!exitGame)
			{
			promptMessage.text="Exit";
			mouseIcon.enabled=true;
			}
			}
			else
			{
				InteractionScript.artist=false;
			}


			if(Input.GetMouseButtonDown(1))
			{
				promptMessage.text="";
				mouseIcon.enabled=false;
				exitGame=true;
				
			}
			if(exitGame)
			{
				exitSequence+=Time.deltaTime;
				
				if(exitSequence<2f)
				{
				exitCam.SetActive (true);
				//gameObject.camera.enabled=false;
					gameObject.camera.enabled=false;
				exitCam.GetComponent<ScreenOverlay>().intensity+=Time.deltaTime;
				exitDoor.animation.Play ("DoorOpen");
				exitDoor.transform.FindChild ("Handle").gameObject.animation.Play ("HandleTurn");
				exitCam.SetActive (true);
				exitCam.gameObject.animation.Play("ExitDoor");
				}
				
				if(exitSequence>2f)
				{
					
					exitSequence=0f;
					//exitGame=false;
					Application.Quit();
				}
				
				
				
			}
			
		}
		else
		{
			quitOnce=true;
			//exitDoor.SetActive (false);
		}
		
		if(InteractionScript.billboard)	//Load Game
		{
//			Debug.Log ("Load");
			if(loadOnce)
			{
			gameObject.GetComponent<SmoothLookAt>().target=loadGame.transform;
			transform.eulerAngles=new Vector3(0f,transform.eulerAngles.y,0f);
			loadOnce=false;
			}
			
			if(loadGame.renderer.isVisible)
				{
			promptMessage.enabled=true;
				if(!loadActive)
			promptMessage.text="Load Game";
			mouseIcon.enabled=true;
				}
			else
			{
				InteractionScript.billboard=false;
			}
			
			if(Input.GetMouseButtonDown(1))
			{
				//cam animation
		/*		loadActive=true;
				promptMessage.text="Back to Main Screen";
				gameObject.camera.enabled=false;
				loadCam.SetActive (true);*/

				footprintHelp.enabled=false;
				sinker.GetComponent<SinkerScript>().enabled=true;
				gameObject.camera.enabled=false;

		}
			
			
		}
		else
		{
			loadOnce=true;
			loadCam.SetActive (false);
			loadActive=false;
		}
		
		if(InteractionScript.anarchist) //New Game
		{
			//Debug.Log ("New");
			if(newOnce)
			{
				gameObject.GetComponent<SmoothLookAt>().target=newGame.transform;
				transform.eulerAngles=new Vector3(0f,transform.eulerAngles.y,0f);
				newOnce=false;
			}
			
			if(newGame.renderer.isVisible)
				{
				promptMessage.enabled=true;
				if(!newSelect)
				{
				promptMessage.text="Start a New Game";
				mouseIcon.enabled=true;
				}
				}
			else
			{
				InteractionScript.anarchist=false;
			}

			
			if(Input.GetMouseButtonDown(1))
			{
				promptMessage.text="";
				mouseIcon.enabled=false;
				newSelect=true;
				
			}
			
			if(newSelect)
			{
				StartCoroutine ("SitBoat");
			}
			if(boatMove)
			{
				promptMessage.text="";
				mouseIcon.enabled=false;
				//actual tutorial
			}
			
		}
		else
		{
			newOnce=true;
			//newGame.SetActive (false);
			//gameObject.camera.enabled=true;
		}
		
		//Debug.Log (InteractionScript.artist);
		
		
		if(DreamWheel.family) //Settings
		{
			Debug.Log ("Settings");
			if(settingsOnce)
			{
			gameObject.GetComponent<SmoothLookAt>().target=settings.transform;
		//		lookAtRotation=Quaternion.LookRotation(settings.transform.position, Vector3.up);
		//	transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, 2f * Time.deltaTime);
			transform.eulerAngles=new Vector3(0f,transform.eulerAngles.y,0f);
			resetTimer=0f;
			settingsOnce=false;
			}
			
			if(settings.renderer.isVisible)
			{
			promptMessage.enabled=true;
			if(!settingsActive)
			promptMessage.text="Change Settings";
			mouseIcon.enabled=true;
			}
			else
			{
				DreamWheel.family=false;
			}
			
			if(Input.GetMouseButtonDown(1))
			{
				//cam animation
				gameObject.camera.enabled=false;
				promptMessage.enabled=false;
				mouseIcon.enabled=false;
				settingsCam.SetActive (true);
				settingsActive=true;
			}
		}
		else
		{
			settingsOnce=true;
			settingsCam.SetActive (false);
			settingsActive=false;
		}
		
		resetTimer+=Time.deltaTime;
		
		if(resetTimer>0.5f)
		{
			if(InteractionScript.artist)
			InteractionScript.artist=false;
			if(InteractionScript.billboard)
			InteractionScript.billboard=false;
			if(InteractionScript.anarchist)
			InteractionScript.anarchist=false;
			transform.eulerAngles=new Vector3(0f,transform.eulerAngles.y,0f);
			if(DreamWheel.family)
			DreamWheel.family=false;
			
			gameObject.GetComponent<SmoothLookAt>().target=null;
			resetTimer=0f;
			
		}
		
		if(!InteractionScript.artist && !InteractionScript.billboard && !InteractionScript.anarchist && !DreamWheel.family )
		{
			//Debug.Log ("NOPE!!");
			turnOff+=Time.deltaTime;
			if(turnOff>0.5f)
			{
			promptMessage.enabled=false;
			gameObject.GetComponent<SmoothLookAt>().target=null;
			mouseIcon.enabled=false;
				}
		}
		else
		{
			turnOff=0f;
		}
		if(settingsActive || loadActive)
		{
			gameObject.camera.enabled=false;
		}
		else
		{
			gameObject.camera.enabled=true;
			settingsCam.SetActive (false);
			loadCam.SetActive (false);
		}
		if(loadActive)
			{
				loadCam.SetActive (false);
				gameObject.camera.enabled=true;
				loadActive=false;
			}
		
		if(newSelect || exitGame || boatMove)
		{
			//gameObject.camera.enabled=false;
			gameObject.camera.enabled=false;
		}
		else
		{
			//gameObject.camera.enabled=true;
			gameObject.SetActive(true);
		}
		
		if(gameObject.activeSelf==false)
		{
			Debug.Log ("TURN OFF");
			InteractionScript.anarchist=false;
			DreamWheel.family=false;
			InteractionScript.billboard=false;
			InteractionScript.artist=false;
			mouseIcon.enabled=false;
			promptMessage.text="";
		}
	
	}
	
	IEnumerator SitBoat()
	{
		newSequence+=Time.deltaTime;
				
				if(newSequence<3f)
				{
				//gameObject.camera.enabled=false;
				gameObject.camera.enabled=false;
				transCam.SetActive (true);
				transCam.animation.Play ("NewCamMove");
				}
				if(newSequence>3f)
				{
					Debug.Log ("BOAT MOVE");
					UISet.SetActive (true);
					transCam.SetActive (false);
					newCam.SetActive (true);
					BoatAnim.boatAllow=true;
					oldBook.SetActive (true);
					newSequence=0f;
					boatMove=true;
				newSelect=false;
			yield break;
					
					//Application.LoadLevel("Main");
				}
		yield return null;
	}
	
}
