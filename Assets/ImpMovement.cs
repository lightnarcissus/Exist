using UnityEngine;
using System.Collections;
using Pathfinding;
public class ImpMovement : MonoBehaviour {
	
	public GameObject player;
	public float checkDistance=0f;
	public float distance=0f;
//	public static bool interact=false;
	private Seeker seek;
	public bool newPos=true;
	private float moveTimer=0f;
    //The point to move to
    public Vector3 targetPosition;
	public bool moveFlag=true;
	private float randomLimit=0f;
	private float pathEnd;
	private AnimControl anim;
	//private Vector3 lookAt;
	//private Vector3 lastPosition;
	private Quaternion lookRotation;
	private Quaternion rotation;
    private CharacterController controller;
    //The calculated path
    public Path path;
	private Path current;
    private float bombDistance=0f;
    //The AI's speed per second
    public float speed = 100;
    private Transform bomber;
    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 30;
 	private float waitTimer=0f;
    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;
 
    public void Start () {
        seek = GetComponent<Seeker>();
        controller = GetComponent<CharacterController>();
        player=GameObject.FindGameObjectWithTag ("Player");
		anim=GetComponent<AnimControl>();

        //Start a new path to the targetPosition, return the result to the OnPathComplete function
    }
    
    public void OnPathComplete (Path p) {
        //Debug.Log ("Yey, we got a path back. Did it have an error? "+p.error);
        if (!p.error) {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
			//Debug.Log ("Path Complete!");
			//moveFlag=true;
        }
    }
 
    public void FixedUpdate () {
		
	//	if(anim.randAction==1 ||(EventManager.riots && (anim.randAction==0 || anim.randAction==1)))
	//	{
		
		
		if(!anim.action)   //CHECK THIS OUT
		if(moveFlag)
		{	
			//Debug.Log ("Yo!");
			//	lookAt = player.position - LastPosition;
			targetPosition=new Vector3(player.transform.position.x+Random.Range (-100f,100f),transform.position.y,player.transform.position.z+Random.Range (10f,100f));
				current=seek.GetNewPath(transform.position,targetPosition);
				seek.StartPath (current,OnPathComplete);
			//seek.StartPath (transform.position,targetPosition, OnPathComplete);
			moveFlag=false;
		}
			
        if (path == null) {
            //We have no path to move after yet
			//Debug.Log ("Null path!");
				anim.randAction=2;
            return;
        }
			
			
        if (currentWaypoint >= path.vectorPath.Length) {
           // Debug.Log ("End Of Path Reached");
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
				//Debug.Log("Next Waypoint");
            currentWaypoint++;
			//lastPosition=player.position;
			anim.randAction=1;
            return;
        }		
		//}
		
		checkDistance+=Time.deltaTime;
		if(checkDistance>6f)
		{
		pathEnd=Vector3.Distance (transform.position,targetPosition);	
		distance=Vector3.Distance(transform.position,player.transform.position);
			checkDistance=0f;
		if(distance>50f)
			{
				transform.position=new Vector3(player.transform.position.x+Random.Range(-100f,100f),transform.position.y,player.transform.position.z+Random.Range (-200f,200f));
			}
			if(pathEnd<3f)
			{
				//Debug.Log("end");
				moveFlag=true;
			}
		}
		if(Bomber.boom)
		{
			bomber=GameObject.FindGameObjectWithTag ("Bomber").transform;
			bombDistance=Vector3.Distance (transform.position,bomber.position);
			if(bombDistance<100f)
			{
				//bomb effected
				GetComponent<CharacterController>().enabled=false;
				GetComponent<BoxCollider>().enabled=true;
				GetComponent<AnimControl>().enabled=false;
				gameObject.animation.enabled=false;
				gameObject.GetComponent<RAIN.Core.RAINAgent>().enabled=false;
				gameObject.rigidbody.useGravity=true;
				gameObject.GetComponent<CivilianMovement>().enabled=false;
				//active.gameObject.SetActive (true);
		
				
			}
			
		}
		
		
	}
	public void OnDisable () {
    seek.pathCallback -= OnPathComplete;
} 

}
