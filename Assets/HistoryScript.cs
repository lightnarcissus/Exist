using UnityEngine;
using System.Collections;

public class HistoryScript : MonoBehaviour {
	
	private bool once=true;
	public static int randHistory=0;
	
	
	//gender/race attributes
	public static bool rich=false;
	private float richFactor=0f;
	
	public static int gender=0;
	public static int race=2;
	
	
	public GameObject whiteGroup;
	public GameObject wavyGroup;
	public GameObject blackGroup;
	
	public GameObject femaleGroup;
	public GameObject maleGroup;
	public GameObject queerGroup;
	
	
	//personality attributes
	
	public static int personality=0;
	
	public GameObject racistGroup;
	public GameObject depressedGroup;			//not using them
	
	
	//fear attributes
	
	public static int fear=0;
	
	public GameObject riskGroup;			//not using them
	public GameObject beautyGroup;
	public GameObject anxietyGroup;
	
	public static int preset=0;
	//history attributes
	
	public static int history=0;
	
	public GameObject harassedGroup;
	public GameObject warGroup;
	public GameObject peerGroup;			//not using them

	
	// Use this for initialization
	void Start () {
	/*	whiteGroup.SetActive (false);
		wavyGroup.SetActive (false);
		blackGroup.SetActive (false);
		femaleGroup.SetActive (false);
		maleGroup.SetActive (false);
		queerGroup.SetActive (false);
		
		racistGroup.SetActive (false);
		depressedGroup.SetActive (false);
		
		riskGroup.SetActive (false);
		beautyGroup.SetActive (false);
		anxietyGroup.SetActive (false);
		
		harassedGroup.SetActive (false);
		warGroup.SetActive (false);
		peerGroup.SetActive (false);
	
	*/
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(once)
		{
			randHistory=0;
			if(randHistory==0)
			{
				gender=1;
				race=2;
				history=1;
				preset=0;
				once=false;
			}
			if(randHistory==1)
			{
				gender=0;
				race=1;
				history=0;
				preset=1;
				once=false;
			}
		}
		
	/*	if(once)
		{
			//gender=Random.Range (0,3);
			gender=Random.Range(0,2);
			race=Random.Range (0,3);
			
			personality=1; 					//CHANGE THIS
			
			fear=Random.Range(1,3);		//CHANGE THIS
			
			history=Random.Range (0,2);			//CHANGE THIS
			
			
			if(race==0)
			{
				blackGroup.SetActive (true);
				richFactor-=0.5f;
			}
			if(race==1)
			{
				wavyGroup.SetActive (true);
				richFactor+=0.5f;
			}
			if(race==2)
			{
				whiteGroup.SetActive (true);
				richFactor++;
			}
			
			if(gender==0)
			{
				femaleGroup.SetActive (true);
			}
			if(gender==1)
			{
				maleGroup.SetActive (true);
			}
			if(gender==2)
			{
				queerGroup.SetActive (true);
				richFactor-=0.5f;
			}
			
			
			if(personality==0)
			{
				racistGroup.SetActive (true);
			}
			if(personality==1)
			{
				depressedGroup.SetActive (true);
			}
			
			
			if(fear==0)
			{
				riskGroup.SetActive (true);
				richFactor-=0.5f;
			}
			if(fear==1)
			{
				beautyGroup.SetActive (true);
				richFactor+=0.5f;
			}
			
			
			if(history==0)
			{
				harassedGroup.SetActive (true);
			}
			if(history==1)
			{
				warGroup.SetActive (true);
			}
			if(history==2)
			{
				peerGroup.SetActive (true);
			}
	
		}
		
	
		*/
	}
}
