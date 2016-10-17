using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public void Pause()
    {
        Application.LoadLevel("PauseMenu");
    }
    public void ReturnToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
    public void ReturnToGame()
    {
        Application.LoadLevel("Level1");
    }
    public void NavToHelpSettings()
    {
        Application.LoadLevel("HelpSettings");
    }
    public void Exit()
    {
        Application.LoadLevel("ExitSplash");
        Application.Quit();
    }
    // Update is called once per frame
    void Update () {
	
	}
}
