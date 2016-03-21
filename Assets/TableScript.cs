using UnityEngine;
using System.Collections;

public class TableScript : MonoBehaviour {

	public TextMesh dialogue;
	private bool once=true;

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {	

		if(once)
		{
			
			if(gameObject.name=="DialogueFB")
		{
			if(Bomber.selectionRand==0)
			{
				transform.parent.FindChild ("Bag").gameObject.SetActive (false);
				transform.parent.FindChild ("SmallBoard").FindChild ("Sale").gameObject.SetActive(false);
				dialogue.text="We just ran out of stock! Sorry!";
			}
				else
				{
					transform.parent.FindChild ("SmallBoard").FindChild ("OutStock").gameObject.SetActive(false);	
				dialogue.text="For sale!";
				}
		}
		
		if(gameObject.name=="DialogueFW")
		{
			if(Bomber.selectionRand==1)
			{
				transform.parent.FindChild ("Bag").gameObject.SetActive (false);
					transform.parent.FindChild ("SmallBoard").FindChild ("Sale").gameObject.SetActive(false);
				dialogue.text="We just ran out of stock! Sorry!";
			}
				else
				{
					transform.parent.FindChild ("SmallBoard").FindChild ("OutStock").gameObject.SetActive(false);	
				dialogue.text="Carry your woes for cheap.At discount!";
				}
				
		}
		
		if(gameObject.name=="DialogueFWh")
		{
			if(Bomber.selectionRand==2)
			{
				transform.parent.FindChild ("Bag").gameObject.SetActive (false);
					transform.parent.FindChild ("SmallBoard").FindChild ("Sale").gameObject.SetActive(false);
				dialogue.text="We just ran out of stock! Sorry!";
			}
				else
				{
					transform.parent.FindChild ("SmallBoard").FindChild ("OutStock").gameObject.SetActive(false);	
				dialogue.text="Buy these fine products for cheap!";
				}
		}
		
		
		if(gameObject.name=="DialogueMB")
		{
			if(Bomber.selectionRand==3)
			{
				transform.parent.FindChild ("Bag").gameObject.SetActive (false);
					transform.parent.FindChild ("SmallBoard").FindChild ("Sale").gameObject.SetActive(false);
				dialogue.text="We just ran out of stock! Sorry!";
			}
				else
				{
					transform.parent.FindChild ("SmallBoard").FindChild ("OutStock").gameObject.SetActive(false);	
				dialogue.text="For sale!";
				}
		}
		
		if(gameObject.name=="DialogueMW")
		{
			if(Bomber.selectionRand==4)
			{
				transform.parent.FindChild ("Bag").gameObject.SetActive (false);
					transform.parent.FindChild ("SmallBoard").FindChild ("Sale").gameObject.SetActive(false);
				dialogue.text="We just ran out of stock! Sorry!";
			}
				else
				{
					transform.parent.FindChild ("SmallBoard").FindChild ("OutStock").gameObject.SetActive(false);	
				dialogue.text="Carry your woes for cheap.At discount!";
				}
		}
		
		if(gameObject.name=="DialogueMWh")
		{
			if(Bomber.selectionRand==5)
			{
				transform.parent.FindChild ("Bag").gameObject.SetActive (false);
					transform.parent.FindChild ("SmallBoard").FindChild ("Sale").gameObject.SetActive(false);
				dialogue.text="We just ran out of stock! Sorry!";
			}
				else
				{
				transform.parent.FindChild ("SmallBoard").FindChild ("OutStock").gameObject.SetActive(false);	
				dialogue.text="Buy these fine products for cheap!";
				}
		}
		
		}
			
			
	}
}
