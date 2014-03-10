using UnityEngine;
using System.Collections;

public class DestroyAchive : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		coll.gameObject.SetActive(false);
	}
}
