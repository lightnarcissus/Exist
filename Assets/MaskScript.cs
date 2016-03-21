using UnityEngine;
using System.Collections;

public class MaskScript : MonoBehaviour {
	
	public static float changeTimer=0f;
	private GameObject player;
	private bool once=true;
	public static int counter=0;
	public TextMesh dialogue;
	public static bool giveUpWarning=false;
	private float warningTimer=0f;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable()
	{
		player=GameObject.FindGameObjectWithTag ("Player");
		transform.position=new Vector3(player.transform.position.x+Random.Range (-10f,-5f),player.transform.position.y+3f,player.transform.position.z+Random.Range (-10f,-5f));
		audio.Play();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(once)
		{
			player=GameObject.FindGameObjectWithTag ("Player");
			once=false;
			
		}
		
		
	
		
		changeTimer+=Time.deltaTime;
		if(WheelScript.maskHelp || MaskHelp.startWarning)
		{
//			Debug.Log("MASK!");
		//player.GetComponent<MouseLook>().enabled=false;
		player.transform.LookAt (transform);
		}
		
		
		
		if(changeTimer>2.5f)
		{
			transform.position=new Vector3(player.transform.position.x+Random.Range (-10f,10f),player.transform.position.y+3f,player.transform.position.z+Random.Range (-10f,10f));
			changeTimer=0f;
			counter++;
		}
		
		if(!MaskHelp.startWarning && counter>=3)
		{
			counter=0;
			//player.GetComponent<MouseLook>().enabled=true;
			player.transform.eulerAngles=new Vector3(0,player.transform.eulerAngles.y,0);
			WheelScript.maskHelp=false;
			gameObject.SetActive (false);
		}
		
		transform.LookAt (player.transform);
		

	}
}
