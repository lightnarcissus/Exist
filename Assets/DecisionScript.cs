using UnityEngine;
using System.Collections;

public class DecisionScript : MonoBehaviour {
	
	//Scene One
	
	
	//Imp Decisions
	public static bool bomb=false;
	public static bool bombThrow=false;
	public static bool bomberKill=false;
	
	
	
	//Scene Two
	public static int realChest=0;
	
	public GameObject deskChest;
	public GameObject guideChest;
	public GameObject deathChest;
	public GameObject artChest;
	public GameObject casketChest;
	public GameObject familyChest;
	
	
	private bool once=true;
	private GameObject rainGlobal;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		
		
		//SCENE ONE
		
		if(once)
		{
			rainGlobal=GameObject.Find ("RainGlobalControl").gameObject;
			once=false;
		}
	
		if(ResetScript.sceneChoice==0)
		{	
		if(Bomber.boom)
		{
			bomb=true;
		}
			
		}
		
		
		
		
		//SCENE TWO
		
		if(ResetScript.sceneChoice==1)
		{		

			if(realChest==1)
			{
				deskChest.SetActive (true);
				deskChest.transform.parent.FindChild ("Chest").gameObject.SetActive (false);
			}
			
			if(realChest==2)
			{
				guideChest.SetActive (true);
				guideChest.transform.parent.FindChild ("Chest").gameObject.SetActive (false);
			}
			
			if(realChest==3)
			{
				familyChest.SetActive (true);
				familyChest.transform.parent.FindChild ("Chest").gameObject.SetActive (false);
			}
			
			if(realChest==4)
			{
				artChest.SetActive (true);
				artChest.transform.parent.FindChild ("Chest").gameObject.SetActive (false);
			}
			if(realChest==5)
			{
				casketChest.SetActive (true);
				casketChest.transform.parent.FindChild ("Chest").gameObject.SetActive (false);
			}
			
			if(realChest==6)
			{
				deathChest.SetActive (true);
				deathChest.transform.parent.FindChild ("Chest").gameObject.SetActive (false);
				transform.FindChild ("RainFallSystem").gameObject.SetActive (true);
				transform.FindChild("RainSplashSystem").gameObject.SetActive (true);
				
			}
			
		}
	
	}
}
