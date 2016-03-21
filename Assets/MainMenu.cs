using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public static int choice=1;
	//1 for New ; 2 for Loaded Game 
	public GameObject sinker;
	public GameObject sinkerCam;
	public GameObject selector;
	public GameObject selectorCam;
	public GameObject player;
	public GameObject pauseCam;
	public GameObject settingsCam;
	public GameObject loadCam;
	public GameObject newGameCam;
	public GameObject exitCam;
	private bool once=true;
	
	// Use this for initialization
	void Start () {
		sinker.SetActive(true);
		sinkerCam.SetActive (false);
		selectorCam.SetActive (false);
		player.SetActive (false);
		pauseCam.SetActive (false);
		exitCam.SetActive (false);
		loadCam.SetActive (false);
		newGameCam.SetActive (false);
		settingsCam.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		if(once)
		{
		if(choice==1)			//new game
		{
			sinker.SetActive (true);
			sinkerCam.SetActive (true);
				once=false;

			
		}
		else if(choice==2)	//load a game
		{
			player.SetActive (true);
				once=false;
		}
		}
		
		
}
}