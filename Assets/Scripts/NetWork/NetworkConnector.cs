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
	public static string connectionIP = "168.61.88.210";
	public static int connectionPort = 2500;
	public static string connectronDns = "gamemixer.cloudapp.net";

	public static void Connect()
	{
		IPHostEntry ipHostInfo = Dns.Resolve(connectronDns);
		connectionIP = ipHostInfo.AddressList[0].ToString();
		Debug.Log ("connectionIP: " + connectionIP);
	}
	public static void Send(String text)
	{
		new Thread(new ParameterizedThreadStart(ThreadSend)).Start(text);
	}

	public static void StartRecive()
	{
		new Thread(new ThreadStart(Receiver)).Start();
	}
	
	//Поток отправления сообщения Message
	private static void ThreadSend(System.Object Message)
	{
		Debug.Log ("Start Send");
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
			Connector.Send(sendbytes);
			Debug.Log ("Send complite");
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
			IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(connectionIP),connectionPort);
			Socket Connector = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			Connector.Connect(EndPoint);
			while (true)
			{
				Byte[] Recive = new Byte[1024];
				MemoryStream MessageR = new MemoryStream();
				Int32 RecivedBytes = 0;
				Debug.Log ("Try connect for receive");
				RecivedBytes = Connector.Receive(Recive);
				Debug.Log ("Connect sucsesful");
				if(RecivedBytes>0)
				{
					MessageR.Write(Recive, 0, RecivedBytes);
					Debug.Log (Encoding.Default.GetString(MessageR.ToArray()));
				}
			}
		}
		catch (System.Exception ex)
		{
			Debug.Log(ex.Message);	
		}
		Debug.Log ("1zzcx0");
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

