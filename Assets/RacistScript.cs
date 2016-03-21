using UnityEngine;
using System.Collections;

public class RacistScript : MonoBehaviour {
	
	
	private float dist=0f;
	private int randDiag=0;
	public GameObject player;
	private float thoughtTimer=0f;
	private int randThought=0;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable()
	{
		randDiag=Random.Range (0,3);
	}
	
	// Update is called once per frame
	void Update () {
	/*	
		if(MirrorScript.gender==1)
		{
			transform.FindChild ("Male").gameObject.SetActive (false);
			current=transform.FindChild ("Female").gameObject;
		}
		else
			{
			transform.FindChild ("Female").gameObject.SetActive (false);
			current=transform.FindChild ("Male").gameObject;
			}
		
		if(SkinSelect.skinChoose==2)
		{
			current.transform.FindChild ("Skin").gameObject.renderer.material=black;
		}
		if(SkinSelect.skinChoose==1)
		{
			current.transform.FindChild ("Skin").gameObject.renderer.material=wavy;
		}
		if(SkinSelect.skinChoose==0)
		{
			current.transform.FindChild ("Skin").gameObject.renderer.material=white;
		}
		
		*/
		
		if(thoughtTimer>2f)
			{
			randThought=Random.Range (0,3);
			thoughtTimer=0f;
			}
			if(ThoughtManager.thoughtAppear && !ButtonAppear.active)
			{
			thoughtTimer+=Time.deltaTime;
				if(randThought==0)
				{
				ThoughtManager.activeID=4;
				ButtonAppear.activeButton=4;
				}
				if(randThought==1)
				{
				ThoughtManager.activeID=4;
				ButtonAppear.activeButton=4;
				}
				if(randThought==2)
				{
				ThoughtManager.activeID=1;
				ButtonAppear.activeButton=1;
				}
			}
			
			//Debug.Log ("Child1"+ThoughtManager.child1Active);
			
			 if(ThoughtManager.activeID==1)
			{
			ThoughtManager.show=true;
				Debug.Log ("1");
				if(ThoughtManager.child11Active)
				{
					//Debug.Log ("CHILD ONE");
					ButtonAppear.active=false;
				}
				if(ThoughtManager.child12Active)
				{
					//Debug.Log ("CHILD TWO");
					ButtonAppear.active=false;
				}
				ThoughtManager.mainThought="Why don't you have one color?";
				ThoughtManager.mainChild1Thought ="They're insane";
				ThoughtManager.mainChild2Thought="It's a trick";
				ThoughtManager.child1Thought="They're trying to be contrarian";
				ThoughtManager.child2Thought="I believe in my truth";
			}
			else if(ThoughtManager.activeID==4)
			{
			ThoughtManager.show=true;
				Debug.Log ("3");
				if(ThoughtManager.child41Active)
				{
					Debug.Log ("CHILD ONE");
					ButtonAppear.active=false;
				}
				if(ThoughtManager.child42Active)
				{
					Debug.Log ("CHILD TWO");
					ButtonAppear.active=false;
				}
			
			if(randThought==0)
			{
				ThoughtManager.mainThought="I do not understand their kind";
				ThoughtManager.mainChild1Thought ="Why..";
				ThoughtManager.mainChild2Thought="What..";
				ThoughtManager.child1Thought="Would you be color-blind?";
				ThoughtManager.child2Thought="Do they hope to achieve?";
			}
			else if(randThought==1)
			{
				ThoughtManager.mainThought="Must be tragic to be colorblind";
				ThoughtManager.mainChild1Thought ="Color...";
				ThoughtManager.mainChild2Thought="Blindness...";
				ThoughtManager.child1Thought="is a historical and biological fact";
				ThoughtManager.child2Thought="is their new-age liberal fallacy";
			}
			}
		
		else if(ThoughtManager.activeID==2 || ThoughtManager.activeID==3)
		{
				Debug.Log ("Blank");
				ThoughtManager.show=false;
		}
		
		
	
	}
}
