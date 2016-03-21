using UnityEngine;
using System.Collections;

public class StereotypeSelector : MonoBehaviour {
	
	public GameObject black;
	public GameObject wavy;
	public GameObject white;
	private int selectionRand=0;
	private bool once=true;
	private GameObject active;
	// Use this for initialization
	void Start () {
	selectionRand=Random.Range (0,3);
	}
	
	// Update is called once per frame
	void Update () {
	if(once)
		{
			if(selectionRand==0)
			{
			active=black;
			black.SetActive (true);
		}
		if(selectionRand==1)
		{
			active=wavy;
			wavy.SetActive (true);
		}
		if(selectionRand==2)
		{
			active=white;
			white.SetActive (true);
		}
			once=false;
	}
	}
}
