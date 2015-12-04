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
		if(TreasureGhost.latestTreasure != null){
			Vector3 translatedTeasurePosition = Camera.main.WorldToScreenPoint (TreasureGhost.latestTreasure.gameObject.transform.position);
			if(translatedTeasurePosition.x > transform.position.x){
				image.color = new Color(1, 1, 1, .5f);
				Vector3 newPosition = transform.position;
				newPosition.y = translatedTeasurePosition.y;
				gameObject.transform.position = newPosition;
			}
		}else{
			image.color = new Color(0, 0, 0, 0);
		}
	}
}
