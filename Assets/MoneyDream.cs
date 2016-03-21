using UnityEngine;
using System.Collections;

public class MoneyDream : MonoBehaviour {
	
	public GameObject player;
	public GameObject sparkles;
	private float playerDist=0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	//	if(WheelScript.randThought==9)
	//	{
			playerDist=Vector3.Distance (transform.position,player.transform.position);
			
			if(playerDist<10f)
			{
				Instantiate (sparkles,transform.position,Quaternion.identity);
				Destroy (gameObject);
			}
		//}
			
	}
}
