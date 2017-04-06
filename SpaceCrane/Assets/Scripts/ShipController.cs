using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public GameObject cargo;
    public float speed;

    private Rigidbody rb;
    private BoxCollider bc;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float moveH = Input.GetAxis("HorizontalAD");
        float moveV = Input.GetAxis("VerticalSW");
        float moveZ = Input.GetAxis("ZAxis");

        Vector3 movementH = transform.right * moveH;
        Vector3 movementV = transform.forward * moveV;
        Vector3 movementZ = transform.up * moveZ;
        rb.velocity = (movementH + movementV + movementZ) * speed * Time.deltaTime;

        UpdateCargoPosition();
    }

    void UpdateCargoPosition()
    {

    }
}
