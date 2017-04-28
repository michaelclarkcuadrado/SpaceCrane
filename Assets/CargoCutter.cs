using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoCutter : MonoBehaviour {

	public GameObject cargoKnife;
	public GameObject cargoStartPoint;
	public GameObject cargoEndPoint;
	public float speed;

	private Transform start;
	private Transform end;
	private Transform target;
	private bool isGoingForward;
	// Use this for initialization
	void Start () {
		start = cargoStartPoint.transform;
		end = cargoEndPoint.transform;
		cargoKnife.transform.position = start.position;
		isGoingForward = true;
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		if (isGoingForward) {
			target = end;
		} else {
			target = start;
		}
		cargoKnife.transform.position = Vector3.MoveTowards (cargoKnife.transform.position, target.position, step);
		if (cargoKnife.transform.position == target.transform.position) {
			isGoingForward = !isGoingForward;
		}
	}
}
