using UnityEngine;
using System.Collections;

public class CylinderRotate : MonoBehaviour {

	public int speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate (speed*Time.deltaTime,0,0);
	}
}
