using UnityEngine;
using System.Collections;

public class CreateSpawn : MonoBehaviour {

	public int Interval = 100;
	public int Count = 100;
	private bool spawn = true;
	// Use this for initialization
	void Start () {
		new System.Threading.Thread(WaitTime).Start();
	}
	
	// Update is called once per frame
	void Update () {
		if(spawn)
		{
			System.Random r = new System.Random();
			for(int i=0;i<Count;i++)
			{
				Vector3 vect = new Vector3(this.transform.position.x + r.Next(-5,5),this.transform.position.y + r.Next(-5,5),this.transform.position.z + r.Next(-5,5));
				Instantiate(Resources.Load ("Sphere"),vect,Quaternion.identity);
			}
			spawn = false;
		}
	}

	void WaitTime()
	{
		while(true)
		{
			System.Threading.Thread.Sleep(Interval);
			spawn = true;
		}
	}
}
