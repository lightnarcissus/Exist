using UnityEngine;
using System.Collections;

public class standScript : MonoBehaviour {
	
	public GameObject mainCam;
	private float speed=2f;
	private float step;
	private bool distFlag=false;
	private bool flag=false;
	
	public AudioClip waves;
	private float shiftTimer=0f;
	public GameObject graveMemory;
	
	public GameObject civMemory;
	
	
	public GameObject villagePlay;
	public GameObject selectorPlay;
	public GameObject tvCam;
	
	// Use this for initialization
	void Start () {
		villagePlay.SetActive (false);
		selectorPlay.SetActive(false);
		graveMemory.SetActive (false);
		civMemory.SetActive (false);
		tvCam.SetActive(false);
//		SoundManager.SetSFXCap(1);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(flag)
		{
//			Debug.Log (TutorialScript.reminisce);
		//	Debug.Log ("MOVING TOWARDS!");
		//	step = speed * Time.deltaTime;
     //   mainCam.transform.position = Vector3.MoveTowards(mainCam.transform.position, transform.position, step);
			((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).enabled=true;
			((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).focalTransform=transform;
			shiftTimer+=Time.deltaTime;
			if(shiftTimer>0f && shiftTimer<4f)
			{
				//SoundManager.PlaySFX (waves);
			}
			
		 TutorialScript.reminisce=true;
			mainCam.GetComponent<NoiseAndGrain>().intensityMultiplier=2.5f*shiftTimer;
			
			if(shiftTimer>4f)
			{
				if(gameObject.name=="Grave")
				{
				graveMemory.SetActive(true);
					TutWheel.deadOak=true;
				mainCam.SetActive(false);
				}
				
				if(gameObject.name=="ClockHand")
				{
				civMemory.SetActive(true);
					TutWheel.otherside=true;
				mainCam.SetActive(false);
				}
				
				if(gameObject.name=="Door")
				{
				mainCam.SetActive(true);
				civMemory.SetActive(false);
					TutWheel.otherside=false;
				}
				shiftTimer=0f;
			}
		}
		else
		{
			if(!Input.GetMouseButton(0) && !TutorialScript.reminisce)
			((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).enabled=false;
		//	Debug.Log ("Not moving towards");
			if(mainCam.GetComponent<NoiseAndGrain>().intensityMultiplier>=1.5f)
			{
				mainCam.GetComponent<NoiseAndGrain>().intensityMultiplier-=Time.deltaTime;
			}
			
			if(shiftTimer>0f)
			shiftTimer-=Time.deltaTime;
		}
	
	
	}
	
	void FixedUpdate()
	{
		if(Vector3.Distance (transform.position,mainCam.transform.position)<=10f)
		{
				if(renderer.isVisible)
				{
					flag=true;
				}
		}
		else
		{
			flag=false;
		}
	}
	
	
/*	void OnBecameVisible() {
		if(Vector3.Distance(transform.position,mainCam.transform.position)<=10f)
		{
		flag=true;
       Debug.Log("You see me!");
		}
    }*/
	
	
	void OnBecameInvisible() {
		flag=false;
		if(mainCam!=null && !Input.GetMouseButton(0))
		{
		((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).enabled=false;
			TutorialScript.reminisce=false;
		}
     //  Debug.Log("Cannot see me");
    }
}
