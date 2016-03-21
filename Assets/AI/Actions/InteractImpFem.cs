using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class InteractImpFem : RAIN.Action.Action
{
    public InteractImpFem()
    {
        actionName = "InteractImpFem";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		InteractionScript.impPerson=true;
		InteractionScript.impPersonActive=agent.Avatar.gameObject;
		WheelScript.fairyBlue=true;
		
		DreamWheel.fairyBlue=true;
		DreamWheel.familyActive=agent.Avatar.gameObject;
		DreamWheel.family=true;
		agent.Avatar.gameObject.renderer.material.SetColor ("_OutlineColor",Color.red);
		
		
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
		//Debug.Log("YO");
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}