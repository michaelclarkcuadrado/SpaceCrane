using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtomUtils : MonoBehaviour {

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

    //Exits the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
