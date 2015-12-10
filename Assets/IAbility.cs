using UnityEngine;
using System.Collections;

interface IAbility {
	
	void Fire();
	
	void SetPlayer(Tank inputPlayer);
	
	float CooldownRatio();
	
}
