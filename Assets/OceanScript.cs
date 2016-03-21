using UnityEngine;
using System.Collections;

public class OceanScript : MonoBehaviour {
	
	public GUIText timer;
	public static float oceanTimer=0f;
	// Use this for initialization
	void Start () {
		
		timer.enabled=false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		oceanTimer+=Time.deltaTime;
	
	}
}
