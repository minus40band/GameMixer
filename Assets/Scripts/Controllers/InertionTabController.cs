using UnityEngine;
using System.Collections;

public class InertionTabController : MonoBehaviour {

	public float Inertion = 0;
	public float Speed = 0;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody2D.velocity = new Vector2(Speed,this.rigidbody2D.velocity.y);
		Action();
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag.Equals("Ground"))
		{
			Global.LoadLvlLose(Application.loadedLevel);
		}
		if(coll.gameObject.tag.Equals("Achive"))
		{
			coll.gameObject.SetActive(false);
			if(GameObject.FindGameObjectsWithTag("Achive").Length.Equals(0))
			{
				Global.LoadLvlComplite();
			}
		}
	}
	
	void Action()
	{
		if (Input.touchCount > 0 && 
		    Input.GetTouch(0).phase == TouchPhase.Began
		    || 
		    Input.GetKeyUp(KeyCode.W)) 
		{
			Speed+=Inertion;
		}

		(this.GetComponent ("Animator") as Animator).speed += Speed/500;
	}
		
}
