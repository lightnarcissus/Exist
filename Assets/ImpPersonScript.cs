using UnityEngine;
using System.Collections;

public class ImpPersonScript : MonoBehaviour {
	
	private bool once=true;
	public static bool follow=false;
	private GameObject player;
	private GameObject current;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(once)
		{
			player=GameObject.FindGameObjectWithTag ("Player");
			
		if(HistoryScript.gender==0)
		{
			transform.FindChild ("ImpFem").gameObject.SetActive (false);
			current=transform.FindChild ("ImpMale").gameObject;
			
		}
		else
		{
			transform.FindChild ("ImpMale").gameObject.SetActive (false);
			current=transform.FindChild ("ImpFem").gameObject;
		}
			
			once=false;
		}
		
		
		if(follow)
		{
			
			if(Input.GetButton ("Forward"))
			{
				transform.position=player.transform.position+player.transform.forward*-6f;
				current.gameObject.animation.Play ("Walk");
				current.transform.eulerAngles=player.transform.eulerAngles;
			}
			
			else
			{
				transform.parent=null;
				current.gameObject.animation.Play ("Idle");
			}
		}
	
	}
}
