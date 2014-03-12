using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
public class ClickButton : MonoBehaviour {
	IAchievement achievement;
	// Use this for initialization
	void Start () 
	{
		/*achievement = Social.CreateAchievement();
		achievement.id = "Achievement01";
		achievement.percentCompleted = 0.0;
		achievement.ReportProgress( result => {
			if (result)
				Debug.Log ("Successfully reported progress");
			else
				Debug.Log ("Failed to report progress");
		});
		Global.SummaryTime = 0;
		Global.Points = -1;*/
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKey(KeyCode.W))
		{

		}
		if(Input.GetKey(KeyCode.S))
		{
			achievement.percentCompleted = 100.0;
		}*/
	}

	void OnMouseDown()
	{
		Global.LoadLvlComplite();
	}
}
