using UnityEngine;
using System.Collections;

public class RandomForce : MonoBehaviour {


	public float XForce = 0;
	public float YForce = 0;
	public float scale = 1.5f;
	public Sprite spriteAchive;
	public Sprite spriteEnemy;
	// Use this for initialization
	void Start () {
		if((new System.Random()).NextDouble()<0.5)
		{
			this.transform.localScale = this.transform.localScale * scale;
			(this.GetComponent("SpriteRenderer") as SpriteRenderer).sprite = spriteAchive;
			this.gameObject.tag = "Achive";
		}
		else
		{
			this.transform.localScale = this.transform.localScale * scale;
			(this.GetComponent("SpriteRenderer") as SpriteRenderer).sprite = spriteEnemy;
			this.gameObject.tag = "Enemy";
		}
		this.rigidbody2D.mass = Global.GetRandom(1,15);
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
