using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DifficultyHUD : MonoBehaviour {
	
	private Text text;
	
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = GameController.Difficulty().ToString ();
	}
}
