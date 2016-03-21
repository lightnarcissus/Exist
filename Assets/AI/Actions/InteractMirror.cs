using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class InteractMirror : RAIN.Action.Action
{
    public InteractMirror()
    {
        actionName = "InteractMirror";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		InteractionScript.mirrorSelf=true;
		InteractionScript.mirrorSelfActive=agent.Avatar.gameObject;
		WheelScript.fairyRed=true;
		DreamWheel.fairyRed=true;
		InteractionScript.reflection=true;
		
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}