using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class InteractChairFB : RAIN.Action.Action
{
    public InteractChairFB()
    {
        actionName = "InteractChairFB";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		if(!InteractionScript.chairLock)
		{
		InteractionScript.chairFB=true;
		//Debug.Log(agent.Avatar.gameObject);
		if(InteractionScript.chairBlack)
		{
		InteractionScript.chairActive=agent.Avatar.gameObject.transform.parent.transform.parent.FindChild("SittingFB").gameObject.transform.FindChild("Female").gameObject;
			agent.Avatar.gameObject.SetActive (false);
		}
		if(InteractionScript.chairWavy || InteractionScript.chairWhite)
		{
			agent.Avatar.gameObject.transform.parent.animation.Play ("KneelSob");
			agent.Avatar.transform.parent.transform.parent.FindChild("SittingFB").gameObject.SetActive (false);
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