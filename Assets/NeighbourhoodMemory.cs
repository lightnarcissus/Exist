using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class NeighbourhoodMemory : MonoBehaviour {
	
	public Material skybox;
	public static bool future=false;
	public GameObject pastBuildings;
	public GameObject futureBuildings;
	
	public GameObject ifColor;
	public GameObject ifWhite;
	
	public GameObject cam;
	
	public static GameObject mainPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable()
	{
		RenderSettings.skybox=skybox;
		
		//if(HistoryScript.race==2)
	//	{
			ifColor.SetActive (false);
			ifWhite.SetActive (true);
			mainPlayer=ifWhite;
		//DreamTracker.dream=7;
	/*	}
		else
		{
			ifColor.SetActive (true);
			ifWhite.SetActive (false);
			mainPlayer=ifColor;
		}*/
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
		if(ButtonAppear.active)
		{
			ThoughtManager.show=true;
			if(ThoughtManager.activeID==3)	//environment
			{
					ThoughtManager.thoughtID=3;
				if(ThoughtManager.mainActive3)
					{
						BranchManager.justOne=true;
						ThoughtManager.mainThought4="maybe the root was rotten";
					}
					else
					{
				ThoughtManager.mainThought4="Memories of my childhood";		
					}
			}
			if(ThoughtManager.activeID==2)	//abstract
			{
					ThoughtManager.thoughtID=2;
				if(ThoughtManager.mainActive2)
					{
						BranchManager.justOne=true;
						ThoughtManager.mainThought4="long before I could think for myself";
					}
					else
					{	
						//BranchManager.zero=true;
					
				ThoughtManager.mainThought3="Was my worldview molded here";
					}
			}
			if(ThoughtManager.activeID==1)	//abstract
			{
					ThoughtManager.thoughtID=2;
				if(ThoughtManager.mainActive2)
					{
						BranchManager.justOne=true;
						ThoughtManager.mainThought4="only now can I see the blindfold he wore";
					}
					else
					{	
						//BranchManager.zero=true;
					
				ThoughtManager.mainThought3="My father was always a patriot";
					}
			}
			
			if(ThoughtManager.activeID==3)
			{
				ThoughtManager.thoughtID=2;
				if(ThoughtManager.mainActive2)
					{
						BranchManager.justOne=true;
						ThoughtManager.mainThought4="a past that feels alien to me";
						StartCoroutine ("ExitCity");
					}
					else
					{	
						//BranchManager.zero=true;
					
				ThoughtManager.mainThought3="This is just a relic to me now";
					}
			}
		}
		
		if(QuestLog.GetQuestState ("FatherFuture")==QuestState.Active)
		{
			future=true;
		}
		
		if(future)
		{
			pastBuildings.SetActive (false);
			futureBuildings.SetActive (true);
			//Debug.Log ("SUP!");
		}
		else
		{
			pastBuildings.SetActive (true);
			futureBuildings.SetActive (false);
		}
	
	}
	
	IEnumerator ExitCity()
	{
		DreamTracker.dream=0;
		DreamTracker.change=true;
		yield return new WaitForSeconds(2f);
		yield break;
	}
	
	void OnConversationStart()
	{
		cam.GetComponent<MouseLook>().enabled=false;
	}
		void OnConversationEnd()
	{
		cam.GetComponent<MouseLook>().enabled=true;
	}
}
