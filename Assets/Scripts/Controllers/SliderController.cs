using UnityEngine;
using System.Collections;

public class SliderController : MonoBehaviour {

	private float StartX = 0;
	private float EndX = 0;
	public float Speed = -0.25f;
	public float LeftX = -1;
	public float RightX = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.touchCount>0)
		{
			if((this.transform.position.x + Input.GetTouch(0).deltaPosition.x * Speed>LeftX) 
			   && (this.transform.position.x + Input.GetTouch(0).deltaPosition.x * Speed<RightX))
			{
				this.transform.position = new Vector3(this.transform.position.x + Input.GetTouch(0).deltaPosition.x * Speed,this.transform.position.y,this.transform.position.z);
			}
			if(this.transform.position.x > LeftX && this.transform.position.x < LeftX + 2)
			{
				(this.GetComponent("StartNetworkScript") as StartNetworkScript).VisibleNetworkSettings = true;
			}
			else
			{
				(this.GetComponent("StartNetworkScript") as StartNetworkScript).VisibleNetworkSettings = false;
			}
		}
	}
}
