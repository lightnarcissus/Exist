using UnityEngine;
using System.Collections;

public class ActivateSlowly : MonoBehaviour {
	
	public GameObject buildings;
	public GameObject poorCity;
	public GameObject peopleGroups;
	public GameObject cloud;
	public GameObject stream;
	public GameObject miscGroup;
	public GameObject player;
	public GameObject war;
	
	private float timer=0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		StartCoroutine ("Activate");
	}

	IEnumerator Activate()
	{

			buildings.SetActive (true);
			stream.SetActive (true);
		yield return new WaitForSeconds(2f);
			poorCity.SetActive (true);
		yield return new WaitForSeconds(2f);
			peopleGroups.SetActive (true);
			cloud.SetActive(true);
		yield return new WaitForSeconds(2f);
			miscGroup.SetActive (true);
			war.SetActive (true);
		yield return new WaitForSeconds(2f);
			player.SetActive (true);
		this.enabled = false;
		

	}
}
