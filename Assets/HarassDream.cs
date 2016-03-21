using UnityEngine;
using System.Collections;

public class HarassDream : MonoBehaviour {
	
	public GameObject hand;
	private float distCovered;
	
	//private Vector3 initialPos=new Vector3(1422.32f,47.016f,1422.82f);
	private Vector3 currentPos;
	private Vector3 firstPos;
	
	private float checkTimer=0f;
	// Use this for initialization
	void Start () {
	
		
	}
	void OnEnable()
	{
	//transform.position=initialPos;
		//DreamTracker.dream=6;
	firstPos=transform.position;
		AgentMove.caught=false;
	MemoryScript.visitedVillage=true;
	}
	// Update is called once per frame
	void FixedUpdate () {
		
		
		checkTimer+=Time.deltaTime;
		if(checkTimer>5f)
		{
			currentPos=transform.position;
			distCovered=Vector3.Distance (currentPos,firstPos);
			if(distCovered>15f)
			{
				Instantiate (hand,new Vector3(transform.position.x,transform.position.y-3f,transform.position.z)+transform.forward*5f,Quaternion.identity);
			}
			firstPos=currentPos;
			checkTimer=0f;
		}
		
		if(AgentMove.caught)
		{
			((ScreenOverlay)gameObject.GetComponent<ScreenOverlay>()).enabled=true;
			GetComponent<NoiseAndGrain>().intensityMultiplier+=Time.deltaTime;
		}
		
	}
	
	void OnDisable()
	{
		((ScreenOverlay)gameObject.GetComponent<ScreenOverlay>()).enabled=false;
			GetComponent<NoiseAndGrain>().intensityMultiplier=3.8f;
	}
}
