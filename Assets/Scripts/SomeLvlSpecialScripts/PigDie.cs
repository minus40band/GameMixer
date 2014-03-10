using UnityEngine;
using System.Collections;

public class PigDie : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
