using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
public class DialogueSupervisor : MonoBehaviour {
	
	public static bool talk=false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnConversationStart()
	{
		talk=true;	
	}
	
	void OnConversationEnd()
	{
		talk=false;	
	}
}
