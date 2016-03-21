using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class InteractChairFWh : RAIN.Action.Action
{
    public InteractChairFWh()
    {
        actionName = "InteractChairFWh";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		if(!InteractionScript.chairLock)
		{
		InteractionScript.chairFWh=true;
		//Debug.Log(agent.Avatar.gameObject);
		if(InteractionScript.chairWhite)
		{
		InteractionScript.chairActive=agent.Avatar.gameObject.transform.parent.transform.parent.FindChild("SittingFWh").gameObject.transform.FindChild("Female").gameObject;
			agent.Avatar.gameObject.SetActive (false);
		}
		if(InteractionScript.chairWavy || InteractionScript.chairBlack)
		{
			agent.Avatar.gameObject.transform.parent.animation.Play ("KneelSob");
			agent.Avatar.transform.parent.transform.parent.FindChild("SittingFWh").gameObject.SetActive (false);
		}
			
			//certain hopeful dialogue
		}
		
		//else dejected dialogue
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}