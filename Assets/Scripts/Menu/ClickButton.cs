using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
public class ClickButton : MonoBehaviour {

	void Start () 
	{
		NetworkConnector.Connect();
		NetworkConnector.Send("0x01|DDDD|122");
		NetworkConnector.StartRecive();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown()
	{
		Global.LoadLvlComplite();
	}
}
