using UnityEngine;
using System.Collections;

public class DialogueScript : MonoBehaviour {
	
	
	private GameObject player;
	private bool once=true;
	public TextMesh dialogue;
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
		
		transform.LookAt (player.transform);
	
	
	}
}
