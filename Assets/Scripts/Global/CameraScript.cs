using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	//public AudioClip backgroundmusic;
	// Use this for initialization
	public GUIStyle ScoreStyle;
	public GUIStyle TimerStyle;
	public Texture2D SoundOnTexture;
	public Texture2D SoundOffTexture;
	public GUISkin SkinMenu;

	public int SecondForTick = 5;
	private bool menuActive = false;
	void Start () {
		if(Global.LimitTime - Global.SummaryTime < SecondForTick + Time.deltaTime)
		{
			(this.GetComponent("AudioSource") as AudioSource).Play();
			SecondForTick--;
		}
		GUIParam.Init (ScoreStyle,TimerStyle);
		//audio.PlayOneShot(backgroundmusic);
	}
	
	// Update is called once per frame
	void Update () 
	{
		(this.GetComponent("AudioSource") as AudioSource).volume = Global.SOUND_VOICE;
		Global.AddTime();
		if(Input.GetKey(KeyCode.Escape))
		{
			Time.timeScale = 0;
			menuActive = true;
		}
		if(Global.SummaryTime>Global.LimitTime)
		{
			Global.LoadLvlLose(Application.loadedLevel);
		}
		if(Global.LimitTime - Global.SummaryTime < SecondForTick + Time.deltaTime
		   && Global.LimitTime - Global.SummaryTime > SecondForTick - Time.deltaTime)
		{
			(this.GetComponent("AudioSource") as AudioSource).Play();
			SecondForTick--;
		}
	}

	void OnGUI()
	{
		GUI.skin = SkinMenu;
		GUIParam.CallMenu(ref menuActive,SoundOnTexture,SoundOffTexture);
	}
}
