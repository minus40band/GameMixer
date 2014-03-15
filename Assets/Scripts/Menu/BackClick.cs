using UnityEngine;
using System.Collections;

public class BackClick : MonoBehaviour {

	public Texture2D soundOnTexture;
	public Texture2D soundOffTexture;
	// Use this for initialization
	void Start () 
	{
		soundOnTexture.width = 100;
		soundOnTexture.height = 100;
		soundOffTexture.width = 100;
		soundOffTexture.height = 100;
	}
	
	// Update is called once per frame
	void Update () 
	{
		(this.GetComponent("AudioSource") as AudioSource).volume = Global.SOUND_VOICE;
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	void OnGUI()
	{
		Rect r = new Rect(Device.Width-Device.Width/4,0,Device.Width/4,Device.Width/4);
		if(Global.SOUND_VOICE == 0)
		{
			GUI.DrawTexture(r, soundOnTexture);
			if (GUI.Button(r,""))
			{
				Global.SOUND_VOICE = 100;
			}
		}
		else
		{
			GUI.DrawTexture(r, soundOffTexture);
			if (GUI.Button(r,""))
			{
				Global.SOUND_VOICE = 0;
			}
		}
	}
}
