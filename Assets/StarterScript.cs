using UnityEngine;
using System.Collections;

public class StarterScript : MonoBehaviour {
	
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
	
	public GameObject inter;
	public GameObject tutorialScene;
	public GameObject sinkerScene;
	public static int opt=0;
	
	
	public GameObject loadCam;
	public GameObject selector;
	
	public GameObject pauseCam;
	public GameObject UICam;
	
	// Use this for initialization
	void Start () {
		
		//player.SetActive (false);
		
		bg0=new Rect(Screen.width/2f,Screen.height/2f,100f,100f);
		play.text="";
		tutorial.text="";
	
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("First"+InterScript.firstYes);
		//Debug.Log ("Second"+InterScript.secondYes);
		if(once)
		{
			player.SetActive (false);
		//	player.transform.FindChild ("Main Camera").gameObject.SetActive(false);
			emotionCam.SetActive(false);
			UICam.SetActive (false);
			loadCam.SetActive(false);
			black.SetActive (true);
			cityCube.SetActive (false);
			desertCube.SetActive (false);
			oceanCube.SetActive (false);
			selector.SetActive(false);
			sinkerScene.SetActive (false);
			pauseCam.SetActive (false);
			inter.SetActive (false);
			tutorialScene.SetActive (false);
			black.renderer.material.color=Color.white;
			once=false;
			
		}
		
		startTimer+=Time.deltaTime;
		
		if(Input.GetKey (KeyCode.Return))
		{
			startTimer=31f;
		}
		
		if(startTimer<2f)
		{
			
			gameObject.camera.enabled=true;
			
		}
		
		if(startTimer>2f && startTimer<5f)
		{
			black.renderer.material.color=new Color(Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime));
			txt.text="Narcissist Reality Presents";
			
		}
		
		if(startTimer>5f && startTimer<8f)
		{
			black.renderer.material.color=new Color(Mathf.Lerp (1f,0f,Time.deltaTime),Mathf.Lerp (1f,0f,Time.deltaTime),Mathf.Lerp (1f,0f,Time.deltaTime));
		}
		
		if(startTimer>8f && startTimer<11f)
		{
			black.renderer.material.color=new Color(Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime));
			txt.text="A Masked Twins Production";
			
		}
		
		if(startTimer>11f && startTimer<14f)
		{
			black.renderer.material.color=new Color(Mathf.Lerp (1f,0f,Time.deltaTime),Mathf.Lerp (1f,0f,Time.deltaTime),Mathf.Lerp (1f,0f,Time.deltaTime));
		}
		
		if(startTimer>14f && startTimer<17f)
		{
			black.renderer.material.color=new Color(Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime));
			cityCube.SetActive(true);
			txt.text="Why do we hate?";
			
		}
		
		if(startTimer>17f && startTimer<20f)
		{
			cityCube.SetActive (false);
			black.renderer.material.color=new Color(Mathf.Lerp (1f,0f,Time.deltaTime),Mathf.Lerp (1f,0f,Time.deltaTime),Mathf.Lerp (1f,0f,Time.deltaTime));
		}
		
		if(startTimer>20f && startTimer<23f)
		{
			black.renderer.material.color=new Color(Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime));
			desertCube.SetActive (true);
			txt.text="Where does true happiness lie?";
			
		}
		
		if(startTimer>23f && startTimer<26f)
		{
			desertCube.SetActive (false);
			black.renderer.material.color=new Color(Mathf.Lerp (1f,0f,Time.deltaTime),Mathf.Lerp (1f,0f,Time.deltaTime),Mathf.Lerp (1f,0f,Time.deltaTime));
		}
		
		if(startTimer>26f && startTimer<29f)
		{
			black.renderer.material.color=new Color(Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime),Mathf.Lerp (0f,1f,Time.deltaTime));
			oceanCube.SetActive (true);
			txt.text="What is our purpose?";
			
		}
		if(startTimer>29f && startTimer<30f)
		{
			oceanCube.SetActive (false);
			black.renderer.material.color=new Color(Mathf.Lerp (1f,0f,Time.deltaTime),Mathf.Lerp (1f,0f,Time.deltaTime),Mathf.Lerp (1f,0f,Time.deltaTime));
		}
		
		if(startTimer>30f && startTimer<34f)
		{
		//	gameObject.camera.enabled=false;
			gameObject.SetActive (false);
			UICam.SetActive (true);
		}
	
		

	
	}
}
