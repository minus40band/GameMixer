using UnityEngine;
using System.Collections;

public class StartNetworkScript : MonoBehaviour {

	public GUIStyle StyleName;
	public GUISkin SkinName;
	private string TextBoxName = "";
	private int width = 240;
	private int heigth = 40;
	private Rect element1;
	private Rect element2;
	private Rect element3;
	// Use this for initialization
	void Start () 
	{
		element1 = new Rect(GUIParam.ScoreLabel.x,GUIParam.ScoreLabel.y,width,heigth);
		element2 = new Rect(GUIParam.ScoreLabel.x,heigth + GUIParam.ScoreLabel.y,width,heigth);
		element3 = new Rect(GUIParam.ScoreLabel.x,heigth * 2 + GUIParam.ScoreLabel.y,width,heigth);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI ()
	{
		GUIElement();
	}

	public void GUIElement()
	{
		GUI.skin = SkinName;
		if(System.String.IsNullOrEmpty(UserParametrs.UserName))
		{
			if (GUI.Button (element2, "Registration"))
			{
				UserParametrs.UserName = TextBoxName;
				Debug.Log(GameMixerAPI.Methods.Registration(UserParametrs.UserName,"0"));
				UserParametrs.UserID = System.Int32.Parse(GameMixerAPI.Methods.GetIDByName("DizzyStyle"));
				Debug.Log(GameMixerAPI.Methods.SetScore(UserParametrs.UserID.ToString(),"3"));
				UserParametrs.UserPosition = System.Int32.Parse(GameMixerAPI.Methods.GetPosition(UserParametrs.UserID.ToString()));
				Debug.Log(UserParametrs.UserPosition);
			}
			TextBoxName = GUI.TextField(element1,TextBoxName,10);
		}
		else
		{
			GUI.Label(element1,"Name: " + UserParametrs.UserName,StyleName);
			GUI.Label(element2,"Score: " + UserParametrs.UserScore.ToString(),StyleName);
			GUI.Label(element3,"Rating: " + UserParametrs.UserPosition.ToString(),StyleName);
		}
	}
}
