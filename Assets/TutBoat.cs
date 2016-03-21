using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class TutBoat : MonoBehaviour {
	
	private bool zeroPhase=true;
	private bool firstPhase=false;
	private bool secondPhase=false;
	private bool thirdPhase=false;
	private bool fourthPhase=false;
	
	public GameObject mirror;
	public GameObject tvGuy;
		public GameObject mask;
	public GameObject waveCam;
	public GameObject footprintCam;
	public GUIText footprintHelp;
	public GameObject playerCam;
		public GameObject chalkboard;
		public GameObject boatObj;

	private GameObject blank=null;
	private GameObject chalk=null;
	
	private bool selfDone=false;
	private bool peopleDone=false;
	private bool envDone=false;
	private bool absDone=false;
	
		public GameObject sinker;
		public GameObject transCam;
		public static bool camZoom=false;

	private Object child1; //first phase
	private Object wave;
	private Object tv;
	private Object footprint;
		private Object maskObj;



	// Use this for initialization
	void Start () 
	{
		Screen.showCursor=true;
	//ThoughtManager.activeID=4;
//		r1=new Rect(Screen.width/2f-330f,Screen.height/2f+50f,250f,250f);
	footprintHelp.text="";
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log (firstPhase);
		//Debug.Log ("ThoughtID"+ThoughtManager.thoughtID);
		
		if(ExistStart.boatMove)
		{

						if (zeroPhase) {
				if(QuestLog.GetQuestState("TutComplete")==QuestState.Active)
				{
					gameObject.camera.enabled=true;
					chalkboard.SetActive (false);
					zeroPhase=false;
					firstPhase=true;
				}
				ThoughtManager.activeID=3;
				ThoughtManager.thoughtID=5;
				ButtonAppear.activeButton=3;
				ThoughtManager.show=true;

					if(ThoughtManager.child32Active)
					{
						//page turn animation
						//Debug.Log ("WHAT!");
						BranchManager.justOne=true;
						StartCoroutine("Show",chalk);


					}
					if(ThoughtManager.child31Active)
					{
						BranchManager.justOne=true;
						StartCoroutine ("Show",blank);
						zeroPhase=false;
						firstPhase=true;
					}
					footprintHelp.text="Active thoughts can be interacted with by moving Mouse over them";

					ThoughtManager.mainThought="Have I been here before?";
					ThoughtManager.mainChild1Thought ="Yes";
					ThoughtManager.mainChild2Thought="No";
					ThoughtManager.child1Thought="I recall setting sail in an infinite ocean";
					ThoughtManager.child2Thought="This is all new to me";

				}

			if(firstPhase)
			{
			//	Debug.Log ("First Phase");
				ThoughtManager.thoughtID=5;
				
				if (ThoughtManager.activeID == 4) {	//self

					ThoughtManager.show=true;

					if(ThoughtManager.child42Active)
					{
						//page turn animation
						//Debug.Log ("WHAT!");\
						BranchManager.justOne=true;
						StartCoroutine("Show",playerCam);

					}
					if(ThoughtManager.child41Active)
					{
						BranchManager.justOne=true;
						ThoughtManager.mainThought3="These thoughts are mine..";
						StartCoroutine ("Show",blank);
					}

					ThoughtManager.thoughtID=5;
					ThoughtManager.mainThought="Are these my thoughts?";
					ThoughtManager.mainChild1Thought ="Yes";
					ThoughtManager.mainChild2Thought="I'm not sure";
					ThoughtManager.child1Thought="I'm alone in this boat";
					ThoughtManager.child2Thought="Am I ever truly alone?";
				}
				else
				{
					ThoughtManager.thoughtID=0;
				}
				
			}
			
			if(secondPhase)
			{
			//	Debug.Log ("Second Phase");
			ThoughtManager.show=true;
			
			if(ThoughtManager.activeID==4 && !selfDone)	//self
			{			
				if(ThoughtManager.child41Active)
					{
						//page turn animation
												BranchManager.justOne=true;
						StartCoroutine("CloseThought",tv);
						StartCoroutine ("Show",tvGuy);
						
						
					}
				if(ThoughtManager.child42Active)
					{
						//Debug.Log ("Show Mirror");
												BranchManager.justOne=true;
						StartCoroutine("CloseThought",wave);
						StartCoroutine("Show",waveCam);
					}
					
				ThoughtManager.thoughtID=5;
				ThoughtManager.mainThought="What am I doing here?";
				ThoughtManager.mainChild1Thought ="I'm dreaming";
				ThoughtManager.mainChild2Thought="I'm conscious";
				ThoughtManager.child1Thought="Nothing surrounds me here";
				ThoughtManager.child2Thought="I still feel the waves";
					
				
			}
			if(ThoughtManager.activeID==3)	//environment
			{
					ThoughtManager.thoughtID=3;
				if(ThoughtManager.mainActive3)
					{
						BranchManager.justOne=true;
						ThoughtManager.mainThought4="Maybe it is...";
					}
					else
					{
				ThoughtManager.mainThought4="This ocean seems infinite";		
					}
			}
			if(ThoughtManager.activeID==2)	//abstract
			{
					ThoughtManager.thoughtID=2;
				if(ThoughtManager.mainActive2)
					{
						BranchManager.justOne=true;
						ThoughtManager.mainThought3="Sweeping over trodden ground in my mind...";
						StartCoroutine ("Show",footprintCam);
					}
					else
					{	
						//BranchManager.zero=true;
				ThoughtManager.mainThought3="These waves...feel familiar";
					}
			}
		if(ThoughtManager.activeID==1)	//people
			{
					if(ThoughtManager.child11Active)
					{
						//page turn animation
						BranchManager.justOne=true;
						ThoughtManager.thoughtID=2;
						ThoughtManager.mainThought3="A solitary passenger on this journey";
												StartCoroutine("CloseThought",maskObj);
												StartCoroutine ("Show",mask);
						
					}
				else if(ThoughtManager.child12Active)
					{
						BranchManager.justOne=true;
						ThoughtManager.thoughtID=2;
						ThoughtManager.mainThought3="Sometimes echoing my own thoughts...";
						StartCoroutine ("Show",blank);
						
					}
					else
					{
				ThoughtManager.thoughtID=5;
				ThoughtManager.mainThought="Am I alone here?";
				ThoughtManager.mainChild1Thought ="Yes";
				ThoughtManager.mainChild2Thought="Maybe";
				ThoughtManager.child1Thought="I'm the only one here";
				ThoughtManager.child2Thought="A silent voice watches over me";
					}
			}
			}
			
			if(thirdPhase)
			{
				//Debug.Log ("Third Phase");
			ThoughtManager.show=true;
			
			if(ThoughtManager.activeID==2)	//self
			{			
	
				if(ThoughtManager.mainActive3)
					{
						//Debug.Log ("Show Mirror");
												BranchManager.justOne=true;
						footprintHelp.text="Some thoughts lead to an action";
						ThoughtManager.mainThought3="there's nothing for me here";
						StartCoroutine("Shift");
					}
					
				ThoughtManager.thoughtID=3;
				ThoughtManager.mainThought4="Emptiness fills this infinite ocean";
					
				
			}
				else
				{
					ThoughtManager.mainThought4="";
					ThoughtManager.mainThought3="";
				}
			
			}
		}
	
	}
	IEnumerator Show(GameObject obj)
	{
				if (zeroPhase) {
				
						if (obj == chalk) {
								tvGuy.SetActive (true);
								transCam.animation.Play ("TVZoom");
								yield return new WaitForSeconds(2f);
								gameObject.camera.enabled = false;
								TutorialScript.tutorialOn = true;
								chalkboard.SetActive (true);
								BranchManager.zero=true;

						}
				}

		if(firstPhase)
		{
		if(obj==playerCam)
		{
		
		obj.SetActive (true);
		gameObject.camera.enabled = false;
		ButtonAppear.active=false;
				footprintHelp.text="Thoughts are powerful \n They can trigger out of body imaginations";
	
		ThoughtManager.thoughtID=0;
		ThoughtManager.activeID=0;
								gameObject.camera.enabled = true;
								obj.SetActive (false);
		yield return new WaitForSeconds(2f);
		}
		if(obj==blank)
			{
				//footprintHelp.text="Some thoughts are just mere indication of state of mind";
				yield return new WaitForSeconds(2f);
			}
	
		firstPhase=false;
		secondPhase=true;
		gameObject.GetComponent<SmoothLookAt>().target=null;
		obj.SetActive (false);
			yield break;
			
		}
			else if(secondPhase)
		{
			if(obj==blank)
			{
				yield return new WaitForSeconds(2f);
				secondPhase=false;
				thirdPhase=true;
			}
				if(obj==waveCam)
				{
					obj.SetActive (true);
					ButtonAppear.active=false;
					ThoughtManager.thoughtID=2;
				footprintHelp.text="Some thoughts are just mere indication of state of mind";
					ThoughtManager.mainThought3="Simply drifting among the waves..";
				yield return new WaitForSeconds(3f);
					selfDone=true;
				gameObject.GetComponent<SmoothLookAt>().target=null;
		obj.SetActive (false);
				yield break;
				}
			if(obj==footprintCam)
			{
				obj.SetActive (true);
					ButtonAppear.active=false;
					footprintHelp.text="Some thoughts trigger abstract visions in your mind";
					ThoughtManager.thoughtID=1;
					ThoughtManager.mainThought2="Memories only a transient reminder of my passage";
				yield return new WaitForSeconds(4f);
				gameObject.GetComponent<SmoothLookAt>().target=null;
		obj.SetActive (false);
				yield break;
			}
						if (obj == tvGuy) {
								ButtonAppear.active = false;
								tvGuy.SetActive (true);
								gameObject.GetComponent<SmoothLookAt> ().target = tvGuy.transform;
								tvGuy.SetActive (true);
						}
		}
	
		yield return null;
		
	}
	IEnumerator CloseThought(Object child)
	{
		if(child==child1)
		{
			ThoughtManager.child42Active=false;
			ThoughtManager.thoughtID=0;
			ThoughtManager.activeID=0;
			yield return new WaitForSeconds(20f);
			if(firstPhase)
		{
			Debug.Log("FIRST OVER");
		firstPhase=false;
		secondPhase=true;
				yield break;
		}
			if(secondPhase)
			{
				secondPhase=false;
				thirdPhase=true;
			}
			yield break;
		}
		
		if(child==footprint)
		{
			ThoughtManager.thoughtID=2;
			ThoughtManager.mainThought3="Sweeping over trodden ground in my mind...";
			
		}
		
		else
		{
			ThoughtManager.child41Active=false;
			ThoughtManager.thoughtID=0;
			ThoughtManager.activeID=0;
			yield return new WaitForSeconds(1f);
			if(firstPhase)
		{
								//Debug.Log("NOT CORRECT FIRST OVER");
		firstPhase=false;
		secondPhase=true;
		}
			yield break;
		}
	}
	
	IEnumerator Shift()
	{
		footprintHelp.enabled=false;
		sinker.GetComponent<SinkerScript>().enabled=true;
				boatObj.SetActive (false);
		yield break;
	}
	
	
}
