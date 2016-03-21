using UnityEngine;
using System.Collections;

public class EmotionScript : MonoBehaviour {
	
	public static int emotion=0;
	public static bool once=true;
	public GameObject riot;
	public GameObject riot2;
	public GameObject riot3;
	private float riotChance=0f;
	private int riotRand=0;
	private GameObject player;
	
	public GameObject emotionCamera;
	private float emotionTimer=0f;
	private bool playing=false;
	private float playTimer=0f;
	private bool startOnce=true;
	private float cooldownTimer=0f;
	private int repeatCount=0;
	private int randCamera=0;
	private bool randOnce=true;
	
	public GameObject dialogueText;
	private GameObject currentDialogue;
	private bool dialogueOnce=true;
	private float dialogueReset=0f;
	
	private bool desertOnce=true;
	
	
	//Scene One
	
	public GameObject sadGroup;
	public GameObject happyGroup;
	public GameObject angryGroup;
	
	private float resetTimer=0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log (playing);
		if(startOnce)
		{
			player=GameObject.FindGameObjectWithTag ("Player");
			startOnce=false;
		}
			
		if(ResetScript.sceneChoice==0)
		{
		
		if(emotion==1)		// Sad
		{
			if(once)
			{
			emotion=2;
			BomberMovement.sound=true;
			RenderSettings.ambientLight=new Color(0.15f,0.15f,0.15f);
					
			happyGroup.SetActive (false);
			angryGroup.SetActive (false);
			sadGroup.SetActive (true);
					
					//play sad bit
					
			once=false;
			}
		}
		if(emotion==2) 		//Happy
		{
			if(once)
			{
			emotion=3;
					BomberMovement.sound=true;
			RenderSettings.ambientLight=new Color(0.8f,0.8f,0.8f);
					
					happyGroup.SetActive (true);
					angryGroup.SetActive (false);
					sadGroup.SetActive (false);

					
					//play happy bit
					
			once=false;
			}
		}
		if(emotion==3)		//Angry
		{
			if(once)
			{
			emotion=3;
			
			BomberMovement.sound=true;
			RenderSettings.ambientLight=new Color(1f,0f,0f);
					
					angryGroup.SetActive (true);
					happyGroup.SetActive (false);
					sadGroup.SetActive (false);
					
					//play angry bit
					
					
				once=false;
			}
		}
			
			
			
			
			
		}
	}
}
	
				
		/*		riotChance=Random.value;
			
			if(riotChance<0.001f)
			{

				if(SkinSelect.skinChoose==0)
				Instantiate (riot,new Vector3(transform.position.x+Random.Range (-100f,100f),0f,transform.position.z+Random.Range (-100f,100f)),Quaternion.identity);
				
				if(SkinSelect.skinChoose==1)
				Instantiate (riot2,new Vector3(transform.position.x+Random.Range (-100f,100f),0f,transform.position.z+Random.Range (-100f,100f)),Quaternion.identity);
				
				if(SkinSelect.skinChoose==2)
				Instantiate (riot3,new Vector3(transform.position.x+Random.Range (-100f,100f),0f,transform.position.z+Random.Range (-100f,100f)),Quaternion.identity);
			}
		}
		
	}
		
		if(ResetScript.sceneChoice==1)
		{
			if(desertOnce)
			{
				emotionCamera.transform.FindChild ("Desert").FindChild("Introspect").GetChild (0).gameObject.SetActive(false);
				emotionCamera.transform.FindChild ("Desert").FindChild("Introspect").GetChild (1).gameObject.SetActive(false);
				emotionCamera.transform.FindChild ("Desert").FindChild("Sad").GetChild (0).gameObject.SetActive(false);
				emotionCamera.transform.FindChild ("Desert").FindChild("Angry").GetChild (0).gameObject.SetActive(false);
				emotionCamera.transform.FindChild ("Desert").FindChild("Angry").GetChild (1).gameObject.SetActive(false);
				
				desertOnce=false;
			}
			if(emotion==1)		//Introspect
		{
			if(once)
			{
			emotion=1;
			GetComponent<SepiaToneEffect>().enabled=true;
						
			once=false;
			}
				emotionTimer+=Time.deltaTime;
				if(emotionTimer>30f)
				{
					emotionTimer=0f;
					resetTimer=0f;
					playTimer=0f;
					emotionCamera.transform.FindChild ("Desert").FindChild("Introspect").GetChild (0).gameObject.SetActive(false);
					emotionCamera.transform.FindChild ("Desert").FindChild("Introspect").GetChild (1).gameObject.SetActive(false);
					player.transform.FindChild ("Main Camera").gameObject.camera.enabled=true;
					emotion=0;
				}
				
			if(Random.value<0.02f && !playing && resetTimer<5f)
			{
				playing=true;		
			}
				else
				{
					resetTimer-=Time.deltaTime;
				}
			if(playing)
			{
					if(randOnce)
					{
						randCamera=Random.Range (0,2);
						randOnce=false;
					}
	
			player.transform.FindChild ("Main Camera").gameObject.camera.enabled=false;
			emotionCamera.transform.FindChild ("Desert").FindChild("Introspect").GetChild (randCamera).gameObject.SetActive(true);
			playTimer+=Time.deltaTime;
			}
					
					if(playing && playTimer>1f)
					{
						randOnce=true;
						emotionCamera.transform.FindChild ("Desert").FindChild("Introspect").GetChild (randCamera).gameObject.SetActive(false);
						player.transform.FindChild ("Main Camera").gameObject.camera.enabled=true;
						repeatCount++;
						playTimer=0f;
					}
			//	Debug.Log(resetTimer);
				if(resetTimer<5f)
				{
				if(repeatCount<=3)
				{
					
					cooldownTimer+=Time.deltaTime;
					if(cooldownTimer>2f)
					{
						playing=true;
						cooldownTimer=0f;
					}
					
				}
				
				else
				{
					playing=false;
					repeatCount=0;
					resetTimer=20f;
				}
			}
	
			
		}
		if(emotion==2)		// Sad
		{
			if(once)
			{
			emotion=2;
			GetComponent<SepiaToneEffect>().enabled=false;
					GetComponent<NoiseAndGrain>().intensityMultiplier=2f;
			GetComponent<NoiseAndGrain>().intensities=new Vector3(0f,0f,0f);
			once=false;
			}
				
				emotionTimer+=Time.deltaTime;
				if(emotionTimer>30f)
				{
					emotionTimer=0f;
					resetTimer=0f;
					playTimer=0f;
					emotion=0;
					emotionCamera.transform.FindChild ("Desert").FindChild("Sad").GetChild (0).gameObject.SetActive(false);
					player.transform.FindChild ("Main Camera").gameObject.camera.enabled=true;
				}
				
				
				if(Random.value<0.02f && !playing && resetTimer<5f)
			{
				playing=true;		
			}
				else
				{
					resetTimer-=Time.deltaTime;
				}
			if(playing)
			{
					if(randOnce)
					{
						randCamera=Random.Range (0,2);
						randOnce=false;
					}
	
			player.transform.FindChild ("Main Camera").gameObject.camera.enabled=false;
			emotionCamera.transform.FindChild ("Desert").FindChild("Sad").GetChild (0).gameObject.SetActive(true);
			playTimer+=Time.deltaTime;
			}
					
					if(playing && playTimer>1f)
					{
						randOnce=true;
						emotionCamera.transform.FindChild ("Desert").FindChild("Sad").GetChild (0).gameObject.SetActive(false);
						player.transform.FindChild ("Main Camera").gameObject.camera.enabled=true;
						repeatCount++;
						playTimer=0f;
					}
				Debug.Log(resetTimer);
				if(resetTimer<5f)
				{
				if(repeatCount<=3)
				{
					
					cooldownTimer+=Time.deltaTime;
					if(cooldownTimer>2f)
					{
						playing=true;
						cooldownTimer=0f;
					}
					
				}
				
				else
				{
					playing=false;
					repeatCount=0;
					resetTimer=20f;
				}
			}
		}
		if(emotion==3) 		//Happy
		{
			if(once)
			{
			emotion=3;
			GetComponent<SepiaToneEffect>().enabled=false;
					GetComponent<NoiseAndGrain>().intensityMultiplier=1f;
								
			once=false;
			}
				emotionTimer+=Time.deltaTime;
				if(emotionTimer>30f)
				{
					emotion=0;
				}
				
					//enable thumping noise
					if(dialogueOnce)
					{
			currentDialogue= Instantiate(dialogueText,transform.position+transform.forward*6f,Quaternion.identity)as GameObject;
			currentDialogue.transform.FindChild ("DialogueText").GetComponent<TextMesh>().text="You can hear happiness....";
					dialogueOnce=false;
						resetTimer=0f;
					}
					
					resetTimer+=Time.deltaTime;
					if(resetTimer>20f)
					{
						dialogueOnce=true;
					}
		
		}
		if(emotion==4 || EventManager.riots)		//Angry
		{
			if(once)
			{
			emotion=4;
			GetComponent<SepiaToneEffect>().enabled=false;
					GetComponent<NoiseAndGrain>().intensityMultiplier=10f;
			GetComponent<NoiseAndGrain>().intensities=new Vector3(1f,0f,0f);
				once=false;
			}
				
				emotionTimer+=Time.deltaTime;
				if(emotionTimer>30f)
				{
					emotionTimer=0f;
					resetTimer=0f;
					playTimer=0f;
					emotion=0;
					emotionCamera.transform.FindChild ("Desert").FindChild("Angry").GetChild (0).gameObject.SetActive(false);
					emotionCamera.transform.FindChild ("Desert").FindChild("Angry").GetChild (1).gameObject.SetActive(false);
					player.transform.FindChild ("Main Camera").gameObject.camera.enabled=true;
				}
				
			if(Random.value<0.02f && !playing && resetTimer<5f)
			{
				playing=true;		
			}
				else
				{
					resetTimer-=Time.deltaTime;
				}
			if(playing)
			{
					if(randOnce)
					{
						randCamera=Random.Range (0,2);
						randOnce=false;
					}
	
			player.transform.FindChild ("Main Camera").gameObject.camera.enabled=false;
			emotionCamera.transform.FindChild ("Desert").FindChild("Angry").GetChild (randCamera).gameObject.SetActive(true);
			playTimer+=Time.deltaTime;
			}
					
					if(playing && playTimer>1f)
					{
						randOnce=true;
						
						emotionCamera.transform.FindChild ("Desert").FindChild("Angry").GetChild (randCamera).gameObject.SetActive(false);
						player.transform.FindChild ("Main Camera").gameObject.camera.enabled=true;
						repeatCount++;
						playTimer=0f;
					}
				//Debug.Log(resetTimer);
				if(resetTimer<5f)
				{
				if(repeatCount<=3)
				{
					
					cooldownTimer+=Time.deltaTime;
					if(cooldownTimer>2f)
					{
						playing=true;
						cooldownTimer=0f;
					}
					
				}
				
				else
				{
					playing=false;
					repeatCount=0;
					resetTimer=20f;
				}
			}
		}
			
		}  */
	
