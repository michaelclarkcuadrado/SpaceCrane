using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargoButton : MonoBehaviour {

	public GameObject[] objectsToDisable;
	private bool isDisabled = false;

	void OnColliderEnter(Collision c){
		Debug.Log ("HIT");
		if (c.gameObject.GetComponent<CargoController> () != null && isDisabled == false) {
			isDisabled = true;
			foreach (GameObject o in objectsToDisable) {
				o.SetActive (false);
			}
		}
	}
	
	void OnCollisionExit(Collision c){
		if (c.gameObject.GetComponent<CargoController> () != null && isDisabled == true) {
			isDisabled = false;
			foreach (GameObject o in objectsToDisable) {
				o.SetActive (true);
			}
		}
	}
}
