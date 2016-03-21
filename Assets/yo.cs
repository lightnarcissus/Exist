using UnityEngine;
using System.Collections;

public class yo : MonoBehaviour {
	
	public GameObject green;
	public GameObject red;
	public GameObject blue;
	public GameObject grey;
	public GameObject gold;
	private GameObject active;
	public static float greenActive=2f;
	public static float greyActive=2f;
	public static  float goldActive=2f;
	public static  float blueActive=2f;
	public static  float redActive=2f;
	public Ray pointRay;
	private Vector3 point;
	private Vector3 fix;
	public RaycastHit hit;
	private float checkPos=0f;
	
	public static int choice=1;
	private Vector3 cursorPos;
	// Use this for initialization
	void Start () {
	fix=new Vector3(-458.02f,0f,-350f);
	//active=green;
	//	active.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.Keypad0))
			choice=0;
		if(Input.GetKey (KeyCode.Keypad1))
			choice=1;
		if(Input.GetKey (KeyCode.Keypad2))
			choice=2;
		if(Input.GetKey (KeyCode.Keypad3))
			choice=3;
		if(Input.GetKey (KeyCode.Keypad4))
			choice=4;
			pointRay=Camera.main.ScreenPointToRay(Input.mousePosition);
			point=Camera.main.WorldToViewportPoint(Input.mousePosition);
			//Debug.DrawRay (Input.mousePosition,Vector3.forward,Color.red);
			//Debug.Log (point);
			Debug.DrawLine(point,fix,Color.red);
			if(Physics.Raycast (pointRay,out hit,100f))
			{
				//Debug.Log(hit.collider.gameObject.name);
			}
			checkPos+=Time.deltaTime;
	//	if(checkPos>3f)
	//	{
		cursorPos=Input.mousePosition;
		Debug.Log (cursorPos);
		if(Input.GetMouseButton(0))
		{
		if(choice==9)
	{
		
		if(cursorPos.x<608f &&cursorPos.x>540f && cursorPos.y<331f && cursorPos.y>208f)
		{
			Debug.Log ("GOLD!");
			choice=1;
		}
			if(cursorPos.x<547f &&cursorPos.x>453f && cursorPos.y<237f && cursorPos.y>198f)
		{
			Debug.Log ("BLUE!");
			choice=2;
		}
		if(cursorPos.x<464f &&cursorPos.x>408f && cursorPos.y<352f && cursorPos.y>217f)
		{
			Debug.Log ("GREY!");
			choice=3;
		}
			if(cursorPos.x<535f &&cursorPos.x>424f && cursorPos.y<406f && cursorPos.y>347f)
		{
			Debug.Log ("RED!");
			choice=4;
		}
		}
		}
	//		checkPos=0f;
		//}
		
		//Debug.Log (choice);
		if(choice==0)
		{
		//	active.SetActive (false);
		//	active=green;
		//	green.SetActive (true); 
			if(Input.GetMouseButton(0))
			{
	//		greenActive+=Time.deltaTime;
			if(greenActive<8f)
					greenActive+=Time.deltaTime;
				greenActive=4f;
			if(goldActive<6f)
		{
			goldActive+=Time.deltaTime;
			goldActive=greenActive-0.1f;
		}
			if(blueActive<4f)
			{	
				blueActive+=Time.deltaTime;
				blueActive=goldActive-0.1f;
			}
			if(greyActive<2f)
			{
				greyActive+=Time.deltaTime;
				greyActive=blueActive-0.1f;
			}
			if(redActive<2f)
				{
				redActive+=Time.deltaTime;
				redActive=greyActive-0.1f;
				}
				
				
			}
		//	goldActive=10f-greenActive-blueActive-redActive-greyActive;
		//	blueActive=10f-greenActive-goldActive-redActive-greyActive;
		//	greyActive=10f-greenActive-blueActive-redActive-goldActive;
		//	redActive=10f-greenActive-blueActive-goldActive-greyActive;
		//	blueActive=10f-greenActive;
		//	redActive=10f-greenActive-blueActive;
		//	greyActive=10f-greenActive-blueActive-redActive;
		//	goldActive=10f-greenActive-blueActive-redActive-greyActive;
			//blueActive-=Time.deltaTime;
			//redActive=blueActive;
			//greyActive=redActive;
			//goldActive=greyActive;
			
		}
		if(choice==1)
		{
		//	active.SetActive (false);
		//	active=red;
		//	red.SetActive (true);
		//	redActive+=Time.deltaTime;
			if(Input.GetMouseButton (0))
			{
			if(redActive<8f)
					redActive+=Time.deltaTime;
			if(greenActive<6f)
		{
			greenActive+=Time.deltaTime;
			greenActive=redActive-0.1f;
		}
			if(goldActive<4f)
			{	
				goldActive+=Time.deltaTime;
				goldActive=greenActive-0.1f;
			}
			if(blueActive<2f)
			{
				blueActive+=Time.deltaTime;
				blueActive=goldActive-0.1f;
			}
			if(greyActive<2f)
				{
				greyActive+=Time.deltaTime;
				greyActive=blueActive-0.1f;
				}
			}
		//		redActive+=Time.deltaTime;
		//	goldActive=10f-greenActive-blueActive-redActive-greyActive;
		//	blueActive=10f-greenActive-goldActive-redActive-greyActive;
		//	greyActive=10f-greenActive-blueActive-redActive-goldActive;
		//	greenActive=10f-redActive-blueActive-goldActive-greyActive;
		}
		if(choice==2)
		{
		//	active.SetActive (false);
		//    active=blue;
		//	blue.SetActive (true);
			if(Input.GetMouseButton(0))
			{
		if(blueActive<8f)
					blueActive+=Time.deltaTime;
			if(greyActive<6f)
		{
			greyActive+=Time.deltaTime;
			greyActive=blueActive-0.1f;
		}
			if(redActive<4f)
			{	
				redActive+=Time.deltaTime;
				redActive=greyActive-0.1f;
			}
			if(greenActive<2f)
			{
				greenActive+=Time.deltaTime;
				greenActive=redActive-0.1f;
			}
			if(goldActive<2f)
				{
				goldActive+=Time.deltaTime;
				goldActive=greenActive-0.1f;
				}
			}
		}
		if(choice==3)
		{
		//	active.SetActive (false);
		//	active=grey;
		//	grey.SetActive (true); 
				if(Input.GetMouseButton(0))
			{
		if(greyActive<8f)
					greyActive+=Time.deltaTime;
			if(redActive<6f)
		{
			redActive+=Time.deltaTime;
			redActive=greyActive-0.1f;
		}
			if(greenActive<4f)
			{	
				greenActive+=Time.deltaTime;
				greenActive=redActive-0.1f;
			}
			if(goldActive<2f)
			{
				goldActive+=Time.deltaTime;
				goldActive=greenActive-0.1f;
			}
			if(blueActive<2f)
				{
				blueActive+=Time.deltaTime;
				blueActive=goldActive-0.1f;
				}
			}
		}
		if(choice==4)
		{
		//	active.SetActive (false);
		//	active=gold;
		//	gold.SetActive (true); 
			if(Input.GetMouseButton(0))
			{
		if(goldActive<8f)
					goldActive+=Time.deltaTime;
			if(blueActive<6f)
		{
			blueActive+=Time.deltaTime;
			blueActive=goldActive-0.1f;
		}
			if(greyActive<4f)
			{	
				greyActive+=Time.deltaTime;
				greyActive=blueActive-0.1f;
			}
			if(redActive<2f)
			{
				redActive+=Time.deltaTime;
				redActive=greyActive-0.1f;
			}
			if(greenActive<2f)
				{
				greenActive+=Time.deltaTime;
				greenActive=redActive-0.1f;
				}
			}
		}
		if(greenActive>=3.9f && greenActive<5.9f)
		{
				if(cursorPos.x<613f &&cursorPos.x>512f && cursorPos.y<405f && cursorPos.y>215f)
				{
						Debug.Log ("Keep it Green!");
				}
		}
		if(greenActive>=5.9f && greenActive<7.9f)
		{
				if(cursorPos.x<613f &&cursorPos.x>463f && cursorPos.y<405f && cursorPos.y>197f)
				{
						Debug.Log ("Keep it Green!");
				}
		}
		
		
		if(greenActive>=7.9f)
				{
					if(cursorPos.x<612f &&cursorPos.x>407f && cursorPos.y<406f && cursorPos.y>197f)
				{
						Debug.Log ("Keep it Green!");
				}
				}
		if(greenActive<3.9f)
		if(cursorPos.x<604f &&cursorPos.x>531f && cursorPos.y<400f && cursorPos.y>325f)
		{
			Debug.Log ("GREEN!");
			choice=0;
		}
		
		if(redActive<3.9f)
		{
			if(cursorPos.x<535f &&cursorPos.x>424f && cursorPos.y<406f && cursorPos.y>347f)
		{
				Debug.Log ("Keep it red!");
		}	
		}
		
		
	}
}
