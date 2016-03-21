using UnityEngine;
using System.Collections;

public class SkinSelect : MonoBehaviour {
	
	public static int skinChoose=0;
	public Material black;
	public Material white;
	public Material wavy;
	public Material mystery;
	private bool once=true;
	// Use this for initialization
	void Start () {
		
				}
	
	void FixedUpdate()
	{
		if(once)
		{
		skinChoose=Random.Range (0,3);
		if(skinChoose==0)
		{
		//	renderer.material=black;
		}
		
		if(skinChoose==1)
		{
	//		renderer.material=wavy;
		}
		
		if(skinChoose==2)
		{
		//	renderer.material=white;
		}
			once=false;
			renderer.material=mystery;
			Debug.Log (skinChoose);
		}
		
		
		
	}

	
	
}
