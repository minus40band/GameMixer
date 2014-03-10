using UnityEngine;
using System.Collections;

public class BeadController : MonoBehaviour {

	public Sprite Feel1;
	public Sprite Feel2;
	public Sprite Feel3;
	public int CountForWin = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectsWithTag("Achive").Length>CountForWin - 5)
		{
			(this.GetComponent("Animator") as Animator).enabled = true;
		}
		if(GameObject.FindGameObjectsWithTag("Achive").Length>CountForWin)
		{
			Global.LoadLvlComplite();
		}
	}

	void OnMouseUp()
	{
		(this.GetComponent("AudioSource") as AudioSource).Stop();
	}

	void OnMouseDrag()
	{
		if(!(this.GetComponent("AudioSource") as AudioSource).isPlaying)
			(this.GetComponent("AudioSource") as AudioSource).Play();
		if(GameObject.FindGameObjectsWithTag("Achive").Length==1)
		{
			(this.GetComponent("SpriteRenderer") as SpriteRenderer).sprite = Feel2;
		}
		if(GameObject.FindGameObjectsWithTag("Achive").Length>15)
		{
			(this.GetComponent("SpriteRenderer") as SpriteRenderer).sprite = Feel3;
		}
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) 
		{
			Vector2 touchposition = new Vector2(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x,
			                                    Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y);
			Instantiate(Resources.Load("Ping",typeof(GameObject)), touchposition, Quaternion.identity);
			//foreach(var p in GameObject.FindGameObjectsWithTag("Achive"))
			//{
			//		p.transform.localScale = new Vector3(4,4,0);
			//}
		}
	}
}
