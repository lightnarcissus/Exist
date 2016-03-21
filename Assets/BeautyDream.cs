using UnityEngine;
using System.Collections;

public class BeautyDream : MonoBehaviour {
	
	public GameObject player;
	public TextMesh impDialogue;
	public TextMesh femDialogue;
	public TextMesh moneyDialogue;
	
	public static bool exit=false;
	
	public Material skybox;
	


	void Start () 
	{
	
	}
	
	void OnEnable()
	{
		DreamTracker.dream=5;
		impDialogue.text="Honey,if only you were like her";
		femDialogue.text="Can you please help me?";
		moneyDialogue.text="Buy Happiness and Feel Good about yourself";
	}

	void FixedUpdate () 
	{
			
		
	if(exit)
		{
			Exit ();
		}
	
	}
	
	
	void Exit()
	{
		player.SetActive (false);
		exit=false;
		GetComponent<BeautyDream>().enabled=false;
		
	}
}
