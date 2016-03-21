using UnityEngine;
using System.Collections;

public class PreBirthScript : MonoBehaviour {
	public GameObject player;
	public static float timer=600f;
	public GUIText text;
	public int minutes;
	public float seconds;
	public int multFactor=1;
	public GameObject obstacle;
	public GameObject obstacle2;
	public GameObject obstacle3;
	public GameObject obstacle4;
	public GameObject obstacle5;
	public GameObject obstacle6;
	public GameObject obstacle7;
	public GameObject obstacle10;
	public GameObject obstacle12;
	private Vector3 targetPos;
	private int smallRand=0;
	public GameObject lightHouse;
	private bool lightOnce=true;
	public GameObject warRoom;
	private bool warOnce=true;
	private float lightChance=0f;
	private float warChance=0f;
	public GameObject pod;
	private bool podOnce=true;
	private float podChance=0f;
	private int podNumber=0;
	public GameObject TV;
	private bool TVOnce=true;
	private float TVChance=0f;
	private int TVNumber=0;
	public GameObject escalator;
	private bool escOnce=true;	//using Direction instead
	private float escChance=0f;
	private int escNumber=0;
	public GameObject gaze;
	private bool gazeOnce=true;
	private float gazeChance=0f;
	private int gazeNumber=0;
	public GameObject pyramid;
	private bool pyraOnce=true;
	private float pyraChance=0f;
	private int pyraNumber=0;
	private int lightNumber=0;
	private int warNumber=0;
	private int randSelect=0;
	private int rand=0;
	private bool impFirst=true;
	private GameObject buildings;
	private int zFact=0;
	private int multZ=0;
	public AstarPath ast;
	private int lightMultZ=-1;
	private int warMultZ=-1;
	private int tempBuffer=0;
	public bool once=true;
	public GameObject telepole;
	public GameObject bill;
	public GameObject small;
	public GameObject stand;
	public GameObject talk1;
	public GameObject talk2;
	public GameObject talk3;
	public GameObject tableFB;
	public GameObject tableFW;
	public GameObject tableFWh;
	public GameObject tableMB;
	public GameObject tableMW;
	public GameObject tableMWh;
	public GameObject money;
	public GameObject stereotype;
	public GameObject stop;		//once
	public GameObject chalk;	//once
	public GameObject glassCase;	//once	
	public GameObject anarchist;	//once
	public GameObject directionSign;	//replaced escalator
	public GameObject dollar;		//once
	public GameObject tent;		//once
	public GameObject impPerson;		//once
	private bool impOnce=false;
	public GameObject debris;	
	public GameObject sphere;
	private GameObject currentMain;
	private GameObject currentSub;
	public GameObject killAll;
	private GameObject main;
	public static bool flag=true;
	private int thread;
	private int counter=0;
	private int divisionFactor=0;
	private int selector=0;
	public GameObject chairs;
	public GameObject timerObj;
	
	public GameObject staticCity;
	
	// Use this for initialization
	void Start () {
		//Instantiate (player,new Vector3(10f,2f,19.041096f),Quaternion.identity);
		lightNumber=4;
		warNumber=2;
		podNumber=3;
		gazeNumber=5;
		pyraNumber=6;
		TVNumber=7;
		escNumber=8;

		//divisionFactor=Random.Range (5,10);
		divisionFactor=1;
	}
	
	
	// Update is called once per frame
	void Update () {
		//if(timer>=598f)
		if(StarterScript.ready)
		{
		
			if(flag)
		{
			main=Instantiate (killAll,new Vector3(0f,0f,0f),Quaternion.identity)as GameObject;
				timerObj.SetActive (true);
				staticCity.SetActive (true);
			flag=false;
		}
		//StartCoroutine("Procedural");
			//Debug.Log (counter);
		if(impOnce)
			{
				
				//Instantiate (impPerson,new Vector3(Random.Range(transform.position.x-200f,transform.position.x-100f),0f,Random.Range(transform.position.z+200f,transform.position.z+100f)),Quaternion.identity);	
			}
		
		if(!ResetScript.doIt)
			{
		text.enabled=true;
		timer-=Time.deltaTime;
		minutes=Mathf.FloorToInt(timer/60);
		seconds=Mathf.FloorToInt(timer-(minutes*60f));
		text.text=string.Format("{0:0}:{1:00}", minutes, seconds);	
			}
			else
				text.enabled=false;
		}
		//Debug.Log(lightChance);
	}
		
