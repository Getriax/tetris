using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayAndExit : MonoBehaviour {

	public void LoadGame()
    {
        SceneManager.LoadScene("GameScen");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
