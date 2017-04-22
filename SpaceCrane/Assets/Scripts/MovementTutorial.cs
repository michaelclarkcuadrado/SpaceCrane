using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementTutorial : MonoBehaviour {
    public GameObject player;
    public GameObject textObject;
    public GameObject firstDoor;
    public GameObject lastDoor;

    private ShipController sc;
    private Text text;
    private bool movementEnabled;

    private string[] script1 = {"Oh! Hello There!", "You must be our new pilot!", "Let me unlock your ship so you can get going.", "Hmm, that's strange...",
    "It looks like you don't have your pilot license yet.", "Not sure how you got hired...", "Well, anyway, we need a pilot, so you're going to be okay.",
    "You just need to complete our pilot training program first.", "That means you can't leave yet, so let me close the exit...",
    "Now, I can unlock your ship...", "Ok now you should be able to move around" };

    private float[] textTime = { 2, 3, 3.5f, 2, 3, 2, 4, 4, 7f, 2, 3 };
	// Use this for initialization
	void Start () {
        sc = player.GetComponent<ShipController>();
        text = textObject.GetComponent<Text>();

        movementEnabled = false;

        StartCoroutine(tutorial());

    }
	
	// Update is called once per frame
	void Update () {
        sc.setMovementEnabled(movementEnabled);
	}

    IEnumerator tutorial()
    {  
        text.text = "";
        yield return new WaitForSeconds(1);
        for (int i = 0; i < script1.Length; i++)
        {
            print("Displaying text# " + i);
            text.text = script1[i];
            switch (i)
            {
                case 8:
                    StartCoroutine(moveDoor(lastDoor, new Vector3(40, 20, -20), 2.5f));
                    break;
                case 9:
                    movementEnabled = true;
                    break;
                default:
                    break;

            }
            yield return new WaitForSeconds(.5f);
            text.text = "";
            yield return new WaitForSeconds(.5f);
        }
        text.text = "";
    }

    IEnumerator moveDoor(GameObject door, Vector3 endPosition, float time)
    {
        Vector3 direction = (endPosition - door.transform.position);
        direction *= Time.deltaTime / time;
        float timeElapsed = 0;
        while (timeElapsed<=time)
        {
            door.transform.position += direction;
            yield return new WaitForSeconds(Time.deltaTime);
            timeElapsed += Time.deltaTime;
        }
    }


}
