using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour {

    // Use this for initialization
    GameObject resumeButton;
    GameObject mainMenuButton;
    GameObject pauseButton;
	void Start () {
        resumeButton = GameObject.Find("Resume");
        pauseButton = GameObject.Find("Pause");
        mainMenuButton = GameObject.Find("MainMenu");
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        mainMenuButton.SetActive(false);

        //pauseCanvas.enabled = false;
        Debug.Log("StartPause");
	}
    public void Pause()
    {
        // Application.LoadLevel("PauseMenu");
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        mainMenuButton.SetActive(true);
    }
    public void ReturnToMainMenu()
    {
        Global.sceneCode = 0;
        Application.LoadLevel("MainMenu");
    }
    public void ReturnToGame()
    {
        Global.sceneCode = 1;
        Application.LoadLevel("Level1");
    }
    public void NavToHelpSettings()
    {
        Global.sceneCode = 4;
        Application.LoadLevel("HelpSettings");
    }
    public void Exit()
    {
        Application.LoadLevel("ExitSplash");
        Application.Quit();
    }
    public void Resume()
    {
        resumeButton.SetActive(false);
        mainMenuButton.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;

    }
    // Update is called once per frame
    void Update () {
	
	}
}
