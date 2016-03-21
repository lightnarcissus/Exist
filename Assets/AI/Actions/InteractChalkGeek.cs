using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class InteractChalkGeek : RAIN.Action.Action
{
    public InteractChalkGeek()
    {
        actionName = "InteractChalkGeek";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		InteractionScript.chalkGeek=true;
		InteractionScript.chalkGeekActive=agent.Avatar.gameObject;
		WheelScript.fairyBlue=true;
		
		// I have forgotten the question -- Why am I sad?
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}