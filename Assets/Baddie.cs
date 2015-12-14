using UnityEngine;
using System.Collections;

public class Baddie : MonoBehaviour {
	public Aura aura;
	
	protected virtual void Start(){
		Aura tempAura = transform.Find ("Aura").GetComponent<Aura>();
		tempAura.owner = gameObject;
		aura = tempAura;
	}
	
	
	public void DestroyMe(){
		Destroy(gameObject);
	}
}
