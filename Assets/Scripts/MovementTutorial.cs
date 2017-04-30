using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementTutorial : MonoBehaviour {
    public GameObject player;
    public GameObject textObject;
	public GameObject textBackground;
    public GameObject firstDoor;
    public GameObject lastDoor;
    public GameObject triggerArea1;
    public GameObject triggerArea2;

    private ShipController sc;
    private Text text;
    private bool movementEnabled;

    private string[] script1 = {"Oh! Hello There!", "You must be our new pilot!", "Let me unlock your ship so you can get going.", "Hmm, that's strange...",
    "It looks like you don't have your pilot license yet.", "Not sure how you got hired...", "Well, anyway, we need a pilot, so you're going to be okay.",
    "You just need to complete our pilot training program first.", "That means you can't leave yet, so let me close the exit...",
    "Now, I can unlock your ship...", "Ok now you should be able to move around", "Why don't you try flying around, just to get the hang of it.",
    "What's that? You don't even know the controls?", "Wow, HR is really getting sloppy...", "It's okay, I'll teach you.", "The arrow keys can be used to look around.",
    "Use W and S to move forward and backwards.", "A and D will move you side to side.", "R and F will move you upwards and downwards",
    "If you want to roll, use Q and E", "And remember, all controls are relative to your current orientation.", "In space there's no such thing as up or down!",
    "And, if you ever forget these controls, they can all be found in the pause menu.", "Now that you know how to fly, it's time to complete our training course.", "Head through the door to continute." };

    private string[] script2 = {"Nicely done!", "Now, you're ready to start working.", "See that cargo crate in front of you?",
    "Most of your job will consist of moving that from place to place.",
    "All of our cargo is made with state-of-the-art anti-theft technology.",
    "It's mostly to deter space pirates.", "What that means for you is that if you ever lose sight of the cargo while holding it, it will immediately teleport back to where you originally picked it up from.",
    "You can still put the cargo down and then move around no problem.", "But, if you ever lose sight of it while holding it, you'll have to go back and pick it up again.",
    "Now I'll tell you how to handle the cargo.", "The spacebar will attempt to pick up any cargo aligned with the crosshairs.", "You can also use P to drop any cargo you're holding.",
	"Last lesson: you can push and pull the cargo with the period key and the comma key.","This one needs to go to a drop-off zone right in front of the facility you just left.", "Alright, champ, you're on your own!", "Good Luck!"};

    private float[] textTime1 = { 2, 3, 3.5f, 2, 3, 2, 4, 4, 7f, 2, 3, 5, 3, 2, 2, 8, 8, 8, 8, 8, 6, 6, 4, 4, 4 };

    private float[] textTime2 = { 1.5f, 2, 3, 3, 5, 3, 2, 8, 5, 6, 3, 6, 8, 6, 8, 8, 8, 8, 8 };
	// Use this for initialization
	void Start () {
        sc = player.GetComponent<ShipController>();
        text = textObject.GetComponent<Text>();

        movementEnabled = false;

        StartCoroutine(movementTutorial());
    }
	
	// Update is called once per frame
	void Update () {
        sc.setMovementEnabled(movementEnabled);
	}

    IEnumerator movementTutorial()
    {  
        text.text = "";
		textBackground.SetActive (true);
        yield return new WaitForSeconds(2);
        for (int i = 1; i < script1.Length; i++)
        {
            print("Displaying text# " + i);
            print(script1[i]);
            text.text = script1[i];
            switch (i)
            {
                case 8:
                    StartCoroutine(moveDoor(lastDoor, new Vector3(40, 20, -20), 2.5f));
                    break;
                case 9:
                    sc.cameraShake(1);
                    movementEnabled = true;
                    break;
                case 23:
                    StartCoroutine(moveDoor(firstDoor, new Vector3(40, -20, 60), 4));
                    break;
                default:
                    break;

            }
            print(textTime1[i]);
            yield return new WaitForSeconds(textTime1[i]);
            //yield return new WaitForSeconds(0);
            text.text = "";
            yield return new WaitForSeconds(.5f);
        }
		textBackground.SetActive (false);
        text.text = "";
    }

    IEnumerator cargoTutorial()
    {
		textBackground.SetActive (true);
        text.text = "";
        yield return new WaitForSeconds(1);
        for (int i = 1; i < script2.Length; i++)
        {
            print(script2[i]);
            text.text = script2[i];
            yield return new WaitForSeconds(textTime2[i]);
            //yield return new WaitForSeconds(0);
            text.text = "";
            yield return new WaitForSeconds(.5f);
        }
        textBackground.SetActive(false);
        text.text = "";
    }

    public void startCargoTutorial()
    {
        StartCoroutine(cargoTutorial());
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
