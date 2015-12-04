using UnityEngine;
using System.Collections;

public class Aura : MonoBehaviour {

	public GameObject owner;
	private int attempts;
	private Aura movedBy;
	public bool canBeMoved;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay2D(Collider2D collider){
		if(owner != null){
			if(collider.GetComponent<TreasureGhost>()){
				MoveMe (null);
			}else{
				Aura aura = collider.GetComponent<Aura>();
				if(aura && this.canBeMoved && aura.movedBy != this){
					print ("moving " + owner.name);
					MoveMe (aura);	
				}
			}
		}
	}
	
	void MoveMe(Aura aura){
		movedBy = aura;
		if(attempts < 5){
			Vector3 newPosition = owner.transform.position;
			newPosition.y = Random.Range (-2f, 2f);
			owner.transform.position = newPosition;
			attempts++;
		}else{
			Destroy (owner);
		}
	}
}
