using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoControllerOld : MonoBehaviour {

    public GameObject cargo;
    public Camera ship;
    public float speed;

    private Rigidbody rb;
    private BoxCollider bc;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
	}
	
	void FixedUpdate () {
        float moveH = Input.GetAxis("HorizontalAD");
        float moveV = Input.GetAxis("VerticalSW");
        float moveZ = Input.GetAxis("ZAxis");
        
        Vector3 movementH = ship.transform.right * moveH;
        Vector3 movementV = ship.transform.forward * moveV;
        Vector3 movementZ = ship.transform.up * moveZ;
        rb.velocity = (movementH + movementV + movementZ) * speed * Time.deltaTime;
    }
}
