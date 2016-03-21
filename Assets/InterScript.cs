using UnityEngine;
using System.Collections;

public class InterScript : MonoBehaviour {

	
		private bool once=true;
	public GameObject player;
	public GameObject emotionCam;
	private float startTimer=0f;
	private Rect bg0;
	public GameObject black;
	public TextMesh txt;
	public TextMesh play;
	public TextMesh tutorial;
	public GUIStyle startStyle;
	public GameObject cityCube;
	public GameObject oceanCube;
	public GameObject desertCube;
	public static bool ready=false;
	public static bool selected=false;
	public static bool firstYes=true;
	public static bool secondYes=false;
	public static bool final=false;
	public GameObject selector;
	private bool selectOnce=true;
	public AudioListener mine;
	public AudioSource aud;
	public GameObject timer;
	// Use this for initialization
	void Start () {
		
		bg0=new Rect(Screen.width/2f,Screen.height/2f,100f,100f);
		play.text="";
		tutorial.text="";
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if(once)
		{
		//	player.transform.FindChild ("Main Camera").gameObject.camera.enabled=false;
			//player.transform.FindChild ("Main Camera").gameObject.SetActive(false);
			player.SetActive (false);
			selector.SetActive(true);
			
			emotionCam.SetActive(false);
			black.SetActive (false);
			cityCube.SetActive (false);
			desertCube.SetActive (false);
			oceanCube.SetActive (false);
			timer.SetActive (false);
			aud.enabled=false;
			mine.enabled=false;
			black.renderer.material.color=Color.white;
			once=false;
			
		}
		
		
		
		
		
		if(selected)
		{
		if(selectOnce)
			{
				selector.SetActive (false);
				black.SetActive (true);
				Debug.Log("OH YSA!");
				aud.enabled=true;
				firstYes=false;
				mine.enabled=true;
				startTimer=0f;
				selectOnce=false;
			}
		startTimer+=Time.deltaTime;
//		Debug.Log (startTimer);
			if(startTimer>6f)
			{
				startTimer=0f;
				firstYes=true;
				Debug.Log ("Inactive");
					gameObject.SetActive (false);
			}
	if(!firstYes)
		{
		if(startTimer<1f)
		{
			black.renderer.material.color=new Color(Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime));
			gameObject.camera.enabled=true;
			
		}
		
		if(startTimer>1f && startTimer<4f)
		{
			cityCube.SetActive (true);
			txt.text="Why do we hate?";
			play.text="Day 1 Sequence 1:\n The Walled City";
				tutorial.text="A bomb ticks off to everyone's doom \n Only you and your prejudice \n hold the Answer to \n Bomber's identity";
			
		}
		
		if(startTimer>4f && startTimer<6f)
		{
				
				//cityGround.SetActive(true);
				//player.SetActive (true);
				StarterScript.ready=true;
				
					player.SetActive (true);
				//	player.transform.FindChild ("Main Camera").gameObject.SetActive(true);
				
				
			
		}
			
			
			
		}
		
		if(firstYes && secondYes)
		{
			if(startTimer<1f)
		{
			black.renderer.material.color=new Color(Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime));
			gameObject.camera.enabled=true;
			
		}
		
		if(startTimer>1f && startTimer<8f)
		{
			desertCube.SetActive (true);
			txt.text="Where does true happiness lie?";
			play.text="Day 3 \n Sequence 1";
			tutorial.text="Lost in the sands of time, \n your true happiness lies locked  \n in your forgotten future. \n One key,many chests.";	
			
			
		}
		
		if(startTimer>8f)
		{
				player.SetActive (true);
				startTimer=0f;
				desertCube.SetActive (false);
			secondYes=true;
				startTimer=0f;
				gameObject.SetActive (false);
		}
		}
		
		
		if(final)
		{
			black.renderer.material.color=new Color(Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime));
			
			if(startTimer<6f)
			{
				txt.text="End of Act I";
			
			}
			if(startTimer>6f && startTimer<12f)
		{
				txt.text="Created By";
				play.text="Ansh Patel";
				
		}
			if(startTimer>12f && startTimer<20f)
			{
				txt.text="Music By";
				play.text="Sumanth Srinivasan \n Aarudra Moudgalya \n Melania Valverde";
			}
			if(startTimer>20f && startTimer<24f)
			{
			txt.text="Thank you for playing the Act One!";
				play.text="";
			}
			if(startTimer>24f)
			{
				Application.Quit ();
			}
				
		}
			
		}
	
	}
}
