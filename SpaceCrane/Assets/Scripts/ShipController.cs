using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public GameObject cargo;
    public float distance;
    public float zoomSpeed;

    private Vector3 offset;
    private float xR;
    private float yR;
    private float zR;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - cargo.transform.position;
        xR = 0;
        yR = 0;
    }

    // Update is called once per frame
    void Update () {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit);
        //print("Object hit: " + hit.transform.gameObject.name);
        if (hit.transform.gameObject != cargo)
        {
            print("Death");
        }
    }

    void LateUpdate()
    {
        float moveV = Input.GetAxis("Horizontal");
        float moveH = Input.GetAxis("Vertical");
        float zoom = Input.GetAxis("Zoom");
        float roll = Input.GetAxis("Roll");

        xR += moveH;
        yR -= moveV;
        zR += roll;
        xR = Mathf.Clamp(xR, -94, 84);
        Quaternion xRotation = Quaternion.AngleAxis(xR, new Vector3(1, 0, 0));
        Quaternion yRotation = Quaternion.AngleAxis(yR, new Vector3(0, 1, 0));
        //Quaternion zRotation = Quaternion.AngleAxis(zR, new Vector3(0, 0, 1));
        Vector3 newOffset = offset;
        newOffset = xRotation * newOffset;
        newOffset = yRotation * newOffset;
        //newOffset = zRotation * newOffset;
        newOffset.Normalize();
        distance += zoom * zoomSpeed * Time.deltaTime;
        distance = Mathf.Clamp(distance, 5, 25);
        newOffset *= distance;
        transform.position = cargo.transform.position + newOffset;
        transform.rotation = Quaternion.LookRotation(cargo.transform.position - transform.position);
        transform.Rotate(0, 0, zR);
    }
}
