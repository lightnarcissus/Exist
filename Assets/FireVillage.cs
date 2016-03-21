using UnityEngine;
using System.Collections;

public class FireVillage : MonoBehaviour {
	
	private float downtime=0f;
	private bool ready=false;
	
	public GameObject tree1;
	public GameObject tree2;
	public GameObject deadTree1;
	public GameObject deadTree2;
	private bool once=true;
	public static bool scream=false;
	private float screamTimer=0f;

	private float treeDist1=0f;
	private float treeDist2=0f;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	if(once)
		{
			treeDist1=Vector3.Distance (transform.position,tree1.transform.position);
			treeDist2=Vector3.Distance (transform.position,tree2.transform.position);
			once=false;
			//Debug.Log ("DIST1="+treeDist1);
//			Debug.Log ("DIST2="+treeDist2);
		}
		
		if(treeDist1<=5f)
		{
			tree1.SetActive (false);
			deadTree1.SetActive(true);
		}
		if(treeDist2<=5f)
		{
			tree2.SetActive (false);
			deadTree2.SetActive(true);
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
	/*	if(col.gameObject==playSoldier)
		{
			scream=true;
		}
	*/
	}
	
	void OnDisable()
	{
		Destroy (gameObject);
	}
}
