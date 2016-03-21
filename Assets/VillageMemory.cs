using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class VillageMemory : MonoBehaviour {
	
	public GameObject original;
	
	public GameObject fire;
	public static bool grass=false;
	private float spawnTimer=0f;
	private float resetTimer=0f;
	private int fireCount=0;
	private bool endSequence=false;
	
	public GameObject armyBoss;
	private Vector3 initialPos=new Vector3(-553.87f,4f,1110.06f);
	

	private float dreamTimer=0f;
	
	public GameObject house;
	private float houseDist=0f;
	private float checkTimer=0f;
	
	public GameObject hand;
	private GameObject blameHand;
	
	private bool blaming=false;
	public Material skybox;
	
	public static int dreamVisit=0;
	public TextMesh bossDialogue;
	
	
	public GameObject shootPlay;
	public GameObject lostPlay;
	
	public static bool pickGun=false;
	private Rect center;
	public GUIStyle redStyle;
	
	public GameObject gun;
	public GameObject gunSoldier;
	
	public GameObject mainCam;
	
	private float lerpValue=0f;
	
	public AudioClip scream;
	private bool gunOnce=true;
	
	public AudioClip bg;
	public AudioClip swoosh;
	private bool swooshPlay;
	// Use this for initialization
	void Start () {
		dreamVisit=0;
		center=new Rect(Screen.width/2f,Screen.height/2f,100f,100f);
	
	}
	
	void OnEnable()
	{
		mainCam.GetComponent<PP_SecurityCamera>().enabled=false;
		mainCam.GetComponent<PP_Scanlines>().enabled=false;
		mainCam.GetComponent<PP_LightWave>().enabled=false;
		swooshPlay=true;	
		//DreamTracker.dream=1;
		transform.position=initialPos;
//		BlankDialogue.player=gameObject;
		
		mainCam.camera.enabled=true;
		((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).enabled=false;
		shootPlay.SetActive (false);
		lostPlay.SetActive (false);
	//	SoundManager.Play(bg);
		
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
	
		//Debug.Log (grass);
		
		
		if(dreamVisit==0)
		{
			
			if(dreamTimer<2f)
			{
				if(swooshPlay)
				{
					//SoundManager.PlaySFX (gameObject,swoosh,false);
					swooshPlay=false;
				}
			//	SoundManager.PlayImmediately (bg);
				gunSoldier.SetActive (false);
				dreamTimer+=Time.deltaTime;
			}
			if(dreamTimer>=2f && dreamTimer<4f)
			{
				swooshPlay=true;
				mainCam.transform.LookAt (armyBoss.transform);
				armyBoss.transform.FindChild ("AI").gameObject.BroadcastMessage("OnUse", this.transform, SendMessageOptions.DontRequireReceiver);
				mainCam.GetComponent<CharacterMotor>().canControl=false;
				dreamTimer+=Time.deltaTime;
			}
			if(pickGun)
			{
				
				if(swooshPlay)
				{
					//SoundManager.PlaySFX (gameObject,swoosh,false);
					swooshPlay=false;
				}
				if(gunOnce)
				{
				gunSoldier.SetActive(true);
				mainCam.GetComponent<CharacterMotor>().canControl=true;
				QuestLog.SetQuestState ("Pick Gun",QuestState.Success);
				mainCam.transform.LookAt (armyBoss.transform);
			armyBoss.transform.FindChild ("AI").gameObject.BroadcastMessage("OnUse", this.transform, SendMessageOptions.DontRequireReceiver);
			armyBoss.transform.FindChild ("AI").gameObject.SetActive (false);
					gun.SetActive(false);
			//	((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).enabled=true;
			//	((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).focalTransform=armyBoss.transform;
				gunOnce=false;
				}
			}
			else
			{
				if(!DialogueSupervisor.talk)
				{
				ThoughtManager.activeID=2;
				ButtonAppear.activeButton=2;
				ThoughtManager.show=true;
				if(ThoughtManager.child21Active)
				{
					//Debug.Log ("CHILD ONE");
					ButtonAppear.active=false;
				}
				if(ThoughtManager.child22Active)
				{
					//Debug.Log ("CHILD TWO");
					ButtonAppear.active=false;
				}
				ThoughtManager.mainThought="Pick Gun";
				ThoughtManager.mainChild1Thought ="It's my duty";
				ThoughtManager.mainChild2Thought="It's necessary";
				ThoughtManager.child1Thought="I wish to serve my country";
				ThoughtManager.child2Thought="I wish to protect";
				}
			}
			
				
		if(grass)
		{
				lerpValue=Mathf.Lerp (0f,1f,2f);
				Debug.Log (lerpValue);
				RenderSettings.ambientLight=new Color(lerpValue,lerpValue,lerpValue);
			spawnTimer+=Time.deltaTime;
			if(spawnTimer>1.2f)
			{
				Instantiate (fire,new Vector3(mainCam.transform.position.x,mainCam.transform.position.y-2f,mainCam.transform.position.z),Quaternion.identity);
			//	SoundManager.PlaySFX (gameObject,scream,false);
				spawnTimer=0f;
				fireCount++;
				
			}
		}
		resetTimer+=Time.deltaTime;
		if(resetTimer>3f)
		{
			grass=false;
			resetTimer=0f;
		}
		
		if(fireCount>=15)
		{
			fireCount=0;
			endSequence=true;
		}
	
		if(endSequence)
		{
			MemoryScript.visitedVillage=true;
			original.SetActive (true);
			gameObject.SetActive (false);
			
		}
			
			checkTimer+=Time.deltaTime;
		
		if(checkTimer>5f)
		{
			houseDist=Vector3.Distance (transform.position,house.transform.position);
			if(houseDist>100f && !blaming)
			{
				Debug.Log ("TRAITOR!");
				blameHand=Instantiate (hand,transform.position+transform.forward*10f,Quaternion.identity)as GameObject;
				((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).enabled=true;
				blaming=true;
				((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).focalTransform=blameHand.transform;

			}
			else if(houseDist<100f)
			{
				
				if(blaming)
				{
					Destroy(blameHand);
					((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).enabled=false;
					blaming=false;
				}
			}
			checkTimer=0f;
		}
			
		}
		
		if(dreamVisit==2)
		{
		dreamTimer+=Time.deltaTime;
		if(dreamTimer<1f)
		{
		((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).enabled=true;
		armyBoss.SetActive (false);
		}
		if(dreamTimer>4f && dreamTimer<5f)
		{
			
			((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).enabled=false;
			armyBoss.SetActive (true);
			transform.LookAt (armyBoss.transform);
		}
		
		checkTimer+=Time.deltaTime;
		
		if(checkTimer>5f)
		{
			houseDist=Vector3.Distance (transform.position,house.transform.position);
			if(houseDist>100f && !blaming)
			{
				Debug.Log ("TRAITOR!");
				blameHand=Instantiate (hand,transform.position+transform.forward*10f,Quaternion.identity)as GameObject;
				((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).enabled=true;
				blaming=true;
				((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).focalTransform=blameHand.transform;

			}
			else if(houseDist<100f)
			{
				
				if(blaming)
				{
					Destroy(blameHand);
					((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).enabled=false;
					blaming=false;
				}
			}
			checkTimer=0f;
		}
		
		if(blameHand!=null)
		{
			blameHand.transform.LookAt (transform);
		}
		
		
		
		
	
//		Debug.Log (grass);
	
		}
		
		
		//Second Visit
		
		if(dreamVisit==1)
		{
			
		}
	
	}
	
	void FixedUpdate()
	{
		if(mainCam.activeSelf==false)
		{
			
			Debug.Log ("NOT ACTIVE");
			
		}
		else
		{
			RenderSettings.skybox=skybox;
			if(!grass)
			{
				lerpValue=Mathf.Lerp (1f,0f,2f);
//				Debug.Log (lerpValue);
				if(lerpValue>0.1f)
		RenderSettings.ambientLight=new Color(lerpValue+0.1f,lerpValue,lerpValue);
		}
	}
	}
	void OnDisable()
	{
		dreamVisit++;
		fireCount=0;
		//transform.FindChild("Camera").gameObject.GetComponent<NoiseAndGrain>().intensityMultiplier+=3.8f;
	}
}
