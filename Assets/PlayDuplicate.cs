using UnityEngine;
using System.Collections;

public class PlayDuplicate : MonoBehaviour {
	
	private GameObject current;
	public Material black;
	public Material wavy;
	public Material white;
	public Material mystery;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if(HistoryScript.race==0)
		{
			transform.FindChild ("Skin").gameObject.renderer.material=black;
		}
		if(HistoryScript.race==1)
		{
			transform.FindChild ("Skin").gameObject.renderer.material=wavy;
		}
		if(HistoryScript.race==2)
		{
			transform.FindChild ("Skin").gameObject.renderer.material=white;
		}
		
		//current.transform.FindChild ("Skin").gameObject.renderer.material=mystery;
	}
}
