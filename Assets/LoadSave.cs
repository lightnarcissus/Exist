using UnityEngine;
using System.Collections;

public class LoadSave : MonoBehaviour {
	
	public static bool active=false;
	
	public RenderTexture render1;
	public RenderTexture render2;
	public RenderTexture render3;
	public RenderTexture render4;
	public RenderTexture render5;
	public RenderTexture render6;
	public RenderTexture render7;
	
	public Texture tv1;
	public Texture tv2;
	public Texture tv3;
	public Texture tv4;
	public Texture tv5;
	public Texture tv6;
	public Texture tv7;
	public Texture noise;
	
	public Material tvBars;
	
	private byte[] data1;
	private byte[] data2;
	private byte[] data3;
	private byte[] data4;
	private byte[] data5;
	private byte[] data6;
	private byte[] data7;
	
	public GameObject cam1;
	public GameObject cam2;
	public GameObject cam3;
	public GameObject cam4;
	public GameObject cam5;
	public GameObject cam6;
	public GameObject cam7;
	
	public GameObject tvScreen1;
	public GameObject tvScreen2;
	public GameObject tvScreen3;
	public GameObject tvScreen4;
	public GameObject tvScreen5;
	public GameObject tvScreen6;
	public GameObject tvScreen7;
	
	
	private int camPos=1;
	private GameObject currentCam;
	
	private byte[] current;
	
	public static GameObject theObject;
	
