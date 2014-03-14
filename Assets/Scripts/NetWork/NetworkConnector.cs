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
using UnityEngine;
public static class NetworkConnector
{
	public static string connectionIP = "192.168.1.109";
	public static int connectionPort = 2500;
	public static string connectronDns = "gamemixer.cloudapp.net";

	public static void init()
	{
		IPHostEntry ipHostInfo = Dns.GetHostEntry(connectronDns);
		connectionIP = ipHostInfo.AddressList[0].ToString();
		Debug.Log ("connectionIP: " + connectionIP);
	}

	public static void Connect()
	{

	}

	public static void Registration(string name)
	{
		SendAndRecive(GetCommand("0x01",name,0));
	}

	public static int GetScore(int id)
	{
		SendAndRecive(GetCommand("0x02",id));
		return -1;
	}

	public static void SetScore(int id,int score)
	{
		SendAndRecive(GetCommand("0x03",id,score));
	}

	public static int GetPosition(int id)
	{
		SendAndRecive(GetCommand("0x04",id));
		return -1;
	}

	private static void SendAndRecive(String text)
	{
		new Thread(new ParameterizedThreadStart(SendRecive)).Start(text);
	}
	private static void Send(String text)
	{
		new Thread(new ParameterizedThreadStart(ThreadSend)).Start(text);
	}

	private static void StartRecive()
	{
		new Thread(new ThreadStart(Receiver)).Start();
	}

	private static void SendRecive(System.Object Message)
	{
		String reciveMessage = "";
		Debug.Log("Start Send and Recive");
		IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(connectionIP),connectionPort);
		Socket Connector = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
		Connector.Connect(EndPoint);
		Byte[] sendbytes = Encoding.Default.GetBytes(Message as String);
		Debug.Log ("Sending");
		Connector.Send(sendbytes);
		while (true)
		{
			Byte[] Recive = new Byte[256];
			MemoryStream MessageR = new MemoryStream();
			Int32 RecivedBytes;
			do 
			{
				RecivedBytes = Connector.Receive(Recive, Recive.Length, 0);
				MessageR.Write(Recive, 0, RecivedBytes);
			} while (Connector.Available > 0);
			reciveMessage = Encoding.Default.GetString(MessageR.ToArray());
			if(!String.IsNullOrEmpty(reciveMessage))break;
		}
		ParseRecive(reciveMessage);
		Debug.Log(reciveMessage);
		Connector.Close();
	}

	public static void ParseRecive(string text)
	{
		string[] s = text.Split('|');
		if(s[0].Equals("0x01"))
		{
			if(s[1].Equals("false"))
			{
				UserParametrs.UserName = "";
			}
		}
		if(s[0].Equals("0x02"))
		{
			if(s[1].Equals("false"))
			{
			//	UserParametrs = "";
			}
		}
		if(s[0].Equals("0x03"))
		{
			if(s[1].Equals("false"))
			{
				UserParametrs.UserName = "";
			}
		}
		if(s[0].Equals("0x04"))
		{
			if(s[1].Equals("false"))
			{
				UserParametrs.UserName = "";
			}
		}
	}

	//Поток отправления сообщения Message
	private static void ThreadSend(System.Object Message)
	{
		Debug.Log("Start Thread Send");
		try
		{
			String MessageText = " ";
			if (Message is String)
			{
				MessageText = Message as String;
			}
			else
			{
				throw new Exception("На вход ожидалась строка");
			}
			IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(connectionIP),connectionPort);
			Socket Connector = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			Connector.Connect(EndPoint);
			Byte[] sendbytes = Encoding.Default.GetBytes(Message as String);
			Debug.Log ("Sending");
			Connector.Send(sendbytes);
			Debug.Log ("Close connection");
			Connector.Close();
		}
		catch (System.Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}
	//Поток отправления сообщения Message но вместе с IP
	private static void ThreadSend_IP(System.Object MessageAndIP)
	{
		Debug.Log("Start Thread Send IP");
		try
		{
			String MessageText = " ";
			if (MessageAndIP is MessageTextAndIP)
			{
				MessageTextAndIP m = MessageAndIP as MessageTextAndIP;
				MessageText = m.message;
			}
			else
			{
				throw new Exception("На вход ожидалась строка");
			}
			IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(connectionIP), connectionPort);
			Socket Connector = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			Connector.Connect(EndPoint);
			Byte[] sendbytes = Encoding.Default.GetBytes(Environment.UserName + ": " + MessageText);
			Connector.Send(sendbytes);
			Connector.Close();
		}
		catch (System.Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}
	//Прослушиваем не пршило ли сообщения по while(true)
	private static void Receiver()
	{
		try
		{
			TcpListener Listener = new TcpListener(IPAddress.Parse(connectionIP),connectionPort);
			Listener.Start();
			Socket ReciverSocket;
			while (true)
			{
				ReciverSocket = Listener.AcceptSocket();
				Byte[] Recive = new Byte[256];
				MemoryStream MessageR = new MemoryStream();
				Int32 RecivedBytes;
				do 
				{
					RecivedBytes = ReciverSocket.Receive(Recive, Recive.Length, 0);
					MessageR.Write(Recive, 0, RecivedBytes);
				} while (ReciverSocket.Available > 0);
				Debug.Log(Encoding.Default.GetString(MessageR.ToArray()));
			}
		}
		catch (System.Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}
	private static string GetCommand(string command,string s1,string s2)
	{
		return command + "|" + s1 + "|" + s2;
	}
	private static string GetCommand(string command,string s1,int s2)
	{
		return command + "|" + s1 + "|" + s2;
	}
	private static string GetCommand(string command,int s1,int s2)
	{
		return command + "|" + s1 + "|" + s2;
	}
	private static string GetCommand(string command,int s1,string s2)
	{
		return command + "|" + s1 + "|" + s2;
	}
	private static string GetCommand(string command,int s1)
	{
		return command + "|" + s1;
	}
}	
class MessageTextAndIP
{
	public MessageTextAndIP(String _message, IPAddress _ip)
	{
		ip = _ip;
		message = _message;
	}
	public IPAddress ip;
	public String message = "";
}
