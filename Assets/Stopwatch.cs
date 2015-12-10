using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour, IAbility {
	
	public float maxAbilityCooldown = 2;
	public float abilityCooldown;
	public Tank player;
	private float effectTime;
	private float maxEffectTime = 4;
	
	void Start(){
		print ("skeleport!");
		abilityCooldown = maxAbilityCooldown;
		transform.Find ("Image").GetComponent<Image>().color = new Color(0, 0, 0, 0);
	}
	
	void Update(){
		effectTime += Time.deltaTime;
		abilityCooldown += Time.deltaTime * GameController.actionTimeScale;
		if(effectTime > maxEffectTime){
			GameController.actionTimeScale = 1;
		}
	}
	
	public void Fire(){
		if(abilityCooldown > maxAbilityCooldown){
			GameController.actionTimeScale = .25f;
			abilityCooldown = 0;
			effectTime = 0;
		}
	}
	
	public void SetPlayer(Tank inputPlayer){
		player = inputPlayer;
	}
	
	public float CooldownRatio(){
		return(abilityCooldown/maxAbilityCooldown);
	}
}
