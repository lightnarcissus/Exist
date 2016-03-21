using UnityEngine;
using System.Collections;

public class GiantScript : MonoBehaviour {
	
	public Material black;
	public Material wavy;
	public Material white;
	private GameObject current;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		
		if(Bomber.selectionRand==0)
		{
			transform.FindChild ("GiantWoman").gameObject.SetActive(true);
			transform.FindChild ("GiantWoman").FindChild ("Female").gameObject.renderer.material=black;
			transform.FindChild ("GiantMan").gameObject.SetActive(false);
		}
		
		if(Bomber.selectionRand==1)
		{
			gameObject.renderer.material=wavy;
			transform.FindChild ("GiantWoman").gameObject.SetActive(true);
			transform.FindChild ("GiantWoman").FindChild ("Female").gameObject.renderer.material=wavy;
			transform.FindChild ("GiantMan").gameObject.SetActive(false);
		}
		
		if(Bomber.selectionRand==2)
		{
			gameObject.renderer.material=white;
			transform.FindChild ("GiantWoman").gameObject.SetActive(true);
			transform.FindChild ("GiantWoman").FindChild ("Female").gameObject.renderer.material=white;
			transform.FindChild ("GiantMan").gameObject.SetActive(false);
		}
		if(Bomber.selectionRand==3)
		{
			gameObject.renderer.material=black;
			transform.FindChild ("GiantWoman").gameObject.SetActive(false);
			
			transform.FindChild ("GiantMan").gameObject.SetActive(true);
			transform.FindChild ("GiantMan").FindChild ("Male").gameObject.renderer.material=black;
		}
		
		if(Bomber.selectionRand==4)
		{
			gameObject.renderer.material=wavy;
			transform.FindChild ("GiantWoman").gameObject.SetActive(false);
			transform.FindChild ("GiantMan").gameObject.SetActive(true);
			transform.FindChild ("GiantMan").FindChild ("Male").gameObject.renderer.material=wavy;
		}
		
		if(Bomber.selectionRand==5)
		{
			gameObject.renderer.material=white;
			transform.FindChild ("GiantWoman").gameObject.SetActive(false);
			transform.FindChild ("GiantMan").gameObject.SetActive(true);
			transform.FindChild ("GiantMan").FindChild ("Male").gameObject.renderer.material=white;
		}
		
	
	}
}
