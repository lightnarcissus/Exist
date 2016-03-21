using UnityEngine;
using System.Collections;

public class SettingsLog : MonoBehaviour {
	
	

	// Use this for initialization
	void Start () {
		
		QualitySettings.SetQualityLevel (3);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnSliderChange()
	{
		AudioListener.volume=UISlider.current.sliderValue;
	}
	
	void OnSelectionChange()
	{
		Debug.Log ("INSIDE");
		
		if(UIPopupList.current.selection=="[99FF66]Very Low")
		{
			QualitySettings.SetQualityLevel (2,true);
			Debug.Log ("Low");
		}
		if(UIPopupList.current.selection=="[FF6633]Medium")
		{
			QualitySettings.SetQualityLevel (3,true);
			Debug.Log ("Medium");
		}
		if(UIPopupList.current.selection=="[FF0066]High")
		{
			QualitySettings.SetQualityLevel (4,true);
			Debug.Log ("High");
		}
	}
	
	void OnButtonPressed()
	{
		ExistStart.settingsActive=false;
		
	}
}
