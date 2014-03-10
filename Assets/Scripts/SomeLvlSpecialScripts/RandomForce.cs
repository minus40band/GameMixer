using UnityEngine;
using System.Collections;

public class RandomForce : MonoBehaviour {


	public float XForce = 0;
	public float YForce = 0;
	// Use this for initialization
	void Start () {
		if((new System.Random()).NextDouble()<0.5)
		{
			this.transform.localScale = this.transform.localScale * 2;
			this.gameObject.tag = "Achive";
		}
		else
		{
			this.gameObject.tag = "Enemy";
		}
		this.rigidbody2D.AddForce(new Vector2(XForce,YForce));
	}
	
	// Update is called once per frame
	void Update () {
		//Time.timeScale = 0.5f;
	}

	void OnMouseDown()
	{
		if(this.tag.Equals("Enemy"))
		{
			Global.LoadLvlLose();
		}
		if(this.tag.Equals("Achive"))
		{
			(GameObject.FindWithTag("MainCamera").GetComponent("TakeAchive") as TakeAchive).AchiveForWin--;
		}
		this.gameObject.SetActive(false);
	}
}
