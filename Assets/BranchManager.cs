using UnityEngine;
using System.Collections;

public class BranchManager : MonoBehaviour {

	
	public GameObject solo;
	public GameObject groupBranch;
	public UILabel main1Text;
	public UIButton main1Button;
	public UIButton mainChild1Button;
	public UIButton mainChild2Button;
	public UILabel mainChild1Text;
	public UILabel mainChild2Text;
	public UILabel child1Text;
	public UIFilledSprite child1;
	public UIFilledSprite child1Back;
	public UILabel child2Text;
	public UIFilledSprite child2;
	public UIFilledSprite child2Back;
	
	private int branchID=0;
	private int soloID=0;
	
	public static bool zero=false;
	public static bool justOne=false;
	
	// Use this for initialization
	void Start () {
		
		
		
	}
	void OnEnable()
	{
		
		if(transform.parent.gameObject.name=="BlueButton")
		{
			branchID=1;
		}
		if(transform.parent.gameObject.name=="GreenButton")
		{
			branchID=2;
		}
		if(transform.parent.gameObject.name=="RedButton")
		{
			branchID=3;
		}
		if(transform.parent.gameObject.name=="YellowButton")
		{
			branchID=4;
		}
		
			if(gameObject.name=="Solo1")
			{
				soloID=1;
			}
			if(gameObject.name=="Solo2")
			{
				soloID=2;
			}
			if(gameObject.name=="Solo3")
			{
				soloID=3;
			}
			if(gameObject.name=="Solo4")
			{
				soloID=4;
			}
			if(gameObject.name=="Group")
			{
				soloID=5;
			}
		solo.SetActive (false);
		groupBranch.SetActive (false);
		
		if(soloID==5)
		{
		child1.fillAmount=0f;
		child1Back.enabled=false;
		child1Text.enabled=false;
		main1Text.enabled=false;
		mainChild1Text.enabled=false;
		main1Button.gameObject.SetActive (false);
		mainChild1Button.gameObject.SetActive(false);
		mainChild2Text.enabled=false;
		mainChild2Button.gameObject.SetActive (false);
		child2.fillAmount=0f;
		child2Back.enabled=false;
		child2Text.enabled=false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log ("Branch ID"+branchID);
	//	Debug.Log ("Solo ID"+soloID);
		
		if(ThoughtManager.thoughtAppear && !ThoughtManager.thoughtActive)
		{
			
			if(branchID==ThoughtManager.activeID)
		{
				
		if(soloID==ThoughtManager.thoughtID)
		{
					
					
					if(soloID==1)
				{
					solo.SetActive (true);
					main1Button.gameObject.SetActive (true);
					main1Text.enabled=true;
					main1Text.text=ThoughtManager.mainThought2;	
				}
					if(soloID==2)
				{
					solo.SetActive (true);
					main1Button.gameObject.SetActive (true);
					main1Text.enabled=true;
					main1Text.text=ThoughtManager.mainThought3;	
				}
					if(soloID==3)
				{
					solo.SetActive (true);
					main1Button.gameObject.SetActive (true);
					main1Text.enabled=true;
					main1Text.text=ThoughtManager.mainThought4;	
				}
					if(soloID==4)
				{
					solo.SetActive (true);
					main1Button.gameObject.SetActive (true);
					main1Text.enabled=true;
					main1Text.text=ThoughtManager.mainThought5;	
				}
					if(soloID==5)
				{
					groupBranch.SetActive (true);
					main1Button.gameObject.SetActive (true);
					main1Text.enabled=true;
					main1Text.text=ThoughtManager.mainThought;	
				}
					
		}
		}
		}
		
		
		if(Input.GetMouseButtonDown(0))
		{
			if(branchID==1)
			{
			ThoughtManager.child11Active=false;
			ThoughtManager.child12Active=false;
			}
			if(branchID==2)
			{
			ThoughtManager.child21Active=false;
			ThoughtManager.child22Active=false;
			}
			if(branchID==3)
			{
			ThoughtManager.child31Active=false;
			ThoughtManager.child32Active=false;
			}
			if(branchID==4)
			{
			ThoughtManager.child41Active=false;
			ThoughtManager.child42Active=false;
			}
			ThoughtManager.mainActive1=false;
			ThoughtManager.mainActive2=false;
			ThoughtManager.mainActive3=false;
			ThoughtManager.mainActive4=false;
		}
		
		
		
		if(ButtonAppear.active)
		{
		if(ThoughtManager.show)
		{
		if(branchID==ThoughtManager.activeID)
		{
		if(soloID==ThoughtManager.thoughtID)
		{
						//Debug.Log (soloID);
						
						if(soloID==1)
				{
					solo.SetActive (true);
					main1Button.gameObject.SetActive (true);
					main1Text.enabled=true;
					main1Text.text=ThoughtManager.mainThought2;
							
					if(main1Button.GetComponent<ButtonThought>().active)
				{
								ThoughtManager.mainActive1=true;
				}
				}
				if(soloID==2)
				{
					solo.SetActive (true);
					main1Button.gameObject.SetActive (true);
					main1Text.enabled=true;
					main1Text.text=ThoughtManager.mainThought3;
							
					if(main1Button.GetComponent<ButtonThought>().active)
				{
								ThoughtManager.mainActive2=true;
				}
				}
				if(soloID==3)
				{
					solo.SetActive (true);
					main1Button.gameObject.SetActive (true);
					main1Text.enabled=true;
					main1Text.text=ThoughtManager.mainThought4;
							
					if(main1Button.GetComponent<ButtonThought>().active)
				{
								ThoughtManager.mainActive3=true;
				}
				}
				if(soloID==4)
				{
					solo.SetActive (true);
					main1Button.gameObject.SetActive (true);
					main1Text.enabled=true;
					main1Text.text=ThoughtManager.mainThought5;
							
					if(main1Button.GetComponent<ButtonThought>().active)
				{
								ThoughtManager.mainActive4=true;
				}
				}
			//	Debug.Log ("SoloID=ThoughtID");
				if(soloID==5)
				{
				groupBranch.SetActive (true);
					main1Button.gameObject.SetActive (true);
					main1Text.enabled=true;
					main1Text.text=ThoughtManager.mainThought;
					mainChild1Text.enabled=true;
					mainChild1Text.text=ThoughtManager.mainChild1Thought;
					mainChild1Button.gameObject.SetActive(true);
					mainChild2Text.enabled=true;
					mainChild2Text.text=ThoughtManager.mainChild2Thought;
					mainChild2Button.gameObject.SetActive(true);
						child1.enabled=true;
						child2.enabled=true;
				if(mainChild1Button.GetComponent<ButtonThought>().active)
				{
						child1.fillAmount+=0.06f;
					if(child1.fillAmount>=0.95f)
					{
								//	Debug.Log("CHILD 1");
						if(branchID==1)
						{
						ThoughtManager.child12Active=false;		
						ThoughtManager.child11Active=true;
						}
						if(branchID==2)
						{
						ThoughtManager.child22Active=false;		
						ThoughtManager.child21Active=true;
						}
						if(branchID==3)
						{
						ThoughtManager.child32Active=false;		
						ThoughtManager.child31Active=true;
						}
						if(branchID==4)
						{
						ThoughtManager.child42Active=false;		
						ThoughtManager.child41Active=true;
						}
							child2.fillAmount=0f;
									
						child2.enabled=false;
						child2Back.enabled=false;
						child2Text.enabled=false;
						mainChild2Button.gameObject.SetActive (false);
						mainChild2Text.enabled=false;
									
						child1Back.enabled=true;
						child1Text.enabled=true;
						child1Text.text=ThoughtManager.child1Thought;
						StartCoroutine("EndChild");
					}
					
				}
				if(mainChild2Button.GetComponent<ButtonThought>().active)
				{
								
						child2.fillAmount+=0.06f;
					if(child2.fillAmount>=0.95f)
					{
							//		Debug.Log("CHILD 2");
									
						if(branchID==1)
						{
						ThoughtManager.child11Active=false;
						ThoughtManager.child12Active=true;
						}
						if(branchID==2)
						{
						ThoughtManager.child21Active=false;
						ThoughtManager.child22Active=true;
						}
						if(branchID==3)
						{
						ThoughtManager.child31Active=false;
						ThoughtManager.child32Active=true;
						}
						if(branchID==4)
						{
						ThoughtManager.child41Active=false;
						ThoughtManager.child42Active=true;
						}
							child1.fillAmount=0f;
	
						child1.enabled=false;
						child1Back.enabled=false;
						child1Text.enabled=false;
						mainChild1Button.gameObject.SetActive (false);
						mainChild1Text.enabled=false;
									
						child2Back.enabled=true;
						child2Text.enabled=true;
						child2Text.text=ThoughtManager.child2Thought;
						StartCoroutine("EndChild");
					}
					
				}
		}
			}
					else
					{
						if(soloID==5)
							groupBranch.SetActive(false);
						else
							solo.SetActive (false);
					//
					}
		}
			else
			{
					
					solo.SetActive (false);
					groupBranch.SetActive(false);
		/*	main1Button.gameObject.SetActive (false);
					main1Text.enabled=false;
					mainChild1Text.enabled=false;
					mainChild1Button.gameObject.SetActive(false);
					mainChild2Text.enabled=false;
					mainChild2Button.gameObject.SetActive(false);
			child1Back.enabled=false;
			child1Text.enabled=false;
				child1.enabled=false;
				if(soloID==5)
			{
			child2Back.enabled=false;
			child2Text.enabled=false;	
			child2.enabled=false; 
			}*/
			}
		}
			else
			{
				solo.SetActive (false);
				groupBranch.SetActive (false);
			}
		}
		else
		{
			if(!ThoughtManager.thoughtAppear)
			{
			solo.SetActive (false);
			groupBranch.SetActive(false);
			}
			child1Back.enabled=false;
			child1Text.enabled=false;
			child1.fillAmount=0;
			if(soloID==5)
			{
			child2.fillAmount=0;
			child2Back.enabled=false;
			child2Text.enabled=false;	
			}
		}
		
		if(ThoughtManager.thoughtID==0)
		{
			solo.SetActive (false);
			groupBranch.SetActive (false);
		}
	
	}
	
	
	IEnumerator EndChild()
	{
		float val=0;
		if(zero)
		{
			val=0f;
			zero=false;
		}
		else if(justOne)
		{
		val=1f;
		justOne=false;
		}
		else
		val=1.5f;
		
		yield return new WaitForSeconds(val);
		groupBranch.SetActive (false);
		yield break;
	}
	
	
}
