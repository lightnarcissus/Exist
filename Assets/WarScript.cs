using UnityEngine;
using System.Collections;

public class WarScript : MonoBehaviour {
	
	public static bool putMoney=false;
	public static int favour=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(putMoney)
		{
			
			if(favour==1)
			{
				transform.FindChild ("scale").eulerAngles=new Vector3(0f,0f,200.38f);
			transform.FindChild ("scale").FindChild ("BalanceWhite").gameObject.animation.Play("JustKneelSob");
			}
			
			if(favour==2)
			{
			transform.FindChild ("scale").eulerAngles=new Vector3(0f,0f,154.4f);
			transform.FindChild ("scale").FindChild ("BalanceBlack").gameObject.animation.Play("JustKneelSob");
			}
		}
	
	}
}
