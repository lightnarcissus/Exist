using UnityEngine;
using System.Collections;

public class ExecutionWar : MonoBehaviour {
	
	public GameObject camera;
	public GameObject stain1;
	public GameObject stain2;
	public GameObject stain3;
	public GameObject victim1;
	public GameObject victim2;
	public GameObject victim3;
	
	private Ray ray;
	private RaycastHit hit;
	
	private int layerMask;
	// Use this for initialization
	void Start () {
		
		layerMask= 1<<16;
	
	}
	
	void OnEnable()
	{
		victim1.animation.Play("Idle");
		victim2.animation.Play("Idle");
		victim3.animation.Play("Idle");
		stain1.SetActive(false);
		stain2.SetActive(false);
		stain3.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		ray=gameObject.camera.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f,0f));
		 if (Input.GetMouseButtonDown(0)) 
		{
        if (Physics.Raycast (ray, out hit, 50,layerMask)) 
			{
				Debug.Log("INSIDE");
				Debug.Log (hit.collider.gameObject);
				if(hit.collider.gameObject==victim1)
				{
					StartCoroutine ("execution",victim1);
					//hit.collider.gameObject.animation.Play("FallDead");
					//hit.collider.gameObject.animation.PlayQueued("RemainDead",QueueMode.CompleteOthers);
					stain1.SetActive (true);
				}
				if(hit.collider.gameObject==victim2)
				{
					StartCoroutine ("execution",victim2);
				//	hit.collider.gameObject.animation.Play("FallDead");
				//	hit.collider.gameObject.animation.Play("RemainDead");
					stain2.SetActive (true);
				}
				if(hit.collider.gameObject==victim3)
				{
					StartCoroutine ("execution",victim3);
					//hit.collider.gameObject.animation.PlayQueued("FallDead",QueueMode.PlayNow);
					//hit.collider.gameObject.animation.PlayQueued("RemainDead",QueueMode.CompleteOthers);
					stain3.SetActive (true);
				}
			}
		}
 
	
	}
	
	IEnumerator execution(GameObject victim)
	{
		victim.animation.Play ("FallDead");
		yield return new WaitForSeconds(0.5f);
		victim.animation.Play ("RemainDead");
		
	}
}
