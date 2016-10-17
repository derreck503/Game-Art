using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public void StartGame()
    {
        Application.LoadLevel("Level1");
    }
    public void ExitGame()
    {
        Application.LoadLevel("ExitSplash");
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
       // Application.Quit();
	}
}