	public IEnumerator Procedural()
	{
		
		if(multZ<=10)
		{
		for(int i=0;i<10&&(multFactor<11);i++)
		{
				counter++;
				if(lightNumber==zFact)
				{
					lightChance=Random.value;
					if(lightChance<0.5f)
					if(lightOnce && multFactor<=10)
					{
						currentMain=Instantiate (lightHouse,new Vector3(20f+(45f*multFactor),0f,30f+(multZ*45f)),Quaternion.identity) as GameObject;
						currentMain.transform.parent=main.transform;
						lightMultZ=multZ;
						if(multFactor<=8)
						multFactor+=1;
						
						
						lightOnce=false;
						tempBuffer=i;
						Debug.Log ("Lighthouse"+tempBuffer);
						tempBuffer=0;
					}
					
					//tempBuffer++;
					//Debug.Log (tempBuffer);
				/*if(tempBuffer>=2)
					{
						if(multZ>=1)
						multZ-=1;
						tempBuffer=-10;
					}*/
					
				}
				if(warNumber==zFact)
				{
					warChance=Random.value;
					if(warChance<0.5f)
					if(warOnce && multFactor<=10)
					{
						Instantiate (warRoom,new Vector3(20f+(45f*multFactor),9f,45f+(multZ*45f)),Quaternion.identity);
						//currentMain.transform.parent=main.transform;
						warMultZ=multZ;
						if(multFactor<=8)
						multFactor+=1;
						
						warOnce=false;

					}
					
					//tempBuffer++;
				//	Debug.Log (tempBuffer);
				/*if(tempBuffer>=2)
					{
						if(multZ>=2)
						multZ-=2;
						tempBuffer=-10;
					}*/
				}
				
				if(podNumber==zFact)
				{
					podChance=Random.value;
					if(podChance<0.5f)
					if(podOnce && multFactor<=10)
					{
						Instantiate (pod,new Vector3(45f*multFactor,0f,(multZ*45f)),Quaternion.identity);
						//currentMain.transform.parent=main.transform;
						if(multFactor<=8)
						multFactor+=1;
						
						podOnce=false;
					}
					
					
				//	Debug.Log (tempBuffer);
				/*if(tempBuffer>=2)
					{
						if(multZ>=2)
						multZ-=2;
						tempBuffer=-10;
					}*/
				}
				
				if(gazeNumber==zFact)
				{
					gazeChance=Random.value;
					if(gazeChance<0.5f)
					if(gazeOnce && multFactor<=10)
					{
						currentMain=Instantiate (gaze,new Vector3(45f*multFactor,10f,(multZ*45f)),Quaternion.identity)as GameObject;
						currentMain.transform.parent=main.transform;
						if(multFactor<=8)
						multFactor+=1;	
						gazeOnce=false;

					}
					
					//tempBuffer++;
					//Debug.Log (tempBuffer);
				/*if(tempBuffer>=2)
					{
						if(multZ>=1)
						multZ-=1;
						tempBuffer=-10;
					}*/
					
				}
				
				if(pyraNumber==zFact)
				{
					pyraChance=Random.value;
					if(pyraChance<0.5f)
					if(pyraOnce && multFactor<=10)
					{
						currentMain=Instantiate (pyramid,new Vector3((45f*multFactor),24f,30f+(multZ*45f)),Quaternion.identity)as GameObject;
						currentMain.transform.parent=main.transform;
						if(multFactor<=8)
						multFactor+=1;
						
						
						pyraOnce=false;
					}
				}
				if(TVNumber==zFact)
				{
					TVChance=Random.value;
					if(TVChance<0.5f)
					if(TVOnce && multFactor<=10)
					{
						currentMain=Instantiate (TV,new Vector3((45f*multFactor),-9f,30f+(multZ*45f)),Quaternion.identity)as GameObject;
						currentMain.transform.parent=main.transform;
						if(multFactor<=8)
						multFactor+=1;
						
						
						TVOnce=false;
					}
				}
					
				if(escNumber==zFact)
				{
					escChance=Random.value;
					if(escChance<0.5f)
					if(escOnce && multFactor<=10)
					{
						currentMain=Instantiate (sphere,new Vector3((45f*multFactor),0f,30f+(multZ*45f)),Quaternion.identity)as GameObject;
						currentMain.transform.parent=main.transform;
						if(multFactor<=8)
						multFactor+=1;
						
						
						escOnce=false;
					}
				}
			randSelect=Random.Range (0,7);
				//randSelect=7;
				//randSelect=Random.Range (0,2);;
				tempBuffer++; //remove this if needed
				
				
				if(multZ<0)
				{
					if(warMultZ>=0)
					{
					multZ=warMultZ;
					warMultZ=-3;
					}
					else if(lightMultZ>=0)
					{
						multZ=lightMultZ;
						lightMultZ=-3;
					}
				}
			if(randSelect==0)
				{
				targetPos=new Vector3((45f*multFactor),30f,30f+(multZ*45f));
			    currentMain=Instantiate (obstacle,targetPos,Quaternion.identity)as GameObject;
					currentMain.transform.parent=main.transform;
					
			if(counter/divisionFactor==2)
			{
			selector++;
			if(selector==1)
			{
				currentSub=	Instantiate (chalk,new Vector3(targetPos.x+15.096f,targetPos.y-30f,targetPos.z+18.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+6.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
			if(selector==2)
			{
				currentSub=	Instantiate (glassCase,new Vector3(targetPos.x+15.096f,targetPos.y-31f,targetPos.z+18.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
					currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+6.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
			if(selector==3)
			{
							currentSub=	Instantiate (tent,new Vector3(targetPos.x+15.096f,targetPos.y-28f,targetPos.z+18.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+6.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==4)
			{
				currentSub=	Instantiate (dollar,new Vector3(targetPos.x-1.31f,targetPos.y-29f,targetPos.z-9.56f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+6.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
			if(selector==5)
			{
					currentSub=	Instantiate (stop,new Vector3(targetPos.x+15.096f,targetPos.y-28f,targetPos.z+18.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+15.096f,targetPos.y-30f,targetPos.z+15.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						if(selector==6)
			{
				currentSub=	Instantiate (anarchist,new Vector3(targetPos.x+15.64f,targetPos.y-29f,targetPos.z-0.43f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
							
			}
						
			if(selector==7)
				{
						currentSub=	Instantiate (tableFB,new Vector3(targetPos.x+15.096f,targetPos.y-29.5f,targetPos.z+12.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+3.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
				}
						
					
				if(selector==8)
			{
				currentSub=	Instantiate (tableFW,new Vector3(targetPos.x+15.096f,targetPos.y-29.5f,targetPos.z+12.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+0.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==9)
			{
				currentSub=	Instantiate (tableFWh,new Vector3(targetPos.x+5.096f,targetPos.y-29.5f,targetPos.z+12.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+15.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==10)
			{
				currentSub=	Instantiate (tableMB,new Vector3(targetPos.x+5.096f,targetPos.y-29.5f,targetPos.z+12.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+15.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==11)
			{
				currentSub=	Instantiate (tableMW,new Vector3(targetPos.x+5.096f,targetPos.y-29.5f,targetPos.z+12.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+15.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==12)
			{
				currentSub=	Instantiate (tableMWh,new Vector3(targetPos.x+5.096f,targetPos.y-29.5f,targetPos.z+12.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+15.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
							if(selector==13)
			{
				currentSub=	Instantiate (telepole,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+12.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+15.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						if(selector==14)
			{
				currentSub=	Instantiate (chairs,new Vector3(targetPos.x+5.096f,targetPos.y-28f,targetPos.z+12.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+15.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						if(selector==15)
			{
				currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+12.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							
			}
						
						counter=0;
						
			}
				
					smallRand=Random.Range (0,7);
					if(smallRand==0)
					{
						currentSub= Instantiate (money,new Vector3(targetPos.x+6.306f,targetPos.y-29.5f,targetPos.z-0.19f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==1)
					{
					currentSub=	Instantiate (bill,new Vector3(targetPos.x+5.096f,targetPos.y-30f,targetPos.z+9.64f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==2)
					{
					currentSub=	Instantiate (small,new Vector3(targetPos.x-5.31f,targetPos.y-29f,targetPos.z-0.56f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==3)
					{
					currentSub=	Instantiate (stand,new Vector3(targetPos.x+5.64f,targetPos.y-29f,targetPos.z-0.43f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==4)
					{
					currentSub=	Instantiate (talk1,new Vector3(targetPos.x-1.31f,targetPos.y-30f,targetPos.z-9.56f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==5)
					{
					currentSub=	Instantiate (talk2,new Vector3(targetPos.x-1.31f,targetPos.y-30f,targetPos.z-9.56f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==6)
					{
					currentSub=	Instantiate (talk3,new Vector3(targetPos.x-1.31f,targetPos.y-30f,targetPos.z-9.56f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==7)
					{
					currentSub=	Instantiate (stereotype,new Vector3(targetPos.x-1.31f,targetPos.y-29f,targetPos.z-9.56f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
							
					
				}
						
			if(randSelect==1)
			{
				targetPos=new Vector3((45f*multFactor),30f,30f+(multZ*45f));
			currentMain= Instantiate (obstacle2,targetPos,Quaternion.identity)as GameObject;
					currentMain.transform.parent=main.transform;
					
			if(counter/divisionFactor==2)
			{
			selector++;
			if(selector==1)
			{
				currentSub=	Instantiate (chalk,new Vector3(targetPos.x+13.38f,targetPos.y-30f,targetPos.z+9.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+3.38f,targetPos.y-30f,targetPos.z+19.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==2)
			{
						currentSub=	Instantiate (glassCase,new Vector3(targetPos.x+13.38f,targetPos.y-31f,targetPos.z+9.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+3.38f,targetPos.y-30f,targetPos.z+19.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
		
			}
				
			if(selector==3)
			{
						currentSub=	Instantiate (tent,new Vector3(targetPos.x+13.38f,targetPos.y-28f,targetPos.z+9.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+3.38f,targetPos.y-30f,targetPos.z+19.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==4)
			{
				currentSub=	Instantiate (dollar,new Vector3(targetPos.x-3.57f,targetPos.y-29f,targetPos.z+7.347f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+3.38f,targetPos.y-30f,targetPos.z+19.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						
			if(selector==5)
			{
						currentSub=	Instantiate (stop,new Vector3(targetPos.x+13.38f,targetPos.y-28f,targetPos.z+9.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+3.38f,targetPos.y-30f,targetPos.z+19.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==6)
			{
						currentSub=	Instantiate (anarchist,new Vector3(targetPos.x+3.38f,targetPos.y-30f,targetPos.z+19.27f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
			}
						
					
						if(selector==7)
			{
						currentSub=	Instantiate (tableFB,new Vector3(targetPos.x+13.38f,targetPos.y-29.5f,targetPos.z+19.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==8)
			{
						currentSub=	Instantiate (tableFW,new Vector3(targetPos.x+13.38f,targetPos.y-29.5f,targetPos.z+9.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==9)
			{
						currentSub=	Instantiate (tableFWh,new Vector3(targetPos.x+13.38f,targetPos.y-29.5f,targetPos.z+9.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==10)
			{
						currentSub=	Instantiate (tableMB,new Vector3(targetPos.x+13.38f,targetPos.y-29.5f,targetPos.z+9.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==11)
			{
						currentSub=	Instantiate (tableMW,new Vector3(targetPos.x+13.38f,targetPos.y-29.5f,targetPos.z+19.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==12)
			{
						currentSub=	Instantiate (tableMWh,new Vector3(targetPos.x+13.38f,targetPos.y-29.5f,targetPos.z+19.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==13)
			{
						currentSub=	Instantiate (telepole,new Vector3(targetPos.x+3.38f,targetPos.y-30f,targetPos.z+9.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==14)
			{
						currentSub=	Instantiate (chairs,new Vector3(targetPos.x+13.38f,targetPos.y-27f,targetPos.z+15.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==15)
			{
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+3.38f,targetPos.y-30f,targetPos.z+19.27f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						counter=0;
						
			}
					
		
						smallRand=Random.Range (0,8);
					if(smallRand==0)
					{
					currentSub=	Instantiate (money,new Vector3(targetPos.x+5.76f,targetPos.y-29.5f,targetPos.z-14.09f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==1)
					{
					currentSub=	Instantiate (bill,new Vector3(targetPos.x+3.38f,targetPos.y-30f,targetPos.z+9.27f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==2)
					{
					currentSub=	Instantiate (small,new Vector3(targetPos.x-0.57f,targetPos.y-29f,targetPos.z+7.347f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==3)
					{
					currentSub=	Instantiate (stand,new Vector3(targetPos.x+0.94f,targetPos.y-29f,targetPos.z+8.79f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==4)
					{
					currentSub=	Instantiate (talk1,new Vector3(targetPos.x-3.57f,targetPos.y-30f,targetPos.z+7.347f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==5)
					{
					currentSub=	Instantiate (talk2,new Vector3(targetPos.x-3.57f,targetPos.y-30f,targetPos.z+7.347f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==6)
					{
					currentSub=	Instantiate (talk3,new Vector3(targetPos.x-3.57f,targetPos.y-30f,targetPos.z+7.347f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==7)
					{
					currentSub=	Instantiate (stereotype,new Vector3(targetPos.x-1.31f,targetPos.y-29f,targetPos.z-9.56f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
				}
			if(randSelect==2)
			{
				targetPos=new Vector3((45f*multFactor),30f,30f+(multZ*45f));
			currentMain= Instantiate (obstacle3,targetPos,Quaternion.identity) as GameObject;
					currentMain.transform.parent=main.transform;
					
					if(counter/divisionFactor==2)
			{
			selector++;
			if(selector==1)
			{
				currentSub=	Instantiate (chalk,new Vector3(targetPos.x+15.52f,targetPos.y-30f,targetPos.z+12.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
			if(selector==2)
			{
							currentSub=	Instantiate (glassCase,new Vector3(targetPos.x+15.52f,targetPos.y-31f,targetPos.z+16.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
			if(selector==3)
			{
					
							currentSub=	Instantiate (tent,new Vector3(targetPos.x+15.52f,targetPos.y-28f,targetPos.z+12.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==4)
			{
							currentSub=	Instantiate (dollar,new Vector3(targetPos.x+5.2f,targetPos.y-29f,targetPos.z-8.96f),Quaternion.identity) as GameObject;
						currentSub.transform.parent=currentMain.transform;
			currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.52f,targetPos.y-30f,targetPos.z+9.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
			if(selector==5)
			{
						currentSub=	Instantiate (stop,new Vector3(targetPos.x+15.52f,targetPos.y-28f,targetPos.z+12.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==6)
			{
							currentSub=	Instantiate (anarchist,new Vector3(targetPos.x+15.52f,targetPos.y-30f,targetPos.z+15.9f),Quaternion.identity) as GameObject;
						currentSub.transform.parent=currentMain.transform;
				currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.52f,targetPos.y-30f,targetPos.z+2.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
	
						
						if(selector==7)
			{
				currentSub=	Instantiate (tableFB,new Vector3(targetPos.x+15.52f,targetPos.y-29.5f,targetPos.z+12.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==8)
			{
				currentSub=	Instantiate (tableFW,new Vector3(targetPos.x+15.52f,targetPos.y-29.5f,targetPos.z+12.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.52f,targetPos.y-30f,targetPos.z+2.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==9)
			{
				currentSub=	Instantiate (tableFWh,new Vector3(targetPos.x+15.52f,targetPos.y-29.5f,targetPos.z+12.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==10)
			{
				currentSub=	Instantiate (tableMB,new Vector3(targetPos.x+15.52f,targetPos.y-29.5f,targetPos.z+12.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==11)
			{
				currentSub=	Instantiate (tableMW,new Vector3(targetPos.x+15.52f,targetPos.y-29.5f,targetPos.z+12.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.52f,targetPos.y-30f,targetPos.z+2.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==12)
			{
				currentSub=	Instantiate (tableMWh,new Vector3(targetPos.x+15.52f,targetPos.y-29.5f,targetPos.z+12.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==13)
			{
				currentSub=	Instantiate (telepole,new Vector3(targetPos.x+15.52f,targetPos.y-30f,targetPos.z+12.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==14)
			{
				currentSub=	Instantiate (chairs,new Vector3(targetPos.x+15.52f,targetPos.y-30f,targetPos.z+12.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						if(selector==15)
			{
				currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.52f,targetPos.y-30f,targetPos.z+9.9f),Quaternion.identity) as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						counter=0;
						
			}
	
					smallRand=Random.Range (0,8);
					if(smallRand==0)
					{
					currentSub=	Instantiate (money,new Vector3(targetPos.x+6.03f,targetPos.y-29.5f,targetPos.z+0.02f),Quaternion.identity) as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==1)
					{
					currentSub=	Instantiate (bill,new Vector3(targetPos.x+5.52f,targetPos.y-30f,targetPos.z+9.9f),Quaternion.identity) as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==2)
					{
					currentSub=	Instantiate (small,new Vector3(targetPos.x+5.5f,targetPos.y-29f,targetPos.z-8.96f),Quaternion.identity) as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==3)
					{
					currentSub=	Instantiate (stand,new Vector3(targetPos.x+6.36f,targetPos.y-29f,targetPos.z-0.16f),Quaternion.identity) as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==4)
					{
					currentSub=	Instantiate (talk1,new Vector3(targetPos.x+5.2f,targetPos.y-30f,targetPos.z-8.96f),Quaternion.identity) as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==5)
					{
					currentSub=	Instantiate (talk2,new Vector3(targetPos.x+5.2f,targetPos.y-30f,targetPos.z-8.96f),Quaternion.identity) as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==6)
					{
					currentSub=	Instantiate (talk3,new Vector3(targetPos.x+5.2f,targetPos.y-30f,targetPos.z-8.96f),Quaternion.identity) as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==7)
					{
					currentSub=	Instantiate (stereotype,new Vector3(targetPos.x+5.2f,targetPos.y-29f,targetPos.z-8.96f),Quaternion.identity) as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
				}
				if(randSelect==3)
					{
				targetPos=new Vector3((45f*multFactor),30f,30f+(multZ*45f));
				currentMain= Instantiate (obstacle4,targetPos,Quaternion.identity)as GameObject;
					currentMain.transform.parent=main.transform;
					if(counter/divisionFactor==2)
			{
			selector++;
			if(selector==1)
			{
				currentSub=	Instantiate (chalk,new Vector3(targetPos.x+15.49f,targetPos.y-30f,targetPos.z+12.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						if(selector==2)
			{
							currentSub=	Instantiate (glassCase,new Vector3(targetPos.x+15.49f,targetPos.y-31f,targetPos.z+12.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.49f,targetPos.y-30f,targetPos.z+3.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
			if(selector==3)
			{
						currentSub=	Instantiate (tent,new Vector3(targetPos.x+15.49f,targetPos.y-28f,targetPos.z+3.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==4)
			{
							currentSub=	Instantiate (dollar,new Vector3(targetPos.x+4.73f,targetPos.y-29f,targetPos.z-9.807f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.49f,targetPos.y-30f,targetPos.z+3.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						
			if(selector==5)
			{
							
						currentSub=	Instantiate (stop,new Vector3(targetPos.x+15.49f,targetPos.y-28f,targetPos.z+12.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.49f,targetPos.y-30f,targetPos.z+5.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			
			}
						
						if(selector==6)
			{
							currentSub=	Instantiate (anarchist,new Vector3(targetPos.x+15.49f,targetPos.y-30f,targetPos.z+12.5f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.49f,targetPos.y-30f,targetPos.z+9.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						
						if(selector==7)
			{
						currentSub=	Instantiate (tableFB,new Vector3(targetPos.x+15.49f,targetPos.y-29.5f,targetPos.z+9.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.49f,targetPos.y-30f,targetPos.z+3.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			
			}
						if(selector==8)
			{
						currentSub=	Instantiate (tableFW,new Vector3(targetPos.x+15.49f,targetPos.y-29.5f,targetPos.z+9.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==9)
			{
						currentSub=	Instantiate (tableFWh,new Vector3(targetPos.x+15.49f,targetPos.y-29.5f,targetPos.z+9.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
					currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.49f,targetPos.y-30f,targetPos.z+3.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			
			}
						if(selector==10)
			{
						currentSub=	Instantiate (tableMB,new Vector3(targetPos.x+15.49f,targetPos.y-29.5f,targetPos.z+9.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
				currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.49f,targetPos.y-30f,targetPos.z+3.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			
			}
						if(selector==11)
			{
						currentSub=	Instantiate (tableMW,new Vector3(targetPos.x+15.49f,targetPos.y-29.5f,targetPos.z+9.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==12)
			{
						currentSub=	Instantiate (tableMWh,new Vector3(targetPos.x+15.49f,targetPos.y-29.5f,targetPos.z+9.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			
			}
						if(selector==13)
			{
						currentSub=	Instantiate (telepole,new Vector3(targetPos.x+15.49f,targetPos.y-30f,targetPos.z+9.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
							if(selector==14)
			{
						currentSub=	Instantiate (chairs,new Vector3(targetPos.x+15.49f,targetPos.y-30f,targetPos.z+9.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==15)
			{
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+5.49f,targetPos.y-30f,targetPos.z+9.5f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						counter=0;
						
			}

					smallRand=Random.Range (0,8);
					if(smallRand==0)
					{
					currentSub=	Instantiate (money,new Vector3(targetPos.x+6.506f,targetPos.y-29.5f,targetPos.z+0.124f),Quaternion.identity) as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==1)
					{
					currentSub=	Instantiate (bill,new Vector3(targetPos.x+5.49f,targetPos.y-30f,targetPos.z+9.5f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==2)
					{
					currentSub=	Instantiate (small,new Vector3(targetPos.x+0.73f,targetPos.y-29f,targetPos.z-9.807f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==3)
					{
					currentSub=	Instantiate (stand,new Vector3(targetPos.x+6.77f,targetPos.y-29f,targetPos.z-1.8f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==4)
					{
					currentSub=	Instantiate (talk1,new Vector3(targetPos.x+4.73f,targetPos.y-30f,targetPos.z-9.807f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==5)
					{
					currentSub=	Instantiate (talk2,new Vector3(targetPos.x+4.73f,targetPos.y-30f,targetPos.z-9.807f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==6)
					{
					currentSub=	Instantiate (talk3,new Vector3(targetPos.x+4.73f,targetPos.y-30f,targetPos.z-9.807f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==7)
					{
					currentSub=	Instantiate (stereotype,new Vector3(targetPos.x+4.73f,targetPos.y-29f,targetPos.z-9.807f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
				}
				if(randSelect==4)
					{
				targetPos=new Vector3((45f*multFactor),30f,30f+(multZ*45f));
				currentMain=Instantiate (obstacle5,targetPos,Quaternion.identity)as GameObject;
					currentMain.transform.parent=main.transform;
					
						if(counter/divisionFactor==2)
			{
			selector++;
			if(selector==1)
			{
				currentSub=	Instantiate (chalk,new Vector3(targetPos.x+11.84f,targetPos.y-30f,targetPos.z+15.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
								currentSub=	Instantiate (debris,new Vector3(targetPos.x+1.84f,targetPos.y-30f,targetPos.z+6.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==2)
			{
							currentSub=	Instantiate (glassCase,new Vector3(targetPos.x+11.84f,targetPos.y-31f,targetPos.z+15.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+1.84f,targetPos.y-30f,targetPos.z+6.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
			if(selector==3)
			{
						currentSub=	Instantiate (tent,new Vector3(targetPos.x+11.84f,targetPos.y-28f,targetPos.z+15.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
								currentSub=	Instantiate (debris,new Vector3(targetPos.x+1.84f,targetPos.y-30f,targetPos.z+6.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==4)
			{
								currentSub=	Instantiate (dollar,new Vector3(targetPos.x+10.28f,targetPos.y-29f,targetPos.z+7.38f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+1.84f,targetPos.y-30f,targetPos.z+6.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						
			if(selector==5)
			{
							currentSub=	Instantiate (stop,new Vector3(targetPos.x+11.84f,targetPos.y-28f,targetPos.z+15.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==6)
			{
							currentSub=	Instantiate (anarchist,new Vector3(targetPos.x+11.84f,targetPos.y-30f,targetPos.z+15.33f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+1.84f,targetPos.y-30f,targetPos.z+12.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						
						if(selector==7)
			{
						currentSub=	Instantiate (tableFB,new Vector3(targetPos.x+11.84f,targetPos.y-29.5f,targetPos.z+15.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==8)
			{
						currentSub=	Instantiate (tableFW,new Vector3(targetPos.x+11.84f,targetPos.y-29.5f,targetPos.z+15.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==9)
			{
						currentSub=	Instantiate (tableFWh,new Vector3(targetPos.x+11.84f,targetPos.y-29.5f,targetPos.z+15.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==10)
			{
						currentSub=	Instantiate (tableMB,new Vector3(targetPos.x+11.84f,targetPos.y-29.5f,targetPos.z+13.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==11)
			{
						currentSub=	Instantiate (tableMW,new Vector3(targetPos.x+11.84f,targetPos.y-29.5f,targetPos.z+15.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==12)
			{
						currentSub=	Instantiate (tableMWh,new Vector3(targetPos.x+11.84f,targetPos.y-29.5f,targetPos.z+13.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==13)
			{
						currentSub=	Instantiate (telepole,new Vector3(targetPos.x+11.84f,targetPos.y-30f,targetPos.z+15.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==14)
			{
						currentSub=	Instantiate (chairs,new Vector3(targetPos.x+11.84f,targetPos.y-30f,targetPos.z+15.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==15)
			{
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+1.84f,targetPos.y-30f,targetPos.z+6.33f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						counter=0;
						
			}
	
					smallRand=Random.Range (0,8);
					if(smallRand==0)
					{
					currentSub=	Instantiate (money,new Vector3(targetPos.x+6.22f,targetPos.y-29.5f,targetPos.z-0.306f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==1)
					{
					currentSub=	Instantiate (bill,new Vector3(targetPos.x+1.84f,targetPos.y-30f,targetPos.z+12.33f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==2)
					{
					currentSub=	Instantiate (small,new Vector3(targetPos.x+6.28f,targetPos.y-29f,targetPos.z-0.48f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==3)
					{
					currentSub=	Instantiate (stand,new Vector3(targetPos.x+6.79f,targetPos.y-29f,targetPos.z+1.52f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==4)
					{
					currentSub=	Instantiate (talk1,new Vector3(targetPos.x+10.28f,targetPos.y-30f,targetPos.z+7.38f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
					if(smallRand==5)
					{
					currentSub=	Instantiate (talk2,new Vector3(targetPos.x+10.28f,targetPos.y-30f,targetPos.z+7.38f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
					if(smallRand==6)
					{
					currentSub=	Instantiate (talk3,new Vector3(targetPos.x+10.28f,targetPos.y-30f,targetPos.z+7.38f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
					if(smallRand==7)
					{
					currentSub=	Instantiate (stereotype,new Vector3(targetPos.x+10.28f,targetPos.y-29f,targetPos.z+7.38f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
				}
					if(randSelect==5)
					{
				targetPos=new Vector3((45f*multFactor),0f,30f+(multZ*45f));
				currentMain=Instantiate (obstacle6,targetPos,Quaternion.identity)as GameObject;
					currentMain.transform.parent=main.transform;
					
									if(counter/divisionFactor==2)
			{
			selector++;
			if(selector==1)
			{
				currentSub=	Instantiate (chalk,new Vector3(targetPos.x+21.18f,targetPos.y,targetPos.z+15f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						if(selector==2)
			{
							currentSub=	Instantiate (glassCase,new Vector3(targetPos.x+21.18f,targetPos.y+1f,targetPos.z+13f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+21.18f,targetPos.y,targetPos.z+9f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
			if(selector==3)
			{
							currentSub=	Instantiate (tent,new Vector3(targetPos.x+21.18f,targetPos.y+2,targetPos.z+13f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==4)
			{
							currentSub=	Instantiate (dollar,new Vector3(targetPos.x-6.52f,targetPos.y+0.87f,targetPos.z+6.91f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+21.18f,targetPos.y,targetPos.z+9f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						
			if(selector==5)
			{
						currentSub=	Instantiate (stop,new Vector3(targetPos.x+21.18f,targetPos.y+2,targetPos.z+14f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==6)
			{
							currentSub=	Instantiate (anarchist,new Vector3(targetPos.x+21.18f,targetPos.y,targetPos.z+13f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
							
			}
				
						if(selector==7)
			{
						currentSub=	Instantiate (tableFB,new Vector3(targetPos.x+21.18f,targetPos.y+0.5f,targetPos.z+9f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							currentSub=	Instantiate (debris,new Vector3(targetPos.x+21.18f,targetPos.y,targetPos.z+15f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						if(selector==8)
			{
						currentSub=	Instantiate (tableFW,new Vector3(targetPos.x+21.18f,targetPos.y+0.5f,targetPos.z+9f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
								currentSub=	Instantiate (debris,new Vector3(targetPos.x+21.18f,targetPos.y,targetPos.z+15f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						if(selector==9)
			{
						currentSub=	Instantiate (tableFWh,new Vector3(targetPos.x+21.18f,targetPos.y+0.5f,targetPos.z+9f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
								currentSub=	Instantiate (debris,new Vector3(targetPos.x+21.18f,targetPos.y,targetPos.z+15f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						if(selector==10)
			{
						currentSub=	Instantiate (tableMB,new Vector3(targetPos.x+21.18f,targetPos.y+0.5f,targetPos.z+9f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==11)
			{
						currentSub=	Instantiate (tableMW,new Vector3(targetPos.x+21.18f,targetPos.y+0.5f,targetPos.z+9f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
								currentSub=	Instantiate (debris,new Vector3(targetPos.x+21.18f,targetPos.y,targetPos.z+15f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						if(selector==12)
			{
						currentSub=	Instantiate (tableMWh,new Vector3(targetPos.x+21.18f,targetPos.y+0.5f,targetPos.z+9f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
								currentSub=	Instantiate (debris,new Vector3(targetPos.x+21.18f,targetPos.y,targetPos.z+15f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
							
						}
						if(selector==13)
			{
						currentSub=	Instantiate (telepole,new Vector3(targetPos.x+21.18f,targetPos.y,targetPos.z+9f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
							if(selector==14)
			{
						currentSub=	Instantiate (chairs,new Vector3(targetPos.x+21.18f,targetPos.y,targetPos.z+12f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
								
			}
			
						if(selector==15)
			{
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+21.18f,targetPos.y,targetPos.z+9f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						counter=0;
						
			}

					smallRand=Random.Range (1,8);
					if(smallRand==1)
					{
					currentSub=	Instantiate (bill,new Vector3(targetPos.x+21.18f,targetPos.y,targetPos.z+9f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==2)
					{
					currentSub=	Instantiate (small,new Vector3(targetPos.x-8.04f,targetPos.y+1.07f,targetPos.z+3.47f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==3)
					{
					currentSub=	Instantiate (stand,new Vector3(targetPos.x-6.52f,targetPos.y+0.87f,targetPos.z+6.91f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==4)
					{
					currentSub=	Instantiate (talk3,new Vector3(targetPos.x-6.52f,targetPos.y+0.3f,targetPos.z+6.91f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
					if(smallRand==5)
					{
					currentSub=	Instantiate (talk2,new Vector3(targetPos.x-6.52f,targetPos.y+0.3f,targetPos.z+6.91f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
					if(smallRand==6)
					{
					currentSub=	Instantiate (talk1,new Vector3(targetPos.x-6.52f,targetPos.y+0.3f,targetPos.z+6.91f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
					if(smallRand==7)
					{
					currentSub=	Instantiate (stereotype,new Vector3(targetPos.x-6.52f,targetPos.y+0.87f,targetPos.z+6.91f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
					
				}
					if(randSelect==6)
					{
				targetPos=new Vector3((45f*multFactor),0f,30f+(multZ*45f));
				currentMain=Instantiate (obstacle7,targetPos,Quaternion.identity)as GameObject;
					currentMain.transform.parent=main.transform;
					
						
									if(counter/divisionFactor==2)
			{
			selector++;
			if(selector==1)
			{
				currentSub=	Instantiate (chalk,new Vector3(targetPos.x-21.64f,targetPos.y,targetPos.z+9.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						if(selector==2)
			{
							currentSub=	Instantiate (glassCase,new Vector3(targetPos.x-11.64f,targetPos.y+1f,targetPos.z+19.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
						currentSub=	Instantiate (debris,new Vector3(targetPos.x-21.64f,targetPos.y,targetPos.z+9.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
			if(selector==3)
			{
						currentSub=	Instantiate (tent,new Vector3(targetPos.x-11.64f,targetPos.y+2,targetPos.z+19.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==4)
			{
							currentSub=	Instantiate (dollar,new Vector3(targetPos.x-2.7f,targetPos.y+0.87f,targetPos.z+18.16f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					currentSub=	Instantiate (debris,new Vector3(targetPos.x-21.64f,targetPos.y,targetPos.z+9.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						
			if(selector==5)
			{	
								currentSub=	Instantiate (stop,new Vector3(targetPos.x-21.64f,targetPos.y+2,targetPos.z+9.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==6)
			{
							currentSub=	Instantiate (anarchist,new Vector3(targetPos.x-11.64f,targetPos.y,targetPos.z+19.28f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						currentSub=	Instantiate (debris,new Vector3(targetPos.x-21.64f,targetPos.y,targetPos.z+9.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						if(selector==7)
			{
						currentSub=	Instantiate (tableFB,new Vector3(targetPos.x-11.64f,targetPos.y+0.5f,targetPos.z+18.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==8)
			{
						currentSub=	Instantiate (tableFW,new Vector3(targetPos.x-11.64f,targetPos.y+0.5f,targetPos.z+18.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==9)
			{
						currentSub=	Instantiate (tableFWh,new Vector3(targetPos.x-11.64f,targetPos.y+0.5f,targetPos.z+18.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==10)
			{
						currentSub=	Instantiate (tableMB,new Vector3(targetPos.x-11.64f,targetPos.y+0.5f,targetPos.z+19.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==11)
			{
						currentSub=	Instantiate (tableMW,new Vector3(targetPos.x-11.64f,targetPos.y+0.5f,targetPos.z+19.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
						}if(selector==12)
			{
						currentSub=	Instantiate (tableMWh,new Vector3(targetPos.x-11.64f,targetPos.y+0.5f,targetPos.z+19.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==13)
			{
						currentSub=	Instantiate (telepole,new Vector3(targetPos.x-11.64f,targetPos.y+0.5f,targetPos.z+19.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==14)
			{
						currentSub=	Instantiate (chairs,new Vector3(targetPos.x-21.64f,targetPos.y,targetPos.z+9.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
			
						if(selector==15)
			{
						currentSub=	Instantiate (debris,new Vector3(targetPos.x-21.64f,targetPos.y,targetPos.z+9.28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						counter=0;
						
			}
					smallRand=Random.Range (1,8);
					if(smallRand==1)
					{
					currentSub=	Instantiate (bill,new Vector3(targetPos.x-21.64f,targetPos.y,targetPos.z+9.28f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
					if(smallRand==2)
					{
					currentSub=	Instantiate (small,new Vector3(targetPos.x+14.99f,targetPos.y+1.07f,targetPos.z+9.89f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
					if(smallRand==3)
					{
					currentSub=	Instantiate (stand,new Vector3(targetPos.x-2.7f,targetPos.y+0.87f,targetPos.z+18.16f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
					if(smallRand==4)
					{
					currentSub=	Instantiate (talk1,new Vector3(targetPos.x-2.7f,targetPos.y+0.25f,targetPos.z+18.16f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
					if(smallRand==5)
					{
					currentSub=	Instantiate (talk3,new Vector3(targetPos.x-2.7f,targetPos.y+0.25f,targetPos.z+18.16f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
					if(smallRand==6)
					{
					currentSub=	Instantiate (talk2,new Vector3(targetPos.x-2.7f,targetPos.y+0.25f,targetPos.z+18.16f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}
					if(smallRand==7)
					{
					currentSub= Instantiate (stereotype,new Vector3(targetPos.x-2.7f,targetPos.y+0.87f,targetPos.z+18.16f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
						
					}			
					
				}
/*
					if(randSelect==7)
					{
				targetPos=new Vector3((45f*multFactor),38f,30f+(multZ*45f));
				currentMain=Instantiate (obstacle10,targetPos,Quaternion.identity)as GameObject;
					currentMain.transform.parent=main.transform;
					
											if(counter/divisionFactor==2)
			{
			selector++;
			if(selector==1)
			{
				currentSub=	Instantiate (glassCase,new Vector3(targetPos.x+37.63f,targetPos.y-38.2f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						if(selector==2)
			{
							currentSub=	Instantiate (glassCase,new Vector3(targetPos.x+37.63f,targetPos.y-38.2f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
						
			}
				
			if(selector==3)
			{
							currentSub=	Instantiate (tent,new Vector3(targetPos.x+37.63f,targetPos.y-36.2f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						
						if(selector==4)
			{
							currentSub=	Instantiate (dollar,new Vector3(targetPos.x+20.72f,targetPos.y-32.36f,targetPos.z+34.35f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					
			}
				
						
			if(selector==5)
			{
							currentSub=	Instantiate (stop,new Vector3(targetPos.x+37.63f,targetPos.y-36.2f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==6)
			{
							currentSub=	Instantiate (anarchist,new Vector3(targetPos.x+37.63f,targetPos.y-37.2f,targetPos.z+28f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
				
			}
				
						
						if(selector==7)
			{
						currentSub=	Instantiate (tableFB,new Vector3(targetPos.x+37.63f,targetPos.y-37.7f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==8)
			{
						currentSub=	Instantiate (tableFW,new Vector3(targetPos.x+37.63f,targetPos.y-37.7f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==9)
			{
						currentSub=	Instantiate (tableFWh,new Vector3(targetPos.x+37.63f,targetPos.y-37.7f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==10)
			{
						currentSub=	Instantiate (tableMB,new Vector3(targetPos.x+37.63f,targetPos.y-37.7f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==11)
			{
						currentSub=	Instantiate (tableMW,new Vector3(targetPos.x+37.63f,targetPos.y-37.7f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==12)
			{
						currentSub=	Instantiate (tableMWh,new Vector3(targetPos.x+37.63f,targetPos.y-37.7f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==13)
			{
						currentSub=	Instantiate (telepole,new Vector3(targetPos.x+37.63f,targetPos.y-38.2f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==14)
			{
						currentSub=	Instantiate (chairs,new Vector3(targetPos.x+37.63f,targetPos.y-38.2f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==15)
			{
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+37.63f,targetPos.y-38.2f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						counter=0;
						
			}
					
					smallRand=Random.Range (0,8);
					if(smallRand==1)
					{
					currentSub=	Instantiate (bill,new Vector3(targetPos.x+37.63f,targetPos.y-38.2f,targetPos.z+28f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==3)
					{
					currentSub=	Instantiate (stand,new Vector3(targetPos.x+20.72f,targetPos.y-37f,targetPos.z+34.35f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==4)
					{
					currentSub=	Instantiate (talk3,new Vector3(targetPos.x+20.72f,targetPos.y-38f,targetPos.z+34.35f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==5)
					{
					currentSub=	Instantiate (talk1,new Vector3(targetPos.x+20.72f,targetPos.y-38f,targetPos.z+34.35f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==6)
					{
					currentSub=	Instantiate (talk2,new Vector3(targetPos.x+20.72f,targetPos.y-38f,targetPos.z+34.35f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==7)
					{
					currentSub=	Instantiate (stereotype,new Vector3(targetPos.x+20.72f,targetPos.y-37f,targetPos.z+34.35f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
				}
				*/
	/*				if(randSelect==8)
					{
				targetPos=new Vector3((45f*multFactor),56f,30f+(multZ*45f));
				currentMain=Instantiate (obstacle12,targetPos,Quaternion.identity)as GameObject;
					currentMain.transform.parent=main.transform;
					
					
			if(counter/divisionFactor==2)
			{
			selector++;
			if(selector==1)
			{
				currentSub=	Instantiate (glassCase,new Vector3(targetPos.x+37.63f,targetPos.y-33.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;
			}
						if(selector==2)
			{
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+37.63f,targetPos.y-33.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
			if(selector==3)
			{
						currentSub=	Instantiate (glassCase,new Vector3(targetPos.x+37.63f,targetPos.y-33.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==4)
			{
					currentSub=	Instantiate (debris,new Vector3(targetPos.x+37.63f,targetPos.y-33.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						
			if(selector==5)
			{
						currentSub=	Instantiate (tent,new Vector3(targetPos.x+37.63f,targetPos.y-31.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						
						if(selector==6)
			{
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+37.63f,targetPos.y-33.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						
			if(selector==7)
				{
						currentSub=	Instantiate (dollar,new Vector3(targetPos.x+20.72f,targetPos.y-32.36f,targetPos.z+34.35f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
				}
					
						if(selector==8)
			{
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+37.63f,targetPos.y-33.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						if(selector==9)
						{
							currentSub=	Instantiate (stop,new Vector3(targetPos.x+37.63f,targetPos.y-31.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
						}
						
						if(selector==10)
			{
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+37.63f,targetPos.y-33.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						
						if(selector==11)
						{
							currentSub=	Instantiate (anarchist,new Vector3(targetPos.x+37.63f,targetPos.y-32.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
							
						}
						if(selector==12)
			{
						currentSub=	Instantiate (tableFB,new Vector3(targetPos.x+37.63f,targetPos.y-32.83f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==13)
			{
						currentSub=	Instantiate (tableFW,new Vector3(targetPos.x+37.63f,targetPos.y-32.83f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==14)
			{
						currentSub=	Instantiate (tableFWh,new Vector3(targetPos.x+37.63f,targetPos.y-32.83f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==15)
			{
						currentSub=	Instantiate (tableMB,new Vector3(targetPos.x+37.63f,targetPos.y-32.83f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
						if(selector==16)
			{
						currentSub=	Instantiate (tableMW,new Vector3(targetPos.x+37.63f,targetPos.y-32.83f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
						}if(selector==17)
			{
						currentSub=	Instantiate (tableMWh,new Vector3(targetPos.x+37.63f,targetPos.y-32.83f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
						}if(selector==18)
			{
						currentSub=	Instantiate (directionSign,new Vector3(targetPos.x+37.63f,targetPos.y-33.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				if(selector==19)
			{
						currentSub=	Instantiate (chairs,new Vector3(targetPos.x+37.63f,targetPos.y-33.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
			
						if(selector==20)
			{
						currentSub=	Instantiate (debris,new Vector3(targetPos.x+37.63f,targetPos.y-33.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
					currentSub.transform.parent=currentMain.transform;	
			}
				
						counter=0;
						
			}
					else
					{
					smallRand=Random.Range (0,8);
					if(smallRand==1)
					{
					currentSub=	Instantiate (bill,new Vector3(targetPos.x+37.63f,targetPos.y-33.33f,targetPos.z+28f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==3)
					{
					currentSub=	Instantiate (stand,new Vector3(targetPos.x+20.72f,targetPos.y-32.36f,targetPos.z+34.35f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==4)
					{
					currentSub=	Instantiate (talk3,new Vector3(targetPos.x+20.72f,targetPos.y-32.36f,targetPos.z+34.35f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==5)
					{
					currentSub=	Instantiate (talk1,new Vector3(targetPos.x+20.72f,targetPos.y-32.36f,targetPos.z+34.35f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==6)
					{
					currentSub=	Instantiate (talk2,new Vector3(targetPos.x+20.72f,targetPos.y-32.36f,targetPos.z+34.35f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
					if(smallRand==7)
					{
					currentSub=	Instantiate (stereotype,new Vector3(targetPos.x+20.72f,targetPos.y-32.36f,targetPos.z+34.35f),Quaternion.identity)as GameObject;
						currentSub.transform.parent=currentMain.transform;
					}
				}
					
				}*/
				multFactor+=1;
			
		}
		//buildings=Instantiate(obstacle,new Vector3(Random.Range (10f,20f+(50*multFactor)),30f,Random.Range(10f,20f+(30*multFactor))),Quaternion.identity) as GameObject;
		
			//Debug.Log ("Z:"+multZ+" : "+multFactor);
	/*	if(multFactor<70)
		Procedural ();*/
		if(zFact<10)
		{
			zFact++;
			multZ=zFact;
			multFactor=1;
			Procedural();
		}
		}
		else
		{
		if(once)
		{
		ast.Scan();
		once=false;
				
		}
		}
		return null;
	}
	
	
}
