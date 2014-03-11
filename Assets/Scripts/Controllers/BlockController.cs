using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {

	public bool Position = false;
	public bool Velocity = true;
	public bool Force = false;
	public int Speed = 10;
	private float ypos = 0;
	// Use this for initialization
	void Start () {
		ypos = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector2(this.transform.position.x,(float)ypos);
	}

	void OnMouseDrag()
	{
		if (Input.touchCount > 0 && 
		    Input.GetTouch(0).phase == TouchPhase.Moved) 
		{
			Vector2 touchposition = new Vector2(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x,
			                                  Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y);
			if(Velocity)
				this.rigidbody2D.velocity = new Vector2(touchposition.x,0).normalized*Speed;
			if(Force)
				this.rigidbody2D.AddForce(new Vector2(touchposition.x,0).normalized*Speed);
			if(Position)
				this.transform.position = new Vector2(touchposition.x,(float)ypos);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(!coll.gameObject.tag.Equals("Player"))
		{
			float xpos = coll.gameObject.transform.position.x + coll.gameObject.transform.localScale.x/2;
			this.transform.position.Set(xpos,ypos,this.transform.position.z);
		}
	}
}
