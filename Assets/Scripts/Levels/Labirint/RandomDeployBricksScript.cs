using UnityEngine;
using System.Collections;

//Создает кирпичик в указанной области. Область рандомно выбирается из заданных условий.
//МОЖНО ПЕРЕДЕАТЬ И ПЕРЕМЕСТИТЬ ПОД УИНИКАЛЬНЫЙ СКРИПТ.
public class RandomDeployBricksScript : MonoBehaviour {

	public bool isNegative = true;   //Положительное число из диапазона получать или нет?
	public int range = 0;

	private float startY = 0;

	// Use this for initialization
	void Start () {
		startY = this.transform.position.y;
		SetRandomPosition ();
	}
	
	// Update is called once per frame
	void Update () {
		//SetRandomPosition ();
	}

	void SetRandomPosition()
	{
		float rand = Global.GetRandom (0, (int)range);
		if (isNegative) rand *= -1;

		rand *= (float)Global.GetRandomDouble ();

		this.transform.position = new Vector3 (  this.transform.position.x,
		                                        (float)startY + rand,
		                                         this.transform.position.z);
	}
}
