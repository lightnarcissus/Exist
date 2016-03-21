using UnityEngine;
using System.Collections;

public class MemoryScript : MonoBehaviour {
	
	public GameObject mainCam;
	private float speed=2f;
	private float step;
	private bool distFlag=false;
	private bool flag=false;
	
	public AudioClip waves;
	private float shiftTimer=0f;
	
	
	public GameObject villageMemory;
	public static bool visitedVillage=false;
	public GameObject warFaceMemory;
	
	public GameObject fenceMemory;
	public GameObject lostCityMemory;
		
	public GameObject neighborMemory;
	public GameObject tortureMemory;
	public GameObject grassfieldMemory;
	public GameObject victimMemory;
	public GameObject executionMemory;
	public GameObject cageMemory;
	public GameObject oilMemory;
	public GameObject governmentMemory;
	public GameObject apathyMemory;
	
	public GameObject racistMemory;
	public GameObject cloudMemory;
	public GameObject streamMemory;
	public GameObject privilegeMemory;

	
	
	private float lerpParam=0f;
	
	
	public static bool reminisce=false;
	
	private bool flashOnce=true;
	
	// Use this for initialization
	void Start () {
	//	mainCam.GetComponent<PP_LightWave>().enabled=false;
		//SoundManager.SetSFXCap(1);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(flag)
		{
//			Debug.Log (TutorialScript.reminisce);
		//	Debug.Log ("MOVING TOWARDS!");
		//	step = speed * Time.deltaTime;
     //   mainCam.transform.position = Vector3.MoveTowards(mainCam.transform.position, transform.position, step);
			

			shiftTimer+=Time.deltaTime;
			if(shiftTimer>0f && shiftTimer<2f)
			{
				((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).enabled=true;
			((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).focalTransform=transform;
				//SoundManager.PlaySFX (waves);
				//wavesPlayer.SetActive (true);
			}
			
			reminisce=true;
		//	mainCam.GetComponent<NoiseAndGrain>().intensityMultiplier=4f*shiftTimer;
			
			if(shiftTimer>2f)
			{
				
				// All relevant dreams-object associations here
				
			/*	if(gameObject.name=="Telepole")
				{
						if(flashOnce)
						StartCoroutine(FlashOnly (racistMemory,0));
				}
				if(gameObject.name=="ArmyBoss")
				{
					StartCoroutine (ScanBlip(mainCam,warFaceMemory));
				}
				*/
				if(gameObject.name=="Village")
				{
					DreamTracker.dream=1;
					DreamTracker.change=true;
				}
				
				else if(gameObject.name=="Cage")
				{
					 DreamTracker.dream=8;
					DreamTracker.change=true;
			
				}
				
				
				shiftTimer=0f;
			}
		}
		else
		{
			if(!Input.GetMouseButton(0) && !reminisce)
			{
			((DepthOfFieldScatter)mainCam.GetComponent<DepthOfFieldScatter>()).enabled=false;
				//wavesPlayer.SetActive (false);
			}
		//	Debug.Log ("Not moving towards");
			
			if(shiftTimer>0f)
			shiftTimer-=Time.deltaTime;
		}
	
	
	}
	
	void FixedUpdate()
	{
		//if(Vector3.Distance (transform.position,mainCam.transform.position)<=10f)
		if(InteractionScript.bull)
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
			reminisce=false;
		}
     //  Debug.Log("Cannot see me");
    }
	IEnumerator ScanBlip(GameObject currentCam, GameObject newCam)
	{
		mainCam.GetComponent<PP_Scanlines>().enabled=true;
		mainCam.GetComponent<PP_SecurityCamera>().enabled=true;
		mainCam.GetComponent<PP_LightWave>().enabled=true;
		yield return new WaitForSeconds(1f);
		
		if(newCam==warFaceMemory)
		{
		mainCam.SetActive (false);
		warFaceMemory.SetActive (true);
		yield return new WaitForSeconds(0.5f);
		mainCam.GetComponent<PP_Scanlines>().enabled=false;
		mainCam.GetComponent<PP_SecurityCamera>().enabled=false;	
		mainCam.GetComponent<PP_LightWave>().enabled=false;	
		yield return new WaitForSeconds(2.5f);
		warFaceMemory.GetComponent<PP_Scanlines>().enabled=true;
		warFaceMemory.GetComponent<PP_SecurityCamera>().enabled=true;
		warFaceMemory.GetComponent<PP_LightWave>().enabled=true;
		yield return new WaitForSeconds(1f);
		warFaceMemory.GetComponent<PP_Scanlines>().enabled=false;
		warFaceMemory.GetComponent<PP_SecurityCamera>().enabled=false;
		warFaceMemory.GetComponent<PP_LightWave>().enabled=false;
		mainCam.SetActive (true);
		warFaceMemory.SetActive (false);
		yield return new WaitForSeconds(1.5f);
			shiftTimer=0f;
		}
		
	}
	
	IEnumerator FlashOnly(GameObject flashCam,int index)
	{
		
		while(index<4)
		{
		flashCam.SetActive (true);
		mainCam.SetActive (false);
		yield return new WaitForSeconds(1.5f);
		flashCam.SetActive (false);
		mainCam.SetActive (true);
		yield return new WaitForSeconds(1.5f);
			index++;
		}
		if(index>=4)
		{
			index=0;
			yield return null;
		
		}
	}
}
