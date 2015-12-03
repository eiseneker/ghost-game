using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static float playTime;
	private float baddySpawnTime;
	private float foodSpawnTime;

	// Use this for initialization
	void Start () {
		playTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
//		print (Time.timeSinceLevelLoad);
		playTime += Time.deltaTime;
		foodSpawnTime += Time.deltaTime;
		baddySpawnTime += Time.deltaTime;
		
		if(Tank.tank.health <= 0){
//			ShowGameOver();
		}
	}
	
	public static int Difficulty(){
		int difficulty = Mathf.FloorToInt(Mathf.Clamp (playTime/10, 0, 10));
		return(difficulty);
	}
	
	
	void ShowGameOver(){
		GameObject.Find ("HUD").transform.Find ("GameOver").gameObject.SetActive(true);
	}
	
	public void Replay(){
		Application.LoadLevel ("Game");
	}
}
