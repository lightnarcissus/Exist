using UnityEngine;
using System.Collections;

//Hack by Si Borokokok

public class RainGlobalControlPro : MonoBehaviour
{

    public float rainLevel = 1.0f;
    public int transitionSpeed = 2;


    public void Update()
    {
        rainLevel = Mathf.Clamp(rainLevel, 0.0f, 2.0f);
		
        GameObject[] rain_Particles = GameObject.FindGameObjectsWithTag("RainParticles");
        int i = 0;
        while (i < rain_Particles.Length)
        {
			Mathf.Lerp(rain_Particles[i].renderer.material.color.a, rainLevel * 0.2f, Time.deltaTime * transitionSpeed);
            i++;
        }
		
//        GameObject[] rain_Pro = GameObject.FindGameObjectsWithTag("RainPro");
  /*      int j = 0;
        while (j < rain_Pro.Length)
        {
            float a_float = rain_Pro[j].renderer.material.GetFloat("_BumpAmt");
            rain_Pro[j].renderer.material.SetFloat("_BumpAmt", Mathf.Lerp(a_float, rainLevel * 60, Time.deltaTime * transitionSpeed));
            j++;
        }
	*/
		
        GameObject[] rain_Ripples = GameObject.FindGameObjectsWithTag("RainRipples");
        int k = 0;
        while (k < rain_Ripples.Length)
        {
            Mathf.Lerp(rain_Ripples[k].renderer.material.color.a, rainLevel * 0.3f, Time.deltaTime * transitionSpeed);
            k++;
        }
		
        GameObject[] rain_Sound = GameObject.FindGameObjectsWithTag("RainSound");
        int l = 0;
        while (l < rain_Sound.Length)
        {
            rain_Sound [l].audio.volume = Mathf.Lerp(rain_Sound[l].audio.volume, rainLevel, Time.deltaTime * transitionSpeed);
            l++;
        }
		
 /*       GameObject effect_Pro = GameObject.FindWithTag("FullscreenEffectPro");
        if ((rainLevel == 0) && (effect_Pro != null))
        {
            effect_Pro.renderer.enabled = false;
        }
        else
        {
            effect_Pro.renderer.enabled = true;
        }
        print("Rain Level " + rainLevel);*/
    }
}

