using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static float playTime;
	public static bool active;
	private float baddySpawnTime;
	private float foodSpawnTime;

	// Use this for initialization
	void Start () {
		active = true;
		playTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		playTime += Time.deltaTime;
		foodSpawnTime += Time.deltaTime;
		baddySpawnTime += Time.deltaTime;
		
		if(Tank.tank.health <= 0){
			ShowGameOver();
		}
	}
	
	public static int Difficulty(){
		int difficulty = Mathf.FloorToInt(Mathf.Clamp (playTime/10, 0, 100));
		return(difficulty);
	}
	
	
	void ShowGameOver(){
		active = false;
		Time.timeScale = 0;
		GameObject.Find ("HUD").transform.Find ("GameOver").gameObject.SetActive(true);
	}
	
	public void Replay(){
		Application.LoadLevel ("Game");
	}
}
