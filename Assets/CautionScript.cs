using UnityEngine;
using System.Collections;

public class CautionScript : MonoBehaviour {
	
	public static bool safePlace=false;
	
	private float distanceOutside=0f;
	public GameObject stopSign;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(!InteractionScript.stop)
		{
			distanceOutside=Vector3.Distance(player.transform.position,stopSign.transform.position);
			
			if(distanceOutside>30f)
			{
				stopSign.transform.position=player.transform.position+player.transform.forward*15f;
				
			}

		}
	
	}
}
