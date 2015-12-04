using UnityEngine;
using System.Collections;

public class TreasureGhost : MonoBehaviour {

	public static GameObject latestTreasure;
	
	void Start(){
		latestTreasure = gameObject;
	}

	void OnTriggerEnter2D(Collider2D collider){
		Tank tank = collider.GetComponent<Tank>();
		if(tank){
			tank.IncreaseLife();
			Destroy (gameObject);
		}
	}
}
