using UnityEngine;
using System.Collections;

public class ScreenWheel : MonoBehaviour {
	
	[System.Serializable]
	public class Reticle {
			public Texture2D inRedRangeTL;
			public Texture2D inBlueRangeBR;
			public Texture2D inGoldRangeBL;
			public Texture2D inGreenRangeTR;
			public Texture2D outOfRangeTL;
			public Texture2D outOfRangeTR;
			public Texture2D outOfRangeBL;
			public Texture2D outOfRangeBR;
		
			public float width = 64f;
			public float height = 64f;
		}
	
	private bool convo=false;
	private bool active=false;
	public Reticle reticle;
	private Texture2D reticleTextureTL;
	private Texture2D reticleTextureTR;
	private Texture2D reticleTextureBL;
	private Texture2D reticleTextureBR;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(DreamWheel.fairyRed || DreamWheel.fairyBlue || DreamWheel.fairyGold || DreamWheel.fairyGrey)
		{
			
					if(WheelScript.fairyRed || DreamWheel.fairyRed)
		{
				reticleTextureTL = reticle.inRedRangeTL;
				active=true;
		}
			else
			{
				reticleTextureTL = reticle.outOfRangeTL;
			}
					if(WheelScript.fairyBlue || DreamWheel.fairyBlue)
		{
				reticleTextureBR =reticle.inBlueRangeBR;
				active=true;
		}
			else
			{
				reticleTextureBR = reticle.outOfRangeBR;
			}
					if(WheelScript.fairyGrey || DreamWheel.fairyGrey)
		{
				reticleTextureTR = reticle.inGreenRangeTR;
				active=true;
		}
			else
			{
				reticleTextureTR = reticle.outOfRangeTR;
			}
					if(WheelScript.fairyGold || DreamWheel.fairyGold)
		{
				reticleTextureBL = reticle.inGoldRangeBL;
				active=true;
		}
			else
			{
				reticleTextureBL = reticle.outOfRangeBL;
			}
	}
		
		else
		{
			active=false;
			reticleTextureTL = reticle.outOfRangeTL;
			reticleTextureTR = reticle.outOfRangeTR;
			reticleTextureBL = reticle.outOfRangeBL;
			reticleTextureBR = reticle.outOfRangeBR;
		}
		
			
	
	}
	
	void OnGUI()
	{
		if (!convo)
					{
		//	Debug.Log("Convo but not Active");
			if(active)
			{
			//	Debug.Log ("Active");
						GUI.Label(new Rect((0.5f * (Screen.width - reticle.width-reticle.width/2f))+50f, 0.5f * ((Screen.height - reticle.height-reticle.height/2f))+50f, reticle.width/2f, reticle.height/2f), reticleTextureTL);
						GUI.Label(new Rect((0.5f * (Screen.width - reticle.width+reticle.width/2f))+50f, 0.5f * ((Screen.height - reticle.height-reticle.height/2f))+50f, reticle.width/2f, reticle.height/2f), reticleTextureTR);
					GUI.Label(new Rect((0.5f * (Screen.width - reticle.width-reticle.width/2f))+50f, 0.5f * ((Screen.height - reticle.height+reticle.height/2f))+50f, reticle.width/2f, reticle.height/2f), reticleTextureBL);
					GUI.Label(new Rect((0.5f * (Screen.width - reticle.width+reticle.width/2f))+50f, 0.5f * ((Screen.height - reticle.height+reticle.height/2f))+50f, reticle.width/2f, reticle.height/2f), reticleTextureBR);
					
			}
		}
	}
	
	
	void OnConversationStart()
	{
		convo=true;
	}
	
	void OnConversationEnd()
	{
		convo=false;
	}
}
