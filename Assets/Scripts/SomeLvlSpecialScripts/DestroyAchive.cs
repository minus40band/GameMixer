using UnityEngine;
using System.Collections;

public class DestroyAchive : MonoBehaviour {

	public bool LoseWhenAchive = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		coll.gameObject.SetActive(false);
		if(LoseWhenAchive && coll.gameObject.tag.Equals("Achive"))
		{
			Global.LoadLvlLose();
		}
	}
}
