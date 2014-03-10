using UnityEngine;
using System.Collections;

public class PukeController : MonoBehaviour {

	public Sprite pigSprite0;
	public Sprite pigSprite1;
	public Sprite pigSprite2;
	public Sprite pigSprite3;
	public Sprite pigSprite4;

	public float Rage = 10;
	public int PointForWin = 10;
	private int currentPoints = 0;
	private float pointToChangeSprite = 0;
	private int currentNumberSprite = 0;
	private double maxX = 0;
	private double minX = 0;
	private double maxY = 0;
	private double minY = 0;
	// Use this for initialization
	void Start () {
		reset();
		pointToChangeSprite = (float)PointForWin / (float)Rage;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if(Input.GetKey(KeyCode.W))
		//{
		//	reset ();
		//	currentPoints++;
	//		GameObject bar = GameObject.Find("ControllForPuke");
			//bar.transform.localScale=new Vector3(bar.transform.localScale.x+0.1f,bar.transform.localScale.y,bar.transform.localScale.z);
		//	bar.transform.position=new Vector3(bar.transform.position.x+0.05f,bar.transform.position.y,bar.transform.position.z);
		//}
		if(Input.acceleration.x > maxX)
		{
			maxX = Input.acceleration.x;
		}
		if(Input.acceleration.x < minX)
		{
			minX = Input.acceleration.x;
		}
		if(Input.acceleration.y > maxY)
		{
			maxY = Input.acceleration.y;
		}
		if(Input.acceleration.y < minY)
		{
			minY = Input.acceleration.y;
		}
		if(maxX - minX>Rage || maxY - minY>Rage)
		{
			reset ();
			currentPoints++;
			(this.GetComponent("AudioSource") as AudioSource).Play();

			if (currentPoints >= pointToChangeSprite) 
			{
					currentNumberSprite++;
					currentPoints = 0;
			}

			switch (currentNumberSprite) 
			{
			case 0:
					(this.GetComponent ("SpriteRenderer") as SpriteRenderer).sprite = pigSprite0;
					break;

			case 1:
					(this.GetComponent ("SpriteRenderer") as SpriteRenderer).sprite = pigSprite1;
					break;

			case 2:
					(this.GetComponent ("SpriteRenderer") as SpriteRenderer).sprite = pigSprite2;
					break;

			case 3:
					(this.GetComponent ("SpriteRenderer") as SpriteRenderer).sprite = pigSprite3;
					break;

			case 4:
					(this.GetComponent ("SpriteRenderer") as SpriteRenderer).sprite = pigSprite4;
					StartRainbowAnimation ();
					break;
			default:
				break;
			}
		}

	}
	private void StartRainbowAnimation()
	{	
		GameObject rainbow = GameObject.FindWithTag ("Achive");
		(rainbow.GetComponent ("SpriteRenderer") as SpriteRenderer).enabled = true;
		(rainbow.GetComponent ("Animator") as Animator).enabled = true; 

	}

	private void reset()
	{
		maxX = 0;
		minX = 0;
		maxY = 0;
		minY = 0;
	}
}
