using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FoodHUD : MonoBehaviour {
	
	private Image filler;
	
	// Use this for initialization
	void Start () {
		filler = transform.Find ("Fill").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		filler.fillAmount = Tank.foodMeter;
	}
}
