using UnityEngine;
using System.Collections;

public class StaticSpeed : MonoBehaviour {


	public float SpeedX = 0;
	public bool OnlySpeedX = false;
	public float SpeedY = 0;
	public bool OnlySpeedY = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(OnlySpeedX)
		{
			this.rigidbody2D.velocity = new Vector2(SpeedX,this.rigidbody2D.velocity.y);
		}
		else
		{
			this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x + SpeedX,this.rigidbody2D.velocity.y);
		}
		if(OnlySpeedX)
		{
			this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x,SpeedY);
		}
		else
		{
			this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x,this.rigidbody2D.velocity.y + SpeedY);
			
		}
	}
}
