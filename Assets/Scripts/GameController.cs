using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance = null;
	public GameObject[] cargoInLevel;

	static int level = 0;

	// Use this for initialization
	void Awake () {
		if (instance == null)
		{
			instance = this;
			level = SceneManager.GetActiveScene().buildIndex;
		}
		else { 
			Destroy(gameObject);
			DontDestroyOnLoad(gameObject);
		}
	}

	public void checkAllAcheived () {
		if (cargoInLevel.Length > 0) {
			foreach(GameObject c in cargoInLevel) {
				if (!c.GetComponent<CargoController>().achieved()) {
					return;
				}
			}
			//if every cargo is achieved, bump level to next
			bumpLevel();
		}
	}

	public void bumpLevel() {
		SceneManager.LoadScene(++level);
	}

	public int getLevel(){
		return level;
	}

	public void backToMainMenu(){
		level = 0;
		SceneManager.LoadScene (level);
		Screen.lockCursor = false;
	}

}
