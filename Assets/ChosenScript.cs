using UnityEngine;
using System.Collections;

public class ChosenScript : MonoBehaviour {
	
	public GameObject player;
	private float playDistance=0f;
	public GameObject chosen1;
	public GameObject fakeChosen1;
	public GameObject chosen2;
	public GameObject fakeChosen2;
	public GameObject chosen3;
	public GameObject fakeChosen3;
	private float nearTimer1=0f;
	private float nearTimer2=0f;
	private float nearTimer3=0f;
	public static int chosen=0;
	public GameObject inter;
	
	
	public static bool selector=false;
	// Use this for initialization
	void Start () {
		inter.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(selector)
		RenderSettings.ambientLight=new Color(0f,0f,0f,0f);
		
		
		playDistance=Vector3.Distance (transform.position,player.transform.position);
		
		if(playDistance<15f)
		{
			//start playing noises
		}
		
		if(playDistance<5f)
		{
			if(transform.parent.gameObject.name=="Chosen1")
		{
				nearTimer1+=Time.deltaTime;
				if(nearTimer1>5f)
				{
					chosen=1;
				}
			chosen1.SetActive (true);
		}
		
		if(transform.parent.gameObject.name=="Chosen2")
		{
				nearTimer2+=Time.deltaTime;
				if(nearTimer2>5f)
				{
					chosen=2;
				}
			chosen2.SetActive (true);
				//Debug.Log ("Yo");
		}
		
		if(transform.parent.gameObject.name=="Chosen3")
		{
				nearTimer3+=Time.deltaTime;
				if(nearTimer3>5f)
				{
					chosen=3;
				}
			chosen3.SetActive (true);
		}
		}
		
		if(playDistance>5f)
		{
			if(transform.parent.gameObject.name=="Chosen1")
		{
				if(nearTimer1>0f)
				nearTimer1-=Time.deltaTime;
				
			chosen1.SetActive (false);
		}
		
		if(transform.parent.gameObject.name=="Chosen2")
		{
				if(nearTimer2>0f)
				nearTimer2-=Time.deltaTime;
			chosen2.SetActive (false);
				//Debug.Log ("Yo");
		}
		
		if(transform.parent.gameObject.name=="Chosen3")
		{
				if(nearTimer3>0f)
				nearTimer3-=Time.deltaTime;
			chosen3.SetActive (false);
		}
		}
		
		if(chosen==1)
		{
			fakeChosen1.gameObject.animation.Play("JustSitting");
			nearTimer1+=Time.deltaTime;
			if(nearTimer1>6f)
			{
				nearTimer1=0f;
				inter.SetActive (true);
				InterScript.selected=true;
				gameObject.SetActive(false);
			}
		}
		
		if(chosen==2)
		{
			fakeChosen2.gameObject.animation.Play("JustSitting");
			nearTimer2+=Time.deltaTime;
			if(nearTimer2>6f)
			{
				nearTimer2=0f;
				inter.SetActive (true);
				InterScript.selected=true;
				gameObject.SetActive(false);
			}
		}
		
		
		if(chosen==3)
		{
			fakeChosen3.gameObject.animation.Play("JustSitting");
			nearTimer3+=Time.deltaTime;
			if(nearTimer3>6f)
			{
				nearTimer3=0f;
				inter.SetActive (true);
				InterScript.selected=true;
				gameObject.SetActive(false);
			}
		}
		
		//Debug.Log (playDistance);
		
		
	
	}
}
