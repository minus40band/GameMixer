using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
using GameMixerAPI;
public class ClickButton : MonoBehaviour {

	public int mode = 0;
	private Vector3 scale;

	void Start () 
	{
		scale = this.transform.localScale;
		foreach(var but in GameObject.FindGameObjectsWithTag("Button"))
		{
			(but.GetComponent("Animator") as Animator).enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseDown()
	{
		if(mode == -1)
		{
			if(Global.MODE>0)
			Global.StartGame();
		}
		else
		{
			foreach(var but in GameObject.FindGameObjectsWithTag("Button"))
			{
				but.transform.localScale = scale;
				(but.GetComponent("Animator") as Animator).enabled = false;
			}

			(this.GetComponent("Animator") as Animator).enabled = true;
			this.transform.localScale = scale * 2;
			Global.MODE = mode;
		}
	}
}
