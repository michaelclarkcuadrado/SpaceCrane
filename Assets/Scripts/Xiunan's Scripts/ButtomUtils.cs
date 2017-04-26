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
        SceneManager.LoadScene(1);
    }

    //Loads the Main Level
    public void MainPressed()
    {
        SceneManager.LoadScene(0);
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

    //Exits the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
