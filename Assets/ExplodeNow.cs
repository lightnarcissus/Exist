using UnityEngine;
using System.Collections;

public class ExplodeNow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(DreamTracker.dream==7)
		{
			if(RazeScript.blow)
			{
				BroadcastMessage ("Explode");
			}
		}
	
	}
}
