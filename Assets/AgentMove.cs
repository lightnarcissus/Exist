using UnityEngine;
using System.Collections;

public class AgentMove : MonoBehaviour {
	
	public NavMeshAgent agent;
	private float changeUp=0f;
	private Vector3 dest;
	public GameObject player;
	public static GameObject eyeGuy;
	public static bool eyeActive=false;
	private float speed=2f;
	public static bool caught=false;
	
	
	public GameObject eye;
	public CharacterMotor motor;
	public FPSInputController fpsInput;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		changeUp+=Time.deltaTime;
		eye.transform.LookAt (player.transform);
		if(changeUp>10f && !eyeActive)
		{
			dest=new Vector3(Random.Range(player.transform.position.x-20f,player.transform.position.x+20f),player.transform.position.y,Random.Range(player.transform.position.z-20f,player.transform.position.z+20f));
			agent.destination=dest;
			changeUp=0f;
		}
		if(agent.hasPath)
		{
			gameObject.animation.Play ("Walk");
		}
		else
		{
			gameObject.animation.Play ("Idle");
		}
		
		//unique for EyeGuy
		
		if(eyeActive && !caught)
		{
			
			if(eyeGuy.transform.parent.gameObject==gameObject)
			{
			//	Debug.Log ("INSIDE");
				//run animation
				agent.destination=new Vector3(player.transform.position.x-2f,player.transform.position.y,player.transform.position.z-2f);
				gameObject.transform.LookAt (player.transform);
				agent.speed=7.5f;
			}
			
			if(Vector3.Distance (eyeGuy.transform.position,player.transform.position)<=5f)
			{
//				Debug.Log("GOTCHA!");
				//snatch sound
				caught=true;
			}
		}
		
		if(caught)
		{
			player.GetComponent<CharacterMotor>().canControl=false;
			player.transform.LookAt (eyeGuy.transform);
			
			//hands appear
			//scream
		}
		
		
		
	
	}
}
