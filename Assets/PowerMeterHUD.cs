using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerMeterHUD : MonoBehaviour {
	Image filler;

	// Use this for initialization
	void Start () {
		filler = transform.Find("Filler").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		filler.fillAmount = Tank.tank.AbilityCooldownRatio();
	}
}
