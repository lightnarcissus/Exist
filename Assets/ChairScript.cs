using UnityEngine;
using System.Collections;

public class ChairScript : MonoBehaviour {

		
	private GameObject player;
	private bool once=true;
	public TextMesh dialogue;
	private float dialogueTimer=0f;
	public static string words;
	public static bool done=false;
	public static int choose=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(once)
		{
			player=GameObject.FindGameObjectWithTag ("Player");
			once=false;
		}
		
		if(!done)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<5f)
			{
				dialogue.text="Is this what we worked so hard for?";
			}
			if(dialogueTimer>15f && dialogueTimer<25f)
			{
				dialogue.text="";
			}
			
			if(dialogueTimer>55f)
				dialogue.text="";
			if(dialogueTimer>60f)
				dialogueTimer=0f;
		}
		
		else
		{
			dialogue.text=words;
			if(choose==0)
			{
				transform.parent.FindChild ("SittingFB").FindChild ("Female").gameObject.renderer.enabled=true;
			}
			if(choose==1)
			{
				transform.parent.FindChild ("SittingFW").FindChild ("Female").gameObject.renderer.enabled=true;
			}
			if(choose==2)
			{
				transform.parent.FindChild ("SittingFWh").FindChild ("Female").gameObject.renderer.enabled=true;
			}
		}
		
		
		
		
		
		transform.LookAt (player.transform);
	}
}