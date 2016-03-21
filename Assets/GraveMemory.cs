using UnityEngine;
using System.Collections;

public class GraveMemory : MonoBehaviour {
	
	
	private float dreamTimer=0f;
	public GameObject whiteCam;
	public GameObject normalTree;
	public GameObject burningTree;
	
	public GUIStyle style;
	
	public GameObject forestCam;

	// Use this for initialization
	void Start () {
		whiteCam.camera.enabled=false;
	}
	
	void Awake()
	{
		normalTree.SetActive (true);
		burningTree.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
		dreamTimer+=Time.deltaTime;
		if(dreamTimer<3f)
		{
			RenderSettings.ambientLight=new Color(0.8f,0.8f,0.8f);
		}
		
		if(dreamTimer>3f && dreamTimer<3.5f)
		{
			whiteCam.camera.enabled=true;
			gameObject.camera.enabled=false;
		}
		
		
		if(dreamTimer>3.5f)
		{
			RenderSettings.ambientLight=new Color(0.4f,0.4f,0.4f);
			whiteCam.camera.enabled=false;
			gameObject.camera.enabled=true;
			
			normalTree.SetActive (false);
			burningTree.SetActive (true);
			gameObject.GetComponent<NoiseAndGrain>().intensityMultiplier+=Time.deltaTime;
		}
		
		if(dreamTimer>7f)
		{
			forestCam.SetActive(true);
			gameObject.GetComponent<NoiseAndGrain>().intensityMultiplier=1f;
			dreamTimer=0f;
			gameObject.SetActive(false);
		}
	
	}
	
	void OnGUI()
	{
		if(dreamTimer<3f)
		{
			GUI.Label (new Rect(100f,Screen.height-100f,100f,100f),"This is a STATIC MEMORY.Observing or interacting with certain objects will trigger them",style);
		}
		
		if(dreamTimer>3.5f && dreamTimer>7f)
		{
			GUI.Label (new Rect(100f,Screen.height-100f,100f,100f),"These memories provide vague glimpses into your character's mind",style);
			
		}
	}
}
