using UnityEngine;
using System.Collections;

public class RandomForce : MonoBehaviour {


	public float XForce = 0;
	public float YForce = 0;
	// Use this for initialization
	void Start () {
		switch(Global.GetRandom(0,1))
		{
			case 0:
				this.tag = "Achive";
				break;
			case 1:
				this.tag = "Enemy";
				break;
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
		this.gameObject.SetActive(false);
	}
}
