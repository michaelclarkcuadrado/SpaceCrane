using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : TriggerArea {

    public GameObject door;
    public Vector3 endPosition;
    public float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void triggerAction()
    {
        StartCoroutine(moveDoor());
    }

    IEnumerator moveDoor()
    {
        print("Move Door");
        Vector3 direction = (endPosition - door.transform.position);
        direction *= Time.deltaTime / time;
        float timeElapsed = 0;
        while (timeElapsed <= time)
        {
            door.transform.position += direction;
            yield return new WaitForSeconds(Time.deltaTime);
            timeElapsed += Time.deltaTime;
        }
    }
}
