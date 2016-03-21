using UnityEngine;
using System.Collections;

public class HighlightCivs : MonoBehaviour {
	
	public static int highlightGroup=0;
	private bool flag=true;
	
	public float randChance=0f;
	public int randDialogue=0;
	public TextMesh dialogue;
	private float chanceTimer=0f;
	private bool randOnce=true;
	
	public Material black;
	public Material white;
	public Material wavy;
	
	private GameObject player;
	private bool once=true;
	
	
	
	private int gender=0; //none
	private int race=0; //none
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(once)
		{
			player=GameObject.FindGameObjectWithTag ("Player");
			once=false;
			
		}
		
		
		if(gender==0)
		{
			if(gameObject.name=="Female")
		{
			gender=1;
		}
		
		else if(gameObject.name=="Male_Human")
		{
			gender=2;
		}
			else
				gender=3;
		}
		
		if(race==0)
		{
			if(gameObject.renderer.material==black)
			race=1;
		
		else if(gameObject.renderer.material==wavy)
			race=2;
			
		else if(gameObject.renderer.material==white)
				race=3;
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
					
				//PLAYER IS FEMALE	
					
				
		if(HistoryScript.gender==0)
		{
			if(gender==1)	//female to female
			{
				if(randDialogue==0)
				{
					dialogue.text="We should stand together and support our cause";
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
					dialogue.text="Just ignore their stares and you'll be fine";
				}
				
				if(randDialogue==3)
				{
					dialogue.text="Only we understand how difficult it is for us";
				}
				
				
				if(randDialogue==4)
				{
					dialogue.text="There is so much hate";
				}
				
				if(randDialogue==5)
				{
					if(HistoryScript.race==0)	
								{
									if(race==1)
									{
										dialogue.text="Hello,sister";
									}
									else if(race==2)		//wavy woman to black woman
									{
										dialogue.text="We are living this nightmare, together";
									}
									else
									{
										dialogue.text="How do you do?";
									}
									
								}
								if(HistoryScript.race==1)	
								{
									if(race==1)
									{
										dialogue.text="I greatly respect your culture";
									}
									else if(race==2)		//wavy woman to wavy woman
									{
										dialogue.text="Where are our ancestors' values that used to defined us?";
									}
									else
									{
										dialogue.text="I greatly respect your culture";
									}
									
								}
								if(HistoryScript.race==2)	
								{
									if(race==1)
									{
										dialogue.text="We are at once alike yet so different";
									}
									else if(race==2)		//wavy woman to white woman
									{
										dialogue.text="You can be the change we all want for us";
									}
									else
									{
										dialogue.text="I greatly respect your culture";
									}
									
								}
				}
			}
						
						
						
			if(gender==2)	//male to female
				{
				
				
					if(randDialogue==0)
				{
					dialogue.text="We should stand together in support for our cause";
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
					dialogue.text="Just ignore the men's stares and you'll be fine";
				}
				
				if(randDialogue==3)
				{
					dialogue.text="Only we understand how difficult it is for us";
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
			else //queer to female
			{
							if(randDialogue==0)
				{
					dialogue.text="Why don't you understand our pain?";
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
					dialogue.text="Just ignore the men's stares and you'll be fine";
				}
				
				if(randDialogue==3)
				{
					dialogue.text="Only we understand how difficult it is for us";
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
					
					//PLAYER IS MALE
					
					
				else if(HistoryScript.gender==1)
					{
						
						if(gender==1)	//female to male
			{
				if(randDialogue==0)
				{
					dialogue.text="We should stand together in support for our cause";
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
					dialogue.text="Just ignore their stares and you'll be fine";
				}
				
				if(randDialogue==3)
				{
					dialogue.text="Only we understand how difficult it is for us";
				}
				
				
				if(randDialogue==4)
				{
					dialogue.text="There is so much hate";
				}
				
				if(randDialogue==5)
				{
					if(HistoryScript.race==0)	
								{
									if(race==1)
									{
										dialogue.text="How do you do sister?";
									}
									else if(race==2)		//wavy woman to black woman
									{
										dialogue.text="There is so much hate";
									}
									else
									{
										dialogue.text="There is so much hate";
									}
									
								}
								if(HistoryScript.race==1)	
								{
									if(race==1)
									{
									}
									else if(race==2)
									{
									}
									else
									{
										
									}
									
								}
								if(HistoryScript.race==2)	
								{
									if(race==1)
									{
									}
									else if(race==2)
									{
									}
									else
									{
										
									}
									
								}
					dialogue.text="Why can't everyone be like me?";
				}
			}
						
						
						
			if(gender==2)	//male to female
				{
				
				
					if(randDialogue==0)
				{
					dialogue.text="We should stand together in support for our cause";
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
					dialogue.text="Just ignore the men's stares and you'll be fine";
				}
				
				if(randDialogue==3)
				{
					dialogue.text="Only we understand how difficult it is for us";
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
			else //queer to female
			{
							if(randDialogue==0)
				{
					dialogue.text="Why don't you understand our pain?";
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
					dialogue.text="Just ignore the men's stares and you'll be fine";
				}
				
				if(randDialogue==3)
				{
					dialogue.text="Only we understand how difficult it is for us";
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
			}
		}
		
		if(chanceTimer>10f)
		{
			randOnce=true;
			dialogue.text="";
			chanceTimer=0f;
		}
		
		transform.LookAt (player.transform);
	
		
		
		
		
		
		
		
		
		
		
		
		
		if(highlightGroup==1)		//Male
		{
			if(gameObject.tag=="Male")
			{
				gameObject.renderer.material.SetColor ("_OutlineColor",Color.white);
				gameObject.renderer.material.SetFloat ("_Outline",0.02f);
				flag=true;
			}
		}
		
		else if(highlightGroup==2)		//Female
		{
			if(gameObject.tag=="Female")
			{
				gameObject.renderer.material.SetColor ("_OutlineColor",Color.white);
				gameObject.renderer.material.SetFloat ("_Outline",0.02f);
				flag=true;
			}
		}
		
		else if(highlightGroup==3)		// Black	
		{
			if(gameObject.tag=="Black")
			{
				gameObject.renderer.material.SetColor ("_OutlineColor",Color.white);
				gameObject.renderer.material.SetFloat ("_Outline",0.02f);
				flag=true;
			}
		}
		
		else if(highlightGroup==4)		//Wavy
		{
			if(gameObject.tag=="Wavy")
			{
				gameObject.renderer.material.SetColor ("_OutlineColor",Color.white);
				gameObject.renderer.material.SetFloat ("_Outline",0.02f);
				flag=true;
			}
		}
		
		else if(highlightGroup==5)		//White
		{
			if(gameObject.tag=="White")
			{
				gameObject.renderer.material.SetColor ("_OutlineColor",Color.white);
				gameObject.renderer.material.SetFloat ("_Outline",0.02f);
				flag=true;
			}
		}
		
		else if(highlightGroup==6)		//Queer
		{
			if(gameObject.tag=="Queer")
			{
				gameObject.renderer.material.SetColor ("_OutlineColor",Color.white);
				gameObject.renderer.material.SetFloat ("_Outline",0.02f);
				flag=true;
			}
		}
		
		
		else if(highlightGroup==7)		//Wavy and Black
		{
			if(gameObject.tag=="Wavy" || gameObject.tag=="Black")
			{
				gameObject.renderer.material.SetColor ("_OutlineColor",Color.white);
				gameObject.renderer.material.SetFloat ("_Outline",0.02f);
				flag=true;
			}
		}
		
		else
		{
			if(flag)
			{
			gameObject.renderer.material.SetColor ("_OutlineColor",Color.black);
			gameObject.renderer.material.SetFloat ("_Outline",0.002f);
			flag=false;
			}
		}
		//Debug.Log(highlightGroup);
	
	}
}
