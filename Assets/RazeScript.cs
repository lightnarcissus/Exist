using UnityEngine;
using System.Collections;

public class RazeScript : MonoBehaviour {
	
	
	public GameObject window;
	public static bool allow=false;
	public static bool blow=false;
	public static int dreamCount=0;
	public static bool rocketAllow=true;
	public static bool bookAllow=true;
	public static bool artistAllow=true;
	
	public GameObject rocketLater;
	public GameObject rocketDream;
	
	public GameObject bookLater;
	public GameObject bookDream;
	
	public GameObject artistLater;
	public GameObject artistDream;
	
	public GameObject fatherLater;
	public GameObject fatherDream;
	
	public GameObject fire;
	public GameObject eyeGuys;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable()
	{
		//DreamTracker.dream=7;
//		BlankDialogue.player=gameObject;
		
		rocketDream.SetActive (true);
		rocketLater.SetActive (false);
		
		bookDream.SetActive (true);
		bookLater.SetActive (false);
		
		artistDream.SetActive (true);
		artistLater.SetActive (false);
		
		fatherDream.SetActive (true);
		fatherLater.SetActive (false);
		
		fire.SetActive (false);
		eyeGuys.SetActive (true);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(dreamCount==2)
		{
			allow=true;
		}
		if(!rocketAllow)
		{
			rocketDream.SetActive (false);
			rocketLater.SetActive (true);
		}
		
		if(!bookAllow)
		{
			bookDream.SetActive (false);
			bookLater.SetActive (true);
		}
		
		if(!artistAllow)
		{
			artistDream.SetActive (false);
			artistLater.SetActive (true);
		}
		
		if(blow)
		{
			fatherDream.SetActive (false);
			fatherLater.SetActive (true);
		
			fire.SetActive(true);
			eyeGuys.SetActive (false);
		}
	
	}
	
	void OnDisable()
	{
		
	}
}
