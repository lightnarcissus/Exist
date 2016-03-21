using UnityEngine;
using System.Collections;

public class CivDialogue : MonoBehaviour {
	
	public float randChance=0f;
	public int randDialogue=0;
	public TextMesh dialogue;
	private float chanceTimer=0f;
	private bool randOnce=true;
	private GameObject player;
	private bool once=true;
	
	// Use this for initialization
	void Start () {
		
		dialogue.text="";
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	if(once)
		{
			player=GameObject.FindGameObjectWithTag ("Player");
			once=false;
			
		}
		
		if(transform.parent.gameObject.GetComponent<AnimControl>().blame)
		{
			dialogue.text="";
		}
		
		if(WheelScript.peopleChoice!=1)
		{
		
		chanceTimer+=Time.deltaTime;
		
		if(chanceTimer<10f)
		{
			if(randOnce)
			{
			randChance=Random.value;
			randDialogue=Random.Range(0,5);
			randOnce=false;
			}
			if(randChance<0.5f)
			{
				
				if(HistoryScript.gender==0)
					{	
					}
				if(HistoryScript.gender==1)
					{
					}
				
				if(randDialogue==0)
				{
					dialogue.text="These are strange times";
				}
				
				if(randDialogue==1)
				{
					if(Bomber.loc1 || Bomber.bomb)
					{
						if(Bomber.location1==GameObject.FindGameObjectWithTag ("Rally"))
						{
							dialogue.text="A large crowd convenes for the words of a leader";
						}
						else
						{
							dialogue.text="The hammer of justice falls today,doesn't it?";
						}
					}
					else
					dialogue.text="A city full of contradictions";
				}
				
				if(randDialogue==2)
				{
					dialogue.text="These lights blind me";
				}
				
				if(randDialogue==3)
				{
					dialogue.text="I hate people";
				}
				
				
				if(randDialogue==4)
				{
					dialogue.text="There is so much hate";
				}
				
				if(randDialogue==5)
				{
					dialogue.text="Why can't everyone be like me?";
				}
				
				
			}
			}
		}
		
		if(chanceTimer>10f)
		{
			randOnce=true;
			dialogue.text="";
			chanceTimer=0f;
		}
		
		transform.LookAt (player.transform);
	
	}
}
