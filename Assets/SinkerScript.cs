using UnityEngine;
using System.Collections;

public class SinkerScript : MonoBehaviour {
	
//	public GameObject mask;
	public GUIStyle sink;
	private float selectorTimer=0f;
	private Rect r1;
	public GameObject mainTerrain;
	//public GameObject sinkMan;
	//private Vector3 bottom;
	//public GameObject timer;
	//public GameObject selector;
//	public AudioSource riot;
//	public AudioSource waves;
//	public AudioSource scream1;
//	public AudioSource scream2;
	// Use this for initialization
	void Start () {
//		selector.SetActive (false);
		r1=new Rect(Screen.width/2f-330f,Screen.height/2f+50f,250f,250f);
		//bottom=new Vector3(sinkMan.transform.position.x+0.98f,sinkMan.transform.position.y-2f,sinkMan.transform.position.z-0.58f);
		//timer.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
/*		if(Input.GetKey (KeyCode.Return))		//REMOVE THIS
		{
			selectorTimer=28f;
		}
			*/
		
		//sinkMan.transform.position=Vector3.Lerp (transform.position,bottom,20f);
		if(selectorTimer>27f)
		{
			DreamTracker.start=true;
			DreamTracker.dream=0;
			//ChosenScript.selector=true;
			gameObject.SetActive (false);
			//screen fade into the crowdscene
		}
	}
	void OnGUI()
	{
		
		selectorTimer+=Time.deltaTime/2f;
		
		if(selectorTimer<3f)
		{
			//ambient sound
			//splash
		}
		
		if(selectorTimer>3f && selectorTimer<6f)
		{
			//activate camera
			GUI.Label(r1,"In the infinite ocean",sink);
			
		}	
		if(selectorTimer>6f && selectorTimer<9f)
		{
			GUI.Label(r1,"You sink slowly",sink);
		}	
		if(selectorTimer>9f && selectorTimer<12f)
		{
			//echo sound
		//	riot.volume=0.3f;
			//scream2.volume=0.2f;
			GUI.Label(r1,"You hear the echoes",sink);
			mainTerrain.GetComponent<ActivateSlowly>().enabled=true;
		}
		if(selectorTimer>12f && selectorTimer<15f)
		{
			//pain and agony
		//	scream1.volume=0.3f;
			
			GUI.Label(r1,"Of agony and pain",sink);
		}
		if(selectorTimer>15f && selectorTimer<18f)
		{
			//the noise appears
		//	riot.volume=0.4f;
			//waves.volume=0.7f;
			//scream1.volume=0.5f;
		//	scream2.volume=0.8f;
			GUI.Label(r1,"The noise keeps us connected",sink);
		}
		if(selectorTimer>18f && selectorTimer<21f)
		{
			//the noises grow more distant
			//riot.volume=0.4f;
			GUI.Label(r1,"Only as we grow more distant from ourselves",sink);
		}
		if(selectorTimer>21f && selectorTimer<23f)
		{
			//volume increase starts
		//	riot.volume=0.6f;
		//	waves.volume=0.5f;
		//	scream1.volume=0.8f;
		//	scream2.volume=0.6f;
			GUI.Label(r1,"It grows louder...",sink);
		}
		if(selectorTimer>23f && selectorTimer<25f)
		{
			//riot.volume=0.9f;
			//waves.volume=0.2f;
		GUI.Label(r1,"And louder...",sink);
		}
		if(selectorTimer>25f && selectorTimer<27f)
		{
			//riot.volume=1f;
			//noise reaches crescendo
		GUI.Label(r1,"Louder...",sink);
			
		}
		
		
	}
}
