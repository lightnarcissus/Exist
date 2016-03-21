using UnityEngine;
using System.Collections;

public class BlankDialogue : MonoBehaviour {
	
	public TextMesh dialogue;
	//public static GameObject player;
	public static bool talk=false;
	private float talkTimer=0f;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable()
	{
		dialogue.text="";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	//	transform.LookAt (player.transform);
		if(talk)
		{
		talkTimer+=Time.deltaTime;
		if(talkTimer>5f)
			{
				talkTimer=0f;
				talk=false;
				
			}
		}
		else
		{
			talkTimer=0f;
			dialogue.text="";
		}
	}
}
