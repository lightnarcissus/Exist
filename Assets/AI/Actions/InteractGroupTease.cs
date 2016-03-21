using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class InteractGroupTease : RAIN.Action.Action
{
    public InteractGroupTease()
    {
        actionName = "InteractGroupTease";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		float timer=0f;
		float chance=0f;
		chance=Random.value;
		if(chance>0.3f)
		{
			
			//dialogue
		}
		
		if(MirrorScript.gender==0)
		{
			
			//dialogue
		}
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}