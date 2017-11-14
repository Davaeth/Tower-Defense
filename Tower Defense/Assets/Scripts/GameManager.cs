using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager{

	public static void LoadLevel(int? levelIndex = null)
    {
        SceneManager.LoadScene(levelIndex ?? SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene((int)MenuItem.Menu);
    }

    public enum MenuItem : int
    {
        Menu = 0,
        Options = 1,
        StartGame = 2
    }
}
