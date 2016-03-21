using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	public GameObject canvas;
	public Material org;
	public Material house;
	public Material person;
	public static bool reminisce=false;
	public static bool envYes=false;
	public static bool absYes=false;

	public Material seaSkybox;
	public GameObject boatCam;


	public GUIText help;

	public static bool tutorialOn=false;

	void Start()
	{
		help.text="";
	}


	void Update()
	{
		PlaylistScript.music=6;
		if (InteractionScript.chalkboard) {
						ThoughtManager.thoughtID = 3;
						ThoughtManager.activeID=2;
						ButtonAppear.activeButton=2;
						ThoughtManager.show=true;

								ThoughtManager.show = true;
			
								if (ThoughtManager.child22Active) {
										
										BranchManager.justOne = true;
										SumScript.mood=1;
										StartCoroutine("Show",1);
				
								}
								if (ThoughtManager.child21Active) {
										BranchManager.justOne = true;
										SumScript.mood=2;
										StartCoroutine("Show",1);
								}

								ThoughtManager.mainThought4 = "I'm feeling...";
								ThoughtManager.mainChild1Thought = "Happy";
								ThoughtManager.mainChild2Thought = "Sad";
								ThoughtManager.child1Thought = "Joy fills me";
								ThoughtManager.child2Thought = "Despair fills me";
				}

		if (InteractionScript.artist) {				//Canvas

			ThoughtManager.thoughtID = 3;
			ThoughtManager.activeID=3;
			ButtonAppear.activeButton=3;
			ThoughtManager.show=true;
			
			ThoughtManager.show = true;
			
			if (ThoughtManager.child31Active) {
				
				BranchManager.justOne = true;
				canvas.renderer.material=house;
				StartCoroutine("Show",2);
				
			}
			if (ThoughtManager.child32Active) {
				BranchManager.justOne = true;
				canvas.renderer.material=person;
				StartCoroutine("Show",2);
			}
			
			ThoughtManager.mainThought4 = "My memories fill up the empty canvas";
			ThoughtManager.mainChild1Thought = "Of someplace";
			ThoughtManager.mainChild2Thought = "Of someone";
			ThoughtManager.child1Thought = "That I once called home";
			ThoughtManager.child2Thought = "Who I used to care about";
				}	

		if (InteractionScript.bull) {            //Man

			
			ThoughtManager.thoughtID = 3;
			ThoughtManager.activeID=1;
			ButtonAppear.activeButton=1;
			ThoughtManager.show=true;
			
			ThoughtManager.show = true;
			
			if (ThoughtManager.child11Active) {
				
				BranchManager.justOne = true;
				StartCoroutine("Show",3);
				
			}
			if (ThoughtManager.child12Active) {
				BranchManager.justOne = true;
				StartCoroutine("Show",3);
			}
			
			ThoughtManager.mainThought4 = "This man feels...";
			ThoughtManager.mainChild1Thought = "strange";
			ThoughtManager.mainChild2Thought = "familiar";
			ThoughtManager.child1Thought = "An alien aura surrounds him";
			ThoughtManager.child2Thought = "A lost fragment of a memory";
				} 

			
			if(ThoughtManager.activeID==2)	//self
			{			
				ThoughtManager.show = true;
				if(ThoughtManager.mainActive3)
				{
					//Debug.Log ("Show Mirror");
					BranchManager.justOne=true;
					//footprintHelp.text="Some thoughts lead to an action";
					ThoughtManager.mainThought3="My consciousness is an infinite ocean again....";
					StartCoroutine("Shift");
				}
				
				ThoughtManager.thoughtID=3;
				ThoughtManager.mainThought4="I have the workings of my mind";
				
				
			}
	}

	IEnumerator Show(int num)
	{
		if(num==1)
		{
			help.text="Your emotions can briefly flash thoughts and memories";
			yield return new WaitForSeconds(3f);
			help.text="Sometimes those memories and thoughts can be explored";
			yield return new WaitForSeconds(3f);
			help.text="";
		}
		if(num==2)
		{
			help.text="Your thoughts can alter the environment in different ways";
			yield return new WaitForSeconds(3f);
			help.text="";
		}
		if(num==3)
		{
			help.text="Some thoughts simply let you know what your character is thinking";
			yield return new WaitForSeconds(3f);
			help.text="";
		}
	}

	IEnumerator Shift()
	{
		tutorialOn=false;
		boatCam.camera.enabled=true;
		RenderSettings.skybox=seaSkybox;
		gameObject.SetActive (false);
		yield return null;
	}


}
	
	/*
	// Update is called once per frame
	void Update () {
		
		mask.transform.LookAt (player.transform);
//		Debug.Log (screenTimer);
		
		
		
		
		
		
		if(true)
		{
		if(once)
		{
				//RenderSettings.ambientLight=new Color(0.8f,0f,0.2f,0f);
			timer.SetActive(false);
				//Debug.Log ("AWW YEAH!");
			screenTimer=0f;
			once=false;
		}
			
			if(((!playClick && screenTimer<18f) || playClick) && ((!lightEnv && screenTimer<27f) || (!lightEnv && screenTimer>=33f)))
			{
				screenTimer+=Time.deltaTime;
			}
			
			
			if(screenTimer<3f)
			{
				maskDialogue.text="Welcome to the Graveyard of Personas";
			}
			if(screenTimer<6f && screenTimer>3f)
			{
				maskDialogue.text="Here lie the buried you once controlled";
			}

			if(screenTimer<9f && screenTimer>6f)
			{
			maskDialogue.text="Among them, your dark secret lies locked in this chest";
			}
			if(screenTimer<12f && screenTimer>9f)
			{
			maskDialogue.text="You will be helped only by the waves";
			}
			if(screenTimer<15f && screenTimer>12f)
			{
			maskDialogue.text="Listen carefully for a moment, you can hear them";
			}
			if(screenTimer<18f && screenTimer>15f)
			{
			maskDialogue.text="In the silence, your thoughts become crystal clear";
			}
			
			if(screenTimer<18f && mask.activeSelf)
			{
				player.transform.LookAt (mask.transform);
			}
			
			if(playClick)
			{
			
			if(screenTimer<21f && screenTimer>18f)
			{
			maskDialogue.text="This is the where your subconscious thoughts can be seen";
			}
			
			
			if(screenTimer<24f && screenTimer>21f)
			{
			maskDialogue.text="Each region influences different aspects of the self and the world";
					
			}
				
			}
			
			
			
			if(screenTimer<27f && screenTimer>24f && !lightEnv)
			{
				playClick=false;
			maskDialogue.text="A signboard to guide you remains unreadable in darkness";
			}
			if(screenTimer>27f && screenTimer<27.5f)
			{
				lightEnv=true;
				
			}
			
			if((screenTimer<33f) && (TutWheel.ambientLight==1 || TutWheel.ambientLight==0))
			{
				lightEnv=false;
				screenTimer=33f;
				mask.SetActive (false);
			}
			
			
			
			
			
			if(TutWheel.otherside)
			{
				clockHand.SetActive(false);
				clockEmpty.SetActive(true);
			}
			
			
			
			//chest is open
			
			if(TutWheel.openChest)
			{
				//waves and end sequence
				chest.animation.Play("Open");
				openChestTimer+=Time.deltaTime;
				player.GetComponent<CharacterController>().enabled=false;
				speed=Time.deltaTime*2f;
				player.transform.position=Vector3.MoveTowards (player.transform.position,chest.transform.position,speed);
				player.GetComponent<NoiseAndGrain>().intensityMultiplier=1f*openChestTimer;
				
				if(openChestTimer>4f)
				{
					player.SetActive (false);
					
				}
			}
			
			
		
		
		
	}
	}
	
	void OnGUI()
	{
		if(Input.GetMouseButton (0))
		{
			if(screenTimer>18f && screenTimer<24f)
			{
				
				playClick=true;
				screenTimer+=Time.deltaTime/2f;
			}
		}
		else
		{
			playClick=false;
		}
		
		if(screenTimer>18f && screenTimer<24f)
		{
			if(!playClick)
			{
				
				GUI.Label (new Rect(100f,Screen.height-100f,100f,100f),"Press and Hold Left Mouse Button to bring up the Subconscious Interface",style);
			}
			else
			{
				if(screenTimer<21f && screenTimer>18f)
			{
			GUI.Label(new Rect(100f,Screen.height-100f,100f,100f),"This is the where your subconscious thoughts can be seen",style);
			}
			
			
			if(screenTimer<24f && screenTimer>21f)
			{
			GUI.Label(new Rect(100f,Screen.height-100f,100f,100f),"Each region influences different aspects of the self and the world",style);
					
			}
				
			}
			
		}
		if(screenTimer>=24f && screenTimer<24.5f)
				{
					screenTimer=27f;
					
				}
		
		
		
		if(lightEnv)
		{
		if(screenTimer>=27f && screenTimer<33f)
		{
			
				GUI.Label (new Rect(100f,Screen.height-100f,100f,100f),"You can interact with your thoughts to alter the environment",style);
		}
		}
		
		if(screenTimer>33f && screenTimer<36f)
		{
			GUI.Label(new Rect(100f,Screen.height-100f,100f,100f),"Your Emotions have power to change the world around you subtly",style);
			
		}
		
		if(screenTimer>36f && screenTimer<40f)
		{
			GUI.Label (new Rect(100f,Screen.height-100f,100f,100f),"Try changing to an Emotion to observe what it changes around you", style);
		}
		
		if(screenTimer>40f && screenTimer<44f)
		{
			GUI.Label (new Rect(100f,Screen.height-100f,100f,100f),"E", style);
		}
		
		if(screenTimer>33f && screenTimer<36f)
		{
			GUI.Label(new Rect(100f,Screen.height-100f,100f,100f),"You can communicate to others through your thoughts via People section of the interface",style);
			
		}
		
		if(screenTimer>36f && screenTimer<40f)
		{
			GUI.Label (new Rect(100f,Screen.height-100f,100f,100f),"However, you can only perceive their response.What you actually speak remains can only be interpreted", style);
		}
		
		if(screenTimer>40f && screenTimer<44f)
		{
			GUI.Label (new Rect(100f,Screen.height-100f,100f,100f),"Emotions ", style);
		}
	}
}*/
