using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class FocusTurn : MonoBehaviour {
	
	public static GameObject focusObj;
	public GameObject dialogueCam;
	// Use this for initialization
	void Start () {
		dialogueCam.SetActive (false);
	}
	
	void OnEnable()
	{
		dialogueCam.SetActive(false);
	}
	
	// Update is called once per frame
/*	void FixedUpdate () {
		if(focusObj!=null && PromptScript.talk)
		{
		mainCam.camera.enabled=false;
		mainCam.GetComponent<MouseLook>().enabled=false;
		mainCam.GetComponent<CharacterMotor>().canControl=false;
		gameObject.camera.enabled=true;
		transform.LookAt (focusObj.transform);
		((DepthOfFieldScatter)gameObject.GetComponent<DepthOfFieldScatter>()).focalTransform=focusObj.transform;
		}
		else
		{
			if(ExistStart.start)
			{
			mainCam.GetComponent<MouseLook>().enabled=true;
			mainCam.GetComponent<CharacterMotor>().canControl=true;
			}
			gameObject.camera.enabled=false;
			mainCam.camera.enabled=true;
		}
	}*/
	void OnConversationStart()
	{
		gameObject.camera.enabled=false;
		GetComponent<MouseLook>().enabled=false;
		if(gameObject.GetComponent<CharacterMotor>()!=null)
		gameObject.GetComponent<CharacterMotor>().canControl=false;
		dialogueCam.SetActive(true);
		var gb=new PixelCrushers.DialogueSystem.ConversationStarter();
		if(focusObj!=null)
		{
		dialogueCam.transform.LookAt (focusObj.transform);
		((DepthOfFieldScatter)dialogueCam.GetComponent<DepthOfFieldScatter>()).focalTransform=focusObj.transform;
		}
	}
	void OnConversationEnd()
	{
			GetComponent<MouseLook>().enabled=true;
		if(gameObject.GetComponent<CharacterMotor>()!=null)
			gameObject.GetComponent<CharacterMotor>().canControl=true;
			dialogueCam.SetActive(false);
			gameObject.camera.enabled=true;
		PromptScript.talk=false;
	}
}
