using UnityEngine;
using System.Collections;

public class DeadRun : MonoBehaviour {

	public static float SummaryTime = 0.0f;
	public float Speed = 0;
	public float Iner = 0;
	public int t = 1000;
	private int i = 0;
	public int countOfInnerInner = 0;
	// Use this for initialization
	void Start () 
	{
		new System.Threading.Thread(addspeed).Start();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject camera = GameObject.FindWithTag("MainCamera");
		camera.transform.position = new Vector3((this.transform.position.x + GameObject.FindWithTag("Player").transform.position.x)/2,camera.transform.position.y,camera.transform.position.z);
		(camera.GetComponent("Camera") as Camera).orthographicSize = System.Math.Abs(this.transform.position.x - GameObject.FindWithTag("Player").transform.position.x)+2;


		SummaryTime+= 1.0f * Time.deltaTime;
		this.rigidbody2D.velocity = new Vector2(Speed,this.rigidbody2D.velocity.y);
	}

	private void addspeed()
	{
		while(true)
		{
			System.Threading.Thread.Sleep(t);
			i++;
			if(i==countOfInnerInner)
			{
				i=0;
				Iner+=Iner/4;
			}
			Speed+=Iner;
		}
	}



}
