using UnityEngine;
using System.Collections;

public class SplashScene : MonoBehaviour {

	public int delay = 1500;
	private bool fin = false;
	// Use this for initialization
	void Start ()
	{
		SplashImage.init();
		edit();
		if(!Global.VISIBLE_SCORE)
		{
			GameObject.Find("ScoreText").SetActive(false);
			GameObject.Find("ScoreNumber").SetActive(false);
		}
		if(!Global.VISIBLE_TIME)
		{
			GameObject.Find("TimeText").SetActive(false);
			GameObject.Find("TimeNumber").SetActive(false);
		}
		new System.Threading.Thread(del).Start();
	}
	
	// Update is called once per frame
	void Update () {
		if(fin)
		{
			(GameObject.FindWithTag("Achive").GetComponent("SpriteRenderer") as SpriteRenderer).sprite = null;
			SplashImage.Drop();
			Global.LoadLvl(SplashImage.LoadingLvl);
		}
		Escape();
	}

	public void edit()
	{

		GUIText text = (GameObject.Find("Text").GetComponent("GUIText") as GUIText);
		text.text = SplashImage.text;
		text.fontSize += text.fontSize * (int)Device.MultiX;
		GUIText scoreNumber = (GameObject.Find("ScoreNumber").GetComponent("GUIText") as GUIText);
		scoreNumber.text = SplashImage.score;
		scoreNumber.fontSize += scoreNumber.fontSize * (int)Device.MultiX;
		GUIText timeNumber = (GameObject.Find("TimeNumber").GetComponent("GUIText") as GUIText);
		timeNumber.text = SplashImage.time;
		timeNumber.fontSize += timeNumber.fontSize * (int)Device.MultiX;
		try
		{
			if(SplashImage.sprite != null)
				(GameObject.FindWithTag("Achive").GetComponent("SpriteRenderer") as SpriteRenderer).sprite 
					= (SplashImage.sprite.GetComponent("SpriteRenderer") as SpriteRenderer).sprite;
		}
		catch(UnityException)
		{
		}
	}
	public void del()
	{
		while(true)
		{
			System.Threading.Thread.Sleep(delay);
			fin = true;
		}
	}
	private	void Escape()
		{
			if (Input.touchCount > 0 && 
			    Input.GetTouch(0).phase == TouchPhase.Began
			    || 
			    Input.GetKeyUp(KeyCode.W)
		    	&&
		    	SplashImage.LoadingLvl != 0) 
			{
				SplashImage.Drop();
				Global.LoadLvl(SplashImage.LoadingLvl);
			}
		}
}
