using UnityEngine;
using System.Collections;

public class CivilianGeneration : MonoBehaviour {
	public GameObject maleBlack;
	public GameObject maleWavy;
	public GameObject maleWhite;
	public GameObject femaleBlack;
	public GameObject femaleWavy;
	public GameObject femaleWhite;
	public GameObject maleBlackBL;
	public GameObject maleWavyBL;
	public GameObject maleWhiteBL;
	public GameObject femaleBlackBL;
	public GameObject femaleWavyBL;
	public GameObject femaleWhiteBL;
/*	public GameObject male;
	public GameObject maleBL;
	public GameObject female;
	public GameObject femaleBL;*/
	public GameObject queer;
	public GameObject queerBL;
	public int randSelect;
	private int inter=0;
/*	public GameObject civGroup1;
	public GameObject civGroup2;
	public GameObject civGroup3;
	public GameObject civGroup4;
	public GameObject civGroup5;*/
	public float spawnVarMinX;
	public float spawnVarMaxX;
	public float spawnVarMinZ;
    public float spawnVarMaxZ;
	public static int spawnNumber=0;
	public AstarPath ast;
	private Vector3 spawnVector;
	private bool instantiateOnce=true;
	private Pathfinding.NNInfo yo;
	
	public GameObject killAll;
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		
	if(StarterScript.ready)
		{
		if(spawnNumber<=75)
		{	
			spawnNumber++;
			spawnVarMinX=Random.Range (transform.position.x-200f,transform.position.x-100f);
			spawnVarMaxX=Random.Range (transform.position.x+100f,transform.position.x+200f);
			spawnVarMinZ=Random.Range (transform.position.z-200f,transform.position.z-100f);
			spawnVarMaxZ=Random.Range (transform.position.z+100f,transform.position.z+200f);
			spawnVector=new Vector3(Random.Range(spawnVarMinX,spawnVarMaxX),1f,Random.Range (spawnVarMinZ,spawnVarMaxZ));
			//Debug.Log (spawnVector);
			//yo=ast.GetNearest (spawnVector);
			//spawnVector=yo.clampedPosition;
		/*	if((spawnVarX<spawnMax.x)&&(spawnVarX<spawnMin.x))
			{
				if((spawnVarZ<spawnMax.z)&&(spawnVarZ<spawnMin.z))
				{*/
			if(spawnVector.x>=10f && spawnVector.x<=410f && spawnVector.z>=10f && spawnVector.z<=390f)
			{
			randSelect=Random.Range (0,12);
					

			if(randSelect==0)
			Instantiate (maleBlack,new Vector3(spawnVector.x,0f,spawnVector.z),Quaternion.identity);
				
			if(randSelect==1)
			Instantiate (maleWavy,new Vector3(spawnVector.x,0f,spawnVector.z),Quaternion.identity);
				
			if(randSelect==2)			
			Instantiate (maleWhite,new Vector3(spawnVector.x,0f,spawnVector.z),Quaternion.identity);
				
			if(randSelect==3)
			Instantiate (femaleBlack,new Vector3(spawnVector.x,0f,spawnVector.z),Quaternion.identity);		
				
			if(randSelect==4)
			Instantiate (maleWavy,new Vector3(spawnVector.x,0f,spawnVector.z),Quaternion.identity);

			if(randSelect==5)
			Instantiate (maleWhite,new Vector3(spawnVector.x,0f,spawnVector.z),Quaternion.identity);
				
			if(randSelect==6)
		{
			Instantiate (femaleBlackBL,new Vector3(spawnVector.x,transform.position.y,spawnVector.z),Quaternion.identity);

		}		
			if(randSelect==7)
		{
			Instantiate (maleWhiteBL,new Vector3(spawnVector.x,transform.position.y,spawnVector.z),Quaternion.identity);
		}			
			if(randSelect==8)
		{
			Instantiate (femaleWhiteBL,new Vector3(spawnVector.x,transform.position.y,spawnVector.z),Quaternion.identity);
		}		
				
			if(randSelect==9)
		{
				Instantiate (maleWavyBL,new Vector3(spawnVector.x,transform.position.y,spawnVector.z),Quaternion.identity);
		}		
			if(randSelect==10)
		{
				Instantiate (femaleWavyBL,new Vector3(spawnVector.x,transform.position.y,spawnVector.z),Quaternion.identity);
		}		
				if(randSelect==11)
		{
			Instantiate (maleBlackBL,new Vector3(spawnVector.x,transform.position.y,spawnVector.z),Quaternion.identity);
		}		
				
				
		//		if(randSelect==12)
		//	Instantiate (male,new Vector3(spawnVector.x,0f,spawnVector.z),Quaternion.identity);
				
		//		if(randSelect==13)
		//	Instantiate (maleBL,new Vector3(spawnVector.x,transform.position.y,spawnVector.z),Quaternion.identity);
				
		//		if(randSelect==14)
		//	Instantiate (female,new Vector3(spawnVector.x,0f,spawnVector.z),Quaternion.identity);
				
		//		if(randSelect==15)
		//	Instantiate (femaleBL,new Vector3(spawnVector.x,transform.position.y,spawnVector.z),Quaternion.identity);
				
		//		if(randSelect==16)
		//	Instantiate (queer,new Vector3(spawnVector.x,0f,spawnVector.z),Quaternion.identity);
				
		//		if(randSelect==17)
		//	Instantiate (queerBL,new Vector3(spawnVector.x,transform.position.y,spawnVector.z),Quaternion.identity);

			}
			//	}
		//	}
		}
		
		if(GlassScript.release)
		{
			if(instantiateOnce)
			{
				Debug.Log ("YO QUEER!");
				for(int i=0;i<15;i++)
				{
					spawnVarMinX=Random.Range (transform.position.x-200f,transform.position.x-100f);
			spawnVarMaxX=Random.Range (transform.position.x+100f,transform.position.x+200f);
			spawnVarMinZ=Random.Range (transform.position.z-200f,transform.position.z-100f);
			spawnVarMaxZ=Random.Range (transform.position.z+100f,transform.position.z+200f);
			spawnVector=new Vector3(Random.Range(spawnVarMinX,spawnVarMaxX),1f,Random.Range (spawnVarMinZ,spawnVarMaxZ));
					Instantiate (queerBL,spawnVector,Quaternion.identity);
					
				}
				instantiateOnce=false;
			}
		}
			
		}
	
	}
}
