using UnityEngine;
using System.Collections;

public class Bomber : MonoBehaviour {
	
	/*public static int bodyChoice=0;
	public GameObject male;
	public GameObject femaleBip;
	public GameObject maleBip;
	public GameObject female;
	private GameObject active;
	public static int skinChoice=0;
	public Material black;
	public Material wavy;
	public Material white;*/
	public static GameObject bombSite;
	public static GameObject location1;
	public static GameObject location2;
	public static int selectionRand=0;
	public GameObject blackFem;
	public GameObject whiteFem;
	public GameObject wavyFem;
	public GameObject blackMale;
	public GameObject whiteMale;
	public GameObject wavyMale;
	public static GameObject active;
	public static bool once=true;
	public static int locationRand=0;
	public static bool loc1=false;
	public static bool loc2=false;
	public static bool loc3=false;
	public static bool bomb=false;
	public static bool boom=false;
	
	public static GameObject currentLoc;
	
	private int randOption=0;
	// Use this for initialization
	void Start () {
				
			locationRand=Random.Range (0,2);
			//locationRand=1;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(HistoryScript.preset==1)
		{
			if(once)
			{
			randOption=Random.Range (0,2);
			if(randOption==0)
			Instantiate (wavyMale,new Vector3(30f,0f,257f),Quaternion.identity);
			if(randOption==1)
			Instantiate (wavyFem,new Vector3(30f,0f,257f),Quaternion.identity);
			once=false;	
			}
		}
		
		if(HistoryScript.preset==2)
		{
			if(once)
			{
			randOption=Random.Range (0,3);
			if(randOption==0)
			Instantiate (whiteMale,new Vector3(30f,0f,257f),Quaternion.identity);
			if(randOption==1)
			Instantiate (wavyMale,new Vector3(30f,0f,257f),Quaternion.identity);	
			if(randOption==2)
			Instantiate (blackMale,new Vector3(30f,0f,257f),Quaternion.identity);
			once=false;
			}
		}
	
/*	if(StarterScript.ready)
		{
			
		if(once)
		{Debug.Log("Bomber Spanwed");
			
			if(SkinSelect.skinChoose==0)		// player is Black
			{
				if(MirrorScript.gender==0)
				{
					selectionRand=5;
					active=whiteMale;
					Instantiate (whiteMale,new Vector3(30f,0f,257f),Quaternion.identity);
					once=false;
				}
				else
				{
					selectionRand=2;
					active=whiteFem;
					Instantiate (whiteFem,new Vector3(30f,0f,257f),Quaternion.identity);
					once=false;
				}
			}
			if(SkinSelect.skinChoose==1)		// player is wavy
			{
				if(MirrorScript.gender==0)
				{
					selectionRand=4;
					active=wavyMale;
					Instantiate (wavyMale,new Vector3(30f,0f,257f),Quaternion.identity);
					once=false;
				}
				else
				{
					selectionRand=1;
					active=wavyFem;
					Instantiate (wavyFem,new Vector3(30f,0f,257f),Quaternion.identity);
					once=false;
				}
			}
			
			if(SkinSelect.skinChoose==2)		//player is white
			{
				if(MirrorScript.gender==0)
				{
					randOption=Random.Range (0,2);
					if(randOption==0)
					{
					selectionRand=4;
					active=wavyMale;
					Instantiate (wavyMale,new Vector3(30f,0f,257f),Quaternion.identity);
					}
					else
					{
					selectionRand=3;
					active=blackMale;
					Instantiate (blackMale,new Vector3(30f,0f,257f),Quaternion.identity);
					}
					once=false;
						
				}
				else
				{
					randOption=Random.Range (0,2);
					if(randOption==0)
					{
					selectionRand=1;
					active=wavyFem;
					Instantiate (wavyFem,new Vector3(30f,0f,257f),Quaternion.identity);
					}
					else
					{
					selectionRand=0;
					active=blackFem;
					Instantiate (blackFem,new Vector3(30f,0f,257f),Quaternion.identity);
					}
					once=false;
				}
			}
		}
		
			

		
		if(PreBirthScript.timer<600f && PreBirthScript.timer>590f)
		{
			if(locationRand==0)
			{		
				bombSite=GameObject.FindGameObjectWithTag("Rally");
				location1=GameObject.FindGameObjectWithTag ("War");
				
			}
		if(locationRand==1)
			{		
				bombSite=GameObject.FindGameObjectWithTag ("War");
				location1=GameObject.FindGameObjectWithTag ("Rally");		
			}
			
			
		}
		
		if(PreBirthScript.timer<498f && PreBirthScript.timer>495f)
		{
			loc1=true;
			currentLoc=location1;
		}
		
		if(PreBirthScript.timer<250f && PreBirthScript.timer>248f)
		{
			loc2=false;
			bomb=true;
			currentLoc=bombSite;
		}
		}*/
	}
}
