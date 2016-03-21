using UnityEngine;
using System.Collections;

public class ResetScript : MonoBehaviour {
	
	private GameObject killAll;
	public static int sceneChoice=0;
	public GameObject player;
	private GameObject cityTerrain;
	private GameObject desertTerrain;
	private GameObject oceanTerrain;
	private GameObject desertGroup;
	private GameObject oceanGroup;
	private bool once=true;
	private bool setOnce=true;
	private bool setDesert=true;
	private bool setOcean=true;
	public GameObject emotionCam;
	public GameObject cityCube;
	public GameObject starter;
	public GUIText timer;
	public GameObject rainGlobal;
	public static Vector3 lastPos;
	public GameObject inter;
	
	private float scareTimer=0f;
	public static bool quit=false;
	private bool yesAllow=true;
	private bool noAllow=false;
	public static bool doIt=false;
	public static float doItTimer=0f;
	private GameObject bomber;
	public static bool giveUp=false;
	
	public GameObject mask;
	
	public GameObject scareCam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//	Debug.Log (doIt);
//		Debug.Log (sceneChoice);
		if(StarterScript.ready)
		{		//CHANGE TO THIS
		//if(true)
		//{
	//		StarterScript.ready=true;
		if(once)
		{
			
			starter.SetActive (false);
			
			//Debug.Log ("YO!");
			player=GameObject.FindGameObjectWithTag ("Player");
			cityTerrain=GameObject.FindGameObjectWithTag ("Ground");
			desertTerrain=GameObject.FindGameObjectWithTag ("Desert");
			oceanTerrain=GameObject.FindGameObjectWithTag ("Ocean");
				bomber=GameObject.FindGameObjectWithTag ("Bomber");
			desertGroup=GameObject.FindGameObjectWithTag ("DesertGroup");
			oceanGroup=GameObject.FindGameObjectWithTag ("OceanGroup");
			if(desertTerrain!=null)
			desertTerrain.SetActive (false);
		//	if(oceanTerrain!=null)
		//	oceanTerrain.SetActive (false);
			if(desertGroup!=null)
			desertGroup.SetActive (false);
		//if(oceanGroup!=null)
		//	oceanGroup.SetActive (false);
			once=false;
		}
		if(InterScript.firstYes)
		if(sceneChoice==0)		//City
		{
//				Debug.Log ("in the city");
			if(setOnce)
			{
					Debug.Log ("SET ONCE");
					player.SetActive (true);
					player.transform.FindChild ("Main Camera").gameObject.SetActive(true);
					//Debug.Log ("IN MY CITY!");
			if(desertTerrain!=null)
			desertTerrain.SetActive (false);
				starter.SetActive (false);
					cityCube.SetActive(false);
				inter.SetActive(false);
					timer.enabled=true;
					mask.SetActive(true);
					
					
			player.GetComponent<CivilianGeneration>().enabled=true;
		//	if(oceanTerrain!=null)
		//	oceanTerrain.SetActive (false);
			if(desertGroup!=null)
			desertGroup.SetActive (false);
		//	if(oceanGroup!=null)
		//	oceanGroup.SetActive (false);
			//	Debug.Log (player.transform.position);
					lastPos=new Vector3(203.257f,1.8f,113.394f);
			player.transform.position=lastPos;
					//	Debug.Log (player.transform.position);
				setOnce=false;
			}
			
		if(Player.doIt)
		{
			PreBirthScript.flag=true;
			killAll=GameObject.FindGameObjectWithTag ("KillAll");
				//fade
					Debug.Log ("ON A ROLLL!!!");
				sceneChoice=1;
				setOnce=true;
				killAll.SetActive (false);
				player.transform.position=new Vector3(438.74f,174.82f,290.25f);
				cityTerrain.SetActive (false);
				desertTerrain.SetActive (true);
				desertGroup.SetActive (true);
					inter.SetActive (true);
					InterScript.secondYes=true;
					player.SetActive (false);
				
		}
		}
			if(InterScript.secondYes)
		if(sceneChoice==1)		//Desert
		{
			if(setDesert)
			{
			if(desertTerrain!=null)
			desertTerrain.SetActive (true);
		//	if(oceanTerrain!=null)
		//	oceanTerrain.SetActive (false);
			if(desertGroup!=null)
			desertGroup.SetActive (true);
					player.SetActive (true);
					MaskHelp.startWarning=true;
					timer.enabled=false;
					emotionCam.SetActive(true);
					player.GetComponent<CivilianGeneration>().enabled=false;
					player.transform.FindChild("Dust Storm").gameObject.SetActive (true);
					rainGlobal.SetActive (true);
					player.transform.FindChild ("RainSplashSystem").gameObject.SetActive (true);
					player.transform.FindChild ("RainFallSystem").gameObject.SetActive (true);
					
		//	if(oceanGroup!=null)
		//	oceanGroup.SetActive (false);
					player.transform.position=new Vector3(447.959f,175.723f,289.798f);
					
					
					if(cityTerrain!=null)
						cityTerrain.SetActive (false);

			player.transform.FindChild("Main Camera").gameObject.GetComponent<GlobalFog>().globalDensity=1f;
			player.transform.FindChild("Main Camera").gameObject.GetComponent<GlobalFog>().startDistance=0f;
				
				player.transform.FindChild("Main Camera").gameObject.GetComponent<GlobalFog>().globalFogColor=new Color(0.550f,0.566f,0.347f,0f);
				player.transform.FindChild("Main Camera").gameObject.GetComponent<IOCcam>().viewDistance=500;
				player.transform.FindChild("Camera").gameObject.SetActive (false);
				player.transform.FindChild ("Dust Storm").gameObject.SetActive (true);
				setDesert=false;
			}
			if(DesertScript.desertTimer>590f || giveUp)
			{
				//play end scene
				
				//fade
				desertTerrain.SetActive (false);
				desertGroup.SetActive (false);	
					player.SetActive(false);
				InterScript.final=true;
				inter.SetActive(true);
				
				//player.transform.position=new Vector3(529.0526f,-204.183f,510.520f);
			
		//		oceanTerrain.SetActive (true);
				
			}
		}
		
/*		if(sceneChoice==2)		//Ocean
		{
			if(setOcean)
			{
			transform.FindChild("Main Camera").gameObject.GetComponent<GlobalFog>().globalDensity=0.5f;
				transform.Find ("Main Camera").gameObject.GetComponent<GlobalFog>().globalFogColor=Color.grey;
			transform.FindChild("Main Camera").gameObject.GetComponent<GlobalFog>().startDistance=100f;
				setOcean=false;
			}
			if(OceanScript.oceanTimer>600f)
			{
				
				//fade
				
				//show the end screen
			}
		}			 */
			//Debug.Log (doIt);
			//Debug.Log (lastPos);
	if(doIt)
			{
			
				if(yesAllow)
				{
				Debug.Log ("YES INSIDE!");
				
		//		if(WheelScript.randThought!=1 || WheelScript.randThought!=2 || WheelScript.randThought!=10)
		//	{
					//Debug.Log (WheelScript.targetVect);
					bomber=GameObject.FindGameObjectWithTag ("Bomber");
				Time.timeScale=0.7f;
	/*					if(killAll!=null)
						killAll.SetActive(false);
						if(civilians!=null)
						civilians.SetActive (false);
					if(bomber!=null)
					bomber.SetActive (false);
						cityTerrain.SetActive (false);*/
						player.transform.FindChild ("Main Camera").gameObject.SetActive (false);
					//	player.SetActive (false);
				//player.transform.position=WheelScript.targetVect;
						yesAllow=false;
						noAllow=true;
						
		//	}
					//stop music
					//sound effect related
				
				}
				
				doItTimer+=Time.deltaTime;
				if(doItTimer>10f)
				{
					doIt=false;
					doItTimer=0f;
				}
			
			}
			
			else
			{
				if(noAllow)
				{
				
						
						Time.timeScale=1.0f;
//						Debug.Log ("Yo");
			/*		cityTerrain.SetActive (true);
						if(killAll!=null)
						killAll.SetActive(true);
						if(civilians!=null)
						civilians.SetActive (true);
						if(bomber!=null)
					bomber.SetActive (true);*/
						player.transform.FindChild ("Main Camera").gameObject.SetActive (true);
					//	player.SetActive (true);
	
						
						
				//player.transform.position=lastPos;
					//resume music
					yesAllow=true;
					noAllow=false;
				}
			}
		
	}
		
	if(quit)
		{
			scareTimer+=Time.deltaTime;
			if(scareTimer>1.5f)
			{
			player.transform.FindChild ("Main Camera").gameObject.SetActive (true);
			scareCam.SetActive(true);	
			}
			
			if(scareTimer>3f)
			{
				Application.Quit ();
			}
		}
	}
}
