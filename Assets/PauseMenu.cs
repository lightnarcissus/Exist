using UnityEngine;
using System.Collections;
public class PauseMenu : MonoBehaviour {
	
	public static bool paused=false;
	private float waitTimer=0f;
	public static GameObject mainCamera;
	public GameObject pausedCamera;
	
	public static bool loadMode=false;
	public static bool saveMode=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(waitTimer<=2f)
		waitTimer+=Time.deltaTime;
		
		if(waitTimer>=2f)
		{
		if(Input.GetKeyDown (KeyCode.Escape))
		{
				Screen.showCursor=true;
			Debug.Log("Once");
			mainCamera.SetActive (false);
			pausedCamera.SetActive (true);
				paused=true;
		}
		}
		
		
		
			
	
	}
		
	
	
}
