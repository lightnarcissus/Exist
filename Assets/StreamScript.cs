using UnityEngine;
using System.Collections;

public class StreamScript : MonoBehaviour {
	
	public Material skybox;
	public static bool stream=false;
	public GameObject tutorial;
	public GameObject streamBoat;
	private int randThought=0;
	private float thoughtTimer=0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable()
	{
		if (!ExistStart.start) {

						RenderSettings.skybox = skybox;
						stream = true;
						//DreamTracker.dream=13;
				}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (ExistStart.start){
		
			tutorial.SetActive (true);
		}
		
		
		if(stream && !ExistStart.start)
		{
			if(ButtonAppear.active)
			{
			 if(ThoughtManager.activeID==4)
			{
				ThoughtManager.show=true;
				ThoughtManager.thoughtID=1;
					if(ThoughtManager.mainActive1)
					{
						ThoughtManager.mainThought2="trying to see where I went wrong";
					}
					else
					ThoughtManager.mainThought2="Down this stream again...";
			}
			else if(ThoughtManager.activeID==3)
			{
				ThoughtManager.show=true;
				ThoughtManager.thoughtID=5;
				//Debug.Log ("3");
				if(ThoughtManager.child31Active)
				{
					//Debug.Log ("CHILD ONE");
					StartCoroutine("ChildChoose",31);
				}
				if(ThoughtManager.child32Active)
				{
					//Debug.Log ("CHILD TWO");
					StartCoroutine("ChildChoose",32);
				}
				ThoughtManager.mainThought="My past lines these shores";
				ThoughtManager.mainChild1Thought ="taunting...";
				ThoughtManager.mainChild2Thought="asking...";
				ThoughtManager.child1Thought="me for my failures";
				ThoughtManager.child2Thought="me to learn from it";
			}
			else if(ThoughtManager.activeID==2)
			{
				ThoughtManager.show=true;
				ThoughtManager.thoughtID=1;
					if(ThoughtManager.mainActive1)
					{
						ThoughtManager.mainThought3="just a drop in a stream where there was once an ocean";
						ThoughtManager.mainThought2="";
					}
					else
					ThoughtManager.mainThought2="One thought flows into another...";
			}
			
			else if(ThoughtManager.activeID==1)
			{		
				ThoughtManager.show=true;
				ThoughtManager.thoughtID=1;
					if(ThoughtManager.mainActive1)
					{
						ThoughtManager.mainThought3="nobody to help me through these dark passages";
						ThoughtManager.mainThought2="";
					}
					else
					ThoughtManager.mainThought2="Alone in a boat again";
			}
	
	}
	}
	}
	
	IEnumerator ChildChoose(int child)
	{
		ButtonAppear.active=false;

		return null;
		
	}
}
