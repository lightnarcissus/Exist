using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class InteractSphere : RAIN.Action.Action
{
    public InteractSphere()
    {
        actionName = "InteractSphere";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		GameObject mainCam;
		InteractionScript.sphere=true;
		InteractionScript.sphereActive=agent.Avatar.gameObject;
		mainCam=GameObject.FindGameObjectWithTag ("MainCamera");
		mainCam.GetComponent<NoiseAndGrain>().intensityMultiplier=6.5f;
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}