using UnityEngine;
using System.Collections;

public class ButtonThought : MonoBehaviour {
	
	public bool active=false;
	
void OnHover(bool isOver)
	{
		if(isOver)
		{
			if(ThoughtManager.thoughtAppear)
			{
				ButtonAppear.active=true;
				ThoughtManager.thoughtActive=true;
			}
			active=true;
			//Debug.Log ("IT WORKS!!");
		}
		else
		{
			active=false;
		}
	}

}