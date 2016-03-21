using UnityEngine;
using System.Collections;

public class ExitDream : MonoBehaviour {
	
	public GameObject current;
	public GameObject original;
	
	public bool allow=false;
	
	private float checkTimer=0f;
	private float distance=0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		checkTimer+=Time.deltaTime;
		if(checkTimer>5f)
		{
			distance=Vector3.Distance (current.transform.position,transform.position);
			if(distance<6f)
			{
				allow=true;
			}
			checkTimer=0f;
		}
		
		if(allow)
		{
			ExitSequence();
		}
		
	}
	
		
	void ExitSequence()
	{
		if(DreamTracker.dream==1)
		{
		if(VillageMemory.dreamVisit==1)
			{
		if(LostSoldier.burn)
			VillageMemory.dreamVisit++;
			}
		}
		
		
		
		original.SetActive (true);
		current.SetActive (false);
	}
}
