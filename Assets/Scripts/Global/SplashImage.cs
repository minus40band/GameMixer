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
public static class SplashImage
{
	public static String text = "";
	public static String score = "0";
	public static String time = "0";
	public static int LoadingLvl = 0;
	public static GameObject sprite;
	private static void SetTextForLvl()
	{
		if(!String.IsNullOrEmpty(text))
		{
			return;
		}
		switch(LoadingLvl)
		{
		case (int)Global.Levels.Levels_Menu:
			//text = "LOSE";
			SetSprite("Splash/lose");
			break;
		case (int)Global.Levels.Levels_Labirint:
			SetSprite("Splash/control");
			//text = "EXIT";
			break;
		case (int)Global.Levels.Levels_Bread:
			SetSprite("Splash/touch");
			//text = "DRAG";
			break;
		case (int)Global.Levels.Levels_Dead:
			SetSprite("Splash/run");
			//text = "RUN";
			break;
		case (int)Global.Levels.Levels_Puke:
			SetSprite("Splash/shake");
			//text = "SHAKE";
			break;
		case (int)Global.Levels.Levels_Balance:
			SetSprite("Splash/balance");
			//text = "SHAKE";
			break;
		case (int)Global.Levels.Levels_Cube:
			SetSprite("Splash/pick");
			//text = "SHAKE";
			break;
		case (int)Global.Levels.Levels_DedRally:
			SetSprite("Splash/jump");
			//text = "SHAKE";
			break;
		default:
			text = "SomeLvl";
			break;

		}
	}
	public static void SetText(String _text)
	{
		if(String.IsNullOrEmpty(_text))
		{
			text = "";
			return;
		}
		else
		{
			text = _text;
		}
	}
	public static void init()
	{
		LoadingLvl = Global.CurrentLvl;
		score = Global.Points.ToString();
		time = ((int)Global.LimitTime - (int)Global.SummaryTime).ToString() + "s";
		SetTextForLvl();
	}
	public static void init(String _text,String _score,String _time)
	{
		text = _text;
		score = _score;
		time = _time;
	}
	public static bool SetSprite(String _path)
	{
		try
		{
			sprite = (Resources.Load(_path)as GameObject);
			return true;
		}
		catch(Exception ex)
		{
			Debug.Log(ex.Message);
			return false;
		}
	}
	public static void Drop()
	{
		text = null;
		score = null;
		time = null;
	}

}
