using UnityEngine;
using System.Collections;

public class CrackScript : MonoBehaviour {
	
	public static int crackLevel=0;
	public Material crackTex1;
	private bool crack1=true;
	public Material crackTex2;
	private bool crack2=true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(crackLevel==1)
		{
			if(crack1)
			StartCoroutine ("Crack",1);
			
		}
		else if(crackLevel==2)
		{
			if(crack2)
			StartCoroutine ("Crack",2);
		}
		
	
	}
	IEnumerator Crack(int level)
	{
		if(level==1)
		{
			gameObject.renderer.material=crackTex1;
			crack1=false;
			yield break;
		}
		if(level==2)
		{
			gameObject.renderer.material=crackTex2;
			crack2=false;
			yield break;
		}
	
	}
}
