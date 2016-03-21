using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class ConvoNPCScript : MonoBehaviour {
	
	public GameObject maleBlackNPC;
	public GameObject maleWavyNPC;
	public GameObject maleWhiteNPC;
	public Variable yo;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void OnConversationStart () 
	{
		if(gameObject==maleBlackNPC)
		{
			if(HistoryScript.race==1)
			{
				
			}
			
			else if(HistoryScript.race==2)
			{
				
			}
			
			else
			{
				
			}
		}
		
		if(gameObject==maleWavyNPC)
		{
			if(HistoryScript.race==1)
			{
				
			}
			else if(HistoryScript.race==2)
			{
				
			}
			else
			{
				
			}
			
		}
		
		if(gameObject==maleWhiteNPC)
		{
			
			if(HistoryScript.race==1)
			{
				
			}
			else if(HistoryScript.race==2)
			{
				
			}
			else
			{
				
			}
		}

	}
}
