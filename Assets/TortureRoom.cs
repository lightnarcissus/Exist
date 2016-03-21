using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class TortureRoom : MonoBehaviour {
	
	public GameObject interrogatorPlayer;
	public GameObject criminalPlayer;
	public GameObject victim;
	
	private bool swapChair=false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	void OnEnable()
	{
		if(!swapChair)
		{
			interrogatorPlayer.SetActive (true);
			criminalPlayer.SetActive (false);
			victim.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(QuestLog.GetQuestState ("SwapChair")==QuestState.Active)
		{
			swapChair=true;
		}
		
		if(swapChair)
		{
			StartCoroutine ("SwapChair");
		}
		else
		{	
			interrogatorPlayer.SetActive(true);
			criminalPlayer.SetActive (false);
		}
	
	}
	
	IEnumerator SwapChair()
	{
		interrogatorPlayer.GetComponent<PP_LightWave>().enabled=true;
		yield return new WaitForSeconds(1f);
		interrogatorPlayer.GetComponent<PP_LightWave>().enabled=false;
		victim.SetActive (false);
		interrogatorPlayer.SetActive(false);		
		criminalPlayer.SetActive (true);
	}
}
