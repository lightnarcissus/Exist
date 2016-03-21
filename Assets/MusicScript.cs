using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {
	
	public AudioSource source;
	public AudioSource ambient;
	public AudioSource effect;
	
	
	public AudioClip tenRiff;
	public AudioClip tenMod;
	public AudioClip tenWhite;
	public AudioClip casu;
	public AudioClip tenBop;
	public AudioClip oceanDream;
	
	
	public AudioClip citySound;
	public AudioClip dustStorm;
	
	private bool modOnce=true;
	private int randSelect=0;
	
	public static bool blipYes=false;
	
	public AudioClip crowd;
	public AudioClip blip;
	public AudioClip bassDrop;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if(Input.GetMouseButtonDown(0))
		{
			effect.PlayOneShot (bassDrop);
			source.volume=0.2f;
			
		}
		else if(blipYes)
		{
			effect.clip=blip;
			effect.Play();
			blipYes=false;
		}
		
		else
		{
			source.volume=0.8f;
		}
		
		
		if(InteractionScript.bomberWavy || InteractionScript.bomberBlack || InteractionScript.bomberWhite)
				{
					if(modOnce)
					{
					source.Stop ();
					source.clip=tenMod;
					source.Play ();
						modOnce=false;
					}
				}
		else if(!source.isPlaying)
		{
			
			if(ResetScript.sceneChoice==0)
			{
				
				randSelect++;
				if(randSelect==2)
				{
						modOnce=true;
					source.clip=oceanDream;
					source.Play ();
					
				}
				
				if(randSelect==1)
				{
						modOnce=true;
					source.clip=tenRiff;
					source.Play ();
					
				}
				if(randSelect==3)
				{
						modOnce=true;
					source.clip=tenWhite;
						source.Play ();
				}
				
				ambient.clip=crowd;
				ambient.Play();
				
				
				
			}
			
			if(ResetScript.sceneChoice==1)
			{
				source.clip=casu;
					source.Play ();
				ambient.clip=dustStorm;
				ambient.Play ();
			}
		}
	
	}
}
