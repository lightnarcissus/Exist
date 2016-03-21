using UnityEngine;
using System.Collections;

public class WheelBar : MonoBehaviour {
	private Quaternion min=Quaternion.identity;
	private Quaternion max=Quaternion.AngleAxis (360f,Vector3.up);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(gameObject.name=="GoldBar")
		{
		renderer.material.SetFloat("_Cutoff", Mathf.Lerp(1f,0f, yo.goldActive/10f));
			transform.position=new Vector3(transform.position.x,transform.position.y,Mathf.Lerp (0f,-0.1f,yo.goldActive/10f));
			//Debug.Log ("Gold"+yo.goldActive/10f);
		}
		
		if(gameObject.name=="RedBar")
		{
		renderer.material.SetFloat("_Cutoff", Mathf.InverseLerp(1f,0f, yo.redActive/10f)); 
			transform.position=new Vector3(transform.position.x,transform.position.y,Mathf.Lerp (0f,-0.1f,yo.redActive/10f));
				//Debug.Log ("Red"+yo.redActive/10f);
		}
		
		if(gameObject.name=="BlueBar")
		{
		renderer.material.SetFloat("_Cutoff", Mathf.InverseLerp(1f,0f, yo.blueActive/10f)); 
			transform.position=new Vector3(transform.position.x,transform.position.y,Mathf.Lerp (0f,-0.1f,yo.blueActive/10f));
				//Debug.Log ("Blue"+yo.blueActive);
		}
		
		if(gameObject.name=="GreenBar")
		{
		renderer.material.SetFloat("_Cutoff", Mathf.InverseLerp(1f,0f, yo.greenActive/10f));
			transform.position=new Vector3(transform.position.x,transform.position.y,Mathf.Lerp (0f,-0.1f,yo.greenActive/10f));
			//	Debug.Log ("Green"+yo.greenActive/10f);
		}
		
		if(gameObject.name=="GreyBar")
		{
		renderer.material.SetFloat("_Cutoff", Mathf.InverseLerp(1f,0f, yo.greyActive/10f)); 
			transform.position=new Vector3(transform.position.x,transform.position.y,Mathf.Lerp (0f,-0.1f,yo.greyActive/10f));
				//Debug.Log ("Grey"+yo.greyActive);
		}
	
	}
	
}
