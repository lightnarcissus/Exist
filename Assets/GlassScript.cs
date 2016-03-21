using UnityEngine;
using System.Collections;

public class GlassScript : MonoBehaviour {

	
	private bool once=true;
	public TextMesh dialogue;
	private float dialogueTimer=0f;
	public static bool release=false;
	private bool releaseOnce=true;
	public GameObject queer;
	public GameObject letter;
	public GameObject closet;
	private GameObject current;
	private float releaseTimer=0f;
	private bool destroy=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(once)
		{
			letter.SetActive (false);
			once=false;
		}
		
		if(release)
		{
			if(releaseOnce)
			{
		
			letter.SetActive (true);
			closet.SetActive (false);
			queer.SetActive(true);
			queer.gameObject.animation.Play ("Walk");
				releaseOnce=false;
			}
			if(destroy)
			{
			releaseTimer+=Time.deltaTime;
			if(releaseTimer>15f)
			{
				Destroy(transform.parent.FindChild ("QueerBL").gameObject);
					destroy=false;
			}
			}
			dialogue.text="You have doomed our society";
		}
		
		
		
		if(WheelScript.peopleChoice!=5 && !release)
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer<10f)
			{
				dialogue.text="The air we share must be kept pure";
			}
			if(dialogueTimer>10f && dialogueTimer<20f)
			{
				dialogue.text="It cannot be corrupted by weak individuals";
			}
			if(dialogueTimer>20f && dialogueTimer<30f)
			{
				dialogue.text="Our body in its natural form is a blessing"; //new dialogue here
			}
			if(dialogueTimer>30f && dialogueTimer<40f)
			{
				dialogue.text="The tainted shall doom our future generations";
			}
			if(dialogueTimer>40f && dialogueTimer<50f)
			{
				dialogue.text="Let them remain in their closets"; //new dialogue here
			}
			
			if(dialogueTimer>50f)
				dialogue.text="";
			if(dialogueTimer>60f)
				dialogueTimer=0f;
		}
		
		else
		{
			dialogueTimer+=Time.deltaTime;
			if(dialogueTimer>25f)
			{
				dialogueTimer=0f;
				WheelScript.peopleChoice=0;
			}
		}

	}
}