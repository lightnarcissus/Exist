using UnityEngine;
using System.Collections;

public class FollowHelperScript : MonoBehaviour {
	
	
	private GameObject player;
	private GameObject familyScale;
	private GameObject moneyDesk;
	private GameObject noose;
	private GameObject artist;
	
	public static float familyDistance=0f;
	public static float moneyDistance=0f;
	public static float nooseDistance=0f;
	public static float artistDistance=0f;
	
	
	
	
	private float checkDistance=0f;
	private bool once=true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(once)
		{
			player=GameObject.FindGameObjectWithTag("Player");
			familyScale=GameObject.FindGameObjectWithTag ("Family");
			moneyDesk=GameObject.FindGameObjectWithTag ("Money");
			noose=GameObject.FindGameObjectWithTag ("Noose");
			artist=GameObject.FindGameObjectWithTag ("Artist");
			
			once=false;
			
		}
		
		if(ImpPersonScript.follow)
		{
		
		checkDistance+=Time.deltaTime;
		
		if(checkDistance>15f)
		{
			familyDistance=Vector3.Distance (familyScale.transform.position,player.transform.position);
			moneyDistance=Vector3.Distance (moneyDesk.transform.position,player.transform.position);
			nooseDistance=Vector3.Distance (noose.transform.position,player.transform.position);
			artistDistance=Vector3.Distance (artist.transform.position,player.transform.position);
			checkDistance=0f;
		}
		}
		
	}
}
