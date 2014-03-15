//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18408
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
public static class GUIParam
{
	public static float LeftIndent = 10;
	public static float RightIndent = 20; 
	public static Rect MenuLabel1;
	public static Rect MenuButton1;
	public static Rect MenuButton2;
	public static Rect ScoreLabel;
	public static Rect TimeLabel;
	public static GUIStyle ScoreStyle;
	public static GUIStyle TimerStyle;
	public static void Init(GUIStyle scoreStyle,GUIStyle timeStyle)
	{
		ScoreStyle = scoreStyle;
		TimerStyle = timeStyle;
		scoreStyle.fontSize = scoreStyle.fontSize + scoreStyle.fontSize * (int)Device.MultiX;
		timeStyle.fontSize = timeStyle.fontSize + timeStyle.fontSize * (int)Device.MultiX;
		//
		MenuGUIInit();
		StatusGUTInit();
	}
	private static void MenuGUIInit()
	{
		float PosX = Device.Width/2 - Device.Width/5 - LeftIndent;
		float PosY = Device.Height/6;
		float Width = Device.Width/2;
		float Height = Device.Height/10;
		int NumberGUIElement = 1;
		MenuLabel1 = new Rect(PosX,NumberGUIElement * PosY,Width,Height);
		NumberGUIElement++;
		MenuButton1 = new Rect(PosX,NumberGUIElement * PosY,Width,Height);
		NumberGUIElement++;
		MenuButton2 = new Rect(PosX,NumberGUIElement * PosY + RightIndent,Width,Height);
	}
	private static void StatusGUTInit()
	{
		float Width = 0;
		float Height = Device.Height/10;
		float PosX1 = LeftIndent;
		float PosX2 = Device.Width - LeftIndent;// - Width;
		float PosY1 = LeftIndent;
		ScoreLabel = new Rect(PosX1,PosY1,Width,Height);
		TimeLabel = new Rect(PosX2,PosY1,Width,Height);
	}
	public static void CallMenu(ref bool menuActive)
	{
		if(Global.VISIBLE_SCORE)
		GUI.Label(ScoreLabel,"Score:" + Global.Points,ScoreStyle);
		if(Global.VISIBLE_TIME)
		GUI.Label(TimeLabel,"Time:" + (Global.LimitTime-(int)Global.SummaryTime),TimerStyle);
		if(menuActive)
		{
			GUI.Label(MenuLabel1,"Game Paused",ScoreStyle);
			if (GUI.Button(MenuButton1,"Resume"))
			{
				menuActive = false;
				Time.timeScale = 1;
			}
			if (GUI.Button(MenuButton2,"Exit"))
			{
				menuActive = false;
				Time.timeScale = 1;
				Application.LoadLevel(0);
			}
		}
	}
}		
