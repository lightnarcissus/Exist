using UnityEngine;
using System.Collections;

public class ShootPlay : MonoBehaviour {
	
	public GameObject mainSoldier;
	
	private float blackTimer=0f;
	public GameObject soldier1;
	public GameObject soldier2;
	public GameObject soldier3;
	public GameObject camera;
	public GameObject gun;
	
	public GameObject lostChild;
	private float distChild=0f;
	
	public static bool helpChild=false;
	public static bool desertChild=false;
	public static bool throwGun=false;
	
	public AudioClip bgclip;
	public AudioClip rifle;
	
	private bool rifleAllow1=true;
	private bool rifleAllow2=true;
	private bool rifleAllow3=true;
	
	// Use this for initialization
	void Start () {
	}
	
	void OnEnable()
	{
		rifleAllow1=true;
		rifleAllow2=true;
		rifleAllow3=true;
		soldier1.SetActive (false);
		soldier2.SetActive (false);
		soldier3.SetActive (false);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(helpChild)
		{
			EndSequence();
			
		}
		
		distChild=Vector3.Distance (transform.position,lostChild.transform.position);
		if(distChild>15f)
		{
			desertChild=true;
			EndSequence();
			
		}
		
		if(throwGun)
		{
			gun.SetActive(false);
		}
		
		if(blackTimer<8f)
		{
		blackTimer+=Time.deltaTime;
	//	SoundManager.Play(bgclip);
		}
		
		if(blackTimer>1f && blackTimer<2.5f)
		{
			if(rifleAllow1)
			{
			//	SoundManager.PlaySFX (mainSoldier,rifle);
				rifleAllow1=false;
			}
			soldier1.SetActive (true);
			((DepthOfFieldScatter)camera.GetComponent<DepthOfFieldScatter>()).focalTransform=soldier1.transform;
			camera.transform.LookAt (soldier1.transform);
			camera.transform.eulerAngles=new Vector3(0,camera.transform.eulerAngles.y,0);	
		}
		if(blackTimer>2.5f && blackTimer<4f)
		{
			if(rifleAllow2)
			{
			//	SoundManager.PlaySFX (mainSoldier,rifle);
				rifleAllow2=false;
			}
			soldier2.SetActive (true);
			camera.transform.LookAt (soldier2.transform);
			camera.transform.eulerAngles=new Vector3(0,camera.transform.eulerAngles.y,0);
			((DepthOfFieldScatter)camera.GetComponent<DepthOfFieldScatter>()).focalTransform=soldier1.transform;
		}
		
		if(blackTimer>4.5f && blackTimer<6f)
		{
			if(rifleAllow3)
			{
			//	SoundManager.PlaySFX (mainSoldier,rifle);
				rifleAllow3=false;
			}
			soldier3.SetActive (true);
			camera.transform.LookAt (soldier3.transform);
			camera.transform.eulerAngles=new Vector3(0,camera.transform.eulerAngles.y,0);
			((DepthOfFieldScatter)camera.GetComponent<DepthOfFieldScatter>()).focalTransform=soldier1.transform;
		}
		
		if(blackTimer>6f && blackTimer<6.5f)
		{
		//	SoundManager.StopSFX();
			((DepthOfFieldScatter)camera.GetComponent<DepthOfFieldScatter>()).visualizeFocus=false;
			((DepthOfFieldScatter)camera.GetComponent<DepthOfFieldScatter>()).focalTransform=lostChild.transform;
		}
	
	}
	void EndSequence()
	{
		if(throwGun)
			Player.cracking++;
		
		mainSoldier.SetActive (false);
		
	}
}
