using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
	public int colorIndex;
	
	private SpriteRenderer bodySprite;
	
	// Use this for initialization
	void Start () {
		bodySprite = transform.Find ("Body").GetComponent<SpriteRenderer>();
		transform.parent = GameObject.Find ("Foods").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void DestroyMe(){
		Destroy(gameObject);
	}
	
	public void OnTriggerEnter2D(Collider2D collider){
		Tank tank = collider.GetComponent<Tank>();
		if(tank){
			tank.EatFood ();
			DestroyMe ();
		}
	}
	
}
