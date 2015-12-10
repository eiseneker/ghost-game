using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerMeterHUD : MonoBehaviour {
	public static PowerMeterHUD instance;

	Image filler;

	// Use this for initialization
	void Start () {
		instance = this;
		filler = transform.Find("Filler").GetComponent<Image>();
		
		if(Tank.tank.ability == null){
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		filler.fillAmount = Tank.tank.AbilityCooldownRatio();
	}
}
