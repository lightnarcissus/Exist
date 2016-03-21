using UnityEngine;
using System.Collections;

public class FaceWarScript : MonoBehaviour {
	
	public Material skybox;
	public static bool sheep=false;
	public static bool skull=false;
	public static bool gun=false;
	public static bool soldier=false;
	
	public GameObject sheepCam;
	public GameObject skullCam;
	public GameObject soldierCam;
	public GameObject gunCam;
	public GameObject mainCam;
	public GameObject orc;
	
	private int race;
	private int randThought=0;
	private float thoughtTimer=0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable()
	{
//		BlankDialogue.player=mainCam;
		race=HistoryScript.race;
		//DreamTracker.dream=2;
		RenderSettings.skybox=skybox;
		sheepCam.SetActive (false);
		skullCam.SetActive (false);
		soldierCam.SetActive (false);
		gunCam.SetActive (false);
		
			mainCam.SetActive(true);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		if(race==2)
		{
			//Debug.Log ("White Player");
			if(thoughtTimer>2f)
			{
			randThought=Random.Range (0,3);
			thoughtTimer=0f;
			}
			if(ThoughtManager.thoughtAppear && !ButtonAppear.active)
			{
			thoughtTimer+=Time.deltaTime;
				if(randThought==0)
				{
				ThoughtManager.activeID=4;
				ThoughtManager.thoughtID=5;
				ButtonAppear.activeButton=4;
				}
				if(randThought==1)
				{
				ThoughtManager.activeID=2;
				ThoughtManager.thoughtID=5;
				ButtonAppear.activeButton=2;
				}
				if(randThought==2)
				{
				ThoughtManager.activeID=2;
				ThoughtManager.thoughtID=5;
				ButtonAppear.activeButton=2;
				}
			}
			
			//Debug.Log ("Child1"+ThoughtManager.child1Active);
			
			 if(ThoughtManager.activeID==4)
			{
				ThoughtManager.show=true;
				//Debug.Log ("4");
				if(ThoughtManager.child41Active)
				{
					
				}
				if(ThoughtManager.child42Active)
				{
					
				}
				ThoughtManager.mainThought="Am I to be blamed?";
				ThoughtManager.mainChild1Thought ="Yes";
				ThoughtManager.mainChild2Thought="Maybe";
				ThoughtManager.child1Thought="I was part of this";
				ThoughtManager.child2Thought="My duty doesn't absolve my sins";
			}
			else if(ThoughtManager.activeID==3 && !skull)
			{
				ThoughtManager.show=true;
				if(ThoughtManager.mainActive1)
				{
					
					//do something HERE
					skull=true;
				}
				
				//Debug.Log ("3");
				ThoughtManager.mainThought2="Dreams of the Dead";
			}
			else if(ThoughtManager.activeID==2 && !gun)
			{
				ThoughtManager.show=true;
				//Debug.Log ("2");
				if(ThoughtManager.mainActive2)
				{
					gun=true;
				}
				if(ThoughtManager.mainActive3)
				{
					sheep=true;
				}
		
				ThoughtManager.mainThought3="We didn't help them";
				ThoughtManager.mainThought4="Their hatred makes more sense now";
			}
			
			else if(ThoughtManager.activeID==1 && !soldier)
			{		
				ThoughtManager.show=true;
				//Debug.Log ("1");
				if(ThoughtManager.mainActive1)
				{
					soldier=true;
				}
			
				ThoughtManager.mainThought2="We lost ourselves in the process...";
			}
		}
	
		if(sheep)
		{
			skull=false;
			gun=false;
			soldier=false;
			mainCam.SetActive(false);
			
			
			StartCoroutine (ScanStay(mainCam,sheepCam));
			orc.SetActive (false);
		}
		
		if(skull)
		{
			sheep=false;
			gun=false;
			soldier=false;
			//Debug.Log("AW YES!");
			StartCoroutine (ScanStay(mainCam,skullCam));
		}
		
		if(gun)
		{
			skull=false;
			sheep=false;
			soldier=false;
			
				StartCoroutine (ScanStay(mainCam,gunCam));
			orc.SetActive (true);
		}
		
		if(soldier)
		{
			skull=false;
			gun=false;
			soldier=false;
			
				StartCoroutine (ScanStay(mainCam,soldierCam));
			orc.SetActive (false);
		}
		
		if(!soldier && !gun && !sheep && !skull)
		{			
		mainCam.SetActive(true);
		sheepCam.SetActive (false);
		skullCam.SetActive (false);
		soldierCam.SetActive (false);
		gunCam.SetActive (false);
		orc.SetActive (false);
		}
		
		
		
	
	}
	
	IEnumerator ScanStay(GameObject currentCam, GameObject newCam)
	{
		((DepthOfFieldScatter)currentCam.GetComponent<DepthOfFieldScatter>()).enabled=true;
		yield return new WaitForSeconds(1f);
		if(currentCam==mainCam)
		{
		currentCam.camera.enabled=false;
		((DepthOfFieldScatter)currentCam.GetComponent<DepthOfFieldScatter>()).enabled=false;
		newCam.SetActive(true);
		}
		else
		{
		currentCam.SetActive(false);
		((DepthOfFieldScatter)currentCam.GetComponent<DepthOfFieldScatter>()).enabled=false;
		newCam.SetActive(true);
		}
		
		
	}
}
