using UnityEngine;
using System.Collections;

public class TentTopScript : MonoBehaviour {
	
	public Material wavy;
	public Material black;
	public Material white;
	private bool once=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(TentScript.tentTop)
		{
			if(once)
			{
			if(Bomber.selectionRand==0 || Bomber.selectionRand==3)
			{
				gameObject.renderer.material=black;
			}
			if(Bomber.selectionRand==1 || Bomber.selectionRand==4)
			{
				gameObject.renderer.material=wavy;
			}
			if(Bomber.selectionRand==2 || Bomber.selectionRand==5)
			{
				gameObject.renderer.material=white;
			}
			once=false;
			}
		}
		
	}
}
