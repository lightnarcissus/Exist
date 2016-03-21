using UnityEngine;
using System.Collections;

public class PromptScript : MonoBehaviour {
	
	public static bool interact=false;
	public static bool talk=false;
	public GameObject interactPrompt;
	public GameObject talkPrompt;
	
	public static GameObject interactObj;
	public static GameObject talkObj;
	
	public static bool talkAllowPrompt=false;
	public static bool interactAllow=false;
	public GameObject talkInterface;
	
	private float resetCounter=0f;
	public GameObject mouseMoveObj;
	
	public GUIStyle interactStyle;
	
	// Use this for initialization
	void Start () {
		
		interactPrompt.SetActive(false);
		talkPrompt.SetActive (false);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		resetCounter+=Time.deltaTime;
		if(resetCounter>2f)
		{
			interact=false;
			resetCounter=0f;
		}
		
		
		if(talk && !interact)
		{
//			talkPrompt.SetActive (true);
		
		}
		else
		{
			
	//		talkPrompt.SetActive (false);
		}
	
	}
	
	void OnGUI()
	{
		if(interact && !talk)
		{
			if(interactObj!=null)
			{
				if(interactObj.renderer.isVisible)
				{
					GUI.Label (new Rect(Screen.width/2f,Screen.height/2f+100f,100f,100f),"Interact",interactStyle);
				}
			}
			
		}
		
		
	}
	
	
}
