using UnityEngine;
using System.Collections;

public class ObjectInteract : MonoBehaviour {
	
	private Rect tex;
	public GUIStyle sty;
	public static bool interact=false;
	private Quaternion fromRotation;
	private Quaternion toRotation;
	private float xDeg=0f;
	
	public GameObject objCam;
	public GameObject obj;
	public static GameObject activeObj;
	private float yDeg=0f;
	public GameObject extraObj;
	private Vector2 targetPos;
	// Use this for initialization
	void Start () {
		
		objCam.SetActive (false);
		tex=new Rect(Screen.width/2f,Screen.height/2f,100f,100f);
		
		
	}
	
	
		// Update is called once per frame
	void Update () {
		
		
		if(Input.GetMouseButtonDown (1))
		{
			interact=true;
		}
		
		if(interact)
		{
			if(InteractionScript.billboard)
			{
				if(InteractionScript.billActive!=null)
				{
					activeObj=InteractionScript.billActive.transform.FindChild ("Obj").gameObject;
					gameObject.camera.enabled=false;
					transform.GetComponent<CharacterMotor>().canControl=false;
					objCam.SetActive (true);
						
				}
				
				
			}
			else if(InteractionScript.artist)
			{
				if(InteractionScript.artistActive!=null)
				{
					activeObj=InteractionScript.artistActive.transform.FindChild ("Obj").gameObject;
					gameObject.camera.enabled=false;
					transform.GetComponent<CharacterMotor>().canControl=false;
					objCam.SetActive (true);
						
				}
				
				
			}
			
			if(Input.GetMouseButtonDown (0))
			{
				interact=false;
			}
		}
		
		
	
	}
	void OnGUI()
	{
		if(InteractionScript.billboard && !interact)
		{
			GUI.Label (tex,"Right Click to Interact",sty);			
		}
		if(interact)
		{
		if(extraObj!=null)
		{
    targetPos =  objCam.camera.WorldToScreenPoint (extraObj.transform.position);   
    GUI.Box(new Rect(targetPos.x, Screen.height- targetPos.y, 60, 20), "GET OUT OF HERE",sty);
		}
		}
	}

}
