using UnityEngine;
using System.Collections;

public class BirthCollision : MonoBehaviour {
	
	public float destroyTimer=0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	destroyTimer+=Time.deltaTime;
		if(destroyTimer>5f)
		{
			Destroy(this);
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag=="Important")
		{
			Destroy (gameObject);
		}
	}
}
