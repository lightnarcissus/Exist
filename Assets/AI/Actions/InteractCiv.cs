using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class InteractCiv : RAIN.Action.Action
{
	public static bool interact=false;
	public float waitTime=4f;
	public float type=0f;
	public static GameObject civActive;
	public Ray pointRay;
	public int dieStyle=0;
    public InteractCiv()
    {
		
        actionName = "InteractCiv";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
	//	Debug.Log("DETECT YOU!");
		if(waitTime>=5f)
		{
		type=Random.value;	
		if((type>0.02f)&&(type<=0.5f))
			{
				Debug.Log ("Audio");
			}
		if((type>0.5f))
			{
				Debug.Log ("Do Nothing");
			}
			 waitTime=0f;
		}
		waitTime+=Time.deltaTime;
		return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {

		//	Debug.Log ("WORKS");
		if(Input.GetMouseButtonDown(0))
		{
			pointRay=Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2f,0f));
			if(Physics.Raycast(pointRay))
			{
				dieStyle=Random.Range (0,3);
				if(dieStyle==0)
					Debug.Log ("Death by Collapse & Sob");
				if(dieStyle==1)
					Debug.Log ("Death by Broken");
				if(dieStyle==2)
					Debug.Log ("Death by Upside Hanging");
				Player.guessChance--;
			}
		}
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
		
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}