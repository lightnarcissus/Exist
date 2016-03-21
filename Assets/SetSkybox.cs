using UnityEngine;
using System.Collections;

public class SetSkybox : MonoBehaviour {

	public Material skybox;

	// Use this for initialization
	void Start () {
	
	}

	void OnEnable()
	{
		RenderSettings.skybox=skybox;
	}


}
