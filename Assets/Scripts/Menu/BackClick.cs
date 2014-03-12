using UnityEngine;
using System.Collections;

public class BackClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NetworkConnector.StartRecive();
		NetworkConnector.Send("ggg");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
