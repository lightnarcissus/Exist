using UnityEngine;
using System.Collections;

public class GazeboScript : MonoBehaviour {
	
	public GameObject player;
	private float distance=0f;
	public GameObject mirror;
	// Use this for initialization
	void Start () {
		
		mirror.SetActive (false);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		
		distance=Vector3.Distance (player.transform.position,mirror.transform.position);
		
		if(distance<20f)
		{
			mirror.SetActive (true);
		}
		
		if(distance>15f)
		{
			mirror.SetActive (false);
		}
		
	
	}
}
