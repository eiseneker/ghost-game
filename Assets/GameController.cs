using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static float playTime;
	public static bool active;
	private float baddySpawnTime;
	private float foodSpawnTime;
	public static float actionTimeScale = 1;
	float bearTime;
	float bearCooldown;

	// Use this for initialization
	void Start () {
		active = true;
		playTime = 0;
		actionTimeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		playTime += Time.deltaTime;
		foodSpawnTime += Time.deltaTime;
		baddySpawnTime += Time.deltaTime;
		bearCooldown += Time.deltaTime;
		
		if(Tank.tank.health <= 0){
			ShowGameOver();
		}
		
		if(Tank.tank.transform.position.y < -1.5f){
			print ("situation A");
			bearTime += Time.deltaTime;
		}else{
			print ("situation B");
			bearTime = 0;
		}
		
		if(bearTime > .5f && bearCooldown > 5){
			Vector3 newPosition = Tank.tank.transform.position;
			newPosition.y = -2.5f;
			newPosition.x += 5.25f;
			Instantiate (Resources.Load ("ObstacleBear"), newPosition, Quaternion.identity);
			bearCooldown = 0;
			bearTime = 0;
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
