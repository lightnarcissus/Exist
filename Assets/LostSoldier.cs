using UnityEngine;
using System.Collections;

public class LostSoldier : MonoBehaviour {
	
	public GameObject camera;
	public Material skybox;
	
	public static bool burn=false;
	// Use this for initialization
	void Start () {

	
	}
	
	void OnEnable()
	{
		RenderSettings.skybox=skybox;
		RenderSettings.ambientLight=new Color(0.2f,0.1f,0.1f);
		camera.GetComponent<PP_SecurityCamera>().enabled=false;
		camera.GetComponent<PP_Scanlines>().enabled=false;
		camera.GetComponent<PP_LightWave>().enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
