using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
public class ClickButton : MonoBehaviour {
	void Start () 
	{
		NetworkConnector.Send("0x01|DDD|1");
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
