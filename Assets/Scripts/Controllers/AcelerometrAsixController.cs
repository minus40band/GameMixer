using UnityEngine;
using System.Collections;

public class AcelerometrAsixController : MonoBehaviour {
	public float SpeedStatic = 0;
	public float SpeedControll = 0;
	public bool XFixedAsix = false;
	public bool YFixedAsix = false;
	public bool XFixedRotation = false;
	public bool YFixedRotation = false;
	public bool ZFixedRotation = false;
	public bool CameraTransform = false;
	public bool Forcer = false;
	public bool Velocity = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(CameraTransform)
		{
			GameObject camera = GameObject.FindWithTag("MainCamera");
			camera.transform.position = new Vector3(this.transform.position.x+2,camera.transform.position.y,camera.transform.position.z);
		}	
		if(XFixedAsix)
		{
			this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x,this.rigidbody2D.velocity.y);
		}
		else
		{
			if(Velocity)
				this.rigidbody2D.velocity = new Vector2(Input.acceleration.x * SpeedControll,this.rigidbody2D.velocity.y);
			if(Forcer)
				this.rigidbody2D.AddForce(new Vector2(Input.acceleration.x * SpeedControll,0));
			
		}
		if(YFixedAsix)
		{
			this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x,this.rigidbody2D.velocity.y);
		}
		else
		{
			if(Velocity)
				this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x,Input.acceleration.y * SpeedControll);
			if(Forcer)
				this.rigidbody2D.AddForce(new Vector2(0,Input.acceleration.y * SpeedControll));
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag.Equals("Ground"))
		{
			Global.LoadLvlLose(Application.loadedLevel);
		}
	}
}
