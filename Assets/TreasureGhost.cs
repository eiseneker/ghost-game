using UnityEngine;
using System.Collections;

public class TreasureGhost : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		Tank tank = collider.GetComponent<Tank>();
		if(tank){
			tank.IncreaseLife();
			Destroy (gameObject);
		}
	}
}
