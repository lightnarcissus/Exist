using UnityEngine;
using System.Collections;

public class BagScript : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
		transform.FindChild("Bag2").gameObject.SetActive (false);
			
			
			
				transform.FindChild("Bag").gameObject.SetActive (false);
			
		
				transform.FindChild("Bag3").gameObject.SetActive (false);

				transform.FindChild("Bag4").gameObject.SetActive (false);

				transform.FindChild("BagWavy").gameObject.SetActive (false);

				transform.FindChild("Bag6").gameObject.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Player.shoot || Player.confront)
		{
			if(Bomber.selectionRand==0)
			{
				transform.FindChild("Bag2").gameObject.SetActive (true);
			}
			
			if(Bomber.selectionRand==1)
			{
				transform.FindChild("Bag").gameObject.SetActive (true);
			}
			
			if(Bomber.selectionRand==2)
			{
				transform.FindChild("Bag3").gameObject.SetActive (true);
			}
			
			if(Bomber.selectionRand==3)
			{
				transform.FindChild("Bag4").gameObject.SetActive (true);
			}
			if(Bomber.selectionRand==4)
			{
				transform.FindChild("BagWavy").gameObject.SetActive (true);
			}
			if(Bomber.selectionRand==5)
			{
				transform.FindChild("Bag6").gameObject.SetActive (true);
			}
		}
	
	}
}
