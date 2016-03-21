using UnityEngine;
using System.Collections;

public class CrowdScript : MonoBehaviour {
	
	private float changeTimer=0.5f;
	private Vector3 randPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		changeTimer+=Time.deltaTime;
		if(changeTimer>0.5f)
		{
			randPos=new Vector3(Random.Range(2000f,2100f),0.1f,Random.Range(3000f,3100f));
			changeTimer=0f;
		}
		transform.position=Vector3.Lerp (transform.position,randPos,Time.deltaTime);
	
	}
}
