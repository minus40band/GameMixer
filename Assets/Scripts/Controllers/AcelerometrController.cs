using UnityEngine;
using System.Collections;

public class AcelerometrController : MonoBehaviour 
{
	private Vector3 myRot;
	public int Speed = 1;
	public int RotationSpeed = 1;
	public bool Rotation = false;
	// Use this for initialization
	void Start () {
		myRot = this.transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody2D.velocity = new Vector2(Input.acceleration.x * Speed,Input.acceleration.y * Speed);
		if(Rotation)
		{
			myRot.z += Input.acceleration.normalized.x * RotationSpeed;
			myRot.z += Input.acceleration.normalized.y * RotationSpeed;
			this.transform.rotation = Quaternion.Euler(myRot); 
		}
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
}
