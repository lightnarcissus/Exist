using UnityEngine;
using System.Collections;
using Pathfinding;

public class AnimControl : MonoBehaviour {
	private Seeker seek;
	private Path currentPath;
	public int randAction=0;
	private float actionTimer=0f;
	public GameObject player;
	private float randTimeout=0f;
	private RaycastHit hit;
	private int benchMask;
	private Ray ray;
	public CharacterController cha;
	public bool playerTalk=false;
	public bool playerInsult=false;
	private float playerTalkTimer=0f;
	public bool blame=false;
	private bool blameOnce=true;
	public bool action=false;
	private bool genderOnce=true;
	private CivilianMovement civMove;
	private BomberMovement bombMove;
	private int gender=0;
	private int bomberThis=0;

	// Use this for initialization
	void Start () {
	seek=GetComponent<Seeker>();
		cha=GetComponent<CharacterController>();
		//randAction=Random.Range (1,6);
		player=GameObject.FindGameObjectWithTag ("Player");
		benchMask= 1<<10;
		randAction=1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(bomberThis!=1 || !BomberMovement.caught)
		{
		
		if(gameObject.tag=="Bomber")
		{
			bomberThis=1;
		}
		
		
		if(genderOnce)
		{
		
		if(transform.FindChild ("Female")!=null)
		{
			gender=1;
		}
		
			if(transform.FindChild ("Male")!=null)
		{
			gender=2;
		}
			if(gameObject.tag=="Bomber")
				bombMove=gameObject.GetComponent<BomberMovement>();
			else
			civMove=gameObject.GetComponent<CivilianMovement>();
			genderOnce=false;
		}
		if(blame)
		{
			gameObject.animation.Play ("KneelSob");
			if(blameOnce)
			{
			gameObject.GetComponent<CivilianMovement>().enabled=false;
				if(gender==1)
			transform.FindChild ("Female").gameObject.GetComponent<RAIN.Core.RAINAgent>().enabled=false;
				else if(gender==2)
				transform.FindChild ("Male").gameObject.GetComponent<RAIN.Core.RAINAgent>().enabled=false;	
				blameOnce=false;
			}
			
		}
	else
		{
		
		if(randAction==1)
		{
			gameObject.animation.Play ("Walk");
		}
		
		
		if(randAction==2)
		{
			gameObject.animation.Play ("Idle");
		}
		
		
		if(action)
	{
		if(playerTalk)
		{
					
			transform.LookAt (player.transform);
			playerTalkTimer+=Time.deltaTime;
			gameObject.animation.Play ("Idle");
				if(gameObject.tag=="Bomber")
						bombMove.enabled=false;
					else
			civMove.enabled=false;
			
			if(playerTalkTimer>6f)
			{
				playerTalk=false;
						if(gameObject.tag=="Bomber")
						bombMove.enabled=false;
					else
						civMove.enabled=true;
				playerTalkTimer=0f;
			}
			
		}
	
		
		else 
		{
		}
					
					
				}
				
			}
		}
}
}
