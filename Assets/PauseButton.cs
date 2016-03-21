using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
	
	public GameObject pausedCamera;
	public GameObject saveCamera;
	public GameObject loadCamera;
	public GameObject optionCamera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick()
	{
		Debug.Log ("Paused");
		if(PauseMenu.paused)
		{
			Debug.Log("PausedInside");
			if(gameObject.name=="Resume")
			{
				Debug.Log("Resume");
				
				Time.timeScale=1f;
				PauseMenu.paused=false;
			}
			
			if(gameObject.name=="Save")
			{
				pausedCamera.SetActive (false);
				PauseMenu.saveMode=true;
				Time.timeScale=1f;
				saveCamera.SetActive (true);
			}
			
			if(gameObject.name=="Load")
			{
				pausedCamera.SetActive (false);
				PauseMenu.loadMode=true;
				Time.timeScale=1f;
				loadCamera.SetActive (true);
			}
			
			if(gameObject.name=="Options")
			{
				pausedCamera.SetActive (false);
				optionCamera.SetActive(true);
			}
			if(gameObject.name=="Quit")
			{
				Application.Quit ();
			}
		}
	}
}
