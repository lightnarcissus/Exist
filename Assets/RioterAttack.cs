using UnityEngine;
using System.Collections;

public class RioterAttack : MonoBehaviour {
	
	private GameObject player;
	private float distance=0f;
	private CharacterMotor mot;
	private GameObject mainCam;
	private bool once=true;
	private GameObject deathCam;
	private float deathTimer=0f;
	public GameObject bloodpool;
	public Material white;
	public Material black;
	public Material wavy;
	private int skinRand=0;
	private bool skinOnce=true;
	// Use this for initialization
	void Start () {
		
		player=GameObject.FindGameObjectWithTag ("Player");
		mot=player.GetComponent<CharacterMotor>();
		mainCam=GameObject.FindGameObjectWithTag ("MainCamera");
		deathCam=GameObject.FindGameObjectWithTag ("Death");
	
	}
	
	// Update is called once per frame
	void Update () {
			if(SkinSelect.skinChoose==0 || SkinSelect.skinChoose==1)
		{
			gameObject.transform.FindChild ("Male").gameObject.renderer.material=white;
		}
		else
		{
			if(skinOnce)
			{
				skinRand=Random.Range (0,2);
				if(skinRand==0)
					gameObject.transform.FindChild ("Male").gameObject.renderer.material=black;
			if(skinRand==1)
					gameObject.transform.FindChild ("Male").gameObject.renderer.material=wavy;
			
			}
		}
	
		distance=Vector3.Distance (player.transform.position,transform.position);
		
		if(distance>1.5f)
		{
			gameObject.animation.Play ("Run1");
			transform.position=Vector3.Lerp (transform.position,player.transform.position-new Vector3(1f,0f,1f),Time.deltaTime*2f);
			transform.LookAt (player.transform);
		}
		
		else
		{
			player.transform.LookAt (transform);
			player.GetComponent<MouseLook>().enabled=false;
			mainCam.GetComponent<MouseLook>().enabled=false;
			mainCam.transform.rotation=Quaternion.Euler (90,0,0);
			Time.timeScale=0.3f;
			if(once)
			{
			gameObject.animation.Play ("Punch");
			PlayerAnim.dead=true;
				Instantiate (bloodpool,new Vector3(player.transform.position.x,0f,player.transform.position.z),Quaternion.identity);
				player.animation.Play ("RemainDead");
				once=false;
				
			}
			else
			{
				gameObject.animation.Play("Idle");
			}
				deathTimer+=Time.deltaTime;
			
			if(deathTimer<5f)
			{
			deathCam.camera.enabled=true;
			mainCam.camera.enabled=false;
				player.GetComponent<CharacterMotor>().canControl=false;
			
		
			deathCam.transform.position+=new Vector3(0f,0.1f,0f);
			deathCam.transform.LookAt (player.transform);
			}
			else
			{
				//fade screen
			}
		
		}
	
	}
}
