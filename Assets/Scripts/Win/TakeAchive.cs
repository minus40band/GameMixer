using UnityEngine;
using System.Collections;

public class TakeAchive : MonoBehaviour {

	public int AchiveForWin = 10;
	public int Interval = 1000;
	private int x = 0;
	private int y = 0;
	// Use this for initialization
	void Start () {
		//(new System.Threading.Thread(SleepInterval)).Start();
	}

	void SleepInterval()
	{
		while(true)
		{
			System.Threading.Thread.Sleep(Interval);
			x = Global.GetRandom(-50,50);
			y = Global.GetRandom(-50,50);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if(AchiveForWin<1)
		{
			Global.LoadLvlComplite();
		}
	}

	void OnGUI()
	{
		GUIStyle guis = new GUIStyle();
		guis = (this.GetComponent("CameraScript") as CameraScript).ScoreStyle;
		guis.alignment = TextAnchor.MiddleLeft;
		GUI.Label(new Rect(Device.Width/2 + x,Device.Height/2 + y,100,100),AchiveForWin.ToString(),guis);
	}
}
