using UnityEngine;
using System.Collections;

public class MonumentScript : MonoBehaviour {
	
	public GameObject wrapCam;
	public GameObject monumentMan;
	private bool wrapAllow=false;
	private bool wrapping=false;
	public GameObject player;

	private Object aura;
	// Use this for initialization
	void Start () {
		
		wrapCam.SetActive (false);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(InteractionScript.monument)
		{
			Debug.Log ("MONUMENT ON");
			if(ThoughtManager.thoughtAppear && !ButtonAppear.active)
			{
				ThoughtManager.activeID=3;
				ThoughtManager.thoughtID=2;
				ButtonAppear.activeButton=3;
				
				if(ThoughtManager.activeID==3)
			{
				ThoughtManager.show=true;
								
				if(ThoughtManager.mainActive2)
					{
						ThoughtManager.mainThought3="Emanating a strange aura alien to this place";
						StartCoroutine("CloseThought",aura);
						
					}
					else
						ThoughtManager.mainThought3="This Monument looks out of place...";
			}
				else
					ThoughtManager.mainThought3="";
			}
			
			if(ButtonAppear.active)
			{
				
			if(ThoughtManager.activeID==4)
			{
				ThoughtManager.show=true;
				ThoughtManager.thoughtID=2;
				ButtonAppear.activeButton=4;
				ThoughtManager.mainThought3="Why do I feel uneasy around this monument?";
					
			}
				if(ThoughtManager.activeID==3)
				{
					if(wrapAllow)
					{
						ThoughtManager.show=true;
						ThoughtManager.thoughtID=2;
						ButtonAppear.activeButton=3;
						
						player.transform.LookAt (transform);
						
						if(ThoughtManager.mainActive2)
						{
							StartCoroutine ("Wrap");
							wrapping=true;
							wrapAllow=false;
						}
						ThoughtManager.mainThought3="Let me try focusing my thoughts on this";
						
					}
				}
				if(ThoughtManager.activeID==1)
			{
				ThoughtManager.show=true;
				ThoughtManager.thoughtID=2;
				ButtonAppear.activeButton=1;
					if(ThoughtManager.mainActive2 || wrapAllow)
					{
						player.transform.LookAt (monumentMan.transform);
						wrapAllow=true;
						ThoughtManager.mainThought3="Should I focus my thoughts on it?";
					}
					else
				ThoughtManager.mainThought3="What does he mean by wrapping my mind around it?";
					
			}
				if(ThoughtManager.activeID==2)
			{
				ThoughtManager.show=true;
				ThoughtManager.thoughtID=2;
				ButtonAppear.activeButton=2;
					if(ThoughtManager.mainActive2)
						ThoughtManager.mainThought2="Brick walls surrounding a closed door";
							else
				ThoughtManager.mainThought3="My mind grows rigid around here";
					
			}
				
			}
		}
		
		if(wrapping)
		{
			wrapCam.SetActive(true);
		}
		else
			wrapCam.SetActive (false);
		
		
	
	}
	
	IEnumerator Wrap()
	{
		player.camera.enabled=false;
		wrapCam.SetActive (true);
		wrapCam.animation.Play ("WrapPillar");
		yield return new WaitForSeconds(10f);
		wrapping=false;
		wrapCam.SetActive (false);
		player.camera.enabled=true;
		yield break;
	}
	
	IEnumerator CloseThought(Object child)
	{
		if(child==aura)
		{
			//eerie wave sound emanating
			yield return new WaitForSeconds(1f);
			yield break;
		}
		yield return null;
	}
}
