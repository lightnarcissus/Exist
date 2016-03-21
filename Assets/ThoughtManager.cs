using UnityEngine;
using System.Collections;

public class ThoughtManager : MonoBehaviour {
	
	
	public static int thoughtID=0;
	
		
	public static bool blueActive=false;
	public static bool greenActive=false;
	public static bool redActive=false;
	public static bool yellowActive=false;
	
	
	public static string mainThought;
	public static string mainThought2;
	public static string mainThought3;
	public static string mainThought4;
	public static string mainThought5;
	
	public static string mainChild1Thought;
	public static string mainChild2Thought;
	public static string child1Thought;
	public static string child2Thought;
	
	public static int activeID=0;
	
	public static bool thoughtAppear=true;
	public static bool thoughtActive=false;
	
	public static bool mainActive1=false;
	public static bool mainActive2=false;
	public static bool mainActive3=false;
	public static bool mainActive4=false;
	
	public static bool child11Active=false;
	public static bool child12Active=false;
	public static bool child21Active=false;
	public static bool child22Active=false;
	public static bool child31Active=false;
	public static bool child32Active=false;
	public static bool child41Active=false;
	public static bool child42Active=false;
	
	public static bool show=false;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(thoughtAppear)
		{

			if(thoughtActive)
			{
				//Debug.Log ("SWITCH IT OFF");
				thoughtAppear=false;
				thoughtActive=false;
			}
		}
		
		if(thoughtAppear || ButtonAppear.active)
		{
			Screen.showCursor=true;
			if(gameObject.GetComponent<MouseLook>()!=null)
			gameObject.GetComponent<MouseLook>().enabled=false;
		}
		else
		{
			Screen.showCursor=false;
			if(gameObject.GetComponent<MouseLook>()!=null)
			gameObject.GetComponent<MouseLook>().enabled=true;
		}
		
	//Debug.Log (activeID);
		if(blueActive)
		{
			activeID=1;
			
			
		}
		else if(greenActive)
		{
			activeID=2;
		}
		else if(redActive)
		{
			activeID=3;
		}
		else if(yellowActive)
		{
			activeID=4;
		}
		
		
		if(thoughtID==0)
		{
			mainThought="";
			mainThought2="";
			mainThought3="";
			mainThought4="";
			mainThought5="";
			
		}
	
	}
	
	
}
