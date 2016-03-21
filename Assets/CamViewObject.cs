using UnityEngine;
using System.Collections;

public class CamViewObject : MonoBehaviour {

	private Quaternion fromRotation;
	private Quaternion toRotation;
	private float xDeg=0f;
	private float yDeg=0f;
	private Vector3 oldPos;
	private Vector3 oldRot;
	private GameObject obj;
	
	public GameObject mainCam;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable()
	{
		if(ObjectInteract.activeObj!=null)
		{
			obj=ObjectInteract.activeObj;
		}
		oldPos=obj.transform.position;
		oldRot=obj.transform.eulerAngles;
		obj.transform.position=transform.position+transform.forward*1f;
		((DepthOfFieldScatter)gameObject.GetComponent<DepthOfFieldScatter>()).focalTransform =ObjectInteract.activeObj.transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		

	
			//Debug.Log ("OH YEAH!");
			transform.LookAt (ObjectInteract.activeObj.transform);
			 xDeg -= Input.GetAxis("Mouse X") * 5f ;
        yDeg += Input.GetAxis("Mouse Y") * 5f;
		fromRotation =   obj.transform.rotation;
        toRotation = Quaternion.Euler(yDeg,xDeg,xDeg);
        ObjectInteract.activeObj.transform.rotation = Quaternion.Lerp(fromRotation,toRotation,5f);
		
		
		if(Input.GetMouseButtonDown(0))
		{
			ObjectInteract.interact=false;
			ObjectInteract.activeObj.transform.position=new Vector3(oldPos.x,oldPos.y,oldPos.z);
			ObjectInteract.activeObj.transform.eulerAngles=new Vector3(oldRot.x,oldRot.y,oldRot.z);
			mainCam.camera.enabled=true;
			mainCam.transform.GetComponent<CharacterMotor>().canControl=true;
			gameObject.SetActive (false);
		}
	
	}
}
