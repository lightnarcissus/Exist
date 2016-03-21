using UnityEngine;
using System.Collections;

public class CageRoom : MonoBehaviour {
	
	public GameObject whitePlayer;
	public GameObject wavyPlayer;
	public GameObject blackPlayer;
	public GameObject whiteNPC;
	public GameObject wavyNPC;
	public GameObject blackNPC;
	
	public GameObject blackCam;
	public GameObject wavyCam;
	public GameObject whiteCam;
	
	private int race=2;
	private int randThought=0;
	private float thoughtTimer=0f;
	
	private GameObject mainCam;
	public GameObject historyChain;
	public GameObject neighbourhood;
	public GameObject chainedCircle;
	public GameObject eyeCircle;
	
	public GameObject wavyCage;
	public GameObject blackCage;
	
	
	// Use this for initialization
	void Start () {
		
		blackPlayer.SetActive (false);
		wavyPlayer.SetActive (false);
		whitePlayer.SetActive (false);
		whiteNPC.SetActive (false);
		wavyNPC.SetActive (false);
		blackNPC.SetActive (false);
		eyeCircle.SetActive (false);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		
	/*	if(HistoryScript.race==0)
		{
			blackPlayer.SetActive (true);
			whiteNPC.SetActive (true);
			wavyNPC.SetActive (true);
			mainCam=blackCam;
			race=0;
		}
		else if(HistoryScript.race==1)
		{
			blackNPC.SetActive (true);
			whiteNPC.SetActive (true);
			wavyPlayer.SetActive (true);
			mainCam=wavyCam;
			race=1;
		}
		else
		{
			blackNPC.SetActive (true);
			whitePlayer.SetActive (true);
			wavyNPC.SetActive (true);
			mainCam=whiteCam;
			race=2;
		}
		*/
		if(race==0)
		{
			//Debug.Log ("Black Player");
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
					StartCoroutine("ChildChoose",41);
				}
				if(ThoughtManager.child42Active)
				{
					StartCoroutine("ChildChoose",42);
				}
				ThoughtManager.mainThought="Why am I caged?";
				ThoughtManager.mainChild1Thought ="It's them";
				ThoughtManager.mainChild2Thought="It's me";
				ThoughtManager.child1Thought="They hate me";
				ThoughtManager.child2Thought="I hate them";
			}
			else if(ThoughtManager.activeID==3)
			{
				ThoughtManager.show=true;
				//Debug.Log ("3");
				if(ThoughtManager.child31Active)
				{
					//Debug.Log ("CHILD ONE");
					StartCoroutine("ChildChoose",31);
				}
				if(ThoughtManager.child32Active)
				{
					//Debug.Log ("CHILD TWO");
					StartCoroutine("ChildChoose",32);
				}
				ThoughtManager.mainThought="How can I escape?";
				ThoughtManager.mainChild1Thought ="Lock";
				ThoughtManager.mainChild2Thought="Break";
				ThoughtManager.child1Thought="I need a key";
				ThoughtManager.child2Thought="I'm not strong enough";
			}
			else if(ThoughtManager.activeID==2)
			{
				ThoughtManager.show=true;
				//Debug.Log ("2");
				if(ThoughtManager.child21Active)
				{
					StartCoroutine("ChildChoose",21);
					gameObject.GetComponent<SmoothLookAt>().target=wavyNPC.transform;
					
				}
				if(ThoughtManager.child22Active)
				{
					StartCoroutine("ChildChoose",22);
					gameObject.GetComponent<SmoothLookAt>().target=whiteNPC.transform;
				}
				ThoughtManager.mainThought="Who are the others?";
				ThoughtManager.mainChild1Thought ="Prisoners";
				ThoughtManager.mainChild2Thought="'Victims'";
				ThoughtManager.child1Thought="Just like me";
			ThoughtManager.child2Thought="Trapped by their own device";
			}
			
