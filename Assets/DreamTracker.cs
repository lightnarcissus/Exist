using UnityEngine;
using System.Collections;

public class DreamTracker : MonoBehaviour {
	
	public static int dream=0;
	/*
	 0 for City
	 1 for VillageWar
	 2 for FaceWar
	 3 for TortureWar
	 4 for ExecutionDream
	5 for GrillDream
	6 for HarassDream
	7 for Neighborhood
	8 for CageDream
	9 for OilDream
	10 for FenceWar
	11 for VictimWar
	12 for LostTown

	13 for StreamDream
	14 for CloudDream
	
	15 for SelectorDream
	16 for SeaMenu
	*/
	
	public GameObject cityCam;
	public GameObject villageCam;
	public GameObject faceCam;
	public GameObject tortureCam;
	public GameObject executionCam;
	public GameObject grillCam;
	public GameObject harassCam;
	public GameObject neighborCam;
	public GameObject cageCam;
	public GameObject oilCam;
	public GameObject fenceCam;
	public GameObject victimCam;
	public GameObject lostCam;
	
	public GameObject streamCam;
	public GameObject cloudCam;
	
	public GameObject selectorCam;
	public GameObject seaCam;
	
	public static GameObject currentCam;
	public static bool change=true;
	
	public static bool start=false;
	
	public GameObject sound;
	public GameObject mainTerrain;
		public static bool startMenu=false;

	public Material eerie;
	public Material nightSky;
	public Material dark;
	public Material sunny;
	public Material overcast;
	public Material clear;
	public Material dawnDusk;
	// Use this for initialization
	void Start () {

		currentCam = cageCam;
		RenderSettings.skybox = eerie;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
	if(start)
		{
			sound.SetActive (true);
			mainTerrain.GetComponent<ActivateSlowly>().enabled=true;
			dream=0;
			start=false;
		}
		
	if(change)
		{		
		if(dream==0)
		{
			currentCam.SetActive(false); //because it is city
			cityCam.camera.enabled=true;
				RenderSettings.skybox=eerie;
			currentCam=cityCam;
			change=false;
		}
			if(dream==1)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			villageCam.SetActive (true);
				currentCam=villageCam;
			change=false;
		}
			
		if(dream==2)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			faceCam.SetActive (true);
				currentCam=faceCam;
			change=false;
		}
			
			if(dream==3)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			tortureCam.SetActive (true);
				currentCam=tortureCam;
			change=false;
		}
			
			if(dream==4)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			executionCam.SetActive (true);
				currentCam=executionCam;
			change=false;
		}
			
			if(dream==5)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			grillCam.SetActive (true);
			currentCam=grillCam;
			change=false;
		}
			
			if(dream==6)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			harassCam.SetActive (true);
				currentCam=harassCam;
			change=false;
		}
			
			if(dream==7)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			neighborCam.SetActive (true);
				currentCam=neighborCam;
			change=false;
			}
			if(dream==8)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			cageCam.SetActive (true);
				currentCam=cageCam;
			change=false;
		}
		
			if(dream==9)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			oilCam.SetActive (true);
				currentCam=oilCam;
			change=false;
		}
			
			if(dream==10)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			fenceCam.SetActive (true);
				currentCam=fenceCam;
			change=false;
		}
			
			if(dream==11)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			victimCam.SetActive (true);
				currentCam=victimCam;
			change=false;
		}
		
			if(dream==12)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			lostCam.SetActive (true);
				currentCam=lostCam;
			change=false;
		}
			
			if(dream==14)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			cloudCam.SetActive (true);
				currentCam=cloudCam;
			change=false;
		}
			
			if(dream==13)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			streamCam.SetActive (true);
				currentCam=streamCam;
			change=false;
		}
			
			if(dream==15)
		{
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);
			
			selectorCam.SetActive (true);
				currentCam=selectorCam;
			change=false;
		}
			
						if(dream==16)
		{
						
			if(currentCam=cityCam)
			cityCam.camera.enabled=false;
			else
			currentCam.SetActive (false);

								if (startMenu) 
								{

								} 
								else {
										seaCam.SetActive (true);
										currentCam = seaCam;
										change = false;
										}
		}
	
	
		}
	}
}
