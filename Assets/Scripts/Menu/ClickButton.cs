using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
using GameMixerAPI;
public class ClickButton : MonoBehaviour {

	public int mode = 0;

	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseDown()
	{
		Global.MODE = mode;
		Global.StartGame();
	}
}
