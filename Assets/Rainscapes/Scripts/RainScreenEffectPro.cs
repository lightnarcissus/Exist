using UnityEngine;
using System.Collections;

//Hack by Si Borokokok

public class RainScreenEffectPro : MonoBehaviour
{
    public GameObject cam1;
    public float effectIntensity = 0.3f;
    public float transitionSpeed = 0.5f;
	

    public void LateUpdate()
    {
        float @float = renderer.material.GetFloat("_BumpAmt");
        renderer.material.SetFloat("_BumpAmt", Mathf.Lerp(@float, cam1.transform.localEulerAngles.x * effectIntensity, Time.deltaTime * transitionSpeed));
    }
}

