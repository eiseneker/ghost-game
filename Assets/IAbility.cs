using UnityEngine;
using System.Collections;

public interface IAbility {
	
	void Fire();
	
	void SetPlayer(Tank inputPlayer);
	
	float CooldownRatio();
	
}
