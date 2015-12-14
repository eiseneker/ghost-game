using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Impulse : MonoBehaviour, IAbility {
	
	public float maxAbilityCooldown = 4;
	public float abilityCooldown;
	public Tank player;
	private float effectTime;
	private float maxEffectTime = .5f;
	
	void Start(){
		print ("skeleport!");
		abilityCooldown = maxAbilityCooldown;
		transform.Find ("Image").GetComponent<Image>().color = new Color(0, 0, 0, 0);
	}
	
	void Update(){
		effectTime += Time.deltaTime;
		abilityCooldown += Time.deltaTime * GameController.actionTimeScale;
		if(effectTime > maxEffectTime){
			player.maxVelocity = 3.5f;
			player.xVelocity = 1;
		}
	}
	
	public void Fire(){
		if(abilityCooldown > maxAbilityCooldown){
			player.maxVelocity = 9f;
			abilityCooldown = 0;
			effectTime = 0;
			player.xVelocity = 5f;
		}
	}
	
	public void SetPlayer(Tank inputPlayer){
		player = inputPlayer;
	}
	
	public float CooldownRatio(){
		return(abilityCooldown/maxAbilityCooldown);
	}
}
