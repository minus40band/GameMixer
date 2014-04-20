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
	private Rect element4;
	private Rect element5;
	public bool VisibleNetworkSettings = false;
	// Use this for initialization
	void Start () 
	{
		//Debug.Log ("Start Log. User ID: " + UserParametrs.UserID);
		//Debug.Log (UserParametrs.UserName);
		//Debug.Log (UserParametrs.UserPosition);
		//Debug.Log (UserParametrs.UserScore);
		try
		{
			UserParametrs.UserScore = PlayerPrefs.GetInt("Score");
			UserParametrs.UserID = PlayerPrefs.GetInt("ID");
			UserParametrs.UserName = PlayerPrefs.GetString("Name");
			UserParametrs.UserPosition = PlayerPrefs.GetInt("Position");
		}
		catch(UnityException ex)
		{
			Debug.Log(ex.Message);
		}
		//Debug.Log (GameMixerAPI.Methods.GetIDByName(UserParametrs.UserName));
		if(GameMixerAPI.Methods.GetIDByName(UserParametrs.UserName)<=0)
		{
			Debug.Log (GameMixerAPI.Methods.Registration(UserParametrs.UserName,UserParametrs.UserScore));
		}
		element1 = new Rect(GUIParam.ScoreLabel.x,GUIParam.ScoreLabel.y,width,heigth);
		element2 = new Rect(GUIParam.ScoreLabel.x,heigth + GUIParam.ScoreLabel.y,width,heigth);
		element3 = new Rect(GUIParam.ScoreLabel.x,heigth * 2 + GUIParam.ScoreLabel.y,width,heigth);
		element4 = new Rect(GUIParam.ScoreLabel.x,heigth + GUIParam.ScoreLabel.y,width/2,heigth);
		element5 = new Rect((width/2) + GUIParam.ScoreLabel.x,heigth + GUIParam.ScoreLabel.y,width/2,heigth);
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

		if(VisibleNetworkSettings)
		{
			NetworkElements();
		}

	}
	private void NetworkElements()
	{
		if(System.String.IsNullOrEmpty(UserParametrs.UserName) || UserParametrs.UserID<=0)
		{
			if (GUI.Button (element4, "SignUp"))
			{
				UserParametrs.UserName = TextBoxName;
				UserParametrs.UserID = GameMixerAPI.Methods.Registration(UserParametrs.UserName,UserParametrs.UserScore);
				NetworkConnector.UpdateData();
				
			}
			if (GUI.Button (element5, "SignIn"))
			{
				UserParametrs.UserName = TextBoxName;
				UserParametrs.UserID = GameMixerAPI.Methods.GetIDByName(UserParametrs.UserName);
				NetworkConnector.UpdateData();
			}
			TextBoxName = GUI.TextField(element1,TextBoxName,10);
		}
		else
		{
			element1 = new Rect(GUIParam.ScoreLabel.x,GUIParam.ScoreLabel.y,width,heigth);
			element2 = new Rect(GUIParam.ScoreLabel.x,heigth + GUIParam.ScoreLabel.y,width,heigth);
			element3 = new Rect(GUIParam.ScoreLabel.x,heigth * 2 + GUIParam.ScoreLabel.y,width,heigth);
			element4 = new Rect(GUIParam.ScoreLabel.x,heigth + GUIParam.ScoreLabel.y,width/2,heigth);
			element5 = new Rect((width/2) + GUIParam.ScoreLabel.x,heigth + GUIParam.ScoreLabel.y,width/2,heigth);
			GUI.Label(element1,"Name: " + UserParametrs.UserName,StyleName);
			GUI.Label(element2,"Score: " + UserParametrs.UserScore.ToString(),StyleName);
			GUI.Label(element3,"Rating: " + UserParametrs.UserPosition.ToString(),StyleName);
		}
	}
}
