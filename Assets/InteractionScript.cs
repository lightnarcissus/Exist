using UnityEngine;
using System.Collections;

public class InteractionScript : MonoBehaviour {
	
	
	
	
	
	//Tutorial
	public static bool tutBust=false;
	public static GameObject tutBustActive;
	
	//Scene One
	public static bool black=false;
	public static GameObject blackActive;
	public static bool wavy=false;
	public static GameObject wavyActive;
	public static bool white=false;
	public static GameObject whiteActive;
	public static bool male=false;
	public static GameObject maleActive;
	public static bool female=false;
	public static GameObject femaleActive;
	public static bool queer=false;
	public static GameObject queerActive;
	public static bool talkGroup=false;
	public static GameObject talkGroupActive;
	public static GameObject talkGroupWavyActive;
	public static GameObject talkGroupFemActive;
	public static bool glassCase=false;
	public static GameObject glassCaseActive;
	public static bool telepole=false;
	public static GameObject telepoleActive;
	public static bool mirrorSelf=false;
	public static GameObject mirrorSelfActive;
	public static bool chairFB=false;
	public static bool chairFW=false;
	public static bool chairFWh=false;
	public static bool chairBlack=false;
	public static bool chairWavy=false;
	public static bool chairWhite=false;
	public static bool chairLock=false;
	private float lockTimer=0f;
	public static GameObject chairActive;
	public static bool sitting=false;
	public static GameObject sittingActive;
	public static bool billboard=false;
	public static GameObject billActive;
	public static bool chalkGeek=false;
	public static GameObject chalkGeekActive;
	public static bool chalkboard=false;
	public static GameObject chalkboardActive;
	public static bool escalator=false;
	public static bool pyramid=false;
	public static GameObject pyramidActive;
	public static bool lightHouseGate=false;
	public static GameObject lightGateActive;
	public static bool lightHouseTop=false;
	public static GameObject lightHouseTopActive;
	public static bool TVBox=false;
	public static GameObject TVBoxActive;
	public static bool direction=false;
	public static GameObject directionActive;
	public static bool tentPeople=false;
	public static GameObject tentPeopleActive;
	public static bool stairs=false;
	public static GameObject stairActive;
	public static bool anarchist=false;
	public static GameObject anarchistActive;
	public static bool sad=false;
	public static bool happy=false;
	public static bool angry=false;
	public static bool introspect=false;
	public static bool impPerson=false;
	public static GameObject impPersonActive;
	public static bool impThing=false;
	public static bool regret=false;
	
	public static bool gas=false;
	public static bool monument=false;
	public static bool lake=false;
	
	public static bool fear=false;
	private float angleX=0f;
	private float angleZ=0f;
	private float angleY=0f;
	public static GameObject active;
	private float resetTimer=0f;
	public static bool bomberWhite=false;
	public static GameObject bomberWhiteActive;
	public static bool bomberBlack=false;
	public static GameObject bomberBlackActive;
	public static bool bomberWavy=false;
	public static GameObject bomberWavyActive;
	public static bool balanceWhite=false;
	public static GameObject balanceWhiteActive;
	public static bool balanceBlack=false;
	public static GameObject balanceBlackActive;
	public static bool scale=false;
	public static GameObject scaleActive;
	public static bool bull=false;
	public static GameObject bullActive;
	public static bool chairJudge=false;
	public static GameObject chairJudgeActive;
	public static bool dollar=false;
	public static GameObject dollarActive;
	public static bool table=false;
	public static GameObject tableActive;
	public static GameObject sphereActive;
	public static bool sphere=false;
	public static bool reflection=false;
	public static GameObject stereotypeActive;
	public static bool stereotype=false;
	public static bool talkGroupWavy=false;
	public static bool talkGroupFem=false;
	public static bool stop=false;
	public static GameObject stopActive;
	public static bool money=false;
	public static GameObject moneyActive;
	public static bool guardian=false;
	public static GameObject guardianActive;
	
	
	
	
	public static bool desk=false;
	public static GameObject deskActive;
	public static bool artist=false;
	public static GameObject artistActive;
	public static bool con=false;
	public static GameObject conActive;
	public static bool giant=false;
	public static GameObject giantActive;
	public static bool family=false;
	public static GameObject familyActive;
	public static bool noose=false;
	public static GameObject nooseActive;
	public static bool casket=false;
	public static GameObject casketActive;
	public static bool guide=false;
	public static GameObject guideActive;
	public static bool key=false;
	public static GameObject keyActive;
	public static bool chest=false;
	public static GameObject chestActive;
	public static bool real=false;
	public static GameObject realActive;
	
	private float sphereCheck=0f;
	private GameObject mainCam;
	
	public static bool boat=true;
	public static GameObject boatActive;
	// Use this for initialization
	void Start () {
		
		mainCam=GameObject.FindGameObjectWithTag ("MainCamera");
	
	}
	
	// Update is called once per frame
	void Update () {
		if(active!=null)
		{
			//Debug.Log("IT'S ON!!");
		if(active!=impPersonActive)
			{
		active.renderer.material.SetColor ("_OutlineColor",Color.white);
		active.renderer.material.SetFloat ("_Outline",0.02f);
			}
		else
			{
				active.renderer.material.SetFloat ("_Outline",0.02f);
			}
		transform.LookAt(active.transform);
			transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
		}
		
		
			
		
	}
	
	void FixedUpdate()
	{
		resetTimer+=Time.deltaTime;
		if(resetTimer>4f)
		{
			WheelScript.activeNode=0;
		
		 black=false;
		 wavy=false;
		white=false;
		male=false;
 		female=false;
			queer=false;

			chest=false;
			gas=false;
			lake=false;
			
			monument=false;
			real=false;
			anarchist=false;
			money=false;
			dollar=false;
			balanceBlack=false;
			balanceWhite=false;
			bull=false;
			table=false;
			
		chalkboard=false;
		chalkGeek=false;
		talkGroup=false;
		talkGroupFem=false;
		talkGroupWavy=false;
		telepole=false;
		glassCase=false;
 		scale=false;
		telepole=false;
		mirrorSelf=false;
		chairFB=false;
		chairFW=false;
 		chairFWh=false;
 		sitting=false;
			
 		billboard=false;
			
		 escalator=false;

		pyramid=false;
 		lightHouseGate=false;
 		lightHouseTop=false;
			
			
			//scene two
			
			con=false;
			artist=false;
			giant=false;
			family=false;
			desk=false;
			key=false;
			noose=false;
			casket=false;
			guide=false;
			
			
			resetTimer=0f;
		}
		
		if(sphere)
		{
			mainCam.GetComponent<NoiseAndGrain>().intensityMultiplier=1f;
			sphereCheck+=Time.deltaTime;
			if(sphereCheck>0.5f)
			{
				sphere=false;
				sphereCheck=0f;
			}
		}
		
		
	if(chairWhite || chairWavy || chairBlack || lockTimer>1f)
		{
			
			lockTimer+=Time.deltaTime;
			if(lockTimer>=1f)
			{
				chairLock=true;
				chairFWh=false;
				chairFW=false;
				chairFB=false;
				chairWhite=false;
				chairWavy=false;
				chairBlack=false;
			}
		}
	}
}
