using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGate : MonoBehaviour {

	public GameObject laser1;
	public GameObject laser2;
	public GameObject laser3;
	public GameObject objectToDisable;

	private bool isDisabled;
	private GameObject[] lasers;
	// Use this for initialization
	void Start () {
		isDisabled = false;
		lasers [0] = laser1;
		lasers [1] = laser2;
		lasers [2] = laser3;
	}	
	// Update is called once per frame
	void Update () {
		foreach(GameObject laser in lasers){
			RaycastHit collide;
			if (Physics.Raycast (laser.transform.position, laser.transform.forward, out collide, 300f)) {
				Vector3 [] positions = new Vector3[2];
				positions [0] = laser.transform.position;
				positions[1] = collide.transform.position;
				if (collide.collider.gameObject.GetComponent<CargoController>() != null) {
					if (!isDisabled) {
						objectToDisable.SetActive (false);
						isDisabled = false;
					}
				} else {
					if (isDisabled) {
						objectToDisable.SetActive (true);
						isDisabled = true;
					}
				}
				laser.GetComponent<LineRenderer>().SetPositions(positions);
			}
		}
	}
}
