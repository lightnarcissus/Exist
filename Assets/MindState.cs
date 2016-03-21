using UnityEngine;
using System.Collections;

public class MindState : MonoBehaviour {
	
	//hate level
	//on a scale of 5
	public int hateLevel=5;
	public int privilegeAware=0;
	public int warGuilt=5;
	public int anarchyLevel=0;
	
	private int randChance=0;
	private int randThought=0;
	private float randTimer=25f;
	
	public static bool villageVisit=false;
	public static bool lostVisit=false;
	public static bool tortureVisit=false;
	public static bool faceVisit=false;
	public static bool Visit=false;
	
	//summation, optional
	public int progressLevel=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(DreamTracker.dream==0)
		{
		if(randTimer<30f)
		randTimer+=Time.deltaTime;
		else
		{
			randChance=Random.Range (1,5);
			randThought=Random.Range (1,5);
			randTimer=0f;
		}
		
		if(randChance==1)	//hate level
		{
			if(hateLevel>3)
			{
				if(randThought==1)
				{
					if(ThoughtManager.activeID==4)
					{
						ThoughtManager.thoughtID=1;
						ThoughtManager.mainThought2="";
					}
				}
				if(randThought==2)
				{
					if(ThoughtManager.activeID==3)
					{
						ThoughtManager.thoughtID=1;
						ThoughtManager.mainThought2="";
					}
				}
				if(randThought==3)
				{
					if(ThoughtManager.activeID==4)
					{
						ThoughtManager.thoughtID=1;
						ThoughtManager.mainThought2="";
					}
				}
				if(randThought==4)
				{
					if(ThoughtManager.activeID==2)
					{
						ThoughtManager.thoughtID=1;
						ThoughtManager.mainThought2="";
					}
				}
			}
			else if(hateLevel<=3 && hateLevel>1)
			{
				if(randThought==1)
				{
					if(ThoughtManager.activeID==4)
					{
						ThoughtManager.thoughtID=1;
						ThoughtManager.mainThought2="";
					}
				}
				if(randThought==2)
				{
					if(ThoughtManager.activeID==3)
					{
						ThoughtManager.thoughtID=1;
						ThoughtManager.mainThought2="";
					}
				}
				if(randThought==3)
				{
					if(ThoughtManager.activeID==4)
					{
						ThoughtManager.thoughtID=1;
						ThoughtManager.mainThought2="";
					}
				}
				if(randThought==4)
				{
					if(ThoughtManager.activeID==2)
					{
						ThoughtManager.thoughtID=1;
						ThoughtManager.mainThought2="";
					}
				}
				
			}
			else
			{
				if(randThought==1)
				{
					if(ThoughtManager.activeID==4)
					{
						ThoughtManager.thoughtID=1;
						ThoughtManager.mainThought2="";
					}
				}
				if(randThought==2)
				{
					if(ThoughtManager.activeID==3)
					{
						ThoughtManager.thoughtID=1;
						ThoughtManager.mainThought2="";
					}
				}
				if(randThought==3)
				{
					if(ThoughtManager.activeID==4)
					{
						ThoughtManager.thoughtID=1;
						ThoughtManager.mainThought2="";
					}
				}
				if(randThought==4)
				{
					if(ThoughtManager.activeID==2)
					{
						ThoughtManager.thoughtID=1;
						ThoughtManager.mainThought2="";
					}
				}
			}
			
		}
		}
	
	}
}
