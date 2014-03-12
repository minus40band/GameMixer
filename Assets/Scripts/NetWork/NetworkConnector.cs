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
	public static String connectionIP = "127.0.0.1";
	public static int connectionPort = 2500;

	public static void Connect()
	{
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
			Byte[] sendbytes = Encoding.Default.GetBytes(Environment.UserName + ": " + MessageText);
			Connector.Send(sendbytes);
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
			IPAddress ip;
			String MessageText = " ";
			if (MessageAndIP is MessageTextAndIP)
			{
				MessageTextAndIP m = MessageAndIP as MessageTextAndIP;
				MessageText = m.message;
				ip = m.ip;
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
			TcpListener Listener = new TcpListener(new IPEndPoint(IPAddress.Parse(connectionIP),connectionPort));;
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

