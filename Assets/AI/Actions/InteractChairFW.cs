using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class InteractChairFW : RAIN.Action.Action
{
    public InteractChairFW()
    {
        actionName = "InteractChairFW";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		if(!InteractionScript.chairLock)
		{
		InteractionScript.chairFW=true;
		//Debug.Log(agent.Avatar.gameObject);
		if(InteractionScript.chairWavy)
		{
		InteractionScript.chairActive=agent.Avatar.gameObject.transform.parent.transform.parent.FindChild("SittingFW").gameObject.transform.FindChild("Female").gameObject;
			agent.Avatar.gameObject.SetActive (false);
		}
		if(InteractionScript.chairWhite || InteractionScript.chairBlack)
		{
			agent.Avatar.gameObject.transform.parent.animation.Play ("KneelSob");
			agent.Avatar.transform.parent.transform.parent.FindChild("SittingFW").gameObject.SetActive (false);
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