using UnityEngine;
using System.Collections;

public class PenaltyScript : MonoBehaviour {
	
	public static bool bombAffected=false;
	public static int randChoice=0;
	private CharacterMotor mot;
	public GameObject trail;
	public Camera mainCam;
	private DepthOfFieldScatter scat;
	public static bool slow=false;
	public static bool myopic=false;
	public static bool buzz=false;
	public static bool paranoid=false;
	public static bool hallucinate=false;
	public static bool weird=false;
	public GameObject player;
	public GameObject bomber;
	private float distance=0f;
	private float trailTimer=0f;
	// Use this for initialization
	void Start () {
		
		mot=GetComponent<CharacterMotor>();
		
		scat=mainCam.GetComponent<DepthOfFieldScatter>();
		player=GameObject.FindGameObjectWithTag ("Player");
		bomber=GameObject.FindGameObjectWithTag ("Bomber");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
				
	if(ResetScript.sceneChoice==0)
	{
		if(bombAffected)
		{
			randChoice=Random.Range (0,2);
				
				if(randChoice==0)	//slow movement
				{
				//	Debug.Log(mot.movement.maxForwardSpeed);
					mot.movement.maxForwardSpeed=3;
					mot.movement.maxBackwardsSpeed=3;
					mot.movement.maxSidewaysSpeed=3;
				//	trailTimer+=Time.deltaTime;
				//	if(trailTimer>0.2f)
				//	{
				//		Instantiate(trail,new Vector3(transform.position.x,0.1f,transform.position.z),Quaternion.identity);
				//		trailTimer=0f;
				//	}
					slow=true;
					bombAffected=false;
				}
			
			if(randChoice==1)	//blurry vision/myopic
				{
					
					((DepthOfFieldScatter)mainCam.gameObject.GetComponent<DepthOfFieldScatter>()).enabled=true;
					myopic=true;
					bombAffected=false;
					
				}
			if(randChoice==2)  //buzzing sound

				{
					buzz=true;
					bombAffected=false;
				}						
		}
			
		else
			{
				randChoice=Random.Range (0,2);
				
				if(randChoice==0)//death paranoid
				{
					paranoid=true;
				}
				
				if(randChoice==1)	//hallucinations
				{
					hallucinate=true;
				}
				
				if(randChoice==2)	//weird world
				{
					weird=true;
				}
				
				
			}
	
	}
}
}
