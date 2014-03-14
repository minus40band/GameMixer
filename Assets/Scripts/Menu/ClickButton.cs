using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
public class ClickButton : MonoBehaviour {

	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseDown()
	{
		Global.StartGame();
	}
}
