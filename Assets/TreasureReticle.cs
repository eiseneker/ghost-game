using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TreasureReticle : MonoBehaviour {

	private Image image;

	// Use this for initialization
	void Start () {
		image = transform.Find ("Image").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		if(TreasureGhost.latestTreasure != null){
			Vector3 translatedTeasurePosition = Camera.main.WorldToScreenPoint (TreasureGhost.latestTreasure.gameObject.transform.position);
			if(translatedTeasurePosition.x > transform.position.x){
				print ("setting to position");
				image.color = new Color(1, 1, 1, 1);
				newPosition.y = translatedTeasurePosition.y;
			}else{
				newPosition.y = 5000;
			}
		}else{
			newPosition.y = 5000;
		}
		gameObject.transform.position = newPosition;
	}
}
