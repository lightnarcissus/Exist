using UnityEngine;
using System.Collections;

public class DisplayGuy : MonoBehaviour {
	
	
	private float timer=0f;
	public GameObject player;
	// Use this for initialization
	void OnEnable () {
	
		timer=0f;
		transform.position=new Vector3(player.transform.position.x+Random.Range (-10f,10f),player.transform.position.y,player.transform.position.z+Random.Range (-10f,10f));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		timer+=Time.deltaTime;
		
		if(timer>10f)
		{
			timer=0f;
			gameObject.SetActive (false);
		}
	
	}
}
