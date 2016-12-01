using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MenuController : MonoBehaviour {

    // Use this for initialization
    public Text scoreText;
	void Start () {
        if(scoreText)
            scoreText.text = "Score: " + Global.score;
    }
    public void MainMenu()
    {
        Global.sceneCode = 0;
        Application.LoadLevel("MainMenu");
    }
	public void StartGame()
    {

        Global.sceneCode = 1;
        Application.LoadLevel("copy3");
        Debug.Log("buttonPressed");
        Global.score = 0;
    }
    public void ExitGame()
    {
        Debug.Log("exit Game");
        Application.LoadLevel("ExitSplash");
        Application.Quit();
    }
    public void LoadLevel2()
    {
        Global.sceneCode = 2;
        Application.LoadLevel("Level2");
    }
    public void LoadWinScene()
    {
        Global.sceneCode = 3;
        Application.LoadLevel("WinScene");
    }
    public void HelpSettings()
    {
        Application.LoadLevel("HelpSettings");
    }
	// Update is called once per frame
	void Update () {
       // Application.Quit();
	}
}
