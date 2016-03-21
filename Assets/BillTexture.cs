using UnityEngine;
using System.Collections;

public class BillTexture : MonoBehaviour {
	
	private bool once=true;
	public Material court;
	public Material rally;
	public Material escalator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(!Bomber.once)
		{
			if(once)
			{
				if(Bomber.locationRand==0)
				{
					gameObject.renderer.material=rally;
				}
				if(Bomber.locationRand==1)
				{
					gameObject.renderer.material=court;
				}
				if(Bomber.locationRand==2)
				{
					gameObject.renderer.material=escalator;
				}
				
				once=false;
					
			}
		}
	}
}
