using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skeleporter : MonoBehaviour, IAbility {

	public float maxAbilityCooldown = 2;
	public float abilityCooldown;
	public Tank player;

	void Start(){
		print ("skeleport!");
		abilityCooldown = maxAbilityCooldown;
		transform.Find ("Image").GetComponent<Image>().color = new Color(0, 0, 0, 0);
	}

	void Update(){
		abilityCooldown += Time.deltaTime;
	}

	public void Fire(){
		if(abilityCooldown > maxAbilityCooldown){
			Vector3 newPosition = player.transform.position;
			
			if(player.transform.position.y > 0){
				newPosition.y -= 1.5f;
			}else{
				newPosition.y += 1.5f;
			}
			
			player.transform.position = newPosition;
			abilityCooldown = 0;
		}
	}
	
	public void SetPlayer(Tank inputPlayer){
		player = inputPlayer;
	}
	
	public float CooldownRatio(){
		return(abilityCooldown/maxAbilityCooldown);
	}
}
