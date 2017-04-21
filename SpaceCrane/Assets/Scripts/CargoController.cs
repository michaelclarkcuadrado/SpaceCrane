using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls pick-uppable objects 
 * Requires a blank spawner object at the 'home base' of the cargo
 */
public class CargoController : MonoBehaviour {

	public GameObject cargoGoalSpace;
	private Vector3 initialPosition;
	private Quaternion initialRotation;
	private bool isAchieved;
	private bool isPickupable;

	// Use this for initialization
	void Start () {
		isPickupable = true;
		initialPosition = gameObject.transform.position;
		initialRotation = gameObject.transform.rotation;
	}

	public void respawnCargo(){
		if (!isAchieved) {
			gameObject.SetActive (false);
			isPickupable = true;
			gameObject.transform.position = initialPosition;
			gameObject.transform.rotation = initialRotation;
			gameObject.SetActive (true);
		}

	}

	public bool pickup(){
		if (isPickupable) {
			isPickupable = false;
			return true;
		} else {
			return false;
		}
	}

	public bool putDown(){
		Debug.Log ("Put down");
		if (!isPickupable) {
			isPickupable = true;
			return true;
		} else {
			return false;
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject == cargoGoalSpace && !isPickupable) {
			GameObject.Find ("Player Ship").GetComponent<ShipController> ().dropOrPickupCargo ();
			playerAchieve ();
		}
	}

	void playerAchieve(){
		isAchieved = true;
		isPickupable = false;
		gameObject.transform.position = cargoGoalSpace.transform.position;
		gameObject.transform.rotation = cargoGoalSpace.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
