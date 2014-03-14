﻿using UnityEngine;
using System.Collections;

public static class Global 
{
	public static int LimitTime = 30;
	public static int CurrentLvl = 0;
	public static int Points = 0;
	public static float SummaryTime = 0.0f;
	public enum Levels
	{
		Levels_Menu = 0,
		Levels_Splash = 1,
		Levels_Labirint,
		Levels_Bread,
		Levels_Puke,
		Levels_Dead
	}
	public static void AddTime()
	{
		SummaryTime+= 1.0f * Time.deltaTime;
	}
	public static void LoadLvl(int lvl)
	{
		//Time.timeScale = 1;
		Application.LoadLevel(lvl);
	}
	public static void LoadLvl()
	{
		Application.LoadLevel(GetRandom());
	}
	public static int GetRandom()
	{
		System.Random r = new System.Random();
		return r.Next(2,Application.levelCount);
	}
	public static double GetRandomDouble()
	{
		System.Random r = new System.Random();
		return r.NextDouble();
	}

	public static double GetRandomDouble(double minimum, double maximum)
	{ 
		System.Random random = new System.Random();
		return (random.NextDouble() * (double)System.Math.Abs((float)maximum - (float)minimum)) + minimum;
	}

	public static int GetRandom(int minimum,int maximum)
	{
		System.Random r = new System.Random();
		return r.Next(minimum,maximum);
	}
	public static void LoadLvlComplite()
	{
		Points++;
		CurrentLvl = GetRandom();
		LoadLvl(1);
	}
	public static void LoadLvlComplite(string spritePath)
	{
		Points++;
		SplashImage.SetSprite(spritePath);
		CurrentLvl = GetRandom();
		LoadLvl(1);
	}
	public static void LoadLvlLose(int lvl)
	{
		SplashImage.SetSprite("Splash/lose");
		CurrentLvl = 0;
		LoadLvl(1);
	}
	public static void LoadLvlLose()
	{
		SplashImage.SetSprite("Splash/lose");
		CurrentLvl = 0;
		LoadLvl(1);
	}

	public static void StartGame()
	{
		CurrentLvl = GetRandom();
		LoadLvl(1);
	}
}
