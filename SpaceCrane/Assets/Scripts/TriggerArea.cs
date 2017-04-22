using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerArea : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerAction();
        }
    }

    abstract protected void triggerAction();
}
