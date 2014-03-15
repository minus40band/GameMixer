using UnityEngine;
using System.Collections;
using System.Threading;

public class RandomIncline : MonoBehaviour {

	public float anglePerFrame = 30.0f;
	public float axixCoordX = 0.0f;
	public float axixCoordY = 0.0f;
	public float timeSecToChangeDirection = 3;
	public float maximumAngle = 65.0f;

	private System.Random randomEngien = new System.Random();
	private Vector3 axixRotating;
	private bool direction = true;
	private float previosTime;
	private bool stop = false;

	// Use this for initialization
	void Start () {
		axixRotating = new Vector3 (axixCoordX, axixCoordY, 0);
		previosTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(stop == false)
			Rotate ();
	}

	void Rotate()
	{
		Debug.Log (this.transform.rotation.z);

		float curAngle = this.transform.rotation.eulerAngles.z;
		if (curAngle >= 0 && curAngle < 65 || curAngle <= 360 && curAngle > 320)
		{
			this.transform.RotateAround (axixRotating, new Vector3 (0, 0, 1), anglePerFrame);
			
			if (Time.time - previosTime >= timeSecToChangeDirection) 
			{
				previosTime = Time.time;
				anglePerFrame *= -1;
			}
		}
		else stop = true;

		if (Input.GetKeyUp(KeyCode.A)) 
		{
			this.transform.RotateAround (axixRotating, new Vector3 (0, 0, 1), anglePerFrame);
		}
		if (Input.GetKeyUp (KeyCode.D)) 
		{
			this.transform.RotateAround (axixRotating, new Vector3 (0, 0, 1), -anglePerFrame);
		}
	}
}
