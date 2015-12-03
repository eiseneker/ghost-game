using UnityEngine;
using System.Collections;

public class TreeLayer : MonoBehaviour {

	public float speed;
	public static TreeLayer current;
	
	float pos = 0;

	// Use this for initialization
	void Start () {
		current = this;
	}
	
	// Update is called once per frame
	void Update () {
		pos += speed * Time.deltaTime * 20;
		if(pos > 1.0f){
			pos -= 1f;
		}
		GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(pos, 0);
	}
}
