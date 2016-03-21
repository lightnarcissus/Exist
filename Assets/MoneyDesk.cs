using UnityEngine;
using System.Collections;

public class MoneyDesk : MonoBehaviour {
	
	public bool tookMoney=false;
	public TextMesh dialogue;
	private float dialogueTimer=0f;
	public GameObject money;
	private float respawnTimer=0f;
	private int randDialogue=0;
	private bool randOnce=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(tookMoney)
		{
			respawnTimer+=Time.deltaTime;
			if(respawnTimer>30f)
			{
				Instantiate (money,new Vector3(transform.position.x+0.0885f,transform.position.y+0.533f,transform.position.z-0.5618f),Quaternion.identity);
				respawnTimer=0f;
			}
			tookMoney=false;
		}
		
		dialogueTimer+=Time.deltaTime;

		
		if(dialogueTimer<5f)
		{	
				dialogue.text="Money with no strings attached";
		}	
		if(dialogueTimer>5f && dialogueTimer<10f)
		{
				dialogue.text="You just need to sign on this little contract";
		}
			
		if(dialogueTimer>10f && dialogueTimer<15f)
		{
				dialogue.text="To buy anything your heart desires";
		}
		
		if(dialogueTimer>15f)
		{
			dialogueTimer=0f;
			randOnce=true;
		}
	}
}
