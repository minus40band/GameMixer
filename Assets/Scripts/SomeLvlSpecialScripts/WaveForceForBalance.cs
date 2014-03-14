using UnityEngine;
using System.Collections;

public class WaveForceForBalance : MonoBehaviour {

	public int Interval = 500;
	private bool GoForce = false;
	public float Speed = 2;
	public bool Force = true;
	public bool Velocity = false;
	
	// Use this for initialization
	void Start () {
		new System.Threading.Thread(Impulse).Start();
	}
	
	// Update is called once per frame
	void Update () {
		if(GoForce)
		{
			float i = System.Math.Abs(Input.acceleration.normalized.y)/5;
			if(Force)
			{
				if(Global.GetRandomDouble() > 0.5)
					this.rigidbody2D.AddForce(new Vector2(-(Speed + i),0));
				else
					this.rigidbody2D.AddForce(new Vector2(Speed + i,0));
			}
			if(Velocity)
			{
				if(Global.GetRandomDouble() > 0.5)
					this.rigidbody2D.velocity = (new Vector2(-(Speed + i),0));
				else
					this.rigidbody2D.velocity = (new Vector2(Speed + i,0));
				GoForce = false;
			}
			GoForce = false;
		}
	}

	void Impulse()
	{
		while(true)
		{
			System.Threading.Thread.Sleep(Interval);
			GoForce = true;
		}
	}
}
