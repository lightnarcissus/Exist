using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class InteractArmyBoss : RAIN.Action.Action
{
    public InteractArmyBoss()
    {
        actionName = "InteractArmyBoss";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		DreamWheel.armyBoss=true;
		DreamWheel.fairyBlue=true;
		DreamWheel.armyBossActive=agent.Avatar.gameObject;
		FocusTurn.focusObj=agent.Avatar.gameObject;
		
		//agent.Avatar.gameObject.renderer.material.SetColor ("_OutlineColor",Color.white);
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
//		agent.Avatar.gameObject.renderer.material.SetColor ("_OutlineColor",Color.black);
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}