	//public GameObject pauseCamera;
	// Use this for initialization
	void Start () 
	{
		cam1.SetActive (false);
		cam2.SetActive (false);
		cam3.SetActive (false);
		cam4.SetActive (false);
		cam5.SetActive (false);
		cam6.SetActive (false);
		cam7.SetActive (false);
		
	
	}
	
	
	void FixedUpdate()
	{
		if(active)
		{
			
		if(data1==null)
		{
			tvScreen1.renderer.material=tvBars;
		}
		else
		{
			tvScreen1.renderer.material.mainTexture=tv1;
		}
		
		
		if(data2==null)
		{
			tvScreen2.renderer.material=tvBars;
		}
		else
		{
			tvScreen2.renderer.material.mainTexture=tv2;
		}
		
		
		if(data3==null)
		{
			tvScreen3.renderer.material=tvBars;
		}
		else
		{
			tvScreen3.renderer.material.mainTexture=tv3;
		}
		
		
		if(data4==null)
		{
			tvScreen4.renderer.material=tvBars;
		}
		else
		{
			tvScreen4.renderer.material.mainTexture=tv4;
		}
		
		
		if(data5==null)
		{
			tvScreen5.renderer.material=tvBars;
		}
		else
		{
			tvScreen5.renderer.material.mainTexture=tv5;
		}
		
		
		if(data6==null)
		{
			tvScreen6.renderer.material=tvBars;
		}
		else
		{
			tvScreen6.renderer.material.mainTexture=tv6;
		}
		
		
		if(data7==null)
		{
			tvScreen7.renderer.material=tvBars;
		}
		else
		{
			tvScreen7.renderer.material.mainTexture=tv7;
		}
		}
	}
	// Update is called once per frame
	void Update () {
		if(active)
		{
		if(Input.GetKeyDown (KeyCode.LeftArrow))
		{
			currentCam.SetActive (false);
			camPos--;
			if(camPos<=0)
				camPos=7;
		}
		
		if(Input.GetKeyDown (KeyCode.RightArrow))
		{
			currentCam.SetActive (false);
			camPos++;
			if(camPos>=8)
				camPos=1;
		
		}
			if(camPos==1)
			{
				cam1.SetActive(true);
			currentCam=cam1;
			}
			if(camPos==2)
			{
			cam2.SetActive(true);
				currentCam=cam2;
			}
			if(camPos==3)
			{
			cam3.SetActive(true);
				currentCam=cam3;
			}
			if(camPos==4)
			{
			cam4.SetActive(true);
				currentCam=cam4;
			}
			if(camPos==5)
			{
			cam5.SetActive(true);
				currentCam=cam5;
			}
			if(camPos==6)
			{
			cam6.SetActive(true);
				currentCam=cam6;
			}
			if(camPos==7)
			{
			cam7.SetActive(true);
				currentCam=cam7;
			}
		
		
		if (Input.GetKeyDown (KeyCode.S)) {
			if(camPos==1)
			{
				theObject.camera.targetTexture=render1;
			data1 = LevelSerializer.SerializeLevel (false, theObject.transform.parent.gameObject.GetComponent<UniqueIdentifier>().Id);
			}
			if(camPos==2)
			{
			data2 = LevelSerializer.SerializeLevel (false, theObject.transform.parent.gameObject.GetComponent<UniqueIdentifier>().Id);
			}
			if(camPos==3)
			{
			data3 = LevelSerializer.SerializeLevel (false, theObject.transform.parent.gameObject.GetComponent<UniqueIdentifier>().Id);
			}
			if(camPos==4)
			{
			data4 = LevelSerializer.SerializeLevel (false, theObject.transform.parent.gameObject.GetComponent<UniqueIdentifier>().Id);
			}
			if(camPos==5)
			{
			data5 = LevelSerializer.SerializeLevel (false, theObject.transform.parent.gameObject.GetComponent<UniqueIdentifier>().Id);
			}
			if(camPos==6)
			{
			data6 = LevelSerializer.SerializeLevel (false, theObject.transform.parent.gameObject.GetComponent<UniqueIdentifier>().Id);
			}
			if(camPos==7)
			{
			data7 = LevelSerializer.SerializeLevel (false, theObject.transform.parent.gameObject.GetComponent<UniqueIdentifier>().Id);
			}
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			if(camPos==1)
			{
			if(data1!=null)
			{
			PauseMenu.loadMode=false;
			gameObject.SetActive (false);		
			LevelSerializer.LoadNow (data1, false, false);
			}
			}
			if(camPos==2)
			{
			if(data2!=null)
			{
			PauseMenu.loadMode=false;			
			gameObject.SetActive (false);		
			LevelSerializer.LoadNow (data2, false, false);
			}
			}
			if(camPos==3)
			{
			if(data3!=null)
			{
			PauseMenu.loadMode=false;
			gameObject.SetActive (false);	
			LevelSerializer.LoadNow (data3, false, false);	
			}
			}
			if(camPos==4)
			{
			if(data4!=null)
			{
			PauseMenu.loadMode=false;
			gameObject.SetActive (false);	
			LevelSerializer.LoadNow (data4, false, false);
			}
			}if(camPos==5)
			{
			if(data5!=null)
			{
			PauseMenu.loadMode=false;
			gameObject.SetActive (false);			
			LevelSerializer.LoadNow (data5, false, false);
			}
			}
			if(camPos==6)
			{
			if(data6!=null)
			{
			PauseMenu.loadMode=false;
			gameObject.SetActive (false);	
			LevelSerializer.LoadNow (data6, false, false);
			}
			}
			if(camPos==7)
			{
			if(data7!=null)
			{
			PauseMenu.loadMode=false;
			gameObject.SetActive (false);	
			LevelSerializer.LoadNow (data7, false, false);
			}
			}
			
		}
		
		if(PauseMenu.saveMode)
		{
			
			if(Input.GetKey (KeyCode.Escape))
			{
				//LevelSerializer.SaveGame("First");
				PauseMenu.saveMode=false;
				gameObject.SetActive (false);
			}
		}
		
		if(PauseMenu.loadMode)
		{
			
			if(Input.GetKey (KeyCode.Escape))
			{
				
				PauseMenu.loadMode=false;
				gameObject.SetActive (false);
				//LevelSerializer.LoadSavedLevel("First");
			}
		}
			
		}
	
	}
}
