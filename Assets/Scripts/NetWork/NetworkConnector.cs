using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using GameMixerAPI;
using UnityEngine;
public static class NetworkConnector
{
	public static void UpdateData()
	{
		if(String.IsNullOrEmpty(UserParametrs.UserName) || UserParametrs.UserID <=0)
		{
			return;
		}
		try
		{

			int ServerScore = GameMixerAPI.Methods.GetScore(UserParametrs.UserID);
			if(UserParametrs.UserScore>ServerScore)
			{
				UserParametrs.UserScore = Global.Points;
				GameMixerAPI.Methods.SetScore(UserParametrs.UserID,UserParametrs.UserScore);
			}
			else
			{
				UserParametrs.UserScore = ServerScore;
			}
			UserParametrs.UserPosition = GameMixerAPI.Methods.GetPosition(UserParametrs.UserID);
			PlayerPrefs.SetString("Name",UserParametrs.UserName);
			PlayerPrefs.SetInt("ID",UserParametrs.UserID);
			PlayerPrefs.SetInt("Score",UserParametrs.UserScore);
			PlayerPrefs.SetInt("Position",UserParametrs.UserPosition);
			PlayerPrefs.Save();
		}
		catch(Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}
}
