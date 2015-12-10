using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TreasureGhost : MonoBehaviour {

	public static GameObject latestTreasure;
	string treasureName = "";
	
	void Start(){
		latestTreasure = gameObject;
		
		float randomValue = Random.value;
		
		if(randomValue < .45f){
			treasureName = "Stopwatch";
		}else if(randomValue < .9f){
			treasureName = "Skeleporter";
		}else{
			treasureName = "LifeUp";
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		Tank tank = collider.GetComponent<Tank>();
		if(tank){
			print ("got PowerUp " + treasureName);
		
			GameObject treasureObject = Instantiate (Resources.Load (treasureName), transform.position, Quaternion.identity) as GameObject;
			
			IAbility ability = treasureObject.GetComponent(typeof(IAbility)) as IAbility;
			
			if(ability != null){
				treasureObject.transform.parent = GameObject.Find ("HUD").transform.Find ("PowerMeter").transform;
				GameObject.Find ("HUD").transform.Find ("PowerMeter").transform.Find ("Image").GetComponent<Image>().sprite = treasureObject.transform.Find ("Image").GetComponent<Image>().sprite;
				tank.SetAbility(ability);
			}else{
				IPowerUp powerUp = treasureObject.GetComponent(typeof(IPowerUp)) as IPowerUp;
				powerUp.Fire (tank);
			}
		
			Destroy (gameObject);
		}
	}
}
