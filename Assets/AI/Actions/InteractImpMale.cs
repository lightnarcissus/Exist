using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class InteractImpMale : RAIN.Action.Action
{
    public InteractImpMale()
    {
        actionName = "InteractImpMale";
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
		agent.Avatar.gameObject.renderer.material.SetColor ("_OutlineColor",Color.red);
		
		if(EmotionScript.emotion==4)		//angry
		{
			//angry/chastising dialogue
		}
		
		float chance=0f;
		chance=Random.value;
			if(chance<0.7f)
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