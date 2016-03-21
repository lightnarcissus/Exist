using UnityEngine;
using System.Collections;

public class IslandColScript : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(Player.playerState==1)
		{
			gameObject.GetComponent<BoxCollider>().enabled=true;
		}
		else
		{
			gameObject.GetComponent<BoxCollider>().enabled=false;
		}
	}
}
