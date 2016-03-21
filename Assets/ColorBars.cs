using UnityEngine;
using System.Collections;

public class ColorBars : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float scaleX = Mathf.Cos(Time.time) * 0.5F + 1;
        float scaleY = Mathf.Sin(Time.time) * 0.5F + 1;
        renderer.material.mainTextureScale = new Vector2(scaleX, scaleY);
	}
}
