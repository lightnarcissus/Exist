using UnityEngine;
using System.Collections;

public class EventScript : MonoBehaviour {
	
	private GameObject player;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(PreBirthScript.timer<=0f)
		{
			StartCoroutine ("Bomb");
			//Destroy yo,but selectively!
			//reload
		}
	}
	
	public IEnumerator Bomb()
	{
		return null;
		
	}
}
