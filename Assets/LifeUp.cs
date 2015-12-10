using UnityEngine;
using System.Collections;

public class LifeUp : MonoBehaviour, IPowerUp {

	public void Fire(Tank player){
		player.IncreaseLife();
	}
}
