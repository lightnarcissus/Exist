using UnityEngine;
using System.Collections;

public class TextLife : MonoBehaviour {
	
	private float destroyTimer=0f;
	private GameObject player;
	private Quaternion fromRotation;
	//public GameObject mainCamera;
	private Quaternion toRotation;
	// Use this for initialization
	void Start () {
		
		player=GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		transform.LookAt(player.transform);
		//mainCamera.transform.LookAt (transform);
		// fromRotation = transform.rotation;
      //  toRotation = Quaternion.Euler(0,player.transform.rotation.y,0);
		//transform.rotation=Quaternion.Lerp(fromRotation,toRotation,5f);
		destroyTimer+=Time.deltaTime;
		if(destroyTimer>4f)
		Destroy (gameObject);
	}
}
