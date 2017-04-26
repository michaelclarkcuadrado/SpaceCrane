using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggerArea : TriggerArea {

    public GameObject movementTutorial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void triggerAction()
    {
        movementTutorial.GetComponent<MovementTutorial>().startCargoTutorial();
    }
}
