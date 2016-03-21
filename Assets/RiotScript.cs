using UnityEngine;
using System.Collections;

public class RiotScript : MonoBehaviour {
	private float riotTimer=0f;
	private int riotAction=0;
	private bool once=true;
	public GameObject bloodpool;
	// Use this for initialization
	void Start () 
	{
		
	riotAction=Random.Range (0,2);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		
	
			riotTimer+=Time.deltaTime;
			if(riotAction==0)
			{
				if(riotTimer<1f)
			{
				gameObject.animation.Play ("TwoPunch");
				transform.FindChild ("Mesh").gameObject.SetActive (false);
			}
				else
			{
				if(once)
				{
					Instantiate (bloodpool,transform.position,Quaternion.identity);
					once=false;
				}
					gameObject.animation.Play ("PointKick");
			}
			}
			else
			{
				if(riotTimer<1f)
				gameObject.animation.Play ("ClubHit");
				else
				{
				if(once)
				{
					Instantiate (bloodpool,transform.position,Quaternion.identity);
					once=false;
				}
					gameObject.animation.Play ("ClubDown");
				}
				
				
			}
		
		
	
	}
}
