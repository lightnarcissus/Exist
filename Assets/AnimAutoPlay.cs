using UnityEngine;
using System.Collections;

public class AnimAutoPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnEnable()
	{
		gameObject.animation.Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