			else if(ThoughtManager.activeID==1)
			{		
				ThoughtManager.show=true;
				//Debug.Log ("1");
				if(ThoughtManager.child11Active)
				{
					StartCoroutine("ChildChoose",11);
				}
				if(ThoughtManager.child12Active)
				{
			
					StartCoroutine("ChildChoose",12);
				}
				ThoughtManager.mainThought="I have been here...";
				ThoughtManager.mainChild1Thought ="forever";
				ThoughtManager.mainChild2Thought="since then";
				ThoughtManager.child1Thought="I'm not the first";
			ThoughtManager.child2Thought="Where it began...";
			}
		}
		else if(race==1)
		{
			
			if(thoughtTimer>10f)
			{
			randThought=Random.Range (0,3);
			thoughtTimer=0f;
			}
			if(!ThoughtManager.thoughtActive)
			thoughtTimer+=Time.deltaTime;
			
			if(randThought==0)
			{
				ThoughtManager.mainThought="";
				ThoughtManager.mainChild1Thought ="";
				ThoughtManager.mainChild2Thought="";
				ThoughtManager.child1Thought="";
				ThoughtManager.child2Thought="";
			}
			else if(randThought==1)
			{
				ThoughtManager.mainThought="";
				ThoughtManager.mainChild1Thought ="";
				ThoughtManager.mainChild2Thought="";
				ThoughtManager.child1Thought="";
				ThoughtManager.child2Thought="";
			}
			else
			{
				ThoughtManager.mainThought="";
				ThoughtManager.mainChild1Thought ="";
				ThoughtManager.mainChild2Thought="";
				ThoughtManager.child1Thought="";
				ThoughtManager.child2Thought="";
			}
			
		}
	else if(race==2)
		{
			//Debug.Log ("White Player");
			if(thoughtTimer>4f)
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
					StartCoroutine("ChildChoose",41);
				}
				if(ThoughtManager.child42Active)
				{
					StartCoroutine("ChildChoose",42);
				}
				ThoughtManager.mainThought="Why was I caged?";
				ThoughtManager.mainChild1Thought ="It's them";
				ThoughtManager.mainChild2Thought="It's me";
				ThoughtManager.child1Thought="They hate me";
				ThoughtManager.child2Thought="I hate them";
			}
			else if(ThoughtManager.activeID==3)
			{
				ThoughtManager.show=true;
				//Debug.Log ("3");
				if(ThoughtManager.child31Active)
				{
					//Debug.Log ("CHILD ONE");
					StartCoroutine("ChildChoose",31);
				}
				if(ThoughtManager.child32Active)
				{
					//Debug.Log ("CHILD TWO");
					StartCoroutine("ChildChoose",32);
				}
				ThoughtManager.mainThought="Why don't they escape?";
				ThoughtManager.mainChild1Thought ="Cages";
				ThoughtManager.mainChild2Thought="People";
				ThoughtManager.child1Thought="They're an illusion";
				ThoughtManager.child2Thought="They're not strong enough";
			}
			else if(ThoughtManager.activeID==2)
			{
				ThoughtManager.show=true;
				//Debug.Log ("2");
				if(ThoughtManager.child21Active)
				{
					StartCoroutine("ChildChoose",21);
					gameObject.GetComponent<SmoothLookAt>().target=wavyNPC.transform;
					
				}
				if(ThoughtManager.child22Active)
				{
					StartCoroutine("ChildChoose",22);
					gameObject.GetComponent<SmoothLookAt>().target=whiteNPC.transform;
				}
				ThoughtManager.mainThought="Who are the others?";
				ThoughtManager.mainChild1Thought ="Prisoners";
				ThoughtManager.mainChild2Thought="'Victims'";
				ThoughtManager.child1Thought="Just like me";
			ThoughtManager.child2Thought="Trapped by their own device";
			}
			
			else if(ThoughtManager.activeID==1)
			{		
				ThoughtManager.show=true;
				//Debug.Log ("1");
				if(ThoughtManager.child11Active)
				{
					StartCoroutine("ChildChoose",11);
				}
				if(ThoughtManager.child12Active)
				{
			
					StartCoroutine("ChildChoose",12);
				}
				ThoughtManager.mainThought="I have been here...";
				ThoughtManager.mainChild1Thought ="forever";
				ThoughtManager.mainChild2Thought="since then";
				ThoughtManager.child1Thought="I'm not the first";
			ThoughtManager.child2Thought="Where it began...";
			}
		}
	
	}
	
	IEnumerator ChildChoose(int child)
	{
		
		yield return new WaitForSeconds(1f);
		if(child==11)
		{
			//brief glimpse of History Chains Us
			mainCam.SetActive (false);
			historyChain.SetActive (true);
			yield return new WaitForSeconds(4f);
			mainCam.SetActive (true);
			historyChain.SetActive (false);			
		}
		if(child==12)
		{
			//neighbourhood
			mainCam.SetActive (false);
			NeighbourhoodMemory.mainPlayer.SetActive (true);		
		}
		if(child==21)
		{
			//chained victims circle
			mainCam.SetActive (false);
			chainedCircle.SetActive (true);
			
		}
		if(child==22)
		{
		}
		if(child==31)
		{
		}
		if(child==32)
		{
			
		}
		if(child==41)
		{
			//Eye Guys Circle
			if(race==0)
			{
				blackCage.SetActive (false);
				blackCam.transform.parent.gameObject.GetComponent<CharacterMotor>().canControl=false;
				eyeCircle.SetActive (true);
				yield return new WaitForSeconds(4f);
				blackCage.SetActive (true);
				eyeCircle.SetActive (false);
				blackCam.transform.parent.gameObject.GetComponent<CharacterMotor>().canControl=true;
			}
			if(race==1)
			{
				wavyCage.SetActive (false);
				wavyCam.transform.parent.gameObject.GetComponent<CharacterMotor>().canControl=false;
				eyeCircle.SetActive (true);
				yield return new WaitForSeconds(4f);
				wavyCage.SetActive (true);
				eyeCircle.SetActive (false);
				wavyCam.transform.parent.gameObject.GetComponent<CharacterMotor>().canControl=true;
			}
		}
		if(child==42)
		{
			//shattered mirror
			
		}
		
		ButtonAppear.active=false;
		
	}
}
