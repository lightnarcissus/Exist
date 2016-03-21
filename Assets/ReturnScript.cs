using UnityEngine;
using System.Collections;

public class ReturnScript : MonoBehaviour {
	
	private GameObject current;
	private GameObject original;
	
	public GameObject mainCam;
	private float speed=2f;
	private float step;
	private bool distFlag=false;
	private bool flag=false;
	
	public AudioClip waves;
	private float shiftTimer=0f;

	
	
	public GameObject villagePlay;
	public GameObject faceWarPlay;
	public GameObject cloudPlay;
	
	public GameObject marriagePlay;
	
	
	public GameObject telepoleCam;
	public GameObject jobPlay;
	
	public GameObject Play;
	public GameObject tvCam;
	
	private float allowTimer=0f;
	
	// Use this for initialization
	void Start () {
		villagePlay.SetActive (false);	
		faceWarPlay.SetActive (false);
		cloudPlay.SetActive (false);
		marriagePlay.SetActive (false);
		jobPlay.SetActive (false);
		telepoleCam.SetActive (false);
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
			//	SoundManager.PlaySFX (mainCam,waves,false);
			}
			
			
			
		
			mainCam.GetComponent<NoiseAndGrain>().intensityMultiplier=2.5f*shiftTimer;
			
			if(shiftTimer>4f)
			{
				if(gameObject.name=="BillFace")
				{
					faceWarPlay.SetActive (true);
					mainCam.SetActive (false);
				}
				if(gameObject.name=="BillVillage")
				{
					villagePlay.SetActive (true);
					mainCam.SetActive (false);
				}
				
				if(gameObject.name=="BillHistory")
				{
					telepoleCam.SetActive(true);
					mainCam.SetActive (false);
					ResetCam(telepoleCam,mainCam,8f);
				}
				
				if(gameObject.name=="BillDream")
				{
					cloudPlay.SetActive (true);
					mainCam.SetActive(false);
				}
				
				if(gameObject.name=="CloudFire")
				{
					jobPlay.SetActive(true);
					cloudPlay.SetActive (false);
					ResetCam (jobPlay,mainCam,8f);
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


	
	void ResetCam(GameObject current,GameObject original,float time)
	{
		
		allowTimer+=Time.deltaTime;
		if(allowTimer>time)
		{
			original.SetActive(true);
			current.SetActive (false);
			allowTimer=0f;
		}
		
	}
}
