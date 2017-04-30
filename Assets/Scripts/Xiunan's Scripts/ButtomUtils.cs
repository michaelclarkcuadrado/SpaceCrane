using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtomUtils : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject ControlMenu;

    //Loads the first level 
    public void StartPressed()
    {
		GameController.instance.bumpLevel ();
    }

    //Exits current Panel and back to main menu
    public void ExitCurrentPanel()
    {
        MainMenu.SetActive(true);
        ControlMenu.SetActive(false);
    }

    //Enters the control help panel
    public void HelpPressed()
    {
        MainMenu.SetActive(false);
        ControlMenu.SetActive(true);
    }

    //Loads the mainmenu
    public void MainMenuPressed()
    {
        Time.timeScale = 1;
		GameController.instance.backToMainMenu ();
    }

    //Exits the game
    public void ExitGame()
    {
		Debug.Log ("Game exited.");
        Application.Quit();
    }
}
