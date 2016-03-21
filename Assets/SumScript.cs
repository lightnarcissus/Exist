using UnityEngine;
using System.Collections;

public class SumScript : MonoBehaviour {
	
	public TextMesh sum;
	public static int mood=0;  //1 for sad ; 2 for optimistic ; 3 for scared
	public GameObject happyCam;
	public GameObject sadCam;
	public GameObject tutCam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (mood == 0) {
		
						sum.text = "My mind is a blank slate";
				}

		else if (mood == 1) 
		{
			sum.text = "A poignant memory chains my past";
			StartCoroutine ("Mood",1);
		}
		else if (mood == 2) 
		{
			sum.text = "I smile at memories that light my past";
			StartCoroutine ("Mood",2);
		}

		/*
		if(SkinSelect.skinChoose==2)
		sum.text="R   G    B \n 0   0    0";
		
		if(SkinSelect.skinChoose==1)
		sum.text="Energy surfing without any medium";
		
		if(SkinSelect.skinChoose==0)
		sum.text="R    G     B \n 256   256    256";
      */
	}
	IEnumerator Mood(int mood)
	{
		if (mood == 1) 
		{
			yield return new WaitForSeconds(2f);
			tutCam.SetActive (false);
			sadCam.SetActive (true);
			yield return new WaitForSeconds (2f);
			tutCam.SetActive (true);
			sadCam.SetActive (false);
			yield return null;
				} 
		else if (mood == 2) {

			yield return new WaitForSeconds(2f);
			tutCam.SetActive (false);
			happyCam.SetActive (true);
			yield return new WaitForSeconds (2f);
			tutCam.SetActive (true);
			happyCam.SetActive (false);

			yield return null;

		}
	}

}
