using UnityEngine;
using System.Collections;

public class Pyramid : MonoBehaviour {

	
	public GameObject riseCam;
	public static bool rise=false;
	private int riseLevel=0;
	
	private int randThought=0;
	private float thoughtTimer=0f;
	// Use this for initialization
	void Start () {
		
		riseCam.SetActive (false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(InteractionScript.lake && !rise)
		{
			if(thoughtTimer>2f)
			{
			randThought=Random.Range (0,2);
			thoughtTimer=0f;
			}
			if(ThoughtManager.thoughtAppear && !ButtonAppear.active)
			{
				if(randThought==0)
				{
				ThoughtManager.activeID=4;
				ThoughtManager.thoughtID=2;
				ButtonAppear.activeButton=4;
				}
				if(randThought==1)
				{
				ThoughtManager.activeID=3;
				ThoughtManager.thoughtID=3;
				ButtonAppear.activeButton=3;
				}
				
				if(ThoughtManager.activeID==4)
			{
					if(ThoughtManager.mainActive2)
					{
						ThoughtManager.mainThought3="Am I invisible or...";
					}
					else
						ThoughtManager.mainThought3="Why can't I see my own reflection?";
			}
			}
				
				if(ThoughtManager.activeID==3)
			{
				ThoughtManager.show=true;
								
				if(ThoughtManager.mainActive2)
					{
						ThoughtManager.mainThought3="Are they coming from the lake?";
					}
					else
						ThoughtManager.mainThought3="What are those voices?";
			}
		}
		
		if(rise)
		{
			if(thoughtTimer>2f)
			{
			randThought=Random.Range (0,6);
			thoughtTimer=0f;
			}
			if(randThought==0)
			{
				ThoughtManager.activeID=4;
				ThoughtManager.thoughtID=3;
				ButtonAppear.activeButton=4;
			}
		}
	
	/*	if(!Bomber.once)
		{
			if(once)
			{
			if(Bomber.selectionRand==0)
			Instantiate (bomberFB,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
			
			if(Bomber.selectionRand==1)
			Instantiate (bomberFW,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
			
			if(Bomber.selectionRand==2)
			Instantiate (bomberFWh,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
			
			if(Bomber.selectionRand==3)
			Instantiate (bomberMB,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
			
			if(Bomber.selectionRand==4)
			Instantiate (bomberMW,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
			
			if(Bomber.selectionRand==5)
			Instantiate (bomberMWh,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
			once=false;
			}
		}*/
}
}
