using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class InteractBomb : RAIN.Action.Action
{
	public Ray pointRay;
	//public Camera cam;
    public InteractBomb()
    {
        actionName = "InteractBomb";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		if(Input.GetMouseButtonDown(0))
		{
			pointRay=Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2f,0f));
			if(Physics.Raycast(pointRay))
			{
				Debug.Log ("Yo!");	
			}
			
		}
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}