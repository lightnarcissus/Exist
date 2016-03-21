using UnityEngine;
using System.Collections;
using Pathfinding;
public class BomberMovement : MonoBehaviour {
	
	public GameObject player;
	public float checkDistance=0f;
//	public static bool interact=false;
	private Seeker seek;
	public bool newPos=true;
	private float moveTimer=0f;
    //The point to move to
    public Vector3 targetPosition;
	public bool moveFlag=true;
	private float pathEnd;
	private AnimControl anim;
	//private Vector3 lookAt;
	//private Vector3 lastPosition;
	private Quaternion lookRotation;
	private Quaternion rotation;
	public static bool boom=false;
    private CharacterController controller;
	public GameObject explosion;
    //The calculated path
    public Path path;
	private bool once=true;
	private bool startOnce=true;
	private GameObject bag;
    private Path current;
    //The AI's speed per second
    public float speed = 100;
	public static float playerDist=0f;
	private float replayTimer=0f;
    private bool replay=true;
    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 30;
 
    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;
 	private float waitTimer=0f;
	public AudioSource aud;
	
	public AudioClip maleClip;
	public AudioClip femClip;
	public AudioClip maleClip2;
	public AudioClip femClip2;
	public static bool caught=false;
	
	public static bool sound=false;
	public static float bombDistance=0f;
	
    public void Start () {
        seek = GetComponent<Seeker>();
        controller = GetComponent<CharacterController>();
        
		
        //Start a new path to the targetPosition, return the result to the OnPathComplete function
    }
    
    public void OnPathComplete (Path p) {
        //Debug.Log ("Yey, we got a path back. Did it have an error? "+p.error);
        if (!p.error) {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
			//Debug.Log ("Path Complete!");
			moveFlag=true;
        }
    }
 
    public void FixedUpdate () 
	{
		
		if(startOnce)
		{
		player=GameObject.FindGameObjectWithTag ("Player");
		bag=GameObject.FindGameObjectWithTag ("Bag");	
		transform.FindChild ("Dialogue").gameObject.GetComponent<TextMesh>().text="";
			anim=GetComponent<AnimControl>();
			startOnce=false;
		}
		
	//Debug.Log(Player.confront);
		
		if(Player.confront || Player.shoot)
		{
			bag.gameObject.SetActive(false);
		}
		
		if(caught)
		{
			//Debug.Log ("INSIDE YO!");
			gameObject.animation.Play ("Idle");
			transform.LookAt (player.transform);
			//perform hand motion
	//		bag.transform.parent=player.transform;
			//bag.transform.position=new Vector3(player.transform.position.x+0.3175f,player.transform.position.y+0.5853f,player.transform.position.z+0.2683f);
			
		}
		else if(!caught)
		{
			replayTimer=0f;
			replay=true;
		if(!anim.action)
	{ 							//CHECK THIS OUT
		if(moveFlag)
		{	
			//Debug.Log ("Yo!");
			//	lookAt = player.position - LastPosition;
				//Debug.Log (Bomber.bombSite);
		
					targetPosition=player.transform.position;
			current=seek.GetNewPath(transform.position,targetPosition);
				seek.StartPath (current,OnPathComplete);
			//seek.StartPath (transform.position,targetPosition, OnPathComplete);
				//Debug.Log (targetPosition);
			moveFlag=false;
		}
        if (path == null) {
            //We have no path to move after yet
			//Debug.Log ("Null path!");
				anim.randAction=2;
            return;
        }
		moveTimer+=Time.deltaTime;
		if(moveTimer>10f)
		{
			//Debug.Log ("Timer!");
			moveFlag=true;
			moveTimer=0f;
		}
        if (currentWaypoint >= path.vectorPath.Length) {
            //Debug.Log ("End Of Path Reached");
			anim.randAction=2;
			waitTimer+=Time.deltaTime;
			if(waitTimer>8f)
			{
				moveFlag=true;
				waitTimer=0f;
			}
            return;
        }
				
        
        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;
			//Debug.Log(dir);
			if(dir!=Vector3.zero)
		lookRotation=Quaternion.LookRotation (dir);
		rotation = Quaternion.Slerp(transform.rotation, lookRotation , Time.deltaTime * 1f);
			transform.rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
			//transform.LookAt(dir);
        controller.SimpleMove (dir);
        
        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
            currentWaypoint++;
			//lastPosition=player.position;
			anim.randAction=1;
            return;
        }
	}
	}
			
		
		if(path!=null)
		{
			anim.randAction=1;
		}
		checkDistance+=Time.deltaTime;
		if(checkDistance>3f)
		{
		pathEnd=Vector3.Distance (transform.position,targetPosition);
			if(Bomber.bombSite!=null)
		bombDistance=Vector3.Distance (Bomber.bombSite.transform.position,transform.position);
		playerDist=Vector3.Distance (transform.position,player.transform.position);
			if(pathEnd<1f)
			{
				Debug.Log("end");
				moveFlag=true;
			}
				checkDistance=0f;
		}
//		Debug.Log (bombDistance);
		
		if(bombDistance<10f && PreBirthScript.timer<=20f)
		{
			//Debug.Log ("BOOM TRUE");
			Bomber.boom=true;
			
		}
		
		else if(PreBirthScript.timer<=2f)
			Bomber.boom=true;
		
		
		
		
		
		
		
	}
/*	public void OnDisable () {
    seek.pathCallback -= OnPathComplete;
} */

}
