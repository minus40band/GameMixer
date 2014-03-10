using UnityEngine;
using System.Collections;

public class TouchJumpController : MonoBehaviour {
	public int Jump = 0;
	public int Speed = 0;
	private bool CanJump;
	// Use this for initialization
	void Start () 
	{
		CanJump = true;
	}

	// Update is called once per frame
	void Update () {
		//GameObject camera = GameObject.FindWithTag("MainCamera");
		//camera.transform.position = new Vector3(this.transform.position.x+2,camera.transform.position.y,camera.transform.position.z);
		this.rigidbody2D.velocity = new Vector2(Speed,this.rigidbody2D.velocity.y);
		ActionJump();
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		CanJump = true;
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

	void ActionJump()
	{
		if (Input.touchCount > 0 && 
		    Input.GetTouch(0).phase == TouchPhase.Began
		    || 
			Input.GetKey(KeyCode.W)) 
		{
			if(CanJump)
			{
				this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x,Jump);
				CanJump = false;;
			}
		}
	}
}
