using UnityEngine;
using System.Collections;

public class AppearNear : MonoBehaviour {
	
	public GameObject player;
	private float distance=0f;
	private float checkTimer=3f;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable()
	{
		gameObject.renderer.enabled=true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		checkTimer+=Time.deltaTime;
		
		if(checkTimer>3f)
		{
			distance=Vector3.Distance (transform.position,player.transform.position);
			
			if(distance>15f)
			{
				gameObject.renderer.enabled=false;
			}
			else
			{
				gameObject.renderer.enabled=true;
			}
	
			
			checkTimer=0f;
		}
	}
}
