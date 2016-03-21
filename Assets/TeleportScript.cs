using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
	
	public static int loc=0;
	private GameObject player;
	private GameObject war;
	private GameObject rally;
	private GameObject sphere;
	private GameObject lighthouse;
	private GameObject pyramid;
	private GameObject direction;
	public static bool once=true;
	
	
	private bool search=true;
	// Use this for initialization
	void Start () {
		
		
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(search)
		{
		player=GameObject.FindGameObjectWithTag ("Player");
		war=GameObject.FindGameObjectWithTag ("War");
		rally=GameObject.FindGameObjectWithTag ("Rally");
		sphere=GameObject.FindGameObjectWithTag ("Sphere");
		lighthouse=GameObject.FindGameObjectWithTag ("Lighthouse");
		pyramid=GameObject.FindGameObjectWithTag ("Pyramid");
		direction=GameObject.FindGameObjectWithTag ("Direction");
			once=false;
		}
		
		if(loc==1)		//War
		{
			if(once)
			{
			//fade first
			//Debug.Log ("TELEPORT!");
			player.transform.position=new Vector3(war.transform.position.x,war.transform.position.y-5f,war.transform.position.z);
			once=false;
			}
		}
		
		if(loc==2)		//War
		{
			if(once)
			{
			//fade first
			player.transform.position=new Vector3(rally.transform.position.x,rally.transform.position.y,rally.transform.position.z);
			once=false;
			}
		}
	}
}
