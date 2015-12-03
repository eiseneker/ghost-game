using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthMeter : MonoBehaviour {

	private Image image;
	public int index;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Tank.tank.maxHealth < index){
			image.color = new Color(0, 0, 0, 0);
		}else if(Tank.tank.health >= index){
			image.color = new Color(1, .4f, 0, 1);
		}else{
			image.color =  new Color(0, 0, 0, 1);
		}
	}
}
