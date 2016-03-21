using UnityEngine;
using System.Collections;

public class PlaylistScript : MonoBehaviour {
	
	public GameObject faceWar; //5
	public GameObject war; // 2, 3, 4
	public GameObject cage;
	public GameObject poorCity;
	public GameObject neighborhood;
	public GameObject sea;
	public GameObject forest;
	public GameObject selector;
	public GameObject oil;
	public GameObject longEerie;
	public GameObject shortScary;

	public static int music=100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(DreamTracker.dream==0 || music==0)
		{
			poorCity.SetActive (true);
			
			war.SetActive (false);
			faceWar.SetActive (false);
			neighborhood.SetActive (false);
			sea.SetActive (false);
			cage.SetActive (false);
			forest.SetActive (false);
			selector.SetActive (false);
			oil.SetActive (false);
			shortScary.SetActive (false);
			longEerie.SetActive (false);
			
		}
		
		if(DreamTracker.dream==1 || DreamTracker.dream==3 || DreamTracker.dream==4 || DreamTracker.dream==12|| music==1)
		{
			war.SetActive (true);
			
			poorCity.SetActive (false);
			faceWar.SetActive (false);
			neighborhood.SetActive (false);
			sea.SetActive (false);
			cage.SetActive (false);
			forest.SetActive (false);
			selector.SetActive (false);
			oil.SetActive (false);
			shortScary.SetActive (false);
			longEerie.SetActive (false);
		}
		
		if(DreamTracker.dream==2 || DreamTracker.dream==6|| music==3)
		{
			faceWar.SetActive (true);
			
			poorCity.SetActive (false);
			war.SetActive (false);
			neighborhood.SetActive (false);
			sea.SetActive (false);
			cage.SetActive (false);
			forest.SetActive (false);
			selector.SetActive (false);
			oil.SetActive (false);
			shortScary.SetActive (false);
			longEerie.SetActive (false);
		}
		
		if(DreamTracker.dream==7|| music==4)
		{
			neighborhood.SetActive (true);
			
			poorCity.SetActive (false);
			faceWar.SetActive (false);
			war.SetActive (false);
			sea.SetActive (false);
			cage.SetActive (false);
			forest.SetActive (false);
			selector.SetActive (false);
			oil.SetActive (false);
			shortScary.SetActive (false);
			longEerie.SetActive (false);
		}
		
		if(DreamTracker.dream==5 ||DreamTracker.dream==8|| music==5)
		{
			cage.SetActive (true);
			
			poorCity.SetActive (false);
			faceWar.SetActive (false);
			war.SetActive (false);
			sea.SetActive (false);
			neighborhood.SetActive (false);
			forest.SetActive (false);
			selector.SetActive (false);
			oil.SetActive (false);
			shortScary.SetActive (false);
			longEerie.SetActive (false);
		}
		
		
		
		
		if(DreamTracker.dream==15|| music==6)
		{
			selector.SetActive (true);
			
			poorCity.SetActive (false);
			faceWar.SetActive (false);
			war.SetActive (false);
			neighborhood.SetActive (false);
			cage.SetActive (false);
			forest.SetActive (false);
			sea.SetActive (false);
			oil.SetActive (false);
			shortScary.SetActive (false);
			longEerie.SetActive (false);
		}
		
		if(DreamTracker.dream==16|| music==7)
		{
			sea.SetActive (true);
			
			poorCity.SetActive (false);
			faceWar.SetActive (false);
			war.SetActive (false);
			neighborhood.SetActive (false);
			cage.SetActive (false);
			forest.SetActive (false);
			selector.SetActive (false);
			oil.SetActive (false);
			shortScary.SetActive (false);
			longEerie.SetActive (false);
		}
	
	
	}
}
