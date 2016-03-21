using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;


public class MoveTarget : RAIN.Action.Action
{
	private Vector3 targetPos;
	public bool once=true;
	private GameObject player;
	public float changeTimer=2.01f;
	public float typeTimer=0f;
	private bool interact;
	public int type=0;
	public RAIN.Path.Waypoint waypoint;
	public Seeker seeker;
	private GameObject thisOne;


	//public RAIN.Path.PathManager path;
    public MoveTarget()
    {
		type=Random.Range (0,5);
		player=GameObject.FindGameObjectWithTag("Player");
        actionName = "MoveTarget";
	
    }
	
	public void Start()
	{
	}
	
	
    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
		if(typeTimer>5f)
		{
			type=Random.Range(0,5);
			typeTimer=0f;
		}
		typeTimer+=Time.deltaTime;
		if(type==0)
		{
			//Debug.Log ("Move");
		if(!InteractCiv.interact)
		{
			if(changeTimer>2f)
		{
			targetPos=new Vector3(Random.Range (0f,50f),0f,Random.Range (0f,50f));
			
			changeTimer=0f;
				
		}
		//changeTimer+=Time.deltaTime;
		}
		}
	/*	if(type==1)
			Debug.Log ("Interact 1");
		if(type==2)
			Debug.Log ("Interact 2");
		if(type==3)
			Debug.Log ("Interact 3");
		if(type==4)
			Debug.Log ("Interact 4");
		*/
			return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		if(type==0)
		{
		
			if(((agent.Avatar.transform.position.x+0.5f<=targetPos.x)||(agent.Avatar.transform.position.x-0.5f>=targetPos.x)||(agent.Avatar.transform.position.z+0.5f<=targetPos.z)||(agent.Avatar.transform.position.z-0.5f>=targetPos.z))&&(!InteractCiv.interact))
		{
			
			agent.MoveTo (targetPos,Time.deltaTime);
			
		}
		else
		{
			
			
			changeTimer=2.01f;
		}
		}
			//agent.Avatar.transform.position=Vector3.Lerp (agent.Avatar.transform.position,targetPos,20f);
		
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}