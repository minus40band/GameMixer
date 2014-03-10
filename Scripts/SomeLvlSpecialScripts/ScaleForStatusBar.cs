using UnityEngine;
using System.Collections;

public class ScaleForStatusBar : MonoBehaviour {

	public float Multiply = 1;
	public float Duration = 5;
	private float finishtime = 0;
	private float localtime = 0;
	// Use this for initialization
	void Start () {
		localtime = Global.SummaryTime;
		finishtime = Global.SummaryTime + Duration;
	}
	
	// Update is called once per frame
	void Update () {
		float i = Time.deltaTime * (Multiply*System.Math.Abs(Input.acceleration.normalized.y));
		this.transform.localScale = new Vector3(this.transform.localScale.x + i/5,this.transform.localScale.y, this.transform.localScale.z);
		this.transform.position = new Vector3(this.transform.position.x + i/10,this.transform.position.y, this.transform.position.z);
		localtime += 1.0f * i;
		if(localtime>finishtime)
		{
			Global.LoadLvlComplite();
		}
	}

}
