using UnityEngine;
using System.Collections;

public class MirrorScript : MonoBehaviour {
	
	public static int gender=0;
	public static bool burn=false;
	public static bool queerChange=false;
	public GameObject flame;
	private GameObject current;
	public Material queerMat;
	private bool once=true;
	// Use this for initialization
	void Start () {
		gender=Random.Range(0,2);
		if(gender==0)
		{
			gameObject.transform.FindChild ("Male").gameObject.SetActive(false);

			gameObject.transform.FindChild ("Female").gameObject.SetActive(true);
		}
		else
		{
			gameObject.transform.FindChild ("Female").gameObject.SetActive(false);
			
			gameObject.transform.FindChild ("Male").gameObject.SetActive(true);
			
		}
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(queerChange)
		{
		if(once)
		{
			if(gender==0)
			{
			gameObject.transform.FindChild ("Female").FindChild ("Female").gameObject.renderer.material=queerMat;
			}
			else
			{
				gameObject.transform.FindChild ("Male").FindChild ("Male").gameObject.renderer.material=queerMat;
			}
		}
			gameObject.transform.FindChild ("Queer").gameObject.SetActive (true);
			once=false;
		}
		
		if(burn)
		{
		current=Instantiate (flame,new Vector3(transform.position.x,transform.position.y-10f,transform.position.z),Quaternion.identity)as GameObject;
			current.transform.parent=gameObject.transform;
			burn=false;
			//play aaaah sound
		}
	
	}
}